//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

	/// <summary>
    /// Gets the current camera.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Gets the current camera",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Camera-current.html")]
	public class GetCurrentCamera : ActionNode {

		/// <summary>
	    /// Store the current camera.
	    /// </summary>
		[VariableInfo (canBeConstant = false, tooltip = "Store the current camera")]
		public GameObjectVar storeCurrentCamera;

		public override void Reset () {
			storeCurrentCamera = new ConcreteGameObjectVar();
		}

		public override Status Update () {
			if (storeCurrentCamera.isNone)
				return Status.Error;

			storeCurrentCamera.Value = Camera.current.gameObject;
			return Status.Success;
		}
	}
}