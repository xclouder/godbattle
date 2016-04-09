//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using BehaviourMachine;

namespace BehaviourMachineEditor {
    /// <summary>
    /// Custom inspector for BehaviourTree.
    /// <seealso cref="BehaviourMachine.InternalBehaviourTree" />
    /// </summary>
    [CustomEditor(typeof(InternalBehaviourTree))]
    public class InternalBehaviourTreeEditor : Editor {

        #region Members
        InternalBehaviourTree m_Tree;
        ParentStatesEditor m_StatesEditor = null;
        NodeEditor m_NodeEditor;
        #endregion Members

        #region Behaviour Machine Callback
        /// <summary>
        /// Behaviour Machine callback called whenever the active node changes.
        /// </summary>
        void ActiveNodeChanged () {
            // Get the active node
            var activeNode = BehaviourWindow.activeNode;
            // Create an editor node for the active node
            m_NodeEditor = activeNode == null ? null : NodeEditor.CreateEditor(activeNode.GetType());
            // Repaint this inspector
            this.Repaint();
        }
        #endregion Behaviour Machine Callback

        #region Unity Callbacks
        /// <summary>
        /// A Unity callback called when the object is loaded.
        /// </summary>
        void OnEnable () {
            m_Tree = target as InternalBehaviourTree;
            BehaviourWindow.activeNodeChanged += this.ActiveNodeChanged;

            m_StatesEditor = new ParentStatesEditor(m_Tree, serializedObject.FindProperty("m_Position"));

            // Try to create an editor for the current active node
            this.ActiveNodeChanged();
        }

        /// <summary>
        /// A Unity callback called when the object goes out of scope.
        /// </summary>
        void OnDisable () {
            if (m_StatesEditor != null) {
                m_StatesEditor.DisposeProperty();
                m_StatesEditor = null;
            }

            BehaviourWindow.activeNodeChanged -= this.ActiveNodeChanged;
        }

        /// <summary>
        /// Unity callback to draw a custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            // Workaround to update tree nodes
            if (Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed") {
                GUIUtility.hotControl = 0;
                GUIUtility.keyboardControl = 0;
            }

            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeInspector();
            #endif

            // Draw the built-in inspector
            DrawDefaultInspector();
            
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeControls();
            #endif

            // The tree is in the inspector view and it is the active parent?
            if (Selection.activeObject == m_Tree && BehaviourWindow.activeParentID == m_Tree.GetInstanceID()) {

                // Draw states
                if (m_StatesEditor != null) {
                    GUILayout.Space(6f);
                    m_StatesEditor.OnGUI();
                    GUILayout.Space(6f);
                }

                // Draw node properties
                if (m_NodeEditor != null) {
                    // Is there a valid active node?
                    var activeNode = BehaviourWindow.activeNode;
                    if (activeNode != null && activeNode.tree == m_Tree)
                        m_NodeEditor.DrawNode(activeNode);
                }
            }
        }
    	#endregion Unity Callbacks
    }
}