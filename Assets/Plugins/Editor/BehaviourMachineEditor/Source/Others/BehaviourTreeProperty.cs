//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary> 
    /// An auxiliary class to traverse a BehaviourTree.
    /// </summary>
    public class BehaviourTreeProperty {

        #region Members
        InternalBehaviourTree m_Tree;
        ActionNode m_CurrentNode;
        BranchNode m_CurrentBranch;
        FunctionNode m_CurrentFunction;
        int m_CurrentNodeIndex = -1;
        IList<ActionNode> m_Nodes = new List<ActionNode>();
        bool m_IsValid = false;
        #endregion Members

        
        #region Properties
        /// <summary> 
        /// The target behaviour tree.
        /// </summary>
        public InternalBehaviourTree tree {get {return m_Tree;} 
            set {
                m_Tree = value;
                Reset();
            }
        }

        /// <summary> 
        /// The current node.
        /// </summary>
        public ActionNode currentNode {get {return m_CurrentNode;}}

        /// <summary> 
        /// The current branch node.
        /// </summary>
        public BranchNode currentBranchNode {get {return m_CurrentBranch;}}

        /// <summary> 
        /// The current function node.
        /// </summary>
        public FunctionNode currentFunctionNode {get {return m_CurrentFunction;}}

        /// <summary> 
        /// The current node index in the tree.
        /// </summary>
        public int currentNodeID {get {return m_CurrentNode != null ? m_CurrentNode.instanceID : 0;}}

        /// <summary> 
        /// The current node depth.
        /// </summary>
        public int currentNodeDepth {
            get {
                if (m_CurrentNode != null) {
                    var depth = 0;
                    for (var branch = m_CurrentNode.branch; branch != null; branch = branch.branch)
                        depth++;
                    return depth;
                }
                return 0; 
            }
        }

        /// <summary> 
        /// The current node icon.
        /// </summary>
        public Texture currentNodeIcon {get {return IconUtility.GetIcon(m_CurrentNode.GetType());}}
        #endregion Properties

        
        #region Private Methods
        /// <summary> 
        /// Reset members.
        /// </summary>
        public void Reset () {
            if (m_Tree != null)
                m_Nodes = m_Tree.GetNodes();
            else
                m_Nodes = new List<ActionNode>();

            m_CurrentNode = null;
            m_CurrentBranch = null;
            m_CurrentFunction = null;
            m_CurrentNodeIndex = -1;
            m_IsValid = true;
        }

        /// <summary> 
        /// Updates current node by incremeting m_CurrentNodeIndex).
        /// </summary>
        void GoToNextNode () {
            m_CurrentNodeIndex++;

            if (m_CurrentNodeIndex >= 0 && m_CurrentNodeIndex < m_Nodes.Count) {
                m_CurrentNode = m_Nodes[m_CurrentNodeIndex];
                m_CurrentBranch = m_CurrentNode as BranchNode;
                m_CurrentFunction = m_CurrentBranch != null ? m_CurrentBranch as FunctionNode : null;
            }
            else {
                m_CurrentNode = null;
                m_CurrentBranch = null;
                m_CurrentFunction = null;
                m_CurrentNodeIndex = -1;
                m_IsValid = false;
            }
        }

        int CountNodesInBranch (BranchNode branch) {
            var n = 0;
            foreach (var child in branch.children) {
                n++;
                if (child is BranchNode)
                    n += CountNodesInBranch(child as BranchNode);
            }
            return n;
        }
        #endregion Private Methods

        
        #region Public Methods
        /// <summary> 
        /// Move to next visible node in the tree.
        /// <param name="expanded">A list of node indexes that are expanded.</param>
        /// <returns>True if the current node is valid.</returns>
        /// </summary>
        public bool Next (List<int> expanded) {
            // The current node is a branch and has no visible children?
            if (m_CurrentBranch != null && expanded != null && !expanded.Contains(m_CurrentNode.instanceID)) {
                // Get next node in branch
                m_CurrentNodeIndex += CountNodesInBranch(m_CurrentBranch);
                GoToNextNode();
            }
            else
                GoToNextNode();

            return m_IsValid;
        }

        /// <summary> 
        /// Move to the behaviour that has the supplied instanceID.
        /// <param name="id">The instanceID to search.</param>
        /// <param name="expanded">A list of nodes' intanceIDs that are expanded.</param>
        /// </summary>
        public bool Find (int id, List<int> expanded) {
            while (Next(expanded) && m_IsValid && m_CurrentNode.instanceID != id);
            return m_CurrentNode != null;
        }

        /// <summary> 
        /// Move to the behaviour that has the supplied index.
        /// <param name="index">The instanceID to search.</param>
		/// <param name="expanded">A list of nodes' intanceIDs that are expanded.</param>
        /// </summary>
        public bool FindByIndex (int index, List<int> expanded) {
            while (Next(expanded) && m_IsValid && m_CurrentNodeIndex != index);
            return m_CurrentNode != null;
        }

        /// <summary> 
        /// Returns the number of remaining visible nodes.
		/// <param name="expanded">A list of nodes' intanceIDs that are expanded.</param>
        /// <returns>The number of remaining visible nodes.</returns>
        /// </summary>
        public int CountRemaining (List<int> expanded) {
            // Stores the currentNode index
            var index = m_CurrentNodeIndex;
            Reset();

            // Count remaining
            int i = 0;
            while(Next(expanded))
                i++;

            // Restore currentNode
            Reset();

            // Goes back to the previous node
            if (index != -1)
                Find(index, expanded);
            
            return i;
        }
        #endregion Public Methods
    }
}