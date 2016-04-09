//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Helper class to get Attributes of fields and classes.
    /// </summary>
    public class AttributeUtility {

        /// <summary>
        /// Returns the first Attribute T in the supplied class type, if found; otherwise null.
        /// <param name="type">The class type to search for the Attribute T.</param>
        /// <param name="inherite">True to search this member's inheritance chain to find the attributes.</param>
        /// </summary>
        public static T GetAttribute<T> (Type type, bool inherite) where T : Attribute  {
            if (type != null) {
                T[] attrs = type.GetCustomAttributes(typeof(T), inherite) as T[];
                if (attrs != null && attrs.Length > 0) {
                    return attrs[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the first Attribute T in the supplied memberInfo, if found; otherwise null.
        /// <param name="memberInfo">The target MemberInfo.</param>
        /// <param name="inherite">True to search this member's inheritance chain to find the attributes. This parameter is ignored for properties and events.</param>
        public static T GetAttribute<T> (MemberInfo memberInfo, bool inherite) where T : Attribute  {
            if (memberInfo != null) {
                T[] attrs = memberInfo.GetCustomAttributes(typeof(T), inherite) as T[];
                if (attrs != null && attrs.Length > 0) {
                    return attrs[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the description of an Enum value, if found; otherwise string.Empty.
        /// <param name="value">The Enum value that has a DescriptionAttribute in it.</param>
        public static string GetEnumDescription (Enum value) {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attrs = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
                return attrs[0].Description;
            else
                return string.Empty;
        }
    }
}

