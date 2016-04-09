using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Moves the "Game Object" to the desired position using the transform.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Moves the \"Game Object\" to the desired position using the transform")]
    public class MoveTo : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The desired position.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The desired position")]
        public GameObjectVar desiredPosition;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            desiredPosition = new ConcreteGameObjectVar(this.self);
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = gameObject.Value != null ? gameObject.Value.transform.position : Vector3.zero;
            Vector3 to = desiredPosition.Value != null ? desiredPosition.Value.transform.position : Vector3.zero;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            transform.position = desiredPosition.Value != null ? desiredPosition.Value.transform.position : Vector3.zero;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            transform.position = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}