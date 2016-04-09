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
    /// Draws a string field as a selectable label.
    /// <seealso cref="BehaviourMachine.SelectableLabelAttribute" />
    /// </summary>
    [CustomPropertyDrawer (typeof(SelectableLabelAttribute))]
    public class SelectableLabelDrawer : PropertyDrawer {

    	/// <summary> 
        /// Draws the gui control.
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// </summary>
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            position = EditorGUI.PrefixLabel(position, EditorGUIUtility.GetControlID(FocusType.Passive, position), label);
            
            var oldIndentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            switch (property.propertyType) {
                case SerializedPropertyType.Integer:
                    EditorGUI.SelectableLabel(position, property.intValue.ToString());
                    break;
                case SerializedPropertyType.ObjectReference:
                    // Get the object as state
                    var state = property.objectReferenceValue as InternalStateBehaviour;
                    if (state != null) 
                        EditorGUI.SelectableLabel(position, state.stateName);   // Draw state name
                    else
                        EditorGUI.SelectableLabel(position, property.objectReferenceValue != null ? property.objectReferenceValue.name : "Null");
                    break;
                case SerializedPropertyType.String:
                    EditorGUI.SelectableLabel(position, property.stringValue);
                    break;
                case SerializedPropertyType.Float:
                    EditorGUI.SelectableLabel(position, property.floatValue.ToString());
                    break;
                default:
                    EditorGUI.SelectableLabel(position, property.propertyType.ToString() + " not supported.");
                    break;
            }
            EditorGUI.indentLevel = oldIndentLevel;
        }
    }
}