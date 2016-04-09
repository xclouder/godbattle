using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate a float value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate a float value")]
    public class AnimateFloat : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target float to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target float to animate")]
        public FloatVar target;

        /// <summary>
        /// The float value.
        /// </summary>
        [VariableInfo(tooltip = "The float value")]
        public FloatVar floatValue;

        [System.NonSerialized]
        float to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            target = new ConcreteFloatVar();
            floatValue = new ConcreteFloatVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            to = floatValue.Value;

            m_From = new float[] {target.Value};
            m_To = new float[] {to};
            m_Result = new float[1];
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            target.Value = m_Result[0];
        }

        public override void OnFinish () {
            target.Value = to;
        }
    }
}