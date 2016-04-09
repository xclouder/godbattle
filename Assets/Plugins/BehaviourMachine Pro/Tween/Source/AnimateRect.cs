using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate a Rect value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate a Rect value")]
    public class AnimateRect : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target Rect to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target Rect to animate")]
        public RectVar target;

        /// <summary>
        /// The Rect value.
        /// </summary>
        [VariableInfo(tooltip = "The Rect value")]
        public RectVar rectValue;

        [System.NonSerialized]
        Rect to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            target = new ConcreteRectVar();
            rectValue = new ConcreteRectVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Rect from = target.Value;
            to = rectValue.Value;

            m_From = new float[] {from.x, from.y, from.width, from.height};
            m_To = new float[] {to.x, to.y, to.width, to.height};
            m_Result = new float[4];
        }

        public override void OnFinish () {
            target.Value = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            target.Value = new Rect(m_Result[0], m_Result[1], m_Result[2], m_Result[3]);
        }
    }
}