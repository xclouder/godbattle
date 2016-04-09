//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

	/// <summary>
    /// Sets the camera background color.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Sets the camera background color",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Camera-main.html")]
	public class SetCameraBackgroundColor : ActionNode {

		/// <summary>
	    /// The camera to change the background color.
	    /// </summary>
		[VariableInfo (requiredField = false, nullLabel = "Main Camera", tooltip = "The camera to change the background color")]
		public GameObjectVar targetCamera;

        /// <summary>
        /// The new background color of the camera.
        /// </summary>
        [VariableInfo (tooltip = "The new background color of the camera")]
        public ColorVar newBackgroundColor;

		public override void Reset () {
            targetCamera = new ConcreteGameObjectVar();
			newBackgroundColor = new ConcreteColorVar();
		}

		public override Status Update () {
			// Get the camera
            Camera camera = null;

            if (targetCamera.isNone)
                camera = Camera.main;
            else if (targetCamera.Value != null)
                camera = targetCamera.Value.GetComponent<Camera>();

            // Validate members
            if (camera == null || newBackgroundColor.isNone)
                return Status.Error;

            // Set camera's background color
            camera.backgroundColor = newBackgroundColor.Value;
			return Status.Success;
		}
	}
}