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
    /// Custom drawer that restricts a float or an int in a range value.
    /// </summary>
    [CustomNodePropertyDrawer (typeof(RangeAttribute))]
    public class NodeRangeDrawer : NodePropertyDrawer {
        /// <summary>
        /// Draw the slider.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // Integer
            if (property.propertyType == NodePropertyType.Integer) {
                var range = base.attribute as RangeAttribute;
                property.value = EditorGUILayout.IntSlider (guiContent, (int)property.value, (int)range.min, (int)range.max);
            }
            // Float
            else if (property.propertyType == NodePropertyType.Float) {
                var range = base.attribute as RangeAttribute;
                property.value = EditorGUILayout.Slider (guiContent, (float)property.value, range.min, range.max);
            }
            else
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use range with float or int."));
        }
    }
}