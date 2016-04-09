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
    /// Draws a text area for a string property.
    /// <seealso cref="BehaviourMachine.TextAreaAttribute" />
    /// </summary>
    [CustomPropertyDrawer (typeof(BehaviourMachine.TextAreaAttribute))]
    public class TextAreaDrawer : PropertyDrawer {

        #region Styles
        static TextAreaDrawer.Styles s_Styles;

        /// <summary> 
        /// Store GUIStyles that are used by a TextAreaDrawer.
        /// </summary>
        class Styles {
            public readonly GUIStyle textArea = new GUIStyle (EditorStyles.textField);

            public Styles () {
                textArea.wordWrap = true;
            }
        }
        #endregion Styles

        public BehaviourMachine.TextAreaAttribute textArea {get {return (BehaviourMachine.TextAreaAttribute)this.attribute;}}

        #region Unity Callbacks
        /// <summary> 
        /// Returns the gui control height.
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// <returns>The gui control height</returns>
        /// </summary>
        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            return 16f * textArea.lines;
            #else
            return EditorGUIUtility.singleLineHeight * textArea.lines;
            #endif
        }

        /// <summary> 
        /// Draws the gui control.
        /// <param name="position">Rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The SerializedProperty to make the custom GUI for.</param>
        /// <param name="label">The label of this property.</param>
        /// </summary>
    	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

            // string?
            if (property.propertyType == SerializedPropertyType.String) {
                // Create style?
                if (s_Styles == null)
                    s_Styles = new TextAreaDrawer.Styles();

                // Store the current content color
                Color contentColor = GUI.contentColor;

                // Get the text
                string text = property.stringValue;

                // The text is empty?
                if (string.IsNullOrEmpty(text)) {
                    text = textArea.hint;
                    Color textColor = EditorStyles.label.normal.textColor;
                    textColor.a = .5f;
                    GUI.contentColor = textColor;
                }

                // Draw the text area.
                EditorGUI.BeginChangeCheck ();

                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                position.width -= 4f;
                position.height = this.GetPropertyHeight(property, label);
                #endif

                string value = EditorGUI.TextArea (position, text, s_Styles.textArea);

                // Check for changes
                if (EditorGUI.EndChangeCheck ())
                    property.stringValue = value;

                // Restore content color
                GUI.contentColor = contentColor;

            }
            else
                EditorGUI.LabelField (position, label.text, "Use BehaviourMachine.TextAreaAttribute with string.");
        }
        #endregion Unity Callbacks
    }
}