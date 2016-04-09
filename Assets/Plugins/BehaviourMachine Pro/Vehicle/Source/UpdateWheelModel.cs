//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Updates the rotation and position (suspension) of a wheel 3D/2D model.
    /// </summary>
    [NodeInfo(  category = "Action/WheelCollider/",
                icon = "WheelCollider",
                description = "Updates the rotation and position (suspension) of a wheel model")]
    public class UpdateWheelModel : ActionNode {
        
        /// <summary>
        /// The target WheelCollider.
        /// </summary>
        [VariableInfo(tooltip = "The target WheelCollider")]
        public WheelCollider wheelCollider;

        /// <summary>
        /// The visual representation of the wheel.
        /// </summary>
        [VariableInfo(tooltip = "The visual representation of the wheel")]
        public Transform wheelModel;

        [System.NonSerialized]
        Vector3 m_OriginalPosition;
        [System.NonSerialized]
        Transform m_WheelColliderTransform;
        [System.NonSerialized]
        RaycastHit m_Hit;
        [System.NonSerialized]
        float m_SuspensionSpringPos;
        [System.NonSerialized]
        Quaternion m_OriginalRotation;
        [System.NonSerialized]
        float m_SpinAngle = 0f;

        public override void Reset () {
            wheelCollider = null;
            wheelModel = null;
        }

        public override void Awake () {
            if (wheelCollider != null)
                m_WheelColliderTransform = wheelCollider.transform;
            else
                m_WheelColliderTransform = null;

            if (wheelModel != null) {
                m_OriginalPosition = wheelModel.localPosition;
                m_OriginalRotation = wheelModel.localRotation;
            }
            else {
                m_OriginalPosition = Vector3.zero;
                m_OriginalRotation = Quaternion.identity;
            }
        }

        public override Status Update () {
            // Validate members?
            if  (wheelCollider == null || wheelModel == null) {
                return Status.Error;
            }

            // Update Position (suspension)
            if (Physics.Raycast(m_WheelColliderTransform.position, -m_WheelColliderTransform.up, out m_Hit, wheelCollider.suspensionDistance + wheelCollider.radius)) {
                m_SuspensionSpringPos = -(m_Hit.distance - wheelCollider.radius);
            }
            else {
                m_SuspensionSpringPos = -(wheelCollider.suspensionDistance);
            }

            wheelModel.localPosition = m_OriginalPosition + Vector3.up * m_SuspensionSpringPos;

            // Update Rotation
            m_SpinAngle += wheelCollider.rpm * 6 * Time.deltaTime;
            wheelModel.localRotation =  Quaternion.AngleAxis(wheelCollider.steerAngle, Vector3.up) * Quaternion.Euler(m_SpinAngle, 0, 0) * m_OriginalRotation;

            return Status.Success;
        }

        public override void OnValidate () {
            Awake();
        }
    }
}
