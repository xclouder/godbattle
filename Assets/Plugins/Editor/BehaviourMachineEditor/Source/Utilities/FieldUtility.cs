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
    public class FieldUtility {
        public static object GetValue (object target, string fieldName) {
            FieldInfo fieldInfo = GetFieldInfo(target, fieldName);
            return fieldInfo != null ? fieldInfo.GetValue(target) : null;
        }

        public static void SetValue (object target, string fieldName, object value) {
            FieldInfo fieldInfo = GetFieldInfo(target, fieldName);
            if (fieldInfo != null)
                fieldInfo.SetValue(target, value);
        }

        public static FieldInfo GetFieldInfo (object target, string fieldName) {
            FieldInfo fieldInfo = null;

            if (target != null) {
                Type currentType = target.GetType();

                // Search for the field in the class hierarchy
                do {
                    fieldInfo = currentType.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                    currentType = currentType.BaseType;
                } while (fieldInfo == null && currentType != null);
            }

            if (fieldInfo == null)
                Print.LogError(target.GetType() + " has no field " + fieldName);

            return fieldInfo;
        }

        public static FieldInfo[] GetFieldInfos (object target, System.Type type, bool includeArray = false) {
            List<FieldInfo> fieldInfos = new List<FieldInfo>();

            if (target != null && type != null) {
                Type currentType = target.GetType();

                // Search for fields in the class hierarchy
                do {
                    // Get fields
                    var fields = currentType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
                    foreach (var field in fields) {
                        if (field != null && fieldInfos.FirstOrDefault(x => x.Name == field.Name) == null) {
                            // The field inherites from the supplied type?
                            if (field.FieldType != null && (field.FieldType == type || field.FieldType.IsSubclassOf(type))) {
                                fieldInfos.Add(field);
                            }
                            // Include arrays?
                            else if (includeArray && typeof(IList).IsAssignableFrom(field.FieldType)/*field.FieldType.IsArray && fieldInfos.FirstOrDefault(x => x.Name == field.Name) == null && (field.FieldType.GetElementType() == type || field.FieldType.GetElementType().IsSubclassOf(type))*/) {
                                var list = (IList)field.GetValue(target);
                                var exit = false;
                                for(var i = 0; i < list.Count && !exit; i++) {
                                    if (list[i] != null && (list[i].GetType() == type || list[i].GetType().IsSubclassOf(type))) {
                                        fieldInfos.Add(field);
                                        exit = true;
                                    }
                                }
                            }
                        }
                        // else if (field != null && field.FieldType.IsArray)
                        //     Debug.Log(field.Name + " " + field.FieldType.GetElementType().IsSubclassOf(type));

                    }
                    // Update currentType
                    currentType = currentType.BaseType;
                } while (currentType != null);
            }

            return fieldInfos.ToArray();
        }

        /// <summary>
        /// Get public FieldInfo and PropertyInfo in a type.
        /// <param name="type">The type of the target object to get the fields and properties.</param>
        /// <param name="propertyType">The type of the property or field; or null if you want to get all field and properties in that type.</param>
        /// <param name="staticMembers">If True returns only static members; otherwise returns instance members.</param>
        /// <param name="canWrite">If True includes properties that can be set; otherwise uses param canRead to filter properties.</param>
        /// <param name="canRead">If True includes properties that can be get; otherwise uses param canWrite to filter properties.</param>
        /// <returns>Public properties and fields in type.</returns>
        /// </summary>
        public static MemberInfo[] GetPublicMembers (System.Type type, System.Type propertyType, bool staticMembers, bool canWrite, bool canRead) {
            List<MemberInfo> memberInfos = new List<MemberInfo>();
            BindingFlags bindingFlags = staticMembers ? BindingFlags.Public | BindingFlags.Static : BindingFlags.Public | BindingFlags.Instance;

            foreach (FieldInfo field in type.GetFields(bindingFlags)) {
                if ((propertyType == null || field.FieldType == propertyType))
                    memberInfos.Add(field);
            }
            
            foreach (PropertyInfo property in type.GetProperties(bindingFlags)) {
                if ((propertyType == null || property.PropertyType == propertyType)) {
                    if ((canRead && property.CanRead && (!canWrite || property.CanWrite)) || (canWrite && property.CanWrite && (!canRead || property.CanRead))) {
                        memberInfos.Add(property);
                    }
                }
            }

            return memberInfos.ToArray();
        }

        /// <summary>
        /// Returns all field values in that has the supplied attribute.
        /// <param name="target">The type to get field and properties.</param>
        /// <param name="attributeType">If True includes properties that can be set; otherwise uses param canRead to filter properties.</param>
        /// <returns>The field values.</returns>
        /// </summary>
        public static object[] GetFieldValues (object target, Type attributeType) {
            var objects = new List<object>();

            if (target != null) {
                Type currentType = target.GetType();
                do {
                    // Get all custom attributes
                    foreach (FieldInfo field in currentType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy)) {
                        if (field != null && field.GetCustomAttributes(attributeType, true).Length > 0) {
                            var value = field.GetValue(target);
                            if (value != null && !objects.Contains(value))
                                objects.Add(value);
                        }
                    }
                    currentType = currentType.BaseType;
                } while (currentType != null);
            }
            return objects.ToArray();
        }

        /// <summary>
        /// Returns whenever the supplied type has the supplied member.
        /// <param name="target">The targetType.</param>
        /// <param name="memberName">If True includes properties that can be set; otherwise uses param canRead to filter properties.</param>
        /// <returns>True if the supplied type has the member; False otherwise.</returns>
        /// </summary>
        public static bool HasMember (Type target, string memberName) {
            return target != null && !string.IsNullOrEmpty(memberName) && ((target.GetProperty(memberName) != null) || (target.GetField(memberName) != null));
        }
    }
}

