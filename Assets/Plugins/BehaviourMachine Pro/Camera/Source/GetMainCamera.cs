//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

	/// <summary>
    /// Gets the main camera.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Gets the main camera",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Camera-main.html")]
	public class GetMainCamera : ActionNode {

		/// <summary>
	    /// Store the main camera.
	    /// </summary>
		[VariableInfo (canBeConstant = false, tooltip = "Store the main camera")]
		public GameObjectVar storeMainCamera;

		public override void Reset () {
			storeMainCamera = new ConcreteGameObjectVar();
		}

		public override Status Update () {
			if (storeMainCamera.isNone)
				return Status.Error;

			storeMainCamera.Value = Camera.main.gameObject;

			return Status.Success;
		}
	}
}