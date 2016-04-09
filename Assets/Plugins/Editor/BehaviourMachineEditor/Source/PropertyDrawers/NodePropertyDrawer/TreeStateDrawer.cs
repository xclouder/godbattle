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
    /// Custom property drawer for trees' states.
    /// <seealso cref="BehaviourMachine.TreeStateAttribute" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(TreeStateAttribute))]
    public class TreeStateDrawer : NodePropertyDrawer {
        /// <summary>
        /// Draw the state pop-up.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // InternalStateBehaviour
            if (property.propertyType == NodePropertyType.UnityObject && property.type == typeof(InternalStateBehaviour)) {
                var rect = GUILayoutUtility.GetRect(GUIContent.none, EditorStyles.popup);
                var id = GUIUtility.GetControlID(FocusType.Passive);
                var popupRect = EditorGUI.PrefixLabel(rect, id, guiContent);
                var state = property.value as InternalStateBehaviour;

                // Set the pop-up color
                var oldGUIColor = GUI.color;
                if (state == null)
                    GUI.color = Color.red;

                if (GUI.Button(popupRect, state != null ? state.stateName : "Null", EditorStyles.popup)) {
                    // Get states
                    var states = node.tree.states;

                    // Create the pop-up menu
                    var menu = new GenericMenu();

                    // Add null
                    menu.AddItem(new GUIContent("Null"), state == null, delegate () {property.value = (InternalStateBehaviour)null;});

                    // Add states
                    for (int i = 0; i < states.Count; i++) {
                        InternalStateBehaviour currentState = states[i];
                        //setField = field != null ? new SetField(this.target, target, states[i], field, m_Tree) : new SetField(this.target, arrayField, index, states[i], m_Tree);
                        menu.AddItem(new GUIContent(states[i].stateName), state == states[i], delegate () {property.value = currentState;});
                    }

                    // Show menu
                    menu.ShowAsContext();
                }

                // Restore GUI.color
                GUI.color = oldGUIColor;
            }
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use TreeState with InternalStateBehaviour."));
        }
    }
}