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
    /// AnyState custom inspector.
    /// <seealso cref="BehaviourMachine.AnyState" />
    /// </summary>
    [CustomEditor(typeof(InternalAnyState))]
    public class InternalAnyStateEditor : Editor {

        #region Members
        SerializedProperty m_Property;
        #endregion Members


        #region Unity
        /// <summary> 
        /// Unity callback called when the object is loaded.
        /// </summary>
        void OnEnable () {
            if (target != null) {
                m_Property = serializedObject.FindProperty("m_CanTransitionToSelf");
            }
        }

        /// <summary> 
        /// Unity callback to draw a custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeInspector();
            #endif
            var oldGuiEnabled = GUI.enabled;
            GUI.enabled = false;
            DrawDefaultInspector();
            GUI.enabled = oldGuiEnabled;


            if (m_Property != null) {
                EditorGUI.BeginChangeCheck();
                EditorGUILayout.PropertyField(m_Property);
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();
            }

        }
        #endregion Unity
    }
}