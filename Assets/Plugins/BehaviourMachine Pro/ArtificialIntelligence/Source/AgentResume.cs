using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Stop movement of the agent along its current path.
    /// </summary>
    [NodeInfo(  category = "Action/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "Stop movement of the agent along its current path")]
    public class AgentResume : ActionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        public override void Reset () {
            gameObject = this.self;
        }

    	public override Status Update () {
            // Get the renderer
            NavMeshAgent agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members
            if (agent == null)
                return Status.Error;

            agent.Resume();
            return Status.Success;
        }
    }
}