//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------


using UnityEngine;
using UnityEditor;
using System.Collections;
using BehaviourMachine;
using BehaviourMachineEditor;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Utility class to draw blackboard variables.
    /// </summary> 
    public class BlackboardGUIUtility {

        
        #region Constants
        const float c_OneLineHeight = 21f;
        const float c_TwoLinesHeight = 39f;
        const float c_MinusButtonWidth = 20f;
        const float c_RightPadding = -1f;
        const float c_Space = 4f;
        const float c_SmallNameWidth = 80f;
        const float c_NameWidth = 120f;
        const float c_LargeNameWidth = 140f;
        #endregion Constants

        
        #region Static Members
        static Variable s_VariableToRemove = null;
        #endregion Static Members

        
        #region Style
        static BlackboardGUIUtility.Styles s_Styles;

        /// <summary> 
        /// A class to store GUIStyles that are used by a BlackboardGUIUtility.
        /// </summary>
        class Styles {
            public GUIContent iconToolbarMinus = new GUIContent(EditorGUIUtility.FindTexture("Toolbar Minus"), "Remove Variable");
            public readonly GUIStyle preButton = "RL FooterButton";
            public readonly GUIStyle invisbleButton = "InvisibleButton";
        }
        #endregion Style

        
        #region Set Object Type
        /// <summary> 
        /// Context menu callback to set an ObjectVar type.
        /// </summary>
        public static void SetObjectType (object userData) {
            var setObjectVarType = userData as SetObjectVarType;
            if (setObjectVarType != null)
                setObjectVarType.Set();
        }

        /// <summary> 
        /// Stores the data to set an ObjectVar type.
        /// </summary>
        public class SetObjectVarType {
            public readonly ObjectVar objectVar;
            public readonly System.Type objectType;

            /// <summary> 
            /// The class constructor.
            /// <param name= "objectVar">The target ObjectVar.</param>
            /// <param name= "objectType">The new ObjectVar type.</param>
            /// </summary>
            public SetObjectVarType (ObjectVar objectVar, System.Type objectType) {
                this.objectVar = objectVar;
                this.objectType = objectType;
            }

            /// <summary> 
            /// Updates the objectVar type.
            /// </summary>
            public void Set () {
                var blackboard = objectVar.blackboard;

                if (blackboard != null) {
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(blackboard, "Set Object Type");
                    #else
                    Undo.RecordObject(blackboard, "Set Object Type");
                    #endif
                }

                objectVar.ObjectType = objectType;
                objectVar.OnValidate();

                if (blackboard != null)
                    EditorUtility.SetDirty(blackboard);
            }
        }
        #endregion Set Object Type

        
        #region Context Menu
        /// <summary> 
        /// Register undo before add a new variable.
        /// <param name="userData">The blackboard to register undo.</param> 
        /// </summary>
        static void RegisterVariableUndo (InternalBlackboard blackboard) {
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            Undo.RegisterUndo(blackboard, "Add Variable");
            #else
            Undo.RecordObject(blackboard, "Add Variable");
            #endif
        }
        #endregion Context Menu

        
        #region Public Methods
        /// <summary> 
        /// Displays a context menu to add variables to a blackboard.
        /// <param name="blackboard">The target blackboard to add a new variable.</param> 
        /// </summary>
        public static void OnAddContextMenu (InternalBlackboard blackboard) {
            GUIUtility.hotControl = 0;
            GUIUtility.keyboardControl = 0;

            var menu = new GenericMenu();

            menu.AddItem(new GUIContent("Float"), false, delegate () {BlackboardUtility.AddFloatVar(blackboard);});
            menu.AddItem(new GUIContent("Int"), false, delegate () {BlackboardUtility.AddIntVar(blackboard);});
            menu.AddItem(new GUIContent("Bool"), false, delegate () {BlackboardUtility.AddBoolVar(blackboard);});
            menu.AddItem(new GUIContent("String"), false, delegate () {BlackboardUtility.AddStringVar(blackboard);});
            menu.AddItem(new GUIContent("Vector3"), false, delegate () {BlackboardUtility.AddVector3Var(blackboard);});
            menu.AddItem(new GUIContent("Rect"), false, delegate () {BlackboardUtility.AddRectVar(blackboard);});
            menu.AddItem(new GUIContent("Color"), false, delegate () {BlackboardUtility.AddColorVar(blackboard);});
            menu.AddItem(new GUIContent("Quaternion"), false, delegate () {BlackboardUtility.AddQuaternionVar(blackboard);});
            menu.AddItem(new GUIContent("GameObject"), false, delegate () {BlackboardUtility.AddGameObjectVar(blackboard);});
            menu.AddItem(new GUIContent("Texture"), false, delegate () {BlackboardUtility.AddTextureVar(blackboard);});
            menu.AddItem(new GUIContent("Material"), false, delegate () {BlackboardUtility.AddMaterialVar(blackboard);});
            menu.AddItem(new GUIContent("Object"), false, delegate () {BlackboardUtility.AddObjectVar(blackboard);});
            menu.AddItem(new GUIContent("DynamicList"), false, delegate () {BlackboardUtility.AddDynamicList(blackboard);});
            menu.AddItem(new GUIContent("FsmEvent"), false, delegate () {BlackboardUtility.AddFsmEvent(blackboard);});
            
            if (!(blackboard is InternalGlobalBlackboard)) {
                menu.AddSeparator("");
                menu.AddItem(new GUIContent("Global Blackboard"), false, delegate () {EditorApplication.ExecuteMenuItem("Tools/BehaviourMachine/Global Blackboard");});
            }

            menu.ShowAsContext();
        }

        /// <summary> 
        /// Returns the total height to draw the blackboard variables.
        /// <param name="blackboard">The target blackboard to calculate the height.</param> 
        /// <returns>The required height to draw all variables in the blackboard.</returns> 
        /// </summary>
        public static float GetHeight (InternalBlackboard blackboard) {
            if (blackboard == null)
                return 0f;

            float height =    blackboard.GetFloatsSize() * c_OneLineHeight 
                            + blackboard.GetIntsSize() * c_OneLineHeight
                            + blackboard.GetBoolsSize() * c_OneLineHeight
                            + blackboard.GetStringsSize() * c_OneLineHeight
                            + blackboard.GetVector3sSize() * c_OneLineHeight
                            + blackboard.GetRectsSize() * c_TwoLinesHeight
                            + blackboard.GetColorsSize() * c_OneLineHeight
                            + blackboard.GetQuaternionsSize() * c_OneLineHeight
                            + blackboard.GetGameObjectsSize() * c_OneLineHeight
                            + blackboard.GetTexturesSize() * c_OneLineHeight
                            + blackboard.GetMaterialsSize() * c_OneLineHeight
                            + blackboard.GetObjectsSize() * c_TwoLinesHeight
                            + blackboard.GetDynamicListsSize() * c_OneLineHeight
                            + blackboard.GetFsmEventsSize() * c_OneLineHeight;
            return height;
        }

        /// <summary> 
        /// Draw the variables of a blackboard in the GUI.
        /// <param name="position">The position in the GUI to draw the variables.</param>
        /// <param name="blackboard">The blackboard to be drawn.</param>
        /// </summary>
        public static void DrawVariables (Rect position, InternalBlackboard blackboard) {
            if (blackboard == null)
                return;

            // Create styles
            if (s_Styles == null)
                s_Styles = new BlackboardGUIUtility.Styles();

            // Update variable to remove
            s_VariableToRemove = null;

            // Is asset?
            bool isAsset = AssetDatabase.Contains(blackboard.gameObject);

            // Save GUI.changed
            EditorGUI.BeginChangeCheck();

            // FloatVar
            position.height = c_OneLineHeight;
            foreach (var floatVar in blackboard.floatVars) {
                DrawFloatVar(position, floatVar);
                position.y += position.height;
            }
            // IntVar
            foreach (var intVar in blackboard.intVars) {
                DrawIntVar(position, intVar);
                position.y += position.height;
            }
            // BoolVar
            foreach (var boolVar in blackboard.boolVars) {
                DrawBoolVar(position, boolVar);
                position.y += position.height;
            }
            // StringVar
            foreach (var stringVar in blackboard.stringVars) {
                DrawStringVar(position, stringVar);
                position.y += position.height;
            }
            // Vector3Var
            foreach (var vector3Var in blackboard.vector3Vars) {
                DrawVector3Var(position, vector3Var);
                position.y += position.height;
            }
            // positionVar
            position.height = c_TwoLinesHeight;
            foreach (var rectVar in blackboard.rectVars) {
                DrawRectVar(position, rectVar);
                position.y += position.height;
            }
            // ColorVar
            position.height = c_OneLineHeight;
            foreach (var colorVar in blackboard.colorVars) {
                DrawColorVar(position, colorVar);
                position.y += position.height;
            }
            // QuaternionVar
            foreach (var quaternionVar in blackboard.quaternionVars) {
                DrawQuaternionVar(position, quaternionVar);
                position.y += position.height;
            }
            // GameObjectVar
            foreach (var gameObjectVar in blackboard.gameObjectVars) {
                DrawGameObjectVar(position, gameObjectVar, isAsset);
                position.y += position.height;
            }
            // TextureVar
            foreach (var textureVar in blackboard.textureVars) {
                DrawTextureVar(position, textureVar);
                position.y += position.height;
            }
            // MaterialVar
            foreach (var materialVar in blackboard.materialVars) {
                DrawMaterialVar(position, materialVar);
                position.y += position.height;
            }
            // ObjectVar
            position.height = c_TwoLinesHeight;
            foreach (var objectVar in blackboard.objectVars) {
                DrawObjectVar(position, objectVar, isAsset);
                position.y += position.height;
            }
            // DynamicList
            position.height = c_OneLineHeight;
            foreach (var dynamicList in blackboard.dynamicLists) {
                DrawDynamicList(position, dynamicList);
                position.y += position.height;
            }
            // FsmEvent
            foreach (var fsmEvent in blackboard.fsmEvents) {
                DrawFsmEvent(position, fsmEvent);
                position.y += position.height;
            }

            // Restore old GUI.changed
            EditorGUI.EndChangeCheck();

            // Delete variable?
            if (s_VariableToRemove != null) {
                GUIUtility.hotControl = 0;
                GUIUtility.keyboardControl = 0;

                BlackboardUtility.RemoveVariable(s_VariableToRemove);
                s_VariableToRemove = null;
            }
        }
        #endregion Public Methods


        #region Variable Draw Methods
        /// <summary> 
        /// Draw the variables name.
        /// <param name="rect">The position to draw the variable name.</param>
        /// <param name="variable">The variable to be drawn.</param>
        /// </summary>
        static void DrawName (Rect rect, Variable variable) {
            EditorGUI.BeginChangeCheck();
            var newName = EditorGUI.TextField (rect, variable.name);
            if (EditorGUI.EndChangeCheck() && newName != variable.name) {
                // Register undo
                if (variable.blackboard != null) {
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(variable.blackboard, "Variable Name");
                    #else
                    Undo.RecordObject(variable.blackboard, "Variable Name");
                    #endif
                }

                // Update variable name
                variable.name = newName;
                // Set blackboard dirty flag
                if (variable.blackboard != null) EditorUtility.SetDirty(variable.blackboard);
            }
        }

        /// <summary> 
        /// Draw a float variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="floatVar">The float variable to be drawn.</param>
        /// </summary>
        static void DrawFloatVar (Rect rect, FloatVar floatVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_LargeNameWidth, rect.height), floatVar);

            rect.xMin += c_LargeNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.FloatField(rect, GUIContent.none, floatVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != floatVar.Value) {
                // Register undo
                if (floatVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(floatVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(floatVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                floatVar.Value = newValue;
                // Set blackboard dirty flag
                if (floatVar.blackboard != null) EditorUtility.SetDirty(floatVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = floatVar;
        }

        /// <summary> 
        /// Draw an int variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="intVar">The int variable to be drawn.</param>
        /// </summary>
        static void DrawIntVar (Rect rect, IntVar intVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_LargeNameWidth, rect.height), intVar);

            rect.xMin += c_LargeNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.IntField(rect, GUIContent.none, intVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != intVar.Value) {
                // Register undo
                if (intVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(intVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(intVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                intVar.Value = newValue;
                // Set blackboard dirty flag
                if (intVar.blackboard != null) EditorUtility.SetDirty(intVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = intVar;
        }

        /// <summary> 
        /// Draw a bool variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="boolVar">The bool variable to be drawn.</param>
        /// </summary>
        static void DrawBoolVar (Rect rect, BoolVar boolVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_LargeNameWidth, rect.height), boolVar);

            rect.xMin += c_LargeNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.Toggle (rect, GUIContent.none, boolVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != boolVar.Value) {
                // Register undo
                if (boolVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(boolVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(boolVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                boolVar.Value = newValue;
                // Set blackboard dirty flag
                if (boolVar.blackboard != null) EditorUtility.SetDirty(boolVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = boolVar;
        }

        /// <summary> 
        /// Draw a string variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="stringVar">The string variable to be drawn.</param>
        /// </summary>
        static void DrawStringVar (Rect rect, StringVar stringVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_NameWidth, rect.height), stringVar);

            rect.xMin += c_NameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.TextField (rect, GUIContent.none, stringVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != stringVar.Value) {
                // Register undo
                if (stringVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(stringVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(stringVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                stringVar.Value = newValue;
                // Set blackboard dirty flag
                if (stringVar.blackboard != null) EditorUtility.SetDirty(stringVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = stringVar;
        }

        /// <summary> 
        /// Draw a vector3 variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="vector3Var">The vector3 variable to be drawn.</param>
        /// </summary>
        static void DrawVector3Var (Rect rect, Vector3Var vector3Var) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), vector3Var);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y -= 19f;
            #endif
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.Vector3Field (rect, string.Empty, vector3Var.Value);
            if (EditorGUI.EndChangeCheck() && newValue != vector3Var.Value) {
                // Register undo
                if (vector3Var.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(vector3Var.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(vector3Var.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                vector3Var.Value = newValue;
                // Set blackboard dirty flag
                if (vector3Var.blackboard != null) EditorUtility.SetDirty(vector3Var.blackboard);
            }

            rect.x += rect.width + 2f;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y += 19f;
            #endif
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = vector3Var;
        }

        /// <summary> 
        /// Draw a rect variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="rectVar">The rect variable to be drawn.</param>
        /// </summary>
        static void DrawRectVar (Rect rect, RectVar rectVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height - (c_TwoLinesHeight - c_OneLineHeight)), rectVar);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y -= 19f;
            #endif
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.RectField (rect, GUIContent.none, rectVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != rectVar.Value) {
                // Register undo
                if (rectVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(rectVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(rectVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                rectVar.Value = newValue;
                // Set blackboard dirty flag
                if (rectVar.blackboard != null) EditorUtility.SetDirty(rectVar.blackboard);
            }

            rect.x += rect.width + 2f;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y += 19f;
            #endif
            rect.height = c_OneLineHeight - 3f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = rectVar;
        }

        /// <summary> 
        /// Draw a color variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="colorVar">The color variable to be drawn.</param>
        /// </summary>
        static void DrawColorVar (Rect rect, ColorVar colorVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            DrawName(new Rect (rect.x, rect.y, c_NameWidth, rect.height), colorVar);

            rect.xMin += c_NameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.ColorField (rect, GUIContent.none, colorVar.Value);
            if (EditorGUI.EndChangeCheck() && newValue != colorVar.Value) {
                // Register undo
                if (colorVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(colorVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(colorVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                colorVar.Value = newValue;
                // Set blackboard dirty flag
                if (colorVar.blackboard != null) EditorUtility.SetDirty(colorVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = colorVar;
        }

        /// <summary> 
        /// Draw a quaternion variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="quaternionVar">The quaternion variable to be drawn.</param>
        /// </summary>
        static void DrawQuaternionVar (Rect rect, QuaternionVar quaternionVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), quaternionVar);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y -= 19f;
            #else
            rect.y -= 16f;
            #endif

            var q = quaternionVar.Value;
            var v4 = new Vector4(q[0], q[1], q[2], q[3]);
            EditorGUI.BeginChangeCheck();
            var newV4 = EditorGUI.Vector4Field (rect, string.Empty, v4);
            if (EditorGUI.EndChangeCheck() && v4 != newV4) {
                // Register undo
                if (quaternionVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(quaternionVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(quaternionVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                quaternionVar.Value = new Quaternion(newV4[0], newV4[1], newV4[2], newV4[3]);
                // Set blackboard dirty flag
                if (quaternionVar.blackboard != null) EditorUtility.SetDirty(quaternionVar.blackboard);
            }

            rect.x += rect.width + 2f;
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            rect.y += 19f;
            #else
            rect.y += 16f;
            #endif

            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = quaternionVar;
        }

        /// <summary> 
        /// Draw a game object variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="gameObjectVar">The game object variable to be drawn.</param>
        /// <param name="isAsset">The variable blackboard is an asset?</param>
        /// </summary>
        static void DrawGameObjectVar (Rect rect, GameObjectVar gameObjectVar, bool isAsset) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), gameObjectVar);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.ObjectField (rect, GUIContent.none, gameObjectVar.Value, typeof(GameObject), !isAsset) as GameObject;
            if (EditorGUI.EndChangeCheck() && newValue != gameObjectVar.Value) {
                // Register undo
                if (gameObjectVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(gameObjectVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(gameObjectVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                gameObjectVar.Value = newValue;
                // Set blackboard dirty flag
                if (gameObjectVar.blackboard != null) EditorUtility.SetDirty(gameObjectVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = gameObjectVar;
        }

        /// <summary> 
        /// Draw a texture variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="textureVar">The texture variable to be drawn.</param>
        /// </summary>
        static void DrawTextureVar (Rect rect, TextureVar textureVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), textureVar);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.ObjectField (rect, GUIContent.none, textureVar.Value, typeof(Texture), true) as Texture;
            if (EditorGUI.EndChangeCheck() && newValue != textureVar.Value) {
                // Register undo
                if (textureVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(textureVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(textureVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                textureVar.Value = newValue;
                // Set blackboard dirty flag
                if (textureVar.blackboard != null) EditorUtility.SetDirty(textureVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = textureVar;
        }

        /// <summary> 
        /// Draw a material variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="materialVar">The material variable to be drawn.</param>
        /// </summary>
        static void DrawMaterialVar (Rect rect, MaterialVar materialVar) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), materialVar);

            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.ObjectField (rect, GUIContent.none, materialVar.Value, typeof(Material), true) as Material;
            if (EditorGUI.EndChangeCheck() && newValue != materialVar.Value) {
                // Register undo
                if (materialVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(materialVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(materialVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                materialVar.Value = newValue;
                // Set blackboard dirty flag
                if (materialVar.blackboard != null) EditorUtility.SetDirty(materialVar.blackboard);
            }

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = materialVar;
        }

        /// <summary> 
        /// Draw an object variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="objectVar">The object variable to be drawn.</param>
        /// <param name="isAsset">The variable blackboard is an asset?</param>
        /// </summary>
        static void DrawObjectVar (Rect rect, ObjectVar objectVar, bool isAsset) {
            // Name
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;
            rect.height -= c_TwoLinesHeight - c_OneLineHeight;
            DrawName(new Rect (rect.x, rect.y, c_SmallNameWidth, rect.height), objectVar);

            // Value
            rect.xMin += c_SmallNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            var objectType = objectVar.ObjectType;
            EditorGUI.BeginChangeCheck();
            var newValue = EditorGUI.ObjectField (rect, GUIContent.none, objectVar.Value, objectType, !isAsset);
            if (EditorGUI.EndChangeCheck() && newValue != objectVar.Value) {
                // Register undo
                if (objectVar.blackboard != null) { 
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(objectVar.blackboard, "Variable Value");
                    #else
                    Undo.RecordObject(objectVar.blackboard, "Variable Value");
                    #endif
                }

                // Update variable value
                objectVar.Value = newValue;
                // Set blackboard dirty flag
                if (objectVar.blackboard != null) EditorUtility.SetDirty(objectVar.blackboard);
            }

            // Object Type
            rect.y += rect.height + 3f;
            var objectTypeAsString = objectType.ToString();
            if (GUI.Button(rect, objectTypeAsString, EditorStyles.popup)) {
                var menu = new GenericMenu();
                // Add None
                menu.AddItem(new GUIContent("None"), string.IsNullOrEmpty(objectTypeAsString), SetObjectType, new SetObjectVarType(objectVar, typeof(UnityEngine.Object)));

                // Add to menu all types that inherites from UnityEngine.Object
                var types = TypeUtility.GetDerivedTypes(typeof(UnityEngine.Object));
                for (int y = 0; y < types.Length; y++) { 
                    var typeAsString = types[y].ToString();
                    menu.AddItem(new GUIContent(typeAsString.Replace('.', '/')), objectTypeAsString == typeAsString, SetObjectType, new SetObjectVarType(objectVar, types[y]));
                }

                menu.ShowAsContext();
            }

            // Minus button
            rect.x += rect.width + 2f;
            rect.y -= rect.height + 3f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = objectVar;
        }

        /// <summary> 
        /// Draw a dynamic list.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="dynamicList">The dynamic list to be drawn.</param>
        /// </summary>
        static void DrawDynamicList (Rect rect, DynamicList dynamicList) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            DrawName(new Rect (rect.x, rect.y, c_LargeNameWidth, rect.height), dynamicList);

            rect.xMin += c_LargeNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.LabelField(rect, "[" + dynamicList.Count.ToString() + "]");

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = dynamicList;
        }

        /// <summary> 
        /// Draw a float variable.
        /// <param name="rect">The position to draw the variable.</param>
        /// <param name="fsmEvent">The float variable to be drawn.</param>
        /// </summary>
        static void DrawFsmEvent (Rect rect, FsmEvent fsmEvent) {
            rect.yMin += 3f;
            rect.yMax -= 2f;
            rect.xMin += 6f;
            rect.xMax -= 6f;

            bool oldGUIEnabled = GUI.enabled;
            GUI.enabled = !fsmEvent.isSystem;
            DrawName(new Rect (rect.x, rect.y, c_LargeNameWidth, rect.height), fsmEvent);
            GUI.enabled = oldGUIEnabled;

            rect.xMin += c_LargeNameWidth + c_Space;
            rect.xMax -= c_MinusButtonWidth + c_RightPadding;
            EditorGUI.SelectableLabel(rect, fsmEvent.id.ToString());

            rect.x += rect.width + 2f;
            rect.width = c_MinusButtonWidth;
            rect.yMin -= 2f;
            rect.yMax += 2f;
            oldGUIEnabled = GUI.enabled;
            GUI.enabled = !fsmEvent.isSystem;
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.invisbleButton))
                s_VariableToRemove = fsmEvent;
            GUI.enabled = oldGUIEnabled;
        }
        #endregion Variable Draw Methods
    }
}
