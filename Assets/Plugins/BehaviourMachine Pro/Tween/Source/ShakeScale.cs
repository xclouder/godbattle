using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Randomly shakes a GameObject's scale by a diminishing amount over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Randomly shakes a GameObject\'s scale by a diminishing amount over time")]
    public class ShakeScale : TweenGameObjectNode {

        /// <summary>
        /// Amount to shake the scale.
        /// </summary>
        [VariableInfo(tooltip = "Amount to shake the scale")]
        public Vector3Var amount;

        [System.NonSerialized]
        Vector3 from;

        public override void Reset () {
            base.Reset();
            amount = new ConcreteVector3Var();
        }

        public override void OnStart () {
            from = transform.localScale;
            Vector3 to = amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[] {0f, 0f, 0f};
        }

        public override void OnFinish () {
            transform.localScale = from;
        }

        public override void OnUpdate () {
            // Reset scale
            transform.localScale = from;

            // Apply
            ApplyShake();

            // Set new scale
            transform.localScale += new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}