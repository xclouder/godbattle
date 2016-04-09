//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Tells a custom PropertyDrawer which class or PropertyAttribute is a drawer for.
    /// </summary>
    [AttributeUsage (AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class CustomNodePropertyDrawerAttribute : Attribute {
        /// <summary>
        /// Defines which property attribute type the custom drawer is for.
        /// </summary>
        public readonly Type type;

        /// <summary>
        /// Class constructor.
        /// <param name="type">The attribute type that decorates the property to use the custom drawer.</param>
        /// </summary>
        public CustomNodePropertyDrawerAttribute(Type type) {
            this.type = type;
        }
    }
}