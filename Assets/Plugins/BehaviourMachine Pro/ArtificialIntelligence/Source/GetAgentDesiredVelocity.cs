//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Resumes the movement along the current path after a pause.
    /// </summary>
    [NodeInfo(  category = "Action/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "Resumes the movement along the current path after a pause")]
    public class GetAgentDesiredVelocity : ActionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// Stores the desired velocity.
        /// </summary>
        [VariableInfo(tooltip = "Stores the desired velocity")]
        public Vector3Var storeDesiredVelocity;

        [System.NonSerialized]
        NavMeshAgent m_Agent = null;

        public override void Reset () {
            gameObject = this.self;
            storeDesiredVelocity = new ConcreteVector3Var();
        }

    	public override Status Update () {
            // Get the renderer
            if (m_Agent == null || m_Agent.gameObject != gameObject.Value)
                m_Agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members
            if (m_Agent == null || storeDesiredVelocity.isNone)
                return Status.Error;

            storeDesiredVelocity.Value = m_Agent.desiredVelocity;
            return Status.Success;
        }
    }
}