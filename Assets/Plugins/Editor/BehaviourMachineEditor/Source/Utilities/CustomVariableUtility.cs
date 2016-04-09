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
    /// Utility class with functions for custom variables.
    /// <seealso cref="BehaviourMachine.Variable" />
    /// </summary>
    public class CustomVariableUtility {

        static Dictionary<Type, Type[]> s_CustomVariables = new Dictionary<Type, Type[]>();

        /// <summary>
        /// Returns a list of derived types of the supllied variable that has the custom attribute.
        /// <param name="baseVariable">The base type of the variable.</param>
        /// <returns>An array of custom variables for the supplied type.</returns>
        /// </summary>
        public static Type[] GetCustomVariables (Type baseVariable) {
            Type[] customVariables = null;
            s_CustomVariables.TryGetValue(baseVariable, out customVariables);
            if (customVariables != null)
                return customVariables;

            // Create a list o derived custom vars
            var customVarsList = new List<Type>();

            // Get the derived types
            foreach (System.Type derivedType in TypeUtility.GetDerivedTypes(baseVariable)) {
                var customVarAttr = AttributeUtility.GetAttribute<CustomVariableAttribute>(derivedType, false);
                // Is there a CustomVariableAttribute on the derivedType? 
                if (customVarAttr != null)
                    customVarsList.Add(derivedType);
            }

            customVariables = customVarsList.ToArray();
            s_CustomVariables.Add(baseVariable, customVariables);
            
            return customVariables;
        }
    }
}


















