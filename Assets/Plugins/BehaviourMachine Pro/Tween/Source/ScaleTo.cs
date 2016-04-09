using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Changes the "Game Object" scale over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Changes the \"Game Object\" scale over time")]
    public class ScaleTo : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target scale.
        /// </summary>
        [VariableInfo(tooltip = "The target scale")]
        public Vector3Var scale;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            scale = new ConcreteVector3Var();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = transform.localScale;
            Vector3 to = scale.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            transform.localScale = scale.Value;
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