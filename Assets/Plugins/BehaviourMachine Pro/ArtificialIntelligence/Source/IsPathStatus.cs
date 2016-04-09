using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// The path status of the NavMeshAgent is equal to the supplied Path Status.
    /// </summary>
    [NodeInfo(  category = "Condition/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "The path status of the NavMeshAgent is equal to the supplied Path Status")]
    public class IsPathStatus : ConditionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The path status to test.
        /// </summary>
        [Tooltip("The path status to test.\nPathComplete: The path terminates at the destination.\nPathPartial: The path cannot reach the destination.\nPathInvalid: The path is invalid.")]
        public NavMeshPathStatus pathStatus;

        [System.NonSerialized]
        NavMeshAgent m_Agent = null;

        public override void Reset () {
            gameObject = this.self;
            pathStatus = NavMeshPathStatus.PathComplete;
        }

        public override Status Update () {
            // Get the renderer
            if (m_Agent == null || m_Agent.gameObject != gameObject.Value)
                m_Agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members?
            if  (m_Agent == null)
                return Status.Error;

            if (m_Agent.pathStatus == pathStatus)
                return Status.Success;
            else
                return Status.Failure;
        }
    }
}