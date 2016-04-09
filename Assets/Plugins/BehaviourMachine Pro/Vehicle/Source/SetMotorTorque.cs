//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Change the motorTorque property of the "Game Object\'s" WheelCollider. Positive or negative values, depending on the direction.
    /// </summary>
    [NodeInfo(  category = "Action/WheelCollider/",
                icon = "WheelCollider",
                description = "Change the motorTorque property of the \"Game Object\'s\" WheelCollider. Positive or negative values, depending on the direction",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/WheelCollider-motorTorque.html")]
    public class SetMotorTorque : ActionNode, IFixedUpdateNode {

        /// <summary>
        /// A game object that has a WheelCollider.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "A game object that has a WheelCollider")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The "New Value" of the motorTorque.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Toggle", tooltip = "The \"New Value\" of the motorTorque")]
        public FloatVar newValue;

        WheelCollider m_WheelCollider;

        public override void Reset () {
            gameObject = new ConcreteGameObjectVar(this.self);
            newValue = 30f;
        }

        public override Status Update () {
            // Get the transform
            if (m_WheelCollider == null || m_WheelCollider.gameObject != gameObject.Value)
                m_WheelCollider = gameObject.Value != null ? gameObject.Value.GetComponent<WheelCollider>() : null;

            // Validate members?
            if  (m_WheelCollider == null || newValue.isNone) {
                return Status.Error;
            }

            // Set the motorTorque
            m_WheelCollider.motorTorque = newValue.Value;

            return Status.Success;
        }
    }
}