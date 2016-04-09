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
    /// Draws a custom gui control for the InternalStateBehaviour.m_Color field.
    /// <seealso cref="BehaviourMachine.StateColorAttribute" />
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    [CustomPropertyDrawer (typeof(StateColorAttribute))]
    public class StateColorDrawer : StatePropertyDrawer {

        #region Unity Callbacks
        /// <summary> 
        /// Returns the gui control height.
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns>The gui control height.</returns>
        /// </summary>
        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            var state = property.serializedObject.targetObject as InternalStateBehaviour;
            return IsNotRoot(state) && IsNotStart(state) ? 18f : 0f;
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
            if (IsNotRoot(state) && IsNotStart(state)) {
                // Draw the toggle field control GUI.
                EditorGUI.BeginChangeCheck ();
                int value = EditorGUI.Popup (position, label.text, property.enumValueIndex, property.enumNames);
                if (EditorGUI.EndChangeCheck ())
                    property.enumValueIndex = value;
            }
        }
        #endregion Unity Callbacks
    }
}
