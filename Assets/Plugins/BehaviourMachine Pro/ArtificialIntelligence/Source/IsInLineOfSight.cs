using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Is in line of sight?
    /// </summary>
    [NodeInfo(  category = "Condition/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "Is in line of sight?")]
    public class IsInLineOfSight : ConditionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The game object to test if is in line of sight.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object to test if is in line of sight")]
        public GameObjectVar target;

        /// <summary>
        /// The max distance of the sight.
        /// </summary>
        [VariableInfo(tooltip = "The max distance of the sight")]
        public FloatVar maxDistanceSight;

        /// <summary>
        /// The max angle of the sight in percentage (1 is 360 degrees of view, 0.5 is 180 degrees of view).
        /// </summary>
        [Range(0f, 1f)]
        [VariableInfo(tooltip = "The max angle of the sight in percentage (1 will get 360 degrees of view, 0.5 is 180 degrees of view)")]
        public FloatVar maxAngleSight;

        /// <summary>
        /// The local direction that the Game Object is looking for.
        /// </summary>
        [VariableInfo(tooltip = "The local direction that the Game Object is looking for")]
        public Vector3Var localDirection;

        [System.NonSerialized]
        NavMeshAgent m_Agent = null;

        public override void Reset () {
            gameObject = this.self;
            target = this.self;
            maxDistanceSight = 10f;
            maxAngleSight = .5f;
            localDirection = Vector3.forward;
        }

        public override Status Update () {
            // Get the renderer
            if (m_Agent == null || m_Agent.gameObject != gameObject.Value)
                m_Agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members?
            if  (m_Agent == null || target.Value == null)
                return Status.Error;

            // Calcaulate the delayed timer
            NavMeshHit hit;
            Vector3 targetPos = target.transform.position;
            Vector3 currentPos = gameObject.transform.position;
            if (!m_Agent.Raycast(target.transform.position, out hit) && Vector3.Distance(currentPos, targetPos) < maxDistanceSight.Value && (Vector3.Dot(gameObject.transform.TransformDirection(localDirection.Value).normalized, (targetPos - currentPos).normalized) + 1f) * .5f >= 1f - maxAngleSight.Value) {
                // Send event?
                if (onSuccess.id != 0)
                    owner.root.SendEvent(onSuccess.id);
                    
                return Status.Success;
            }
            else
                return Status.Failure;
        }
    }
}