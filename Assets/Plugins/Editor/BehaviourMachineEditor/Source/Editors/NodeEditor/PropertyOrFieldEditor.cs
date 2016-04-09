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
    /// Custom editor for nodes that inherit from PropertyOrField.
    /// <seealso cref="BehaviourMachine.PropertyOrField" />
    /// </summary>
    [CustomNodeEditor(typeof(PropertyOrField), true)]
    public class PropertyOrFieldEditor : NodeEditor {

        System.Type propertyType;

    	/// <summary>
        /// The custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            // Update serialized node data
            if (Event.current.type == EventType.Layout) {
                this.serializedNode.Update();
            }

            // Cache the indent level
            int indentLevel = EditorGUI.indentLevel;

            // Get an iterator
            var iterator = this.serializedNode.GetIterator();

            // Draw the target object
            if (iterator.Find("targetObject")) {
                EditorGUI.indentLevel = indentLevel + iterator.depth;
                GUILayoutHelper.DrawNodeProperty(new GUIContent(iterator.current.label, iterator.current.tooltip), iterator.current, this.target);
            }

            // Draw the propertyName
            if (iterator.Find("propertyName")) {
                EditorGUI.indentLevel = indentLevel + iterator.depth;
                GUILayoutHelper.DrawNodeProperty(new GUIContent(iterator.current.label, iterator.current.tooltip), iterator.current, this.target);
            }

            // Draw the property value
            var propertyOrField = target as PropertyOrField;
            if (propertyOrField != null) {
                if (Event.current.type == EventType.Layout)
                    propertyType = propertyOrField.propertyType;

                if (propertyType != null) {
                    if (iterator.Find(propertyType.Name + "Value")) {
                        EditorGUI.indentLevel = indentLevel + iterator.depth;
                        GUILayoutHelper.DrawNodeProperty(new GUIContent(propertyOrField.propertyName, iterator.current.tooltip), iterator.current, this.target);
                    }
                    else if (propertyType == typeof(GameObject) && iterator.Find("GameObjectValue")) {
                        EditorGUI.indentLevel = indentLevel + iterator.depth;
                        GUILayoutHelper.DrawNodeProperty(new GUIContent(propertyOrField.propertyName, iterator.current.tooltip), iterator.current, this.target);
                    }
                    else if (typeof(UnityEngine.Object).IsAssignableFrom(propertyType) && iterator.Find("ObjectValue")) {
                        EditorGUI.indentLevel = indentLevel + iterator.depth;
                        GUILayoutHelper.DrawNodeProperty(new GUIContent(propertyOrField.propertyName, iterator.current.tooltip), iterator.current, this.target);
                    }
                    else if (target is SetProperty && propertyType.IsEnum && iterator.Find("StringValue.value")) {

                        string value = (string)iterator.current.value;

                        // The enum is defined?
                        if (!System.Enum.IsDefined(propertyType, value)) {
                            iterator.current.value = value = "0";
                        }

                        // Used to check if the gui was changed in editor
                        EditorGUI.BeginChangeCheck();
                        // Draw an enum popup field
                        System.Enum newValue = EditorGUILayout.EnumPopup(new GUIContent(propertyOrField.propertyName, iterator.current.tooltip), (System.Enum)System.Enum.Parse(propertyType, value));
                        // Value changed?
                        if (EditorGUI.EndChangeCheck()) {
                            iterator.current.value = newValue.ToString();
                        }
                    }
                    else
                        EditorGUILayout.LabelField(propertyType.Name ,"not supported.");
                }
            }

            // Restore the indent level
            EditorGUI.indentLevel = indentLevel;
            
            // Apply modified properties
            this.serializedNode.ApplyModifiedProperties();
        }
    }
}