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
    /// Draws a text area for a string or StringVar property.
    /// <seealso cref="BehaviourMachine.TextAreaAttribute" />
    /// </summary>
    [CustomNodePropertyDrawer (typeof(NodeTextAreaAttribute))]
    public class NodeTextAreaDrawer : NodePropertyDrawer {

        #region Styles
        static NodeTextAreaDrawer.Styles s_Styles;

        /// <summary> 
        /// Store GUIStyles that are used by a NodeTextAreaAttribute.
        /// </summary>
        class Styles {
            public readonly GUIStyle textArea = new GUIStyle (EditorStyles.textField);

            public Styles () {
                textArea.wordWrap = true;
            }
        }
        #endregion Styles

        /// <summary>
        /// Draw the TextArea.
        /// </summary>
        public override void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent) {
            // The text to display
            string text;

            // string
            if (property.propertyType == NodePropertyType.String) {
                // Get the text
                text = property.value as string ?? string.Empty;
            }
            // StringVar
            else if (property.propertyType == NodePropertyType.Variable && property.type == typeof(StringVar)) {
                // Get the text
                var stringVar = property.value as StringVar;
                if (stringVar != null)
                    text = stringVar.Value as string ?? string.Empty;
                else
                    text = string.Empty;
            }
            // Not supported
            else {
                EditorGUILayout.LabelField(guiContent, new GUIContent("Use TextAreaAttribute with string or StringVar."));
                return;
            }

            // Create style?
            if (s_Styles == null)
                s_Styles = new NodeTextAreaDrawer.Styles();

            // Get the text area
            var textAreaAttr = (NodeTextAreaAttribute) attribute;

            // Store the current content color
            Color contentColor = GUI.contentColor;

            // The text is empty?
            if (string.IsNullOrEmpty(text)) {
                text = textAreaAttr.hint;
                Color textColor = EditorStyles.label.normal.textColor;
                textColor.a = .5f;
                GUI.contentColor = textColor;
            }

            // Draw the text area.
            EditorGUI.BeginChangeCheck ();


            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            string value = EditorGUILayout.TextArea (text, s_Styles.textArea, GUILayout.Height(16f * textAreaAttr.lines));
            #else
            string value = EditorGUILayout.TextArea (text, s_Styles.textArea, GUILayout.Height(EditorGUIUtility.singleLineHeight * textAreaAttr.lines));
            #endif
            

            // Check for changes
            if (EditorGUI.EndChangeCheck ()) {
                if (property.propertyType == NodePropertyType.String)
                    property.value = value;
                else {
                    // Get the text
                    var stringVar = property.value as StringVar;
                    if (stringVar != null) {
                        stringVar.Value = value;
                        property.ValueChanged();
                    }
                }
            }

            // Restore content color
            GUI.contentColor = contentColor;
        }
    }
}