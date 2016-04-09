//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Change the steerAngle property of the "Game Object\'s" WheelCollider, always around the y-axis.
    /// </summary>
    [NodeInfo(  category = "Action/WheelCollider/",
                icon = "WheelCollider",
                description = "Change the steerAngle property of the \"Game Object\'s\" WheelCollider, always around the y-axis",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/WheelCollider-steerAngle.html")]
    public class SetSteerAngle : ActionNode, IFixedUpdateNode {

        /// <summary>
        /// A game object that has a WheelCollider.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "A game object that has a WheelCollider")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The "New Value" of the steerAngle.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Toggle", tooltip = "The \"New Value\" of the steerAngle")]
        public FloatVar newValue;

        [System.NonSerialized]
        WheelCollider m_WheelCollider;

        public override void Reset () {
            gameObject = new ConcreteGameObjectVar(this.self);
            newValue = 30f;
        }

        public override Status Update () {
            // Get the WheelCollider
            if (m_WheelCollider == null || m_WheelCollider.gameObject != gameObject.Value)
                m_WheelCollider = gameObject.Value != null ? gameObject.Value.GetComponent<WheelCollider>() : null;

            // Validate members?
            if  (m_WheelCollider == null || newValue.isNone)
                return Status.Error;

            // Set the steerAngle
            m_WheelCollider.steerAngle = newValue.Value;

            return Status.Success;
        }
    }
}