using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate a Vector3 value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate a Vector3 value")]
    public class AnimateVector3 : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target Vector3 to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target Vector3 to animate")]
        public Vector3Var target;

        /// <summary>
        /// The Vector3 value.
        /// </summary>
        [VariableInfo(tooltip = "The Vector3 value")]
        public Vector3Var vectorValue;

        [System.NonSerialized]
        Vector3 to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            target = new ConcreteVector3Var();
            vectorValue = new ConcreteVector3Var();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = target.Value;
            to = vectorValue.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            target.Value = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            target.Value = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}