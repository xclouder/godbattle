using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Animate a Quaterion value.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Animate a Quaterion value")]
    public class AnimateQuaternion : TweenNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target Quaterion to animate.
        /// </summary>
        [VariableInfo(canBeConstant = false, tooltip = "The target Quaterion to animate")]
        public QuaternionVar target;

        /// <summary>
        /// The euler angle value.
        /// </summary>
        [VariableInfo(tooltip = "The euler angle value")]
        public Vector3Var vectorValue;

        [System.NonSerialized]
        Vector3 to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            target = new ConcreteQuaternionVar();
            vectorValue = new ConcreteVector3Var();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = target.Value.eulerAngles;
            to = vectorValue.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            Quaternion newValue = Quaternion.identity;
            newValue.eulerAngles = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            target.Value = newValue;
        }

        public override void OnFinish () {
            Quaternion newValue = Quaternion.identity;
            newValue.eulerAngles = to;
            target.Value = newValue;
        }
    }
}