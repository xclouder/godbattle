//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {
    /// <summary>
    /// Utility class to set and get field values of objects.
    /// </summary>
    public class FunctionUtility {

        public static bool IsSupported (Type type) {
            if (!type.IsValueType) {
                return type == typeof(string) || typeof(UnityEngine.Object).IsAssignableFrom(type);
            }
            else if (type == typeof(int) || type == typeof(float) || type == typeof(bool) || type == typeof(Vector3) || type == typeof(Quaternion) || type == typeof(Rect) || type == typeof(Color)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get public MethodInfos in a type.
        /// <param name="type">The type of the target object to get the methods.</param>
        /// <param name="staticMethods">If True returns only static members; otherwise returns instance members.</param>
        /// <returns>Public methods in a type.</returns>
        /// </summary>
        public static MethodInfo[] GetPublicMembers (System.Type type, bool staticMethods) {
            List<MethodInfo> methodInfos = new List<MethodInfo>();
            BindingFlags bindingFlags = staticMethods ? BindingFlags.Public | BindingFlags.Static : BindingFlags.Public | BindingFlags.Instance;

            foreach (MethodInfo method in type.GetMethods(bindingFlags)) {
                Type returnType = method.ReturnParameter.ParameterType;
                
                if (returnType == typeof(void) || FunctionUtility.IsSupported(returnType)) {
                    bool validParameters = true;

                    foreach (ParameterInfo parameter in method.GetParameters()) {
                        if (!FunctionUtility.IsSupported(parameter.ParameterType)) {
                            validParameters = false;
                            break;
                        }
                    }
                    
                    if (validParameters)
                        methodInfos.Add(method);
                }
            }

            return methodInfos.ToArray();
        }
    }
}

