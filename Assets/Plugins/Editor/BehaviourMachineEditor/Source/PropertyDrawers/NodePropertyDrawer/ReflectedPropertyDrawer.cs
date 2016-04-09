//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Custom drawer for Reflected variables.
    /// <seealso cref="BehaviourMachine.FloatProperty" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(ReflectedPropertyAttribute))]
    public class ReflectedPropertyDrawer : NodePropertyDrawer {

        #region Styles
        static ReflectedPropertyDrawer.Styles s_Styles;

        /// <summary>
        /// A class that holds GUIStyles used by the ReflectedPropertyAttribute.
        /// </summary>
        class Styles {
            public readonly Color labelTextColor;

            public Styles () {
                labelTextColor = EditorStyles.label.normal.textColor;
            }
        }
        #endregion Styles 

        /// <summary>
        /// Draw the property pop-up.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // Create styles?
            if (s_Styles == null)
                s_Styles = new ReflectedPropertyDrawer.Styles();

            // String
            if (property.propertyType == NodePropertyType.String) {
                var popupName = property.value as string ?? string.Empty;
                
                // Get the current vaue of the member
                var memberName = property.value as string ?? string.Empty;
                var attr = this.attribute as ReflectedPropertyAttribute;
                UnityEngine.Object obj = null;
                Component component = null;
                SerializedNodeProperty componentProperty = null;
                SerializedNodeProperty isStaticProperty = null;

                // Get the path
                string path = property.path;
                int lastDotIndex = path.LastIndexOf('.');

                if (lastDotIndex > -1)
                    path = path.Remove(lastDotIndex + 1, path.Length - lastDotIndex - 1);
                else
                    path = string.Empty;

                // Get the property iterator
                NodePropertyIterator iterator = property.serializedNode.GetIterator();

                // Get the game object
                if (iterator.Find(path + attr.objectPropertyPath)) {
                    SerializedNodeProperty objectProperty = iterator.current;
                    obj = objectProperty.value as UnityEngine.Object;
                }

                // Get the isStatic property
                if (iterator.Find(path + attr.isStaticPropertyPath)) {
                    isStaticProperty = iterator.current;
                    if ((bool) isStaticProperty.value)
                        popupName += " (static)";
                }

                // Get the component
                if (iterator.Find(path + attr.componentPropertyPath)) {
                    componentProperty = iterator.current;
                    component = componentProperty.value as Component;
                }

                // Update popup name
                if (string.IsNullOrEmpty(memberName))
                    popupName = "No Property";
                else if (component != null)
                    popupName = component.GetType().Name + "." + popupName;
                else if (obj != null)
                    popupName = obj.GetType().Name + "." + popupName;
                else
                    popupName = "No Property";

                // Get the target type
                System.Type targetType = null;
                if (component != null)
                    targetType = component.GetType();
                else if (obj != null)
                    targetType = obj.GetType();

                // Draw Prefix Label
                if (!FieldUtility.HasMember(targetType, memberName)) {
                    EditorStyles.label.normal.textColor = Color.red;
                }
                var rect = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.popup);
                var id = GUIUtility.GetControlID(FocusType.Passive);
                var popupRect = EditorGUI.PrefixLabel(rect, id, guiContent);

                bool oldGUIEnabled = GUI.enabled;
                GUI.enabled = obj != null;

                if (GUI.Button(popupRect, string.IsNullOrEmpty(popupName) ? "No Property" : popupName, EditorStyles.popup) && obj != null && componentProperty != null && isStaticProperty != null) {
                    var menu = new GenericMenu();

                    // Unique names in the menu
                    var uniqueNames = new List<string>();
                    uniqueNames.Add("No Property");

                    // Add none
                    menu.AddItem(new GUIContent("No Property"), popupName == "No Property", delegate () {componentProperty.value = null; isStaticProperty.value = false; property.value = string.Empty;});

                    // Add separator
                    menu.AddSeparator(string.Empty);

                    string staticName = obj.GetType().Name + "/Static Properties/";

                    // Add Object static members
                    var members = FieldUtility.GetPublicMembers(obj.GetType(), attr.propertyType, true, true, true);
                    if (members.Length > 0) {
                        for (int i = 0; i < members.Length; i++) {
                            var currentMemberName = members[i].Name;
                            menu.AddItem(new GUIContent(staticName + currentMemberName), component == null && currentMemberName == memberName, delegate () {componentProperty.value = null; isStaticProperty.value = true; property.value = currentMemberName;});
                        }
                    }

                    // Add Object members
                    members = FieldUtility.GetPublicMembers(obj.GetType(), attr.propertyType, false, true, true);
                    for (int i = 0; i < members.Length; i++) {
                        var currentMemberName = members[i].Name;
                        menu.AddItem(new GUIContent(obj.GetType().Name + "/" +  currentMemberName), component == null && currentMemberName == memberName, delegate () {componentProperty.value = null; isStaticProperty.value = false; property.value = currentMemberName;});
                    }

                    // Add components
                    var gameObject = obj as GameObject;
                    if (gameObject != null) {
                        Component[] components = gameObject.GetComponents<Component>();
                        for (int i = 0; i < components.Length; i++) {
                            // Get the current componet
                            Component currentComponent = components[i];
                            // Get the component type
                            System.Type componentType = currentComponent.GetType();

                            // Get a unique name for the component names
                            string componentName = StringHelper.GetUniqueNameInList(uniqueNames, componentType.Name);
                            uniqueNames.Add(componentName);

                            // Add static members
                            staticName = componentName + "/Static Properties/";
                            members = FieldUtility.GetPublicMembers(currentComponent.GetType(), attr.propertyType, true, true, true);
                            if (members.Length > 0) {
                                for (int j = 0; j < members.Length; j++) {
                                    var currentMemberName = members[j].Name;
                                    menu.AddItem(new GUIContent(staticName +  currentMemberName), currentComponent == component && currentMemberName == memberName, delegate () {componentProperty.value = currentComponent; isStaticProperty.value = true; property.value = currentMemberName;});
                                }
                            }

                            // Get members
                            members = FieldUtility.GetPublicMembers(currentComponent.GetType(), attr.propertyType, false, true, true);

                            // Add members
                            for (int j = 0; j < members.Length; j++) {
                                var currentMemberName = members[j].Name;
                                menu.AddItem(new GUIContent(componentName + "/" +  currentMemberName), currentComponent == component && currentMemberName == memberName, delegate () {componentProperty.value = currentComponent; isStaticProperty.value = false; property.value = currentMemberName;});
                            }
                        }
                    }

                    menu.ShowAsContext();   
                }

                // Restore olde gui enabled
                GUI.enabled = oldGUIEnabled;

                // Restore label color
                EditorStyles.label.normal.textColor = s_Styles.labelTextColor;
            }
            // Not String
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use UnityObjectReflectProperty with string."));
        }
    }
}