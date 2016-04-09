using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Adds to the GameObject's scale over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Adds to the GameObject's scale over time")]
    public class ScaleAdd : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The amount to add to the scale.
        /// </summary>
        [VariableInfo(tooltip = "The amount to add to the scale")]
        public Vector3Var amount;

        [System.NonSerialized]
        Vector3 to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            amount = new ConcreteVector3Var();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = transform.localScale;
            to = from + amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            transform.localScale = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            transform.localScale = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}