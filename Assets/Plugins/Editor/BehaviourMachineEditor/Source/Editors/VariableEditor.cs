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
    /// Class used to draw blackboard variables in the inspector.
    /// <seealso cref="BehaviourMachineEditor.BlackboardEditor" />
    /// </summary>
    public class VariableEditor {

    	#region Constants
        const float c_HeaderHeight = 18f;
        const float c_FooterHeight = 13f;
        #endregion Constants

        #region Styles
        static VariableEditor.Styles s_Styles;

        /// <summary> 
        /// A class to store GUIStyles that are used by a VariableEditor.
        /// </summary>
        class Styles {
            public GUIContent iconToolbarPlus = new GUIContent(EditorGUIUtility.FindTexture("Toolbar Plus"), "Add New Variable");
            public readonly GUIStyle headerBackground = "RL Header";
            public readonly GUIStyle footerBackground = "RL Footer";
            public readonly GUIStyle boxBackground = "RL Background";
            public readonly GUIStyle preButton = "RL FooterButton";
        }
        #endregion Styles

        #region Members
        InternalBlackboard m_Blackboard;
        #endregion Members

        #region Constructors
        /// <summary> 
        /// Class constructor.
        /// <param name="blackboard">The blackboard to be drawn.</param> 
        /// </summary>
        public VariableEditor (InternalBlackboard blackboard) {
            m_Blackboard = blackboard;
        }
        #endregion Constructors

        #region Draw Methods
        /// <summary> 
        /// Draw the header.
        /// </summary>
        void DrawHeader () {
            Rect rect = GUILayoutUtility.GetRect (0f, c_HeaderHeight, new GUILayoutOption[] {GUILayout.ExpandWidth (true)});

            if (Event.current.type == EventType.Repaint) {
                // Draw background
                rect.xMin += 4f;
                rect.xMax -= 4f; 
                s_Styles.headerBackground.Draw (rect, false, false, false, false);
            }

            // Draw header title
            rect.xMin += 6f;
            rect.xMax -= 6f;
            rect.height -= 2f;
            rect.y += 1f;
            #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2
            rect.xMin += 8f;
            #endif
            EditorGUI.LabelField (rect, "Variables");
        }

        /// <summary> 
        /// Draw the plus button to add new variables.
        /// </summary>
        void DrawFooter () {
            Rect rect = GUILayoutUtility.GetRect (4f, c_FooterHeight, new GUILayoutOption[]{GUILayout.ExpandWidth (true)});
            rect.xMin += 4f;
            rect.xMax -= 4f;
            rect = new Rect (rect.x + rect.width - 33f, rect.y, 33f, rect.height);

            // Draw background
            if (Event.current.type == EventType.Repaint)
                s_Styles.footerBackground.Draw(rect, false, false, false, false);

            // Draw plus button
            rect = new Rect(rect.x + 4f, rect.y - 4f, 25f, c_FooterHeight);
            if (GUI.Button(rect, s_Styles.iconToolbarPlus, s_Styles.preButton))
               BlackboardGUIUtility.OnAddContextMenu(m_Blackboard);
        }

        /// <summary> 
        /// Draw variables.
        /// </summary>
        void DrawVariables () {
            float height = BlackboardGUIUtility.GetHeight(m_Blackboard);
            bool listIsEmpty = height == 0f;

            Rect rect = GUILayoutUtility.GetRect (10f, (listIsEmpty ? 21f : height) + 7f, new GUILayoutOption[] {GUILayout.ExpandWidth (true)});

            // Draw background
            rect.xMin += 4f;
            rect.xMax -= 4f;
            if (Event.current.type == EventType.Repaint) {
                s_Styles.boxBackground.Draw (rect, false, false, false, false);
            }

            rect.yMin += 2f;
            rect.yMax -= 3f;
            var rect2 = rect;

            // The blackboard is empty?
            if (listIsEmpty) {
                rect2.height = 21f;
                rect2.x += 6f;
                EditorGUI.LabelField (rect2, "List is Empty");
            }
            else {
                BlackboardGUIUtility.DrawVariables(rect2, m_Blackboard);
            }
        }
        #endregion Draw Methods


        #region Public Methods
        /// <summary> 
        /// Call this method to draw the blackboard variables in the gui.
        /// </summary>
        public void OnGUI () {
            if (s_Styles == null)
                s_Styles = new VariableEditor.Styles();

            // Save indentlevel
            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            this.DrawHeader();
            this.DrawVariables();
            this.DrawFooter();

            // Restore indent level
            EditorGUI.indentLevel = indentLevel;
        }

        /// <summary> 
        /// Returns whenever this editor is valid.
        /// <returns>Returns true if this editor is valid; false otherwise.</returns>
        /// </summary>
        public bool IsValid () {
            return m_Blackboard != null;
        }
        #endregion Public Methods
    }
}