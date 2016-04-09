//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Class for editing properties on nodes in a completely generic way that automatically handles undo.
    /// </summary>
    public class SerializedNode {

        #region Static Methods
        /// <summary>
        /// Returns the node property type of the supplied System.Type.
        /// <param name="type">The System.Type to get the node property type.</param>
        /// <returns>The node property type.</returns>
        /// </summary>
        static NodePropertyType GetPropertyType (Type type) {
            if (typeof(BehaviourMachine.Variable).IsAssignableFrom(type))
                return NodePropertyType.Variable;
            else if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                return NodePropertyType.UnityObject;
            else if (type == typeof(int))
                return NodePropertyType.Integer;
            else if (type == typeof(float))
                return NodePropertyType.Float;
            else if (type == typeof(bool))
                return NodePropertyType.Boolean;
            else if (type == typeof(string))
                return NodePropertyType.String;
            else if (type == typeof(Color))
                return NodePropertyType.Color;
            else if (type == typeof(Vector2))
                return NodePropertyType.Vector2;
            else if (type == typeof(Vector3))
                return NodePropertyType.Vector3;
            else if (type == typeof(Vector4))
                return NodePropertyType.Vector4;
            else if (type == typeof(Quaternion))
                return NodePropertyType.Quaternion;
            else if (type == typeof(Rect))
                return NodePropertyType.Rect;
            else if (type == typeof(AnimationCurve))
                return NodePropertyType.AnimationCurve;
            else if (type == typeof(LayerMask))
                return NodePropertyType.LayerMask;
            else if (type.IsArray)
                return NodePropertyType.Array;
            else if (type.IsEnum)
                return NodePropertyType.Enum;
            else
                return NodePropertyType.NotSupported;
        }

        /// <summary>
        /// Returns a set of serialized properties in an object.
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="target">The object to get the properties.</param>
        /// <param name="targetType">The target object type.</param>
        /// <param name="currentPath">The property path of the target.</param>
        /// <returns>The serialized properties in the target object.</returns>
        /// </summary>
        static SerializedNodeProperty[] GetPropertiesData (SerializedNode serializedNode, object target, Type targetType, string currentPath = "") {
            // Create the property data list
            var propertyData = new List<SerializedNodeProperty>();
            // Get serialized fields for the target type
            FieldInfo[] serializedFields = NodeSerialization.GetSerializedFields(targetType);

            for (int i = 0; i < serializedFields.Length; i++) {
                // Get field
                FieldInfo field = serializedFields[i];
                // Get field type
                var fieldType = field.FieldType;
                // Get the field property attribute
                var propertyAttr = AttributeUtility.GetAttribute<PropertyAttribute>(field, true);
                // Get the property type
                var propertyType = SerializedNode.GetPropertyType(fieldType);
                // Create the property data
                var currentSerializedField = new SerializedNodeField(serializedNode, currentPath + field.Name, propertyType, target, field);
                propertyData.Add(currentSerializedField);

                // Variable?
                if (propertyType == NodePropertyType.Variable) {
                    // Get the field value
                    object fieldValue = target != null ? field.GetValue(target) : null;

                    // Get the children fields
                    SerializedNodeProperty[] children = SerializedNode.GetPropertiesData(serializedNode, fieldValue, fieldValue != null ? fieldValue.GetType() : fieldType, currentPath + field.Name + ".");

                    // Create the property drawer for the "Value" child property
                    if (propertyAttr != null && currentSerializedField.isConcreteVariable) {
                        foreach (var child in children) {
                            // It is the "Value" property?
                            if (child.label == "Value")
                                child.customDrawer = NodePropertyDrawer.GetDrawer(propertyAttr);
                        }
                    }

                    // Set children
                    currentSerializedField.SetChildren(children);
                }
                // Array?
                else if (propertyType == NodePropertyType.Array) {
                    // Get the array value
                    Array array = target != null ? field.GetValue(target) as Array : null;
                    // Get array element type
                    var elementType = fieldType.GetElementType();
                    // Create the array children list
                    var childrenList = new List<SerializedNodeProperty>();

                    // Create the array size
                    childrenList.Add(new SerializedArraySize(target, serializedNode, currentSerializedField.path + ".size", currentSerializedField, array, elementType));

                    // Create children
                    var variableInfo = AttributeUtility.GetAttribute<VariableInfoAttribute>(field, true) ?? new VariableInfoAttribute();
                    childrenList.AddRange(SerializedNode.GetPropertiesData(serializedNode, target, array, elementType, currentSerializedField.path + ".", variableInfo, propertyAttr));

                    // Set array data children
                    currentSerializedField.SetChildren(childrenList.ToArray());
                }
                // Get the property drawer
                else if (propertyAttr != null)
                    currentSerializedField.customDrawer = NodePropertyDrawer.GetDrawer(propertyAttr);
            }

            return propertyData.ToArray();
        }

        /// <summary>
        /// Returns a set of serialized properties in an array.
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="target">The target object (node, variable or generic object).</param>
        /// <param name="targetArray">The target array.</param>
        /// <param name="type">The elements type in the array.</param>
        /// <param name="currentPath">The property path of the target array.</param>
        /// <param name="variableInfo">The variable info in the array or null.</param>
        /// <param name="propertyAttr">The property attribute in the array.</param>
        /// <returns>The serialized properties in the array.</returns>
        /// </summary>
        static SerializedNodeProperty[] GetPropertiesData (SerializedNode serializedNode, object target, Array targetArray, Type type, string currentPath, VariableInfoAttribute variableInfo, PropertyAttribute propertyAttr) {
            // Create the property data list
            var propertyData = new List<SerializedNodeProperty>();
            // Get the property type
            var propertyType = SerializedNode.GetPropertyType(type);

            if (targetArray != null) {
                // Variable?
                if (propertyType == NodePropertyType.Variable) {
                    for (int i = 0; i < targetArray.Length; i++) {
                        // Get the field value
                        object elementValue = targetArray.GetValue(i);
                        // Create the variable data
                        var variableData = new SerializedArrayElement(target, serializedNode, currentPath + "data[" + i.ToString() + "]", type, propertyType, targetArray, i, variableInfo);

                        // Create the variable children
                        SerializedNodeProperty[] children = SerializedNode.GetPropertiesData(serializedNode, elementValue, elementValue != null ? elementValue.GetType() : type, variableData.path + ".");

                        // Create the property drawer for the "Value" child property
                        if (propertyAttr != null && variableData.isConcreteVariable) {
                            foreach (var child in children) {
                                // It is the "Value" property?
                                if (child.label == "Value")
                                    child.customDrawer = NodePropertyDrawer.GetDrawer(propertyAttr);
                            }
                        }

                        // Set children
                        variableData.SetChildren(children);

                        // Add the variable data to the list
                        propertyData.Add(variableData);
                    }
                }
               // Array?
                else if (propertyType == NodePropertyType.Array) {
                    for (int i = 0; i < targetArray.Length; i++) {
                        // Create the current property data
                        var currentPropertyData = new SerializedArrayElement(target, serializedNode, currentPath + "data[" + i.ToString() + "]" , type, propertyType, targetArray, i, variableInfo);
                        // Get the array value
                        var array = targetArray.GetValue(i) as Array;
                        // Get array element type
                        var elementType = type.GetElementType();
                        // Create the array children list
                        var childrenList = new List<SerializedNodeProperty>();

                        // Create the array size
                        childrenList.Add(new SerializedArraySize(target, serializedNode, currentPropertyData.path + ".size", currentPropertyData, array, elementType));
                        // Create array children
                        childrenList.AddRange(SerializedNode.GetPropertiesData(serializedNode, target, array, elementType, currentPropertyData.path + ".", variableInfo, propertyAttr));

                        // Set array data children
                        currentPropertyData.SetChildren(childrenList.ToArray());

                        // Add to list
                        propertyData.Add(currentPropertyData);
                    }
                }
                else {
                    for (int i = 0; i < targetArray.Length; i++) {
                        // Create the current property data
                        var currentPropertyData = new SerializedArrayElement(target, serializedNode, currentPath + "data[" + i.ToString() + "]" , type, propertyType, targetArray, i, variableInfo);
                        // Try to get a property drawer
                        if (propertyAttr != null)
                            currentPropertyData.customDrawer = NodePropertyDrawer.GetDrawer(propertyAttr);
                        // Add to list
                        propertyData.Add(currentPropertyData);
                    }
                }
            }

            return propertyData.ToArray();
        }

        /// <summary>
        /// Update the supplied properties recursively.
        /// <param name="properties">The properties to be updated.</param>
        /// </summary>
        static void UpdatePropertiesRecursively (SerializedNodeProperty[] properties) {
            // Call Update in properties data
            for (int i = 0; i < properties.Length; i++) {
                properties[i].Update();
                if (properties[i].hasChildren)
                    UpdatePropertiesRecursively(properties[i].children);
            }
        }
        #endregion Static Methods


        #region Members
        ActionNode m_Target;
        Type m_Type;
        bool m_RecreateData;
        SerializedNodeProperty[] m_PropertiesData;
        List<SerializedNodeProperty> m_PropertiesChanged = new List<SerializedNodeProperty>();
        #endregion Members

        
        #region Properties
        /// <summary>
        /// The target object.
        /// </summary>
        public ActionNode target {get {return m_Target;}}

        /// <summary>
        /// The target type.
        /// </summary>
        public Type type {get {return m_Type;}}
        #endregion Properties


        #region Constructor
        /// <summary>
        /// Class constructor. Create SerializedNode for inspected object.
        /// <param name="target">The node to get the be inspected.</param>
        /// </summary>
    	public SerializedNode (ActionNode target) {
            m_Target = target;
            m_Type = m_Target.GetType();
            m_RecreateData = true;
        }
        #endregion Constructor


        #region Public Methods
        /// <summary>
        /// Called by the serialized properties when their data change.
		/// <param name="property">The property value that has changed.</param>
        /// </summary>
        public void PropertyDataChanged (SerializedNodeProperty property) {
            if (property.serializedNode == this && !m_PropertiesChanged.Contains(property))
                m_PropertiesChanged.Add(property);
        }

        /// <summary>
        /// Update the values in the properties.
        /// </summary>
        public void Update () {
            if (m_RecreateData) {
                m_RecreateData = false;
                m_PropertiesData = SerializedNode.GetPropertiesData(this, m_Target, m_Type);
            }

            if (m_Target != null)
                SerializedNode.UpdatePropertiesRecursively(m_PropertiesData);
        }

        /// <summary>
        /// Apply property modifications.
        /// </summary>
        public void ApplyModifiedProperties () {

            if (m_Target != null && m_PropertiesChanged.Count > 0) {

                var ownerUnityObj = m_Target.owner as UnityEngine.Object;
                var variableModified = new List<Variable>();

                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(ownerUnityObj, "Inspector");
                #else
                Undo.RecordObject(ownerUnityObj, "Inspector");
                #endif

                // Call ApplyModifiedValue in all change properties
                for (int i = 0; i < m_PropertiesChanged.Count; i++) {
                    // Apply changes in the property data
                    m_PropertiesChanged[i].ApplyModifiedValue();

                    // Recreate data?
                    m_RecreateData = m_RecreateData || m_PropertiesChanged[i].hasChildren || m_PropertiesChanged[i].propertyType == NodePropertyType.Variable;

                    // It is a variable?
                    var variable = m_PropertiesChanged[i].target as Variable;
                    if (variable != null && !variableModified.Contains(variable))
                        variableModified.Add(variable);
                }

                // Clear changed properties
                m_PropertiesChanged.Clear();

                // Call OnValidate
                foreach (var variable in variableModified)
                    variable.OnValidate();
                m_Target.OnValidate();

                // Set tree dirty flag
                StateUtility.SetDirty(m_Target.owner);
            }
        }

        /// <summary>
        /// Gets a property iterator.
        /// <returns>The property iterator for this serialized node.</returns>
        /// </summary>
        public NodePropertyIterator GetIterator () {
            return new NodePropertyIterator(m_PropertiesData);
        }
        #endregion Public Methods
    }
}