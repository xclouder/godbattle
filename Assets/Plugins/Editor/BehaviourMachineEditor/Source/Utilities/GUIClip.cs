//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;
using System.Reflection;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Wrapper class for the internal UnityEngine.GUIClip type.
    /// </summary>
    public class GUIClip {

        static System.Type s_Type;
        static MethodInfo s_UnclipMethodV2;

        static System.Type type {
            get {
                if (s_Type == null)
                    s_Type = Types.GetType("UnityEngine.GUIClip", "UnityEngine.dll");
                return s_Type;
            }
        }

        /// <summary>
        /// Returns an uncliped poistion on the GUI.
        /// <param name="pos">The position to be uncliped.</param>
        /// <returns>The uncliped value of supplied position.</returns>
        /// </summary>
    	public static Vector2 Unclip (Vector2 pos) {
            if (s_UnclipMethodV2 == null)
                s_UnclipMethodV2 = type.GetMethod("Unclip", new System.Type[] {typeof(Vector2)});
            return (Vector2) s_UnclipMethodV2.Invoke(null, new object[] {pos});
        }
    }
}