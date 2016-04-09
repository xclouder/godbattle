//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Is the agent currently positioned on an OffMeshLink that is valid, is activated and has the supplied linkType?
    /// </summary>
    [NodeInfo(  category = "Condition/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "Is the agent currently positioned on an OffMeshLink that is valid, is activated and has the supplied linkType?")]
    public class IsAgentOnOffMeshLink : ConditionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        /// <summary>
        /// Filter OffMeshLink by type.
        /// <summary>
        [Tooltip("Filter OffMeshLink by type")]
        public OffMeshLinkType linkType;

        /// <summary>
        /// Store the link end world position.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Store", tooltip = "Store the link end world position")]
        public Vector3Var storeEndPos;

        [System.NonSerialized]
        NavMeshAgent m_Agent = null;

        public override void Reset () {
            gameObject = this.self;
            storeEndPos = new ConcreteVector3Var();
        }

        public override Status Update () {
             // Get the agent
            if (m_Agent == null || m_Agent.gameObject != gameObject.Value)
                m_Agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

             // Validate members
            if (m_Agent == null)
                return Status.Error;

            if (m_Agent.isOnOffMeshLink && m_Agent.currentOffMeshLinkData.valid && m_Agent.currentOffMeshLinkData.activated && m_Agent.currentOffMeshLinkData.linkType == linkType) {
                // Store end pos
                storeEndPos.Value = m_Agent.currentOffMeshLinkData.endPos;
                // Send event?
                if (onSuccess.id != 0)
                    owner.SendEvent(onSuccess.id);
                return Status.Success;
            }

            return Status.Failure;
        }
    }
}