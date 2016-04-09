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
    /// Draws a custom gui control for the InternalStateBehaviour.m_Parent field.
    /// <seealso cref="BehaviourMachine.ParentPropertyAttribute" />
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    [CustomPropertyDrawer (typeof(ParentPropertyAttribute))]
    public class ParentPropertyDrawer : StatePropertyDrawer {

        #region Unity Callbacks
        /// <summary> 
        /// Draws the gui control.
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// </summary>
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            // Get state
            var targetState = property.serializedObject.targetObject as InternalStateBehaviour;

            // It's a valid state?
            if (targetState != null) {
                // Draw prefix label
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Rect controlPosition = EditorGUI.PrefixLabel(position, EditorGUIUtility.GetControlID(FocusType.Passive, position), label);
                #else
                Rect controlPosition = EditorGUI.PrefixLabel(position, label);
                #endif

                // Get the parent
                ParentBehaviour parent = targetState.parent;

                // Draw button as popup
                if (GUI.Button(controlPosition, parent != null ? parent.stateName : "Null", EditorStyles.popup)) {
                    
                    // Get valid parents for the state
                    List<ParentBehaviour> validParents = new List<ParentBehaviour>();
                    var targetParent = targetState as ParentBehaviour;
                    validParents.AddRange(targetState.GetComponents<ParentBehaviour>());

                    // The target state is a parent behaviour?
                    if (targetParent != null) {
                        for (int i = validParents.Count - 1; i >= 0; i--) {
                            // it's the targetParent?
                            if (validParents[i] == targetParent)
                                validParents.RemoveAt(i);
                            // The parent is a child of the target parent?
                            else if (validParents[i].IsAncestor(targetParent))
                                validParents.RemoveAt(i);
                        }
                    }

                    // Create menu
                    var menu = new GenericMenu();

                    // Add null item
                    menu.AddItem(new GUIContent("Null"), parent == null, this.OnSetNewParent, new SetParent(targetState, null));

                    // Add menu items
                    var parentNames = new List<string>();
                    for (int i = 0; i < validParents.Count; i++) {
                        string parentName = StringHelper.GetUniqueNameInList(parentNames, validParents[i].fullStateName);
                        parentNames.Add(parentName);
                        menu.AddItem(new GUIContent(parentName), parent == validParents[i], this.OnSetNewParent, new SetParent(targetState, validParents[i]));
                    }

                    // Show context menu
                    menu.ShowAsContext();
                }
            }
        }
        #endregion Unity Callbacks

        #region Set Parent
        void OnSetNewParent (object userData) {
            var setParent = userData as SetParent;
            if (setParent != null)
                setParent.DoSetNewParent();
        }

        class SetParent {
            public readonly InternalStateBehaviour state;
            public readonly ParentBehaviour newParent;

            public SetParent (InternalStateBehaviour state, ParentBehaviour newParent) {
                this.state = state;
                this.newParent = newParent;
            }

            public void DoSetNewParent () {
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterSceneUndo("Inspector");
                #else
                Undo.RecordObject(state, "Inspector");

                // Register undo in siblings states
                if (state.fsm != null) {
                    List<InternalStateBehaviour> states = state.fsm.states;
                    for (int i = 0; i < states.Count; i++)    
                        UnityEditor.Undo.RecordObject(states[i], "Inspector");
                }
                #endif

                state.parent = newParent;
                EditorUtility.SetDirty(state);
            }
        }
        #endregion Set Parent
    }
}