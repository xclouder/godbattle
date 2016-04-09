using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate an int value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate an int value")]
    public class AnimateInt : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target int to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target int to animate")]
        public IntVar target;

        /// <summary>
        /// The float value.
        /// </summary>
        [VariableInfo(tooltip = "The float value")]
        public IntVar intValue;

        [System.NonSerialized]
        int to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            target = new ConcreteIntVar();
            intValue = new ConcreteIntVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            to = intValue.Value;

            m_From = new float[] {(float) target.Value};
            m_To = new float[] {(float) to};
            m_Result = new float[1];
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            target.Value = (int) m_Result[0];
        }

        public override void OnFinish () {
            target.Value = to;
        }
    }
}