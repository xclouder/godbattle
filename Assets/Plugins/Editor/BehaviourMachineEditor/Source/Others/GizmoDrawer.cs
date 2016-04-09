//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {
    /// <summary> 
    /// Gizmo drawer callbacks.
    /// </summary>
    public class GizmoDrawer {

        #region Styles
        static GizmoDrawer.Styles s_Styles;

        /// <summary> 
        /// Class to store GUIStyles that are used by the GizmoDrawer.
        /// </summary>
        class Styles {
            public readonly GUIStyle enabledStateName;

            public Styles () {
                enabledStateName = new GUIStyle("MeTransitionSelect");
                enabledStateName.alignment = TextAnchor.UpperLeft;
                enabledStateName.padding = new RectOffset (2, 2, 1, 1);
                enabledStateName.fontStyle = FontStyle.Bold;
                enabledStateName.normal.textColor = Color.white;
            }
        }
        #endregion Styles

        /// <summary> 
        /// Draws the name of the enabled states.
        /// <param name="blackboard">The GameObject's blackboard.</param>
        /// <param name="blackboard">Type of object for which the gizmo should be drawn.</param>
        /// </summary>
    	[DrawGizmo(GizmoType.NotInSelectionHierarchy | GizmoType.Selected)]
        static void EnabledStatesNameGizmo (InternalBlackboard blackboard, GizmoType gizmoType) {
            //  Is in playmode?
            if (EditorApplication.isPlaying && BehaviourMachinePrefs.enabledStateName) {
                // The styles is null?
                if (s_Styles == null)
                    s_Styles = new GizmoDrawer.Styles();

                // Get root parents
                var rootParents = blackboard.GetEnabledRootParents();
                Camera currentCamera = Camera.current;

                // There is at least one fsm enabled?
                if (rootParents.Length <= 0 || currentCamera == null)
                    return;

                // The object is visible by the camera?
                Vector3 position = blackboard.transform.position;
                Vector3 viewportPoint = currentCamera.WorldToViewportPoint(position);
                if (viewportPoint.z <= 0 || !(new Rect(0, 0, 1, 1)).Contains(viewportPoint))
                    return;

                // Get enabled state names
                string names = rootParents[0].GetEnabledStateName();
                for (int i = 1; i < rootParents.Length; i++)
                    names += "\n" + rootParents[i].GetEnabledStateName();

                // Handles.Label has an offset bug when working with styles that are not MiddleLeft, bellow is a workaround to center the text.
                GUIContent nameContent = new GUIContent(names);
                Vector2 size = s_Styles.enabledStateName.CalcSize(nameContent);
                Vector3 screenPoint = currentCamera.WorldToScreenPoint(position);
                position = currentCamera.ScreenToWorldPoint(new Vector3(screenPoint.x - size.x * .5f, screenPoint.y, - screenPoint.z));

                // Draw enabled states name
                Handles.Label(position, nameContent, s_Styles.enabledStateName);
            }
        }
    }
}