//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
    /// <summary>
    /// Stop movement of the agent along its current path.
    /// </summary>
    [NodeInfo(  category = "Action/ArtificialIntelligence/",
                icon = "NavMeshAgent",
                description = "Stop movement of the agent along its current path")]
    public class AgentStop : ActionNode {

        /// <summary>
        /// The game object that has a NavMeshAgent in it.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a NavMeshAgent in it")]
        public GameObjectVar gameObject;

        #if UNITY_4 || UNITY_4_1 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6
        /// <summary>
        /// If true, the GameObject is stopped immediately and not affected by the avoidance system. If false, the NavMeshAgent controls the deceleration.
        /// </summary>
        [VariableInfo(tooltip = "If true, the GameObject is stopped immediately and not affected by the avoidance system. If false, the NavMeshAgent controls the deceleration")]
        public BoolVar stopUpdates;
        #endif

        public override void Reset () {
            gameObject = this.self;
            
            #if UNITY_4 || UNITY_4_1 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6
            stopUpdates = false;
            #endif
        }

    	public override Status Update () {
            // Get the agent
            NavMeshAgent agent = gameObject.Value != null ? gameObject.Value.GetComponent<NavMeshAgent>() : null;

            // Validate members
            if (agent == null)
                return Status.Error;

            #if UNITY_4 || UNITY_4_1 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6
            agent.Stop(stopUpdates.Value);
            #else
            agent.Stop();
            #endif
            return Status.Success;
        }
    }
}