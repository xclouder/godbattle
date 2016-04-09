//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// An auxiliary class that has some functions to draw gui controls.
    /// </summary>
    public class GUILayoutHelper {

        #region Styles
        static GUILayoutHelper.Styles s_Styles;

        /// <summary>
        /// A class that holds GUIStyles used by the GUILayoutHelper.
        /// </summary>
        class Styles {
            public readonly GUIStyle radioButton;
            public readonly GUIStyle popup;
            public readonly Color popupTextColor;
            public readonly Texture noneTexture;
            public readonly Texture constantTexture;
            public readonly Texture blackboardTexture;
            public readonly Texture globalBlackboardTexture;
            public readonly Color labelTextColor;

            public Styles () {
                radioButton = new GUIStyle(EditorStyles.radioButton);
                radioButton.margin = new RectOffset(2, 2, -1, 0);

                popup = new GUIStyle(EditorStyles.popup);
                popupTextColor = popup.normal.textColor;
                noneTexture = Resources.Load("Icons/None") as Texture;
                constantTexture = Resources.Load("Icons/Constant") as Texture;
                blackboardTexture = Resources.Load("Icons/Blackboard") as Texture;
                globalBlackboardTexture = Resources.Load("Icons/GlobalBlackboard") as Texture;

                labelTextColor = EditorStyles.label.normal.textColor;
                
            }
        }
        #endregion Styles

        /// <summary>
        /// Draws a variable field on the GUI.
        /// <param name= "guiContent">The GUI content to draw the property.</param>
        /// <param name= "property">The variable property.</param>
        /// <param name= "node">The node that owns the variable to be drawn.</param>
        /// </summary>
        public static void VariableField (GUIContent guiContent, SerializedNodeProperty property, ActionNode node) {
            var variable = property.value as Variable;
            var isNone = variable == null || variable.isNone;
            var isConstant = !isNone && variable.isConstant;
            VariableInfoAttribute variableInfo = property.variableInfo;
            string popupName = string.Empty;
            Texture popupTexture = null;


            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            var rect = GUILayoutUtility.GetRect(guiContent, EditorStyles.popup);
            #else
            var rect = EditorGUILayout.GetControlRect();
            #endif

            var id = GUIUtility.GetControlID(FocusType.Keyboard);

            // Set label color
            if (isNone && variableInfo.requiredField)
                EditorStyles.label.normal.textColor = Color.red;
            // Draw label
            rect = EditorGUI.PrefixLabel(rect, id, guiContent);
            // Restore label color
            EditorStyles.label.normal.textColor = s_Styles.labelTextColor;
                
            if (isNone) {
                popupName = variableInfo.nullLabel;
                popupTexture = s_Styles.noneTexture;
            }
            else if (isConstant) {
                if (property.isConcreteVariable) {
                    popupName = "Constant";
                    popupTexture = s_Styles.constantTexture;
                }
                else {
                    popupName = variable.GetType().Name;
                    popupTexture = IconUtility.GetIcon(variable.GetType());
                }
            }
            else {
                popupName = variable.name;
                // Its a global var?
                popupTexture = variable.isGlobal ? s_Styles.globalBlackboardTexture : popupTexture = s_Styles.blackboardTexture;;
            }

            // Popup button
            if (GUIHelper.EditorButton(rect, id, new GUIContent(popupName, popupTexture), s_Styles.popup)) {
                // Set keyboard focus to the label
                GUIUtility.keyboardControl = id;
                // Create the menu and the list of unique names
                var menu = new GenericMenu();
                var names = new List<string>() {};

                // None
                names.Add(variableInfo.nullLabel);
                menu.AddItem(new GUIContent(variableInfo.nullLabel), isNone , delegate {
                    if (isConstant && property.isConcreteVariable) {
                        variable.SetAsNone();
                        property.ValueChanged();
                    }
                    else if (!isNone) {
                        object noneVariable;
                        if (property.type == typeof(GameObjectVar))
                            noneVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(property.type), new object[] {node.self});
                        else if (property.type.IsAbstract)
                            noneVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(property.type));
                        else
                            noneVariable = Activator.CreateInstance(property.type);
                        property.value = noneVariable;
                    }
                });

                // Create the anonymous function to set constants
                GenericMenu.MenuFunction2 createConstant = delegate (object userData) {
                    // Get the desired variable type
                    var type = userData as System.Type;
                    
                    // its not a constant or its an "ex global" var (an ex global var does not have a GlobalBlackboard)?
                    if (variable == null || variable.isInvalid || property.type == typeof(BehaviourMachine.Variable)) {
                        // Create a constant
                        Variable newVariable;
                        if (property.type == typeof(GameObjectVar))
                            newVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(type), new object[] {node.self}) as Variable;
                        else if (type.IsAbstract)
                            newVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(type)) as Variable;
                        else
                            newVariable = Activator.CreateInstance(type) as Variable;

                        newVariable.SetAsConstant();
                        property.value = newVariable;
                        property.ValueChanged();
                    }
                    else if (isNone) {
                        variable.SetAsConstant();
                        property.ValueChanged();
                    }
                    else if ((isConstant && !property.isConcreteVariable) || !isConstant) {
                        // Create a concrete variable type and update the field value!
                        Variable newVariable;
                        
                        if (type == typeof(GameObjectVar))
                            newVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(type), new object[] {node.self}) as Variable;
                        else if (type.IsAbstract)
                            newVariable = Activator.CreateInstance(TypeUtility.GetConcreteType(type)) as Variable;
                        else
                            newVariable = Activator.CreateInstance(type) as Variable;
                        
                        newVariable.SetAsConstant();
                        property.value = newVariable;
                    }
                };

                // Add the Constant name to the list
                names.Add("Constant");

                // Can be constant?
                if (variableInfo.canBeConstant && property.type != typeof(BehaviourMachine.FsmEvent) && property.type != typeof(BehaviourMachine.DynamicList)) {
                    if (property.type != typeof(BehaviourMachine.Variable)) {
                        menu.AddItem(new GUIContent("Constant"), isConstant && property.isConcreteVariable, createConstant, property.type);
                    }
                    else {
                        bool variableNotNull = variable != null;
                        // If its a Variable type then add options for all concrete variables
                        if (!variableInfo.fixedType) {
                            menu.AddItem(new GUIContent("Constant/Variable"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.Variable), createConstant, typeof(BehaviourMachine.Variable));
                            menu.AddItem(new GUIContent("Constant/FloatVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteFloatVar), createConstant, typeof(BehaviourMachine.ConcreteFloatVar));
                            menu.AddItem(new GUIContent("Constant/IntVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteIntVar), createConstant, typeof(BehaviourMachine.ConcreteIntVar));
                            menu.AddItem(new GUIContent("Constant/BoolVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteBoolVar), createConstant, typeof(BehaviourMachine.ConcreteBoolVar));
                            menu.AddItem(new GUIContent("Constant/StringVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteStringVar), createConstant, typeof(BehaviourMachine.ConcreteStringVar));
                            menu.AddItem(new GUIContent("Constant/Vector3Var"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteVector3Var), createConstant, typeof(BehaviourMachine.ConcreteVector3Var));
                            menu.AddItem(new GUIContent("Constant/RectVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteRectVar), createConstant, typeof(BehaviourMachine.ConcreteRectVar));
                            menu.AddItem(new GUIContent("Constant/ColorVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteColorVar), createConstant, typeof(BehaviourMachine.ConcreteColorVar));
                            menu.AddItem(new GUIContent("Constant/QuaternionVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteQuaternionVar), createConstant, typeof(BehaviourMachine.ConcreteQuaternionVar));
                            menu.AddItem(new GUIContent("Constant/GameObjectVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteGameObjectVar), createConstant, typeof(BehaviourMachine.ConcreteGameObjectVar));
                            menu.AddItem(new GUIContent("Constant/MaterialVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteMaterialVar), createConstant, typeof(BehaviourMachine.ConcreteMaterialVar));
                            menu.AddItem(new GUIContent("Constant/TextureVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteTextureVar), createConstant, typeof(BehaviourMachine.ConcreteTextureVar));
                            menu.AddItem(new GUIContent("Constant/ObjectVar"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteObjectVar), createConstant, typeof(BehaviourMachine.ConcreteObjectVar));
                        }
                        else if (variable != null) {
                            // Get the base type
                            System.Type baseType = BehaviourMachine.TypeUtility.GetBaseType(variable.GetType());
                            if (baseType == typeof(Variable))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.Variable), createConstant, typeof(BehaviourMachine.Variable));
                            else if (baseType == typeof(FloatVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteFloatVar), createConstant, typeof(BehaviourMachine.ConcreteFloatVar));
                            else if (baseType == typeof(IntVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteIntVar), createConstant, typeof(BehaviourMachine.ConcreteIntVar));
                            else if (baseType == typeof(BoolVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteBoolVar), createConstant, typeof(BehaviourMachine.ConcreteBoolVar));
                            else if (baseType == typeof(StringVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteStringVar), createConstant, typeof(BehaviourMachine.ConcreteStringVar));
                            else if (baseType == typeof(Vector3Var))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteVector3Var), createConstant, typeof(BehaviourMachine.ConcreteVector3Var));
                            else if (baseType == typeof(RectVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteRectVar), createConstant, typeof(BehaviourMachine.ConcreteRectVar));
                            else if (baseType == typeof(ColorVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteColorVar), createConstant, typeof(BehaviourMachine.ConcreteColorVar));
                            else if (baseType == typeof(QuaternionVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteQuaternionVar), createConstant, typeof(BehaviourMachine.ConcreteQuaternionVar));
                            else if (baseType == typeof(GameObjectVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteGameObjectVar), createConstant, typeof(BehaviourMachine.ConcreteGameObjectVar));
                            else if (baseType == typeof(MaterialVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteMaterialVar), createConstant, typeof(BehaviourMachine.ConcreteMaterialVar));
                            else if (baseType == typeof (TextureVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteTextureVar), createConstant, typeof(BehaviourMachine.ConcreteTextureVar));
                            else if (baseType == typeof (ObjectVar))
                                menu.AddItem(new GUIContent("Constant"), isConstant && variableNotNull && variable.GetType() == typeof(BehaviourMachine.ConcreteObjectVar), createConstant, typeof(BehaviourMachine.ConcreteObjectVar));
                        }
                    }
                }
                else {
                    menu.AddDisabledItem(new GUIContent("Constant"));
                }

                // Custom variables
                if (property.type != null) {
                    System.Type[] customVars = CustomVariableUtility.GetCustomVariables(variableInfo.fixedType && variable != null ? BehaviourMachine.TypeUtility.GetBaseType(variable.GetType()) : property.type);

                    // if (customVars.Length > 0) {
                    //     menu.AddSeparator(string.Empty);
                    // }

                    for (int i = 0; i < customVars.Length; i++) {
                        // Get the type of the custom variable
                        System.Type customVarType = customVars[i];
                        // Get a unique name
                        string uniqueName = StringHelper.GetUniqueNameInList(names, "Custom/" + customVarType.Name);
                        names.Add(uniqueName);
                        // Add to the menu
                        menu.AddItem(new GUIContent(uniqueName), isConstant && variable != null && variable.GetType() == customVarType, delegate {
                            try {
                                var newVariable = Activator.CreateInstance(customVarType, new object[] {node.self}) as Variable;
                                if (newVariable != null) {
                                    newVariable.SetAsConstant();
                                    property.value = newVariable;
                                }
                            }
                            catch (Exception e) {
                                Print.LogError(e.ToString());
                            }
                        });
                    }
                }

                // Boolean used to know if the variables separator was already added to the menu.
                bool separatorAdded = false;

                // Blackboard variables
                var variables = node.self.GetComponent<InternalBlackboard>().GetVariables(variable != null && variableInfo.fixedType ? BehaviourMachine.TypeUtility.GetBaseType(variable.GetType()) : property.type);

                // Add separator?
                if (variables.Count > 0) {
                    menu.AddSeparator(string.Empty);
                    separatorAdded = true;
                }

                // Blackboard variables
                for (int i = 0; i < variables.Count; i++) {
                    var v = variables[i];
                    var name = StringHelper.GetUniqueNameInList(names, v.name);
                    names.Add(name);
                    menu.AddItem(new GUIContent(name), variable == v , delegate {property.value = v;});
                }

                // Global variables
                if (InternalGlobalBlackboard.Instance != null) {
                    var globalVariables = InternalGlobalBlackboard.Instance.GetVariables(property.type);

                    // Add separator?
                    if (!separatorAdded && globalVariables.Count > 0) {
                        menu.AddSeparator(string.Empty);
                        separatorAdded = true;
                    }

                    for (int i = 0; i < globalVariables.Count; i++) {
                        var v = globalVariables[i];
                        var name = StringHelper.GetUniqueNameInList(names, "Global/" + v.name);
                        names.Add(name);
                        menu.AddItem(new GUIContent(name), variable == v ,  delegate {property.value = v;});
                    }
                }

                // Show menu
                menu.DropDown(rect);
                // Set GUI as not changed
                GUI.changed = false;
            }

            // Draw constant properties
            if (isConstant) {
                // Get children
                var children = property.children;

                // The variable is an ObjectVar?
                var objectVar = variable as ObjectVar;
                System.Type objType = objectVar != null ? objectVar.ObjectType : null;

                // Draw properties
                if (children.Length > 0) {
                    EditorGUI.indentLevel++;

                    if (property.isConcreteVariable) {
                        for (int i = 0; i < children.Length; i++) {
                            SerializedNodeProperty childProperty = children[i];
                            if (!childProperty.hideInInspector) {
                                if (childProperty.propertyType == NodePropertyType.Vector3 || childProperty.propertyType == NodePropertyType.Quaternion || childProperty.propertyType == NodePropertyType.Vector2) {
                                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                                    GUILayout.Space(-20f);
                                    EditorGUI.indentLevel--;
                                    #endif
                                    
                                    DrawNodeProperty(GUIContent.none, childProperty, node, objType);
                                    
                                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                                    EditorGUI.indentLevel++;
                                    #endif
                                }
                                else if (childProperty.propertyType == NodePropertyType.Rect) {
                                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                                    GUILayout.Space(-20f);
                                    EditorGUI.indentLevel--;
                                    #endif
                                   
                                    DrawNodeProperty(GUIContent.none, childProperty, node, objType);
                                   
                                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                                    GUILayout.Space(20f);
                                    EditorGUI.indentLevel++;
                                    #endif
                                }
                                else
                                    DrawNodeProperty(new GUIContent(childProperty.label, childProperty.tooltip), childProperty, node, objType);
                            }
                        }
                    }
                    else {
                        for (int i = 0; i < children.Length; i++) {
                            SerializedNodeProperty childProperty = children[i];
                            if (!childProperty.hideInInspector)
                                DrawNodeProperty(new GUIContent(childProperty.label, childProperty.tooltip), childProperty, node, objType);
                        }
                    }
                    
                    EditorGUI.indentLevel--;
                }
            }
        }

        /// <summary>
        /// Draws a layer maks popup button.
        /// <param name="label">The content of the label.</param>
        /// <param name="layerMask">The layer mask to be drawn.</param>
        /// <returns>The new value of the layer mask; if it was changed.</returns>
        /// </summary>
        public static LayerMask LayerMaskField (GUIContent label, LayerMask layerMask) {
            var layers = new List<string>();

            for (int i = 0; i < 32; i++) {
                var name = LayerMask.LayerToName(i);
                if (name != string.Empty)
                    layers.Add(name);
                else {
                    layers.Add("Layer (" +  i.ToString() + ") - empty");
                }
            }

            var newLayer = EditorGUILayout.MaskField(label, layerMask.value, layers.ToArray());

            if (layerMask.value != newLayer) {
                var newLayerMask = new LayerMask();
                 newLayerMask.value = newLayer;
                 return newLayerMask;
            }
            else
                return layerMask;
        }

        /// <summary>
        /// Draws a node property in the GUI.
        /// <param name="guiContent">The content of the property.</param>
        /// <param name="property">The property do be drawn.</param>
        /// <param name="node">The node that owns the property.</param>
        /// <param name="objectType">An optionaly type to be used to with UnityEngine.Object properties.</param>
        /// <param name="useCustomDrawer">If false the custom node drawer will be ignored if it exists.</param>
        /// </summary>
        public static void DrawNodeProperty (GUIContent guiContent, SerializedNodeProperty property, ActionNode node, Type objectType = null, bool useCustomDrawer = true) {

            if (s_Styles == null)
                s_Styles = new GUILayoutHelper.Styles();

            // Get the current value
            object value = property.value;
            // Create the newValue
            object newValue = value;

            // Variable?
            if (property.propertyType == NodePropertyType.Variable) {
                GUILayoutHelper.VariableField(guiContent, property, node);
            }
            // Use custom property drawer?
            else if (useCustomDrawer && property.customDrawer != null) {
                property.customDrawer.OnGUI(property, node, guiContent);
                return;
            }
            else {
                EditorGUI.BeginChangeCheck();
                
                switch (property.propertyType) {
                    // Integer
                    case NodePropertyType.Integer:
                        newValue = EditorGUILayout.IntField(guiContent, value != null ? (int) value : 0);
                        break;
                    // Float
                    case NodePropertyType.Float:
                        newValue = EditorGUILayout.FloatField(guiContent, (float) value);
                        break;
                    // Boolean
                    case NodePropertyType.Boolean:
                        newValue = EditorGUILayout.Toggle(guiContent, (bool) value);
                        break;
                    // String
                    case NodePropertyType.String:
                        newValue = EditorGUILayout.TextField(guiContent, (string) value);
                        break;
                    // Color
                    case NodePropertyType.Color:
                        newValue = EditorGUILayout.ColorField(guiContent, (Color) value);
                        break;
                    // Vector2
                    case NodePropertyType.Vector2:
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        newValue = EditorGUILayout.Vector2Field(guiContent.text, (Vector2) value);
                        #else
                        newValue = EditorGUILayout.Vector2Field(guiContent, (Vector2) value);
                        #endif
                        break;
                    // Vector3
                    case NodePropertyType.Vector3:
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        newValue = EditorGUILayout.Vector3Field(guiContent.text, (Vector3) value);
                        #else
                        newValue = EditorGUILayout.Vector3Field(guiContent, (Vector3) value);
                        #endif
                        break;
                    // Quaternion
                    case NodePropertyType.Quaternion:
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        newValue = Quaternion.Euler(EditorGUILayout.Vector3Field(guiContent.text, ((Quaternion)value).eulerAngles));
                        #else
                        newValue = Quaternion.Euler(EditorGUILayout.Vector3Field(guiContent, ((Quaternion)value).eulerAngles));
                        #endif
                        break;
                    // Vector4
                    case NodePropertyType.Vector4:
                        newValue = EditorGUILayout.Vector4Field(guiContent.text, (Vector4) value);
                        break;
                    // Rect
                    case NodePropertyType.Rect:
                        newValue = EditorGUILayout.RectField(guiContent, (Rect) value);
                        break;
                    // Enum
                    case NodePropertyType.Enum:
                        newValue = EditorGUILayout.EnumPopup(guiContent, (System.Enum) value);
                        break;
                    // AnimationCurve
                    case NodePropertyType.AnimationCurve:
                        newValue = EditorGUILayout.CurveField(guiContent, (AnimationCurve) value);
                        break;
                    // UnityObject
                    case NodePropertyType.UnityObject:
                        newValue = EditorGUILayout.ObjectField(guiContent, value as UnityEngine.Object, objectType != null ? objectType : property.type, !AssetDatabase.Contains(node.self));
                        break;
                    // Array
                    case NodePropertyType.Array:
                        EditorGUILayout.LabelField(guiContent);
                        GUI.changed = false;
                        break;
                    // ArraySize
                    case NodePropertyType.ArraySize:
                        goto case NodePropertyType.Integer;
                    // LayerMask
                    case NodePropertyType.LayerMask:
                        newValue = GUILayoutHelper.LayerMaskField(guiContent, (LayerMask) value);
                        break;
                    // Not Supported
                    default:
                        Color oldGuiColor = GUI.color;
                        GUI.color = Color.red;
                        EditorGUILayout.LabelField(guiContent.text, "Not supported.");
                        GUI.color = oldGuiColor;
                        break;
                }

                // Value changed?
                if (EditorGUI.EndChangeCheck()) {
                    property.value = newValue;
                    Event.current.Use();
                }
            }
        }
    }
}