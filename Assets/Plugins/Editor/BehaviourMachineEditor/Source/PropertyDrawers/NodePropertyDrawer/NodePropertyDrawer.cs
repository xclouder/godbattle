//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Base class to derive custom node property drawers from.
    /// </summary>
    public abstract class NodePropertyDrawer {

        #region Static
        static Dictionary<Type, Type> s_CustomDrawers = null;

        /// <summary>
        /// Returns the custom drawer for the supplied property attribute or null.
        /// <param name="attribute">The property attribute to search for a custom drawer.</param>
        /// <returns>The custom property drawer or null.</returns>
        /// </summary>
        public static NodePropertyDrawer GetDrawer (PropertyAttribute attribute) {
            if (attribute == null)
                return null;

            // The custom drawer dictionary is not loaded?
            if (s_CustomDrawers == null) {
                s_CustomDrawers = new Dictionary<Type, Type>();
                foreach (Type t in EditorTypeUtility.GetDerivedTypes(typeof(NodePropertyDrawer))) {
                    var customDrawerAttr = AttributeUtility.GetAttribute<CustomNodePropertyDrawerAttribute>(t, false);
                    if (customDrawerAttr != null && !s_CustomDrawers.ContainsKey(customDrawerAttr.type))
                        s_CustomDrawers.Add(customDrawerAttr.type, t);
                }
            }

            // Try to get the type of the custom property drawer
            Type drawerType;
            s_CustomDrawers.TryGetValue(attribute.GetType(), out drawerType);
            if (drawerType != null) {
                // Create the drawer
                var drawer = Activator.CreateInstance(drawerType) as NodePropertyDrawer;
                if (drawer != null) {
                    // Set the attribute and return the drawer
                    drawer.attribute = attribute;
                    return drawer;
                }
            }

            return null;
        }
        #endregion Static


        #region Members
        PropertyAttribute m_Attribute;
        #endregion Members


        #region Properties
        /// <summary>
        /// The PropertyAttribute for the property.
        /// </summary>
        public PropertyAttribute attribute {get {return m_Attribute;} set {m_Attribute = value;}}
        #endregion Properties


        #region Public Methods
        /// <summary>
        /// Override this method to make your own GUI for the property.
        /// </summary>
        public abstract void OnGUI (SerializedNodeProperty property, ActionNode node, GUIContent guiContent);
        #endregion Public Methods
    }
}