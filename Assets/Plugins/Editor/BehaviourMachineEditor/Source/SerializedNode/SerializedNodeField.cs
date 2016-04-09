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

    /// <summary>
    /// Class that stores a serialized field.
    /// </summary>
    public class SerializedNodeField : SerializedNodeProperty {

        #region Members
        FieldInfo m_FieldInfo;
        #endregion Members


        #region Constructor
        /// <summary>
        /// Constructor.
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="path">The property path.</param>
        /// <param name="propertyType">The serialize property type.</param>
        /// <param name="target">The object that owns the serialized field.</param>
        /// <param name="fieldInfo">The field info of the property.</param>
        /// </summary>
        public SerializedNodeField (SerializedNode serializedNode, string path, NodePropertyType propertyType, object target, FieldInfo fieldInfo) : base (target, serializedNode, path, fieldInfo.FieldType, propertyType) {
            m_FieldInfo = fieldInfo;
            this.hideInInspector = AttributeUtility.GetAttribute<HideInInspector>(fieldInfo, true) != null;

            // Variable?
            if (propertyType == NodePropertyType.Variable) {
                this.label = StringHelper.SplitCamelCase(fieldInfo.Name);
                m_VariableInfo = AttributeUtility.GetAttribute<VariableInfoAttribute>(fieldInfo, true) ?? new VariableInfoAttribute();

                var variable = m_FieldInfo.GetValue(m_Target) as BehaviourMachine.Variable;
                System.Type variableType = variable != null ? variable.GetType() : null; 

                m_IsConcreteVariable = variableType != null && TypeUtility.GetConcreteType(variableType) == variableType;
                this.tooltip = (fieldInfo.FieldType.Name + ": " + m_VariableInfo.tooltip).Replace("Var", string.Empty);
            }
            else {
                this.label = StringHelper.SplitCamelCase(fieldInfo.Name);
                var tooltip = AttributeUtility.GetAttribute<BehaviourMachine.TooltipAttribute>(fieldInfo, true);
                if (tooltip != null)
                    m_Tooltip = tooltip.tooltip;
            }
        }
        #endregion Constructor


        #region Callbacks
        /// <summary>
        /// Updates the serialize property value.
        /// </summary>
        public override void Update () {
            if (m_Target != null && !this.valueChanged)
                m_Value = m_FieldInfo.GetValue(m_Target);
        }

        /// <summary>
        /// Applies the new value to the property.
        /// </summary>
        public override void ApplyModifiedValue () {
            this.valueChanged = false;
            m_FieldInfo.SetValue(m_Target, m_Value);
        }
        #endregion Callbacks
    }
}