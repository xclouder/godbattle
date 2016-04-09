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
    /// Draws a custom gui control for the MonoState.m_MonoBehaviour field.
    /// <seealso cref="BehaviourMachine.MonoBehaviourAttribute" />
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    [CustomPropertyDrawer (typeof(MonoBehaviourAttribute))]
    public class MonoBehaviourDrawer : StatePropertyDrawer {

        void RegisterUndo (UnityEngine.Object obj) {
            // Register undo
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            Undo.RegisterUndo(obj,"Inspector");
            #else
            Undo.RecordObject(obj,"Inspector");
            #endif
        }

        #region Unity Callbacks
        /// <summary> 
        /// Returns the gui control height.
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns>The gui control height</returns>
        /// </summary>
        // public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
        //     return property.objectReferenceValue != null ? 32f : 18f;
        // }

        /// <summary> 
        /// Draws the gui control.
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// </summary>
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            // Get the MonoState
            var monoState = property.serializedObject.targetObject as InternalMonoState;

            // It's a valid state and property?
            if (monoState != null && property.propertyType == SerializedPropertyType.ObjectReference) {

                // Get the target GameObject
                GameObject targetGameObject = monoState.target as GameObject;

                // If the target target GameObject is null then disable the GUI
                bool cachedGuiEnabled = GUI.enabled;
                GUI.enabled = targetGameObject != null;

                // Draw prefix label
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Rect controlPosition = EditorGUI.PrefixLabel(position, EditorGUIUtility.GetControlID(FocusType.Passive, position), label);
                #else
                Rect controlPosition = EditorGUI.PrefixLabel(position, label);
                #endif

                // Get the current MonoBehaivour
                MonoBehaviour monoBehaviour = monoState.monoBehaviour;

                // Draw button as popup
                if (GUI.Button(controlPosition, monoBehaviour != null ? monoBehaviour.GetType().Name : "Null", EditorStyles.popup)) {
                    
                    // Get the MonoBehaviours in the target GameObject
                    List<MonoBehaviour> monoBehaviours = new List<MonoBehaviour>(targetGameObject.GetComponents<MonoBehaviour>());

                    // Removes the MonoState from list if it exists
                    if (monoBehaviours.Contains(monoState))
                        monoBehaviours.Remove(monoState);

                    // Create menu
                    var menu = new GenericMenu();

                    // Add null item
                    menu.AddItem(new GUIContent("Null"), monoBehaviour == null, 
                        delegate () {
                            RegisterUndo(monoState);
                            monoState.monoBehaviour = null;
                            EditorUtility.SetDirty(monoState);
                        }
                    );

                    // Add menu items
                    var monoBehaviourNames = new List<string>();
                    for (int i = 0; i < monoBehaviours.Count; i++) {
                        string monoBehaviourName = StringHelper.GetUniqueNameInList(monoBehaviourNames, monoBehaviours[i].GetType().Name);
                        monoBehaviourNames.Add(monoBehaviourName);
                        MonoBehaviour currentMonoBehaviour = monoBehaviours[i];
                        menu.AddItem(new GUIContent(monoBehaviourName), monoBehaviour == currentMonoBehaviour, 
                            delegate () {
                                RegisterUndo(monoState);
                                RegisterUndo(currentMonoBehaviour);
                                monoState.monoBehaviour = currentMonoBehaviour;
                                EditorUtility.SetDirty(monoState);
                            }
                        );
                    }

                    // Show context menu
                    menu.ShowAsContext();
                }

                // Restore GUI enabled
                GUI.enabled = cachedGuiEnabled;
            }
            else
                EditorGUI.LabelField (position, label.text, "Use MonoBehaviour with GameObject fields.");
        }
        #endregion Unity Callbacks
    }
}