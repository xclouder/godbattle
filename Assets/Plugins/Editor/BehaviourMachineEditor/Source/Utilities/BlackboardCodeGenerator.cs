//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {
    /// <summary> 
    /// Utility class to used generate code.
    /// </summary>
    public class BlackboardCodeGenerator {

        #region Private Methods
        static string GetHeader () {
            var header = new StringBuilder();
            header.AppendLine("//----------------------------------------------");
            header.AppendLine("//            Behaviour Machine");
            header.AppendLine("//     Auto-Generated Code, edit carefully");
            header.AppendLine("//----------------------------------------------");

            return header.ToString();
        }


        static string GetClassName (string path) {
            int indexOfClassName = path.LastIndexOf("/") + 1;
            return path.Substring(indexOfClassName, path.Length - indexOfClassName).Replace(".cs", string.Empty);
        }

        static string GetVariableMember (Variable variable) {
            return "public static readonly int " + variable.name.Replace(" ", "_") + " = " + variable.id.ToString() + ";";
        }
        #endregion Private Methods


        #region Public Methods
        public static MonoScript CreateOrEditCustomBlackboard (string path, InternalBlackboard blackboard) {
            try {
                // opens the file if it allready exists, creates it otherwise
                using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write)) {
                    // Create the string builder
                    var code = new CodeBuilder();
                    // Has Namespace
                    bool hasNamespace = !string.IsNullOrEmpty(blackboard.Namespace);

                    // Add header
                    code.AppendLine(BlackboardCodeGenerator.GetHeader());
                    // Add namespaces
                    code.AppendLine("using UnityEngine;");
                    code.AppendLine("using BehaviourMachine;");
                    code.AppendLine();

                    // Add namespace?
                    if (hasNamespace) {
                        code.AppendLine("namespace " + blackboard.Namespace + " {");
                        // Add more one tab
                        code.tabSize += 1;  
                    }

                    // It is the GlobalBlackboard?
                    if (blackboard.GetType().Name == "GlobalBlackboard") {
                        // Add Componente Menu
                        code.AppendLine("[AddComponentMenu(\"\")]");
                        // Add class
                        code.AppendLine("public class " + BlackboardCodeGenerator.GetClassName(path) + " : InternalGlobalBlackboard {");
                        // Add more one tab
                        code.tabSize += 1;

                        // Add Instance property
                        code.AppendLine("/// <summary>");
                        code.AppendLine("/// The GlobalBlackboard instance.");
                        code.AppendLine("/// </summary>");
                        code.AppendLine("public static new GlobalBlackboard Instance {get {return InternalGlobalBlackboard.Instance as GlobalBlackboard;}}");
                        code.AppendLine();
                    }
                    else {
                        // Add class
                        code.AppendLine("public class " + BlackboardCodeGenerator.GetClassName(path) + " : Blackboard {");
                        // Add more one tab
                        code.tabSize += 1;
                    }

                    // FloatVar
                    FloatVar[] floatVars = blackboard.floatVars;
                    if (floatVars.Length > 0) {
                        code.AppendLine("// FloatVars");
                        for (int i = 0; i < floatVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(floatVars[i]));
                    }

                    // IntVar
                    IntVar[] intVars = blackboard.intVars;
                    if (intVars.Length > 0) {
                        code.AppendLine("// IntVars");
                        for (int i = 0; i < intVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(intVars[i]));
                    }

                    // BoolVar
                    BoolVar[] boolVars = blackboard.boolVars;
                    if (boolVars.Length > 0) {
                        code.AppendLine("// BoolVars");
                        for (int i = 0; i < boolVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(boolVars[i]));
                    }

                    // StringVar
                    StringVar[] stringVars = blackboard.stringVars;
                    if (stringVars.Length > 0) {
                        code.AppendLine("// StringVars");
                        for (int i = 0; i < stringVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(stringVars[i]));
                    }

                    // Vector3Var
                    Vector3Var[] vector3Vars = blackboard.vector3Vars;
                    if (vector3Vars.Length > 0) {
                        code.AppendLine("// Vector3Vars");
                        for (int i = 0; i < vector3Vars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(vector3Vars[i]));
                    }

                    // RectVar
                    RectVar[] rectVars = blackboard.rectVars;
                    if (rectVars.Length > 0) {
                        code.AppendLine("// RectVars");
                        for (int i = 0; i < rectVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(rectVars[i]));
                    }

                    // ColorVar
                    ColorVar[] colorVars = blackboard.colorVars;
                    if (colorVars.Length > 0) {
                        code.AppendLine("// ColorVars");
                        for (int i = 0; i < colorVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(colorVars[i]));
                    }

                    // QuaternionVar
                    QuaternionVar[] quaternionVars = blackboard.quaternionVars;
                    if (quaternionVars.Length > 0) {
                        code.AppendLine("// QuaternionVars");
                        for (int i = 0; i < quaternionVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(quaternionVars[i]));
                    }

                    // GameObjectVar
                    GameObjectVar[] gameObjectVars = blackboard.gameObjectVars;
                    if (gameObjectVars.Length > 0) {
                        code.AppendLine("// GameObjectVars");
                        for (int i = 0; i < gameObjectVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(gameObjectVars[i]));
                    }

                    // TextureVar
                    TextureVar[] textureVars = blackboard.textureVars;
                    if (textureVars.Length > 0) {
                        code.AppendLine("// TextureVars");
                        for (int i = 0; i < textureVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(textureVars[i]));
                    }

                    // MaterialVar
                    MaterialVar[] materialVars = blackboard.materialVars;
                    if (materialVars.Length > 0) {
                        code.AppendLine("// MaterialVars");
                        for (int i = 0; i < materialVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(materialVars[i]));
                    }

                    // ObjectVar
                    ObjectVar[] objectVars = blackboard.objectVars;
                    if (objectVars.Length > 0) {
                        code.AppendLine("// ObjectVars");
                        for (int i = 0; i < objectVars.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(objectVars[i]));
                    }

                    // FsmEvents
                    FsmEvent[] fsmEvents = blackboard.fsmEvents;
                    if (fsmEvents.Length > 0) {
                        code.AppendLine("// FsmEvents");
                        for (int i = 0; i < fsmEvents.Length; i++)
                            code.AppendLine(BlackboardCodeGenerator.GetVariableMember(fsmEvents[i]));
                    }

                    // Remove one tab
                    code.tabSize -= 1;

                    // Close class brackets
                    code.AppendLine("}");

                    // Close namespace brackets
                    if (hasNamespace) {
                        // Remove one tab
                        code.tabSize -= 1;
                        // Close brackets
                        code.AppendLine("}");
                    }

                    // Write data on file
                    using(StreamWriter writer = new StreamWriter(stream)) {
                        writer.Write(code.ToString());
                    }
                }

                AssetDatabase.Refresh();
                return AssetDatabase.LoadAssetAtPath(path, typeof(MonoScript)) as MonoScript;
            }
            catch(System.Exception e) {
                Debug.LogException(e);
                return null;
            }
        }
        #endregion Public Methods

        
        #region Nested Class
        /// <summary>
        /// Helper class to build code.
        /// </summary>
        public class CodeBuilder {

            #region Members
            StringBuilder m_StringBuilder = new StringBuilder();
            string m_CurrentTab = string.Empty;
            int m_TabSize = 0;
            #endregion Members


            #region Properties
            public string currentTab {get {return m_CurrentTab;}}

            public int tabSize {get {return m_TabSize;}
                set {
                    if (value < 0)
                        value = 0;

                    // Update tabSize
                    m_TabSize = value;

                    // Update the current tab
                    var tabBuilder = new StringBuilder();
                    for (int i = 0; i < value; i++) {
                        tabBuilder.Append("    ");
                    }
                    m_CurrentTab = tabBuilder.ToString();
                }
            }
            #endregion Properties


            #region Public Methods
            public void Append (string s) {
                m_StringBuilder.Append(m_CurrentTab);
                m_StringBuilder.Append(s);
            }

            public void AppendLine () {
                m_StringBuilder.AppendLine();
            }

            public void AppendLine (string line) {
                m_StringBuilder.Append(m_CurrentTab);
                m_StringBuilder.AppendLine(line);
            }

            public override string ToString () {
                return m_StringBuilder.ToString();
            }
            #endregion Public Methods
        }
        #endregion Nested Class
    }
}