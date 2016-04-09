//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// The NavMeshAgent follows the target.
    /// </summary>
    [NodeInfo(  category = "Action/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "The NavMeshAgent follows the target")]
    public class AgentFollow : ActionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// The game object to be followed.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object to be followed")]
        public GameObjectVar target;

        /// <summary>
        /// The agent's path will be reseted if the value of 'Reset Path' is True.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "True", tooltip = "The agent's path will be reseted if the value of 'Reset Path' is True")]
        public BoolVar resetPath;

        [System.NonSerialized]
        NavMeshAgent m_GOAgent = null;

        public override void Reset () {
            gameObject = this.self;
            target = this.self;
            resetPath = new ConcreteBoolVar();
        }

        public override void End () {
            if ((resetPath.isNone || resetPath.Value) && m_GOAgent != null && m_GOAgent.hasPath && gameObject.Value != null) {
                m_GOAgent.ResetPath();
            }
        }

        public override Status Update () {
            // Get the renderer
            if (m_GOAgent == null || m_GOAgent.gameObject != gameObject.Value)
                m_GOAgent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members?
            if  (m_GOAgent == null || target.Value == null) {
                return Status.Error;
            }

            if (target.transform.hasChanged) {
                m_GOAgent.SetDestination(target.transform.position);
            }

            return Status.Running;
        }
    }
}