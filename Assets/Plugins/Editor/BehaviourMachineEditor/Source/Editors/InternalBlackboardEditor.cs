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
    /// Blackboard custom inspector.
    /// <seealso cref="BehaviourMachine.InternalBlackboard" />
    /// </summary>
    [CustomEditor(typeof(InternalBlackboard), true)]
    public class InternalBlackboardEditor : Editor {

        #region Members
        InternalBlackboard m_Blackboard;
        VariableEditor m_VariableEditor;
        SerializedObject m_SerialObj;
        SerializedProperty m_ScriptProperty;
        #endregion Members

        #region Unity Callbacks
        /// <summary> 
        /// Unity callback called when the object is loaded.
        /// </summary>
        void OnEnable () {
            if (target != null) {
                m_SerialObj = new SerializedObject(target);
                m_ScriptProperty = m_SerialObj.FindProperty("m_Script");
                m_Blackboard = target as InternalBlackboard;
                m_VariableEditor = new VariableEditor(m_Blackboard);
            }
        }

        /// <summary> 
        /// A Unity callback called when the object goes out of scope.
        /// </summary>
        void Disable () {
            m_VariableEditor = null;
        }

        /// <summary> 
        /// Unity callback to draw a custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            // Workaround to update gui controls
            if (Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed") {
                GUIUtility.hotControl = 0;
                GUIUtility.keyboardControl = 0;
            }

            // Draw Default Inspector
            DrawDefaultInspector();

            // Draw Variables
            EditorGUILayout.Space();
            if (!m_VariableEditor.IsValid()) {
                // UnityEditor does not immediately updates the "target" property data if you change the script reference in the inspector.
                // Below is a workaround that uses a "null" target to get the actual Blackboard:
                m_VariableEditor = new VariableEditor(m_Blackboard.gameObject.GetComponent<InternalBlackboard>());
            }
            m_VariableEditor.OnGUI();
            EditorGUILayout.Space();

            // Draw Script Button
            if (target != null) {
                var script = m_ScriptProperty.objectReferenceValue as MonoScript;
                System.Type type = script != null ? script.GetClass() : null;
                if (type != null) {
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (type.FullName == "BehaviourMachine.Blackboard") {
                        if (GUILayout.Button(new GUIContent("Generate Script", "It will generate a C# script with properties containing the variables' id in this Blackboard. Very usefull to get variables in the Blackboard from a custom state"), GUILayout.MaxWidth(200f))) {
                            var scriptPath = EditorUtility.SaveFilePanelInProject("Save Custom Blackboard Script", m_Blackboard.name.Replace(" ", "_") + "Blackboard.cs", "cs", "Please enter the class name of the custom Blackboard");
                            
                            if (!string.IsNullOrEmpty(scriptPath)) {
                                MonoScript newScript = BlackboardCodeGenerator.CreateOrEditCustomBlackboard(scriptPath, m_Blackboard);
                                // Validate the newScript
                                if (newScript != null) {
                                    m_ScriptProperty.objectReferenceValue = newScript;
                                    m_SerialObj.ApplyModifiedProperties();

                                    // Recreate members
                                    this.OnEnable();
                                    // Ping the script in the Project
                                    EditorGUIUtility.PingObject(newScript.GetInstanceID());
                                }
                            }
                        }
                    }
                    else if (GUILayout.Button(new GUIContent("Update Script", "It will update the file " + script.name + ".cs with the variables in this Blackboard, use this when you have added/removed/renamed a variable in this Blackboard."), GUILayout.MaxWidth(200f))) {
                        var scriptPath = AssetDatabase.GetAssetPath(script.GetInstanceID());
                        BlackboardCodeGenerator.CreateOrEditCustomBlackboard(scriptPath, m_Blackboard);
                    }
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                }
            }
            else {
                EditorGUILayout.HelpBox("The component script has changed. Enter and exit in play mode to reaload this editor.", MessageType.Warning);
            }
        }
        #endregion Unity Callbacks
    }
}