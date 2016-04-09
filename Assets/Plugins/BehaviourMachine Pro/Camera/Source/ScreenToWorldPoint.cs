//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Transforms position from screen space into world space.
    /// <seealso cref="BehaviourMachine.MovePosition" />
    /// </summary>
    [NodeInfo(  category = "Action/Camera/",
                icon = "Camera",
                description = "Transforms position from screen space into world space",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Camera.ScreenToWorldPoint.html")]
    public class ScreenToWorldPoint : ActionNode {

        /// <summary>
        /// The target camera.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Main Camera", tooltip = "The target camera")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The position in screen coordinates. The z position is in world units from the camera
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "The position in screen coordinates. The z position is in world units from the camera")]
        public Vector3Var position;

        /// <summary>
        /// The position in the x axis (overrides position.x).
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "The position in the x axis (overrides position.x)")]
        public FloatVar x;

        /// <summary>
        /// The position in the y axis (overrides position.y).
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "The position in the y axis (overrides position.y)")]
        public FloatVar y;

        /// <summary>
        /// The position in the z axis (overrides position.z). The z position is in world units from the camera.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "The position in the z axis (overrides position.z). The z position is in world units from the camera")]
        public FloatVar z;

        /// <summary>
        /// Stores the world position.
        /// </summary>
        [VariableInfo(tooltip = "Stores the world position")]
        public Vector3Var worldPosition;

        public override void Reset () {
            position = new ConcreteVector3Var();
            x = new ConcreteFloatVar();
            y = new ConcreteFloatVar();
            z = new ConcreteFloatVar();
            worldPosition = new ConcreteVector3Var();
        }

        public override Status Update () {
            // Get the camera
            Camera camera = !gameObject.isNone ? gameObject.Value.GetComponent<Camera>() : Camera.main;

            // Validate members?
            if  (camera == null)
                return Status.Error;

            // Get the desiredPosition
            Vector3 desiredPosition = !position.isNone ? position.Value : Vector3.zero;

            // Override values?
            if (!x.isNone) desiredPosition.x = x.Value;
            if (!y.isNone) desiredPosition.y = y.Value;
            if (!z.isNone) desiredPosition.z = z.Value;

            worldPosition.Value = camera.ScreenToWorldPoint(desiredPosition);

            return Status.Success;
        }
    }
}