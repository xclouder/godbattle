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
    /// Custom property drawer to draw a UnityEngine.Object proeprty using another string property as its type.
    /// Use it with UnityEngine.Object.
    /// <seealso cref="BehaviourMachine.ObjectValueAttribute" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(ObjectValueAttribute))]
    public class ObjectValueDrawer : NodePropertyDrawer {
        /// <summary>
        /// Draw the UnityEngine.Object using the objectType field.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // Object
            if (property.propertyType == NodePropertyType.UnityObject) {
                
                // Get the type path
                var attr = this.attribute as ObjectValueAttribute;
                string path = property.path;
                int lastDotIndex = path.LastIndexOf('.');

                if (lastDotIndex > -1)
                    path = path.Remove(lastDotIndex + 1, path.Length - lastDotIndex - 1);
                else
                    path = string.Empty;

                // Get the property iterator
                NodePropertyIterator iterator = property.serializedNode.GetIterator();

                // The type of the object
                string objectTypeAsString = string.Empty;

                // Get the object type as string
                if (iterator.Find(path + attr.typePropertyPath)) {
                    SerializedNodeProperty typeProperty = iterator.current;
                    objectTypeAsString = typeProperty.value as string ?? string.Empty;
                }

                // Get the object type
                System.Type objectType = !string.IsNullOrEmpty(objectTypeAsString) ? BehaviourMachine.TypeUtility.GetType(objectTypeAsString) ?? typeof(UnityEngine.Object) : typeof(UnityEngine.Object);

                // Used to detect if the gui control was changed
                EditorGUI.BeginChangeCheck();

                // Draw the object gui control
                UnityEngine.Object newValue = EditorGUILayout.ObjectField(guiContent, property.value as UnityEngine.Object, objectType, !AssetDatabase.Contains(node.self));

                // Value changed?
                if (EditorGUI.EndChangeCheck())
                    property.value = newValue;
            }
            // Not Object
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use ObjectValue with UnityEngine.Object."));
        }
    }
}