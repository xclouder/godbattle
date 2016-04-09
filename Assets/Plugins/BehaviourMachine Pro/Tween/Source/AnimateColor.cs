using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate a color value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate a color value")]
    public class AnimateColor : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target color to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target color to animate")]
        public ColorVar targetColor;

        /// <summary>
        /// The color value.
        /// </summary>
        [VariableInfo(tooltip = "The color value")]
        public ColorVar color;

        [System.NonSerialized]
        Color to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            targetColor = new ConcreteColorVar();
            color = new ConcreteColorVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Color from = targetColor.Value;
            to = color.Value;

            m_From = new float[] {from.r, from.g, from.b, from.a};
            m_To = new float[] {to.r, to.g, to.b, to.a};
            m_Result = new float[4];
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            targetColor.Value = new Color(m_Result[0], m_Result[1], m_Result[2], m_Result[3]);
        }

        public override void OnFinish () {
            targetColor.Value = to;
        }
    }
}