//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Draws a colorized GUI texture over the camera.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Draws a colorized GUI texture over the camera")]
    public class CameraOverlayColor : ActionNode {

        /// <summary>
        /// The overlay color.
        /// </summary>
        [VariableInfo(tooltip = "The overlay color")]
        public ColorVar color;

        public override void Reset () {
            color = Color.black * .5f;
        }

        public override void Start () {
            GUICallback.onGUI += OnGUI;
        }

        public override Status Update () {
            if (color.isNone)
                return Status.Error;

            return Status.Running;
        }

        public override void End () {
            GUICallback.onGUI -= OnGUI;
        }


        #region GUI
        public CameraOverlayColor () {
            // Create guiCallback
            InternalGlobalBlackboard.CreateGUICallback();
        }

        void OnGUI () {
            if (status == Status.Running) {
                Color oldGuiColor = GUI.color;
                GUI.color = color.Value;

                GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), NodeUtility.whiteTexture);

                GUI.color = oldGuiColor;
            }
        }
        #endregion GUI
    }
}