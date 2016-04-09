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
    /// Custom drawer for PropertyOrField.propertyName.
    /// <seealso cref="BehaviourMachine.PropertyOrField" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(UnityObjectPropertyAttribute))]
    public class UnityObjectPropertyDrawer : NodePropertyDrawer {
        /// <summary>
        /// Draw the property pop-up.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // String
            if (property.propertyType == NodePropertyType.String) {
                var rect = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.popup);
                var id = GUIUtility.GetControlID(FocusType.Passive);
                var popupRect = EditorGUI.PrefixLabel(rect, id, guiContent);
                var popupName = property.value as string ?? string.Empty;
                var propertyOrField = node as PropertyOrField;

                var oldGUIColor = GUI.color;
                if (propertyOrField.propertyType == null)
                    GUI.color = Color.red;

                if (GUI.Button(popupRect, string.IsNullOrEmpty(popupName) ? "None" : popupName, EditorStyles.popup)) {
                    var isSetProperty = propertyOrField is SetProperty;
                    var members = FieldUtility.GetPublicMembers(propertyOrField.targetObject.ObjectType, null, false, isSetProperty, !isSetProperty);
                    var menu = new GenericMenu();

                    // Add none
                    menu.AddItem(new GUIContent("None"), string.IsNullOrEmpty(popupName), delegate () {property.value = string.Empty;});

                    // Add members
                    for (int i = 0; i < members.Length; i++) {
                        var memberName = members[i].Name;
                        menu.AddItem(new GUIContent(memberName), popupName == memberName, delegate () {property.value = memberName;});
                    }

                    menu.ShowAsContext();
                }
                GUI.color = oldGUIColor;
            }
            // Not String
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use UnityObjectProperty with string."));
        }
    }
}