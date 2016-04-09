using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// The Agent has reached its destination?
    /// </summary>
    [NodeInfo(  category = "Condition/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "The Agent has reached its destination?")]
    public class IsInDestination : ConditionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// A threshould value added to the destination distance comparision.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "A threshould value added to the destination distance comparision")]
        public FloatVar pathEndThreshold;

        [System.NonSerialized]
        NavMeshAgent m_Agent = null;

        public override void Reset () {
            gameObject = this.self;
            pathEndThreshold = .1f;
        }

        public override Status Update () {
            // Get the renderer
            if (m_Agent == null || m_Agent.gameObject != gameObject.Value)
                m_Agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members?
            if  (m_Agent == null)
                return Status.Error;

            if (m_Agent.hasPath && m_Agent.pathStatus == NavMeshPathStatus.PathComplete && m_Agent.remainingDistance <= m_Agent.stoppingDistance + pathEndThreshold.Value)
                return Status.Success;
            else
                return Status.Failure;
        }
    }
}