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
    /// Custom property drawer for UnityEngine.Object type.
    /// Use it with strings.
    /// <seealso cref="BehaviourMachine.UnityObjectTypeAttribute" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(UnityObjectTypeAttribute))]
    public class UnityObjectTypeDrawer : NodePropertyDrawer {
        /// <summary>
        /// Draw the UnityEngine.Object types pop-up.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // String
            if (property.propertyType == NodePropertyType.String) {

                var stringValue = property.value as string ?? string.Empty;
                var rect = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.popup);
                var id = GUIUtility.GetControlID(FocusType.Passive);
                var popupRect = EditorGUI.PrefixLabel(rect, id, guiContent);
                var objectType = UnityObjectTypeAttribute.GetObjectType(stringValue);

                if (GUI.Button(popupRect, objectType != null ? objectType.ToString() : "None", EditorStyles.popup)) {
                    var menu = new GenericMenu();

                    // Add None
                    menu.AddItem(new GUIContent("None"), string.IsNullOrEmpty(stringValue), delegate {property.value = string.Empty;});

                    // Add all types that inherit from UnityEngine.Object
                    var types = TypeUtility.GetDerivedTypes(typeof(UnityEngine.Object));
                    for (int i = 0; i < types.Length; i++) {
                        var typeAsString = types[i].ToString();
                        menu.AddItem(new GUIContent(typeAsString.Replace('.', '/')), stringValue == typeAsString, delegate {property.value = typeAsString;});
                    }

                    menu.ShowAsContext();
                }
            }
            // Not String
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use UnityObjectType with string."));
        }
    }
}