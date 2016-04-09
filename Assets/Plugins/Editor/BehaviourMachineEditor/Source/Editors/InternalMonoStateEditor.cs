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
    /// Custom inspector for MonoState.
    /// <seealso cref="BehaviourMachine.MonoState" />
    /// </summary>
    [CustomEditor(typeof(InternalMonoState))]
    public class InternalMonoStateEditor : Editor {

        #region Member
        InternalMonoState m_MonoState;
        MonoBehaviour m_MonoBehaviour;
        Editor m_MonoBehaviourEditor;
        SerializedProperty m_SerialProp = null;
    	#endregion Member

        #region Unity Callbacks
        /// <summary> 
        /// A Unity callback called when the object is loaded.
        /// </summary>
        void OnEnable () {
            m_MonoState = target as InternalMonoState;
            m_MonoBehaviour = m_MonoState.monoBehaviour;
            m_SerialProp = serializedObject.FindProperty("m_Transitions");
        }

        /// <summary> 
        /// A Unity callback called when the object goes out of scope.
        /// </summary>
        void OnDisable () {
            m_SerialProp.Dispose();
        }

        /// <summary> 
        /// Unity callback to draw a custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeInspector();
            #endif
            DrawDefaultInspector();     // Draw the built-in inspector

            // Create a new monoBehaviour Editor?
            if (m_MonoBehaviourEditor == null || m_MonoState.monoBehaviour != m_MonoBehaviour) {
                m_MonoBehaviour = m_MonoState.monoBehaviour;
                m_MonoBehaviourEditor = m_MonoBehaviour == null ? null : Editor.CreateEditor(m_MonoBehaviour);
            }

            // Draw monoBehaviour inspector
            if (m_MonoBehaviourEditor != null && m_MonoBehaviourEditor.target != null && Selection.activeObject == m_MonoState) {
                int oldIndentLevel = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;
                GUILayout.Space(8f);
                m_SerialProp.isExpanded = EditorGUILayout.InspectorTitlebar(m_SerialProp.isExpanded, m_MonoBehaviour);
                if (m_SerialProp.isExpanded) {
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    EditorGUIUtility.LookLikeInspector();
                    #endif
                    m_MonoBehaviourEditor.OnInspectorGUI();
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    EditorGUIUtility.LookLikeControls();
                    #endif
                }
                EditorGUI.indentLevel = oldIndentLevel;
            }
            if (GUI.changed)
                m_MonoState.OnValidate();
        }
        #endregion Unity Callbacks
    }
}