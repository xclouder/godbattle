//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Utility class used to handle the Object.hideFlags property of states.
    /// </summary>
    [InitializeOnLoad]
    public class HideFlagUtility {

        /// <summary>
        /// Initialized listeners.
        /// </summary>
    	static HideFlagUtility () {
            InternalStateBehaviour.onUpdateHideFlag += HideFlagUtility.OnStateHideFlag;
            InternalBlackboard.onUpdateHideFlag += HideFlagUtility.OnBlackboardHideFlag;
        }

        /// <summary>
        /// Update the hideFlags of the supplied state.
        /// <param name ="state">The target state.</param>
        /// </summary>
        static void OnStateHideFlag (InternalStateBehaviour state) {
            // It's a valid state?
            if (state != null) {
                // It is not a prefab?
                if (!UnityEditor.AssetDatabase.Contains(state.gameObject)) {
                    // The state is not a root parent and the hide flag is True?
                    if (state.hideFlag && !state.isRoot)
                        state.hideFlags = HideFlags.HideInInspector;
                    else
                        state.hideFlags = (HideFlags) 0;
                }
            }
        }

        /// <summary>
        /// Update the hideFlag of all states on the same GameObject as the supplied blackboard.
        /// <param name ="blackboard">The target blackboard.</param>
        /// </summary>
        static void OnBlackboardHideFlag (InternalBlackboard blackboard) {
            // It's a blackboard?
            if (blackboard != null) {
                // Get the prefab type
                var prefabType = UnityEditor.PrefabUtility.GetPrefabType(blackboard.gameObject);
                // Its an instance of a prefab?
                if (prefabType != UnityEditor.PrefabType.None) {
                    // Get all states in the blackboard
                    InternalStateBehaviour[] states = blackboard.GetComponents<InternalStateBehaviour>();
                    for (int i = 0; i < states.Length; i++)
                        OnStateHideFlag(states[i]);
                }
                
            }
        }
    }
}