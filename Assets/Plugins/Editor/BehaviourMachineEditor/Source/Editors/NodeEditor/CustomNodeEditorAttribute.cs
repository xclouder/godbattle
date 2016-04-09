//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Tells a NodeEditor class which run-time type it's an editor for.
    /// <seealso cref="BehaviourMachineEditor.NodeEditor" />
    /// </summary>
    [AttributeUsage (AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class CustomNodeEditorAttribute : Attribute {
        /// <summary>
        /// Defines which object type the custom editor class can edit.
        /// </summary>
        public readonly Type inspectedType;

        /// <summary>
        /// If true the editor will be used for the children class too.
        /// </summary>
        public readonly bool editorForChildClasses;

        /// <summary>
        /// Class constructor.
        /// <param name="inspectedType">The type to be editor by the custom editor.</param>
        /// <param name="editorForChildClasses">Should the editor be used to edit children classes?</param>
        /// </summary>
        public CustomNodeEditorAttribute(Type inspectedType, bool editorForChildClasses = false) {
            this.inspectedType = inspectedType;
            this.editorForChildClasses = editorForChildClasses;
        }
    }
}