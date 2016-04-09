//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// An iterator for node SerializedProperties.
    /// <seealso cref="BehaviourMachine.SerializedNode" />
    /// <seealso cref="BehaviourMachine.SerializedNodeProperty" />
    /// </summary>
    public class NodePropertyIterator {

        #region Members
        Stack<SerializedNodeProperty[]> m_ParentProperties = new Stack<SerializedNodeProperty[]>();
        Stack<int> m_ParentPropertiesIndex = new Stack<int>();
        SerializedNodeProperty[] m_Properties;
        int m_CurrentIndex = -1;
        SerializedNodeProperty m_Current;
        #endregion Members


        #region Properties
        /// <summary>
        /// Returns the current SerializedNodeProperty.
        /// </summary>
        public SerializedNodeProperty current {get {return this.m_Current;}}

        /// <summary>
        /// The depth of the current serialized node.
        /// </summary>
        public int depth {get {return m_ParentProperties.Count;}}
        #endregion Properties


        #region Constructor
        /// <summary>
        /// Constructor.
        /// <param name="members">The serialized properties to iterate through.</param>
        /// </summary>
        public NodePropertyIterator (SerializedNodeProperty[] members) {
            m_Properties = members;
        }
        #endregion Constructor


        #region Public Methods
        /// <summary>
        /// Moves to the next property.
        /// <param name="enterChildren">Should iterate through the current property children?</param>
        /// <returns>The current property is valid?</returns>
        /// </summary>
        public bool Next (bool enterChildren) {
            // The current property has children?
            if (enterChildren && this.m_Current != null && this.m_Current.hasChildren) {
                m_ParentPropertiesIndex.Push(m_CurrentIndex);
                m_ParentProperties.Push(m_Properties);
                m_Properties = this.m_Current.children;
                m_CurrentIndex = 0;
                m_Current = m_Properties[0];
                return true;
            }
            // Get next property
            else if (++m_CurrentIndex < m_Properties.Length) {
                m_Current = m_Properties[m_CurrentIndex];
                return true;
            }
            // Restore last property set
            else if (m_ParentProperties.Count > 0) {
                m_Properties = m_ParentProperties.Pop();
                m_CurrentIndex = m_ParentPropertiesIndex.Pop();
                return this.Next(enterChildren);
            }
            return false;
        }

        /// <summary>
        /// Selects the property that has the supplied path.
        /// <param name="propertyPath">The target property path.</param>
        /// <returns>True if the property was found; false otherwise.</returns>
        /// </summary>
        public bool Find (string propertyPath) {
            this.Reset();

            while (this.Next(true)) {
                if (m_Current != null && m_Current.path == propertyPath)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the first state of the iterator.
        /// </summary>
        public void Reset () {
            m_CurrentIndex = -1;
            m_Current = null;
        }
        #endregion Public Methods
    }
}