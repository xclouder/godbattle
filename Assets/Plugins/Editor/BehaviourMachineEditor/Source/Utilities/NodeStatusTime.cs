//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Utility class used for visual debugging the nodes.
    /// <seealso cref="BehaviourMachine.ActionNode" />
    /// </summary>
    public class NodeStatusTime {

        /// <summary>
        /// The time of the node.
        /// </summary>
        public double time = 0;

        /// <summary>
        /// The status of the node at the given time.
        /// </summary>
        public Status status = Status.Ready;

        /// <summary>
        /// The class constructor.
        /// <param name="status">.The status of the node.</param>
        /// </summary>
        public NodeStatusTime (Status status) {
            this.time = EditorApplication.timeSinceStartup;
            this.status = status;
        }

        /// <summary>
        /// Updates the status of the node.
        /// <param name="status">.The new status of the node.</param>
        /// </summary>
        public void Update (Status status) {
            if (status != Status.Ready) {
                this.time = EditorApplication.timeSinceStartup;
                this.status = status;
            }
        }
    }
}