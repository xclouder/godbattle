using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Randomly shakes a GameObject's position by a diminishing amount over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Randomly shakes a GameObject\'s position by a diminishing amount over time")]
    public class ShakePosition : TweenGameObjectNode {

        /// <summary>
        /// Amount to shake the position.
        /// </summary>
        [VariableInfo(tooltip = "Amount to shake the position")]
        public Vector3Var amount;

        /// <summary>
        /// For whether to animate in world space or relative to the parent.
        /// </summary>
        [Tooltip("For whether to animate in world space or relative to the parent")]
        public bool isLocal = false;

        [System.NonSerialized]
        Vector3 from;

        public override void Reset () {
            base.Reset();
            amount = new ConcreteVector3Var();
        }

        public override void OnStart () {
            from = isLocal ? transform.localPosition : transform.position;
            Vector3 to = amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[] {0f, 0f, 0f};
        }

        public override void OnFinish () {
            if (isLocal)
                transform.localPosition = from;
            else
                transform.position = from;
        }

        public override void OnUpdate () {
            // Reset position
            if (isLocal)
                transform.localPosition = from;
            else
                transform.position = from;

            // Apply
            ApplyShake();

            // Set new position
            if (isLocal)
                transform.localPosition += new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            else
                transform.position += new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}