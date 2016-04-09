using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Applies a jolt of force to the Game Object's scale and returns it back to its original scale.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Applies a jolt of force to the Game Object\'s scale and returns it back to its original scale")]
    public class PunchScale : TweenGameObjectNode {

        /// <summary>
        /// Amount to punch the rotation.
        /// </summary>
        [VariableInfo(tooltip = "Amount to punch the rotation")]
        public Vector3Var amount;

        public override void Reset () {
            base.Reset();
            amount = new ConcreteVector3Var();
        }

        public override void OnStart () {
            Vector3 from = transform.localScale;
            Vector3 to = amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[] {0f, 0f, 0f};
        }

        public override void OnFinish () {
            
        }

        public override void OnUpdate () {
            ApplyPunch();
            
            // Apply
            transform.localScale = new Vector3(m_From[0], m_From[1], m_From[2]) + new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}