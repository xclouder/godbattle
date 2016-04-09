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
    /// Base classs to draw custom gui control for InternalStateBehaviour fields.
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    public class StatePropertyDrawer : PropertyDrawer {

    	/// <summary> 
        /// Returns true if the supplied state is not null and is not a root.
        /// <param name="state">The state to test.</param>
        /// <returns>False if the state is a root; True otherwise.</returns>
        /// </summary>
        protected bool IsNotRoot (InternalStateBehaviour state) {
            return state != null && !state.isRoot;
        }

        /// <summary> 
        /// Returns true if he supplied state is not null and is not a start state.
        /// <param name="state">The state to test.</param>
        /// <returns>False if the state is a start state; True otherwise.</returns>
        /// </summary>
        protected bool IsNotStart (InternalStateBehaviour state) {
            return state != null && state.fsm != null && state.fsm.startState != state;
        }
    }
}