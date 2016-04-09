//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;
using UnityEngine;
using System.Reflection;
using System.Collections;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    public enum NodePropertyType {
        NotSupported,
        Variable,
        Integer,
        Float,
        Enum,
        Boolean,
        String,
        Color,
        Vector2,
        Vector3,
        Vector4,
        Quaternion,
        Rect,
        Array,
        ArraySize,
        LayerMask,
        AnimationCurve,
        UnityObject,
    }

    /// <summary>
    /// Base class to create objects that store serialized data.
    /// </summary>
    public abstract class SerializedNodeProperty {

        #region Members
        SerializedNode m_SerializedNode;
        NodePropertyType m_PropertyType;
        string m_Path = string.Empty;
        protected object m_Value;
        bool m_ValueChanged = false;
        SerializedNodeProperty[] m_Children;
        System.Type m_Type;
        string m_Label = string.Empty;
        bool m_HideInInspector = false;
        protected object m_Target;
        protected bool m_IsConcreteVariable = false;
        protected NodePropertyDrawer m_PropertyDrawer;
        protected string m_Tooltip = string.Empty;
        protected VariableInfoAttribute m_VariableInfo = null;
        #endregion Members


        #region Properties
        /// <summary>
        /// The object that owns the property.
        /// </summary>
        public object target {get {return m_Target;}}

        /// <summary>
        /// The serialized node that owns the property.
        /// </summary>
        public SerializedNode serializedNode {get {return m_SerializedNode;}}

        /// <summary>
        /// The property path.
        /// </summary>
        public string path {get {return m_Path;}}

        /// <summary>
        /// The inspector label for this property.
        /// </summary>
        public string label {get {return m_Label;} set {m_Label = value;}}

        /// <summary>
        /// The tooltip inspector for the property.
        /// </summary>
        public string tooltip {get {return m_Tooltip;} set {m_Tooltip = value;}}

        /// <summary>
        /// The custom drawer for the property; or null.
        /// </summary>
        public NodePropertyDrawer customDrawer {get {return m_PropertyDrawer;} set {m_PropertyDrawer = value;}}

        /// <summary>
        /// True if the property has the HideInInspector attribute.
        /// </summary>
        public bool hideInInspector {get {return m_HideInInspector;} set {m_HideInInspector = value;}}

        /// <summary>
        /// True if the property is a concrete variable.
        /// </summary>
        public bool isConcreteVariable {get {return m_IsConcreteVariable;}}

        /// <summary>
        /// The type of the property.
        /// </summary>
        public System.Type type {get {return m_Type;}}

        /// <summary>
        /// The variable info if the property is a Variable; null otherwise.
        /// </summary>
        public VariableInfoAttribute variableInfo {get {return m_VariableInfo;}}

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object value {
            get {return m_Value;}
            set {
                if (!object.Equals(m_Value, value)) {
                    m_Value = value;
                    ValueChanged();
                }
            }
        }

        /// <summary>
        /// True if the value was changed; false otherwise.
        /// </summary>
        public bool valueChanged {
            get {return m_ValueChanged;}
            protected set {m_ValueChanged = value;}
        }

        /// <summary>
        /// The property type.
        /// </summary>
        public NodePropertyType propertyType {get {return m_PropertyType;}}

        /// <summary>
        /// True if the property has children; false otherwise.
        /// </summary>
        public bool hasChildren {get {return m_Children != null && m_Children.Length > 0;}}

        /// <summary>
        /// The property children.
        /// </summary>
        public SerializedNodeProperty[] children {get {return m_Children;}}
        #endregion Properties


        #region Constructor
        /// <summary>
        /// Class constructor.
        /// <param name="target">The target object (node, variable or a generic object).</param>
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="path">The property path.</param>
        /// <param name="type">The type of the property.</param>
        /// <param name="propertyType">The property type.</param>
        /// </summary>
        public SerializedNodeProperty (object target, SerializedNode serializedNode, string path, Type type, NodePropertyType propertyType) {
            m_Target = target;
            m_SerializedNode = serializedNode;
            m_Path = path;
            m_PropertyType = propertyType;
            m_Type = type;
        }
        #endregion Constructor


        #region Public Methods
        /// <summary>
        /// Set the children of the property.
        /// </summary>
        public void SetChildren (SerializedNodeProperty[] children) {
            m_Children = children;
        }

        /// <summary>
        /// Override this method to update the serialized property value.
        /// </summary>
        public abstract void Update ();

        /// <summary>
        /// Override this function to apply the new value to the property.
        /// </summary>
        public abstract void ApplyModifiedValue ();

        /// <summary>
        /// Call this method if the value of the property was changed using some object method.
        /// </summary>
        public void ValueChanged () {
            m_ValueChanged = true;
            m_SerializedNode.PropertyDataChanged(this);
        }
        #endregion Public Methods
    }
}