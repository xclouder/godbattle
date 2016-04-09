//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

	/// <summary> 
    /// BehaviourTree utility functions.
    /// <seealso cref="BehaviourMachine.InternalBehaviourTree" />
    /// </summary>
	public class BehaviourTreeUtility {

        static MonoScript[] s_NodeScripts;
        static System.Type[] s_NodeTypes;

        /// <summary> 
        /// Stores a node to be copied and pasted in the editor.
        /// </summary>
        public static ActionNode nodeToPaste = null;

        /// <summary> 
        /// Returns a collection of ActionNode types ordered by category.
        /// <returns>A collection of System.Type whose class inherits from ActionNode.</returns>
        /// </summary>
        public static System.Type[] GetNodeTypes () {
            if (s_NodeTypes != null)
                return s_NodeTypes;

            var categoryNodeScript = new Dictionary<string, System.Type>();
            foreach (var type in TypeUtility.GetDerivedTypes(typeof(ActionNode))) {
                if (type != null) {
                    var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(type, false) ?? new NodeInfoAttribute();
                    string key = nodeInfo.category + type.Name;
                    // The node was already added?
                    if (categoryNodeScript.ContainsKey(key)) {
                        Print.LogWarning("You have more than one \'" + type.Name + "\' node script. You should have only one copy of each node script. Please, search for them in the ProjectView and then delete its copies", null);
                    }
                    else {
                        categoryNodeScript.Add(key, type);
                    }
                }
            }

            // Sort the dictionary keys
            var sortedKeys = new List<string>(categoryNodeScript.Keys);
            sortedKeys.Sort();

            // Add all scripts in the sortedNodeTypes
            var sortedNodeTypes = new List<System.Type>();
            for (int i = 0; i < sortedKeys.Count; i++) {
                sortedNodeTypes.Add(categoryNodeScript[sortedKeys[i]]);
            }

            s_NodeTypes = sortedNodeTypes.ToArray();
            return s_NodeTypes;
        }

        /// <summary> 
        /// Returns a collection of ActionNode scripts ordered by category.
        /// <returns>A collection of MonoScript whose class inherits from ActionNode.</returns>
        /// </summary>
        public static MonoScript[] GetNodeScripts () {
            if (s_NodeScripts != null)
                return s_NodeScripts;

            var categoryNodeScript = new Dictionary<string, MonoScript>();
            foreach (var script in FileUtility.GetScripts<ActionNode>()) {
                System.Type type = script.GetClass();
                if (type != null) {
                    var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(type, false) ?? new NodeInfoAttribute();
                    categoryNodeScript.Add(nodeInfo.category + type.Name, script);
                }
            }

            // Sort the dictionary keys
            var sortedKeys = new List<string>(categoryNodeScript.Keys);
            sortedKeys.Sort();

            // Add all scripts in the sortedNodeScripts
            var sortedNodeScripts = new List<MonoScript>();
            for (int i = 0; i < sortedKeys.Count; i++) {
                sortedNodeScripts.Add(categoryNodeScript[sortedKeys[i]]);
            }

            s_NodeScripts = sortedNodeScripts.ToArray();
            return s_NodeScripts;
        }

        /// <summary> 
        /// Returns the script for the supplied node type.
        /// <param name= "type">The type of the node to search for the script.</param>
        /// <returns>A MonoScript of the supplied node type.</returns>
        /// </summary>
        public static MonoScript GetNodeScript (System.Type type) {
            if (type != null && type.IsSubclassOf(typeof(ActionNode))) {
                foreach (MonoScript script in BehaviourTreeUtility.GetNodeScripts()) {
                    if (script.GetClass() == type)
                        return script;
                }
            }
            return null;
        }

        /// <summary> 
        /// Adds a new node to the parent, automatically handles undo, dirty flag and save node.
        /// <param name="parent">The branch to add the child.</param>
        /// <param name="childType">The type of the new node.</param>
        /// <returns>The new node.</returns>
        /// </summary>
        public static ActionNode AddNode (BranchNode parent, System.Type childType) {
            // Validate parameters
            if (parent != null && parent.tree != null && childType != null) {
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(parent.tree,"Add New Node");
                #else
                Undo.RecordObject(parent.tree,"Add New Node");
                #endif

                var newNode = parent.tree.AddNode(childType);

                if (newNode != null) {
                    // Adds new node as child of parent
                    parent.Add(newNode);

                    // Call OnValidate on the parent
                    parent.OnValidate();

                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(parent.tree);
                    return newNode;
                }
            }

            return null;
        }

        /// <summary> 
        /// Adds a new node to the tree, automatically handles undo, dirty flag and save node.
        /// <param name="tree">The tree to add a new node.</param>
        /// <param name="nodeType">The type of the new node.</param>
        /// <returns>The new node.</returns>
        /// </summary>
        public static ActionNode AddNode (InternalBehaviourTree tree, System.Type nodeType) {
            // Validate parameters
            if (tree != null && nodeType != null && nodeType.IsSubclassOf(typeof(ActionNode)) && !nodeType.IsAbstract) {
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(tree,"Add New Node");
                #else
                Undo.RecordObject(tree,"Add New Node");
                #endif

                // Create new node
                var newNode = tree.AddNode(nodeType);

                if (newNode != null) {                    
                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(tree);
                    return newNode;
                }
            }

            return null;
        }

        /// <summary> 
        /// Inserts a new node to the supplied branch, automatically handles undo, dirty flag and save node.
        /// <param name="branch">The branch to add a new node.</param>
        /// <param name="index">The index of the new node.</param>
        /// <param name="nodeType">The type of the new node.</param>
        /// <returns>The new node.</returns>
        /// </summary>
        public static ActionNode InsertNode (BranchNode branch, int index, System.Type nodeType) {
            // Validate parameters
            if (branch != null  && branch.tree != null && nodeType != null && index >= 0 && index <= branch.children.Length) {
                // Get the tree
                var tree = branch.tree;

                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(tree,"Insert New Node");
                #else
                Undo.RecordObject(tree,"Insert New Node");
                #endif

                // Create new node
                var newNode = tree.AddNode(nodeType);

                if (newNode != null) {  
                    // Insert new node 
                    branch.Insert(index, newNode);

                    // Call OnValidate on the parent
                    branch.OnValidate();

                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(tree);
                    return newNode;
                }

            }
            return null;
        }

        /// <summary> 
        /// Inserts a new node to the supplied branch, automatically handles undo, dirty flag and save node.
        /// <param name="node">The branch to add a new node.</param>
        /// <param name="newNodePosition">Move the node to the position of this node.</param>
        /// <param name="branch">The branch to drop the node or null.</param>
        /// </summary>
        public static bool MoveNode (ActionNode node, ActionNode newNodePosition, BranchNode branch) {
            // Validate parameters
            if (node != null  && node.tree != null) {
                // Get the tree
                var tree = node.tree;

                // The node does not belongs to the tree?
                if (!tree.GetNodes().Contains(node))
                    return false;

                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(tree,"Move Node");
                #else
                Undo.RecordObject(tree,"Move Node");
                #endif

                // The node will be a root node?
                if (branch == null) {
                    // Remove from old branch
                    if (node.branch != null) {
                        BranchNode oldBranch = node.branch;
                        node.branch.Remove(node);

                        // Call OnValidate on old branch
                        oldBranch.OnValidate();
                    }

                    if (newNodePosition == null) {
                        var newIndex = node.tree.GetNodes().Count - 1;
                        node.tree.MoveNode(node.GetIndex(), newIndex);
                    }
                    else {
                        var newIndex = newNodePosition.root.GetIndex();
                        node.tree.MoveNode(node.GetIndex(), newIndex);
                    }
                }
                // The new node position is null?
                else if (newNodePosition == null) {
                    // node.branch = branch;
                    // Store old branch
                    var oldBranch = node.branch;

                    // Remove from old branch
                    if (oldBranch != null) {
                        oldBranch.Remove(node);
                    }

                    // Add to drop
                    if (!branch.Add(node)) {
                        // Restore old branch
                        if (oldBranch != null)
                            oldBranch.Add(node);
                        return false;
                    }

                    // Call OnValidate on branches
                    branch.OnValidate();
                    if (oldBranch != null && oldBranch != branch)
                        oldBranch.OnValidate();

                    node.tree.HierarchyChanged();
                }
                else {
                    // Cache the oldBranch
                    BranchNode oldBranch = node.branch;

                    // Get index
                    var index = -1;
                    var children = branch.children;
                    for (int i = 0; i < children.Length; i++) {
                        if (children[i] == newNodePosition) {
                            index = i;
                            break;
                        }
                    }

                    // The index is invalid?
                    if (index < 0 || !branch.Insert(index, node)) {
                        return false;
                    }
                    else {
                        // Call OnValidate on the branches
                        if (oldBranch != null)
                            oldBranch.OnValidate();
                        branch.OnValidate();
                        node.tree.HierarchyChanged();
                    } 
                }

                // Save move opration
                StateUtility.SetDirty(tree);

                return true;
            }
            return false;
        }

        /// <summary> 
        /// Paste the node in BehaviourTreeUtility.nodeToPaste in the supplied tree.
        /// <param name="tree">The target tree.</param>
        /// <param name="parent">Optional parent to paste the node; or null to paste as a root node.</param>
        /// <returns>The pasted node.</returns>
        /// </summary>
        public static ActionNode PasteNode (InternalBehaviourTree tree, BranchNode parent = null) {
            // Get the node to be pasted
            var node = BehaviourTreeUtility.nodeToPaste;

            // Validate parameters
            if (node != null && tree != null) {
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(tree,"Paste Node");
                #else
                Undo.RecordObject(tree,"Paste Node");
                #endif

                var newNode = node.Copy(tree);

                if (newNode != null) {
                    // Add to parent branch?
                    if (parent != null) {
                        parent.Add(newNode);

                        // Call OnValidate on the parent
                        parent.OnValidate();
                    }

                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(tree);

                    // Reload tree to update variables
                    tree.LoadNodes();
                }
                return newNode;
            }
            return null;
        }


        /// <summary> 
        /// Remove the suplied branch from the tree.
        /// <param name="branch">The node to be removed.</param>
        /// <returns>True if the node was successfully removed; false otherwise.</returns>
        /// </summary>
        public static bool RemoveBranch (BranchNode branch) {
            // The Branch is not a decorator
            if (branch != null && branch.tree != null) {
                // Gets parent's children and node's id
                var parent = branch.branch;
                ActionNode[] children = branch.children;
                var tree = branch.tree;             

                // The parent is a decorator or null (node is root) and the branch has more than one child?
                if (children.Length >= 2 && (parent == null || parent is DecoratorNode) || parent == null) {
                    EditorApplication.Beep();
                    return false;
                }

                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(branch.tree, "Remove Branch");
                #else
                Undo.RecordObject(branch.tree, "Remove Branch");
                #endif

                // Removes children from branch and adds to parent
                if (parent != null) {
                    // Get the branch index
                    int branchIndex = (new List<ActionNode>(parent.children)).IndexOf(branch);
                    parent.Remove(branch);

                    for (int i = 0; i < children.Length; i++) {
                        branch.Remove(children[i]);
                        parent.Insert(branchIndex++, children[i]);
                    }

                    // Call OnValidate on the parent
                    parent.OnValidate();
                }

                // Removes node from tree
                tree.RemoveNode(branch, false);

                // Saves tree and marks dirty flag
                StateUtility.SetDirty(tree);

                return true;
            }
            return false;
        }

        /// <summary> 
        /// Destroys the suplied node and its hierarchy from the tree.
        /// <param name="node">The node to be destroyed.</param>
        /// <returns>True if the node was successfully destroyed; false otherwise.</returns>
        /// </summary>
        public static bool DestroyNode (ActionNode node) {
            // Validate parameters
            if (node != null && node.tree != null) {
                // Get parent and tree
                var tree = node.tree; 
                var parent = node.branch;               

                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(tree, "Delete " + node.name);
                #else
                Undo.RecordObject(tree, "Delete " + node.name);
                #endif

                // Removes node from parent
                if (parent != null) {
                    parent.Remove(node);

                    // Call OnValidate on the parent
                    parent.OnValidate();
                }

                // Removes node from tree
                tree.RemoveNode(node, true);

                // Saves tree and marks dirty flag
                StateUtility.SetDirty(tree);

                return true;
            }
            return false;
        }
	}
}