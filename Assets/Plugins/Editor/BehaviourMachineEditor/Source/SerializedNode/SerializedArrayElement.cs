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
    /// Class that stores a serialized array element.
    /// </summary>
    public class SerializedArrayElement : SerializedNodeProperty {

        #region Members
        Array m_Array;
        int m_Index;
        #endregion Members


        #region Properties
        public int index {get {return m_Index;}}
        #endregion Properties


        #region Constructor
        /// <summary>
        /// Class constructor.
        /// <param name="target">The target object (node, variable or generic object).</param>
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="path">The property path.</param>
        /// <param name="type">The type of the property.</param>
        /// <param name="propertyType">The property type.</param>
        /// <param name="array">The array that the element belongs to.</param>
        /// <param name="index">The element index.</param>
        /// <param name="variableInfo">A variable info if the serialized property is a variable; null otherwise.</param>
        /// </summary>
        public SerializedArrayElement (object target, SerializedNode serializedNode, string path, System.Type type, NodePropertyType propertyType, Array array, int index, VariableInfoAttribute variableInfo) : base (target, serializedNode, path, type, propertyType) {
            m_Array = array;
            m_Index = index;
            m_VariableInfo = variableInfo;
            this.label = "Element " + index.ToString();

            // Its a variable type?
            if (propertyType == NodePropertyType.Variable) {
                // Update label
                this.tooltip = (type.Name + ": " + this.tooltip).Replace("Var", string.Empty);

                // Set concreteVariable
                var variable = m_Array.GetValue(m_Index) as BehaviourMachine.Variable;
                System.Type variableType = variable != null ? variable.GetType() : null;
                m_IsConcreteVariable = variableType != null && TypeUtility.GetConcreteType(variableType) == variableType;
            }
        }
        #endregion Constructor


        #region Callbacks
        /// <summary>
        /// Updates the serialize property value.
        /// </summary>
        public override void Update () {
            if (!this.valueChanged)
                m_Value = m_Array.GetValue(m_Index);
        }

        /// <summary>
        /// Applies the new value to the property.
        /// </summary>
        public override void ApplyModifiedValue () {
            this.valueChanged = false;
            m_Array.SetValue(m_Value, m_Index);
        }
        #endregion Callbacks
    }
}