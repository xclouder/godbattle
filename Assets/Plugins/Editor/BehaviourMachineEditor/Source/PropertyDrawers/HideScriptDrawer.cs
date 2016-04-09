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
    /// Draws a custom gui control for the InternalStateBehaviour.m_HideScript field.
    /// <seealso cref="BehaviourMachine.HideScriptAttribute" />
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    [CustomPropertyDrawer (typeof(HideScriptAttribute))]
    public class HideScriptDrawer : StatePropertyDrawer {

        #region Unity Callbacks
        /// <summary> 
        /// Returns the gui control height.
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="labe">The label of this property.</param>
        /// <returns>The gui control height</returns>
        /// </summary>
        public override float GetPropertyHeight (SerializedProperty property, GUIContent labe) {
            var state = property.serializedObject.targetObject as InternalStateBehaviour;
            return IsNotRoot(state) ? 18f : 0f;
        }

        /// <summary> 
        /// Draws the gui control.
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// </summary>
    	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            // Get state
            var state = property.serializedObject.targetObject as InternalStateBehaviour;

            // It's a valid state?
            if (IsNotRoot(state)) {
                // Draw the toggle field control GUI.
                EditorGUI.BeginChangeCheck ();
                bool value = EditorGUI.Toggle (position, label, property.boolValue);
                if (EditorGUI.EndChangeCheck ())
                    property.boolValue = value;
            }
        }
        #endregion Unity Callbacks
    }
}