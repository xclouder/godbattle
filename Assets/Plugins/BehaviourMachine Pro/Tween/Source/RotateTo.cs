using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Rotates the "Game Object" to the supplied Euler angles in degrees over time.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Rotates the \"Game Object\" to the supplied Euler angles in degrees over time")]
    public class RotateTo : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The target Euler angles.
        /// </summary>
        [VariableInfo(tooltip = "The target Euler angles")]
        public Vector3Var rotation;

        /// <summary>
        /// For whether to animate in world space or relative to the parent.
        /// </summary>
        [Tooltip("For whether to animate in world space or relative to the parent")]
        public bool isLocal = false;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            rotation = new ConcreteVector3Var();
            isLocal = false;
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = isLocal ? transform.localEulerAngles : transform.eulerAngles;
            Vector3 to = rotation.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            if (isLocal)
                transform.localEulerAngles = rotation.Value;
            else
                transform.eulerAngles = rotation.Value;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);
                
            Apply();
            
            if (isLocal)
                transform.localEulerAngles = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            else
                transform.eulerAngles = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}