using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Adds the supplied coordinates to a Game Object's position.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Adds the supplied coordinates to a Game Object's position",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/Transform.Translate.html")]
    public class MoveAdd : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// Amount to add to the position.
        /// </summary>
        [VariableInfo(tooltip = "Amount to add to the position")]
        public Vector3Var amount;

        /// <summary>
        /// For whether to animate in world space or relative to the parent.
        /// </summary>
        [Tooltip("For whether to animate in world space or relative to the parent")]
        public bool isLocal = false;

        [System.NonSerialized]
        Vector3 to;

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            amount = new ConcreteVector3Var();
            isLocal = false;
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }

        public override void OnStart () {
            Vector3 from = isLocal ? transform.localPosition : transform.position;
            to = from + amount.Value;

            m_From = new float[] {from.x, from.y, from.z};
            m_To = new float[] {to.x, to.y, to.z};
            m_Result = new float[3];
        }

        public override void OnFinish () {
            if (isLocal)
                transform.localPosition = to;
            else
                transform.position = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);
                
            Apply();
            
            if (isLocal)
                transform.localPosition = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
            else
                transform.position = new Vector3(m_Result[0], m_Result[1], m_Result[2]);
        }
    }
}