//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

	/// <summary>
    /// Sets the camera field of view.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Sets the camera field of view",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Camera-main.html")]
	public class SetCameraFOV : ActionNode {

		/// <summary>
	    /// The camera to change the background color.
	    /// </summary>
		[VariableInfo (requiredField = false, nullLabel = "Main Camera", tooltip = "The camera to change the background color")]
		public GameObjectVar targetCamera;

        /// <summary>
        /// The new field of view of the camera.
        /// </summary>
        [VariableInfo (tooltip = "The new field of view of the camera")]
        public FloatVar newFieldOfView;

		public override void Reset () {
            targetCamera = new ConcreteGameObjectVar();
			newFieldOfView = 60f;
		}

		public override Status Update () {
			// Get the camera
            Camera camera = null;

            if (targetCamera.isNone)
                camera = Camera.main;
            else if (targetCamera.Value != null)
                camera = targetCamera.Value.GetComponent<Camera>();

            // Validate members
            if (camera == null || newFieldOfView.isNone)
                return Status.Error;

            // Set camera's background color
            camera.fieldOfView = newFieldOfView.Value;
			return Status.Success;
		}
	}
}