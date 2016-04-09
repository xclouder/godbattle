//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourMachineEditor {
    /// <summary>
    /// Utility class to get editor types.
    /// </summary>
    public class EditorTypeUtility {

        static Assembly[] s_LoadedAssemblies;
        static Dictionary<string, Type> s_LoadedType = new Dictionary<string, Type>();

        #region Properties
        /// <summary>
        /// Editor assemblies.
        /// </summary>
        public static Assembly[] loadedAssemblies {
            get {
                if (s_LoadedAssemblies == null) {
                    // Get the editor asm
                    var editorAsms = new List<Assembly>();
                    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies()) {
                        if (asm.GetName().Name.Contains("Editor")) {
                            editorAsms.Add(asm);
                        }
                    }
                    s_LoadedAssemblies = editorAsms.ToArray();
                }

                return s_LoadedAssemblies;
            }
        }
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Returns the children classes of the supplied type.
        /// <param name="baseType">The base type.</param>
        /// <returns>The children classes of baseType.</returns>
        /// </summary>
        public static System.Type[] GetDerivedTypes (System.Type baseType) {
            // Create the derived type list
            var derivedTypes = new List<System.Type>();

            foreach (Assembly asm in EditorTypeUtility.loadedAssemblies) {
                // Get types
                Type[] exportedTypes;

                try {
                    exportedTypes = asm.GetExportedTypes();
                }
                catch (ReflectionTypeLoadException) {
                    UnityEngine.Debug.LogWarning(string.Format("Behaviour Machine will ignore the following assembly due to type-loading errors: {0} ({1})", asm.FullName, asm.Location));
                    continue;
                }
                
                for (int i = 0; i < exportedTypes.Length; i++) {
                    // Get type
                    Type type = exportedTypes[i];
                    // The type is a subclass of baseType?
                    if (!type.IsAbstract && type.IsSubclassOf(baseType) && type.FullName != null) {
                        derivedTypes.Add(type);
                    }
                }
            }
            derivedTypes.Sort((Type o1, Type o2) => o1.ToString().CompareTo (o2.ToString ()));
            return derivedTypes.ToArray();
        }

        /// <summary>
        /// Returns the System.Type of the supplied name.
        /// <param name="name">The type name.</param>
        /// <returns>The System.Type of the supplied string.</returns>
        /// </summary>
        public static Type GetType (string name) {
            // Try get type
            Type type = null;
            if (s_LoadedType.TryGetValue(name, out type))
                return type;

            // Try C# scripts
            type = Type.GetType (name + ",Assembly-CSharp-Editor-firstpass") ?? Type.GetType (name + ",Assembly-CSharp-Editor");

            // Try AppDomain
            if (type == null) {
                // Get type
                foreach (Assembly asm in EditorTypeUtility.loadedAssemblies) {
                    type = asm.GetType (name);
                    if (type != null)
                        break;
                }
            }

            // Add type
            s_LoadedType.Add(name, type);

            return type;
        }
        #endregion Public Methods
    }
}