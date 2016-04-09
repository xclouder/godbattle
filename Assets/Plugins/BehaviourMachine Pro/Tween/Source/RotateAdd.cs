using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Adds supplied Euler angles in degrees to a GameObject's rotation over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Adds supplied Euler angles in degrees to a GameObject's rotation over time")]
    public class RotateAdd : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The amount of Euler angles to add to the rotation.
        /// </summary>
        [VariableInfo(tooltip = "The amount of Euler angles to add to the rotation")]
        public Vector3Var amount;

        /// <summary>
        /// For whether to animate in world space or relative to the parent.
        /// </summary>
        [Tooltip("For whether to animate in world space or relative to the parent")]
        public bool isLocal = false;

        [System.NonSerialized]
        Vector3 to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            amount = new ConcreteVector3Var();
            isLocal = false;
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = isLocal ? transform.localEulerAngles : transform.eulerAngles;
            to = from + amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            if (isLocal)
                transform.localEulerAngles = to;
            else
                transform.eulerAngles = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            if (isLocal)
                transform.localEulerAngles = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            else
                transform.eulerAngles = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}