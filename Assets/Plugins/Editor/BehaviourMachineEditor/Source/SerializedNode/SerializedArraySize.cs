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
    /// Class that stores a serialized array size.
    /// </summary>
    public class SerializedArraySize : SerializedNodeProperty {

        #region Members
        SerializedNodeProperty m_ArrayData;
        Array m_Array;
        Type m_ElementType;
        #endregion Members


        #region Constructor
        /// <summary>
        /// Class constructor.
        /// <param name="target">The target object (node, variable or generic object).</param>
        /// <param name="serializedNode">The target serialized node.</param>
        /// <param name="path">The property path.</param>
        /// <param name="arrayData">The serialize property of the target array.</param>
        /// <param name="array">The target array.</param>
        /// <param name="elementType">The array element type.</param>
        /// </summary>
        public SerializedArraySize (object target, SerializedNode serializedNode, string path, SerializedNodeProperty arrayData, Array array, Type elementType) : base (target, serializedNode, path, typeof(int), NodePropertyType.ArraySize) {
            m_ArrayData = arrayData;
            m_Array = array;
            m_ElementType = elementType;
            this.label = "Size";
        }
        #endregion Constructor


        #region Callbacks
        /// <summary>
        /// Updates the serialize property value.
        /// </summary>
        public override void Update () {
            if (this.m_Array != null && !this.valueChanged)
                this.m_Value = this.m_Array.Length;
        }

        /// <summary>
        /// Applies the new value to the property.
        /// </summary>
        public override void ApplyModifiedValue () {
            this.valueChanged = false;

            // Get array size
            int size = Math.Max(0, (int)m_Value);

            // The size has changed?
            if (size != m_Array.Length) {
                var newArray = Array.CreateInstance (this.m_ElementType, size);

                // Get last item
                object lastItem = m_Array.Length > 0 ? m_Array.GetValue(m_Array.Length -1) : null;

                for (int i = 0; i < newArray.Length; i++) {
                    // Get array item
                    object item = lastItem;

                    if (i < m_Array.Length)
                        item = m_Array.GetValue(i);
                    else if (!this.m_ElementType.IsValueType) {
                        if (this.m_ElementType.IsArray)
                            item = Array.CreateInstance (this.m_ElementType.GetElementType(), 0);
                        else if (this.m_ElementType == typeof(GameObjectVar))
                            item = Activator.CreateInstance(m_ElementType.IsAbstract ? TypeUtility.GetConcreteType(m_ElementType) : this.m_ElementType, new object[] {this.serializedNode.target.self});
                        else if (typeof(UnityEngine.Object).IsAssignableFrom(this.m_ElementType))
                            item = null;
                        else if (this.m_ElementType.IsAbstract)
                            item = Activator.CreateInstance(TypeUtility.GetConcreteType(this.m_ElementType));
                        else if (this.m_ElementType == typeof(string))
                            item = string.Empty;
                        else
                            item = Activator.CreateInstance(this.m_ElementType);
                    }

                    // Set array item
                    newArray.SetValue (item, i);
                }

                // Set new array
                this.m_ArrayData.value = newArray;

                // Apply changes
                this.m_ArrayData.ApplyModifiedValue();
            }
        }
        #endregion Callbacks
    }
}