//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary> 
    /// ActionState utility functions.
    /// <seealso cref="BehaviourMachine.InternalActionState" />
    /// </summary>
    public class ActionStateUtility {

    	/// <summary> 
        /// Adds a new node to the action state, automatically handles undo, dirty flag and save node.
        /// <param name="actionState">The action state to add a new node.</param>
        /// <param name="nodeType">The type of the new node.</param>
        /// <returns>The new node.</returns>
        /// </summary>
        public static ActionNode AddNode (InternalActionState actionState, System.Type nodeType) {
            // Validate parameters
            if (actionState != null && nodeType != null && nodeType.IsSubclassOf(typeof(ActionNode)) && !nodeType.IsAbstract) {
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(actionState,"Add New Node");
                #else
                Undo.RecordObject(actionState,"Add New Node");
                #endif

                // Create new node
                var newNode = actionState.AddNode(nodeType);

                if (newNode != null) {                    
                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(actionState);
                    return newNode;
                }
            }

            return null;
        }

        /// <summary> 
        /// Destroys the suplied node and its hierarchy from the tree.
        /// <param name="node">The node to be destroyed.</param>
        /// <returns>True if the node was successfully destroyed; false otherwise.</returns>
        /// </summary>
        public static bool DestroyNode (ActionNode node) {
            // Get the tree action state
            var actionState = node != null ? node.owner as InternalActionState : null;

            // Validate parameters
            if (actionState != null) {                
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(actionState, "Delete " + node.name);
                #else
                Undo.RecordObject(actionState, "Delete " + node.name);
                #endif

                // Removes node from actionState
                actionState.RemoveNode(node);

                // Saves actionState and marks dirty flag
                StateUtility.SetDirty(actionState);

                return true;
            }
            return false;
        }

        /// <summary> 
        /// Paste the supplied nodes in the supplied ActionState.
        /// <param name="actionState">The ActionState to paste the node.</param>
        /// <param name="nodes">The nodes to be pasted.</param>
        /// <returns>The pasted nodes.</returns>
        /// </summary>
        public static ActionNode[] PasteNodes (InternalActionState actionState, ActionNode[] nodes) {
            var newNodes = new List<ActionNode>();

            // Validate parameters
            if (nodes != null && actionState != null) {
                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(actionState,"Paste Node");
                #else
                Undo.RecordObject(actionState,"Paste Node");
                #endif

                // Copy nodes
                for (int i = 0; i < nodes.Length; i++) {
                    if (nodes[i] != null && !(nodes[i] is BranchNode)) {
                        ActionNode newNode = nodes[i].Copy(actionState);
                        if (newNode != null)
                            newNodes.Add(newNode);
                    }
                }

                if (newNodes.Count > 0) {
                    // Saves node and sets dirty flag
                    StateUtility.SetDirty(actionState);

                    // Reload actionState to update variables
                    actionState.LoadNodes();
                }
            }
            return newNodes.ToArray();
        }

        /// <summary> 
        /// Returns action and condition nodes in the supplied nodes; branch nodes are ignored but their hierarchy will be included.
        /// <returns>The actions and conditions in the supplied nodes.</returns>
        /// </summary>
        public static ActionNode[] GetActionsAndConditions (ActionNode[] nodes) {
            var actionCondition = new List<ActionNode>();

            if (nodes != null) {
                for (int i = 0; i < nodes.Length; i++) {
                    if (nodes[i] is BranchNode) {
                        var branch = nodes[i] as BranchNode;
                        actionCondition.AddRange(ActionStateUtility.GetActionsAndConditions(branch.children));
                    }
                    else
                        actionCondition.Add(nodes[i]);
                }
            }

            return actionCondition.ToArray();
        }
    }
}