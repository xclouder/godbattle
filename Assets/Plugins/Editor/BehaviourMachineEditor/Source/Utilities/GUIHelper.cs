//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    public class GUIHelper {

        public static bool EditorButton (Rect position, int controlID, GUIContent content, GUIStyle style) {
            switch (Event.current.GetTypeForControl(controlID)) {
                case EventType.MouseDown:
                    if (position.Contains(Event.current.mousePosition)) {
                        EditorGUIUtility.hotControl = controlID;
                        Event.current.Use();
                    }
                    return false;

                case EventType.MouseUp:
                    if (EditorGUIUtility.hotControl == controlID) {
                        EditorGUIUtility.hotControl = 0;
                        EditorGUIUtility.keyboardControl = controlID;
                        Event.current.Use();
                        return position.Contains(Event.current.mousePosition);
                    }
                    return false;

                #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2
                case EventType.KeyDown:
                    if (EditorGUIUtility.keyboardControl == controlID && Event.current.keyCode == KeyCode.Space && (int)Event.current.modifiers == 0) {
                        Event.current.Use();
                        return true;
                    }
                    break;
                #endif

                case EventType.MouseDrag:
                    if (EditorGUIUtility.hotControl == controlID)
                        Event.current.Use();
                    break;

                case EventType.Repaint:
                    style.Draw(position, content, controlID);
                    break;
            }
            
            return false;
        }
    }
}