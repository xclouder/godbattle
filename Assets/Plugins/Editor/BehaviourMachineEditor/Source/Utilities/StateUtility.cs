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
    /// InternalStateBehaviour and ParentBehaviour utility functions.
    /// </summary>
    public static class StateUtility {

        #region State
        /// <summary> 
        /// Stores a state to be copied and pasted in the editor.
        /// </summary>
        public static InternalStateBehaviour[] statesToPaste = new InternalStateBehaviour[0];

        /// <summary>
        /// Sets the state as the start state of the fsm.
        /// Automatically handles undo.
        /// <param name="state">The new fsm start state.</param>
        /// </summary>
        public static void SetAsStart (InternalStateBehaviour state) {
            // Get the fsm
            var fsm = state.fsm;

            // The fsm is valid and the state is not the start state?
            if (fsm != null && fsm.startState != state) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(fsm, "Start State");
                #else
                Undo.RecordObject(fsm, "Start State");
                #endif

                fsm.startState = state;
                EditorUtility.SetDirty(fsm);

                EditorUtility.SetDirty(state); // Repaint state inspector
            }
        }

        /// <summary>
        /// Sets the state as the concurrent state of the fsm.
        /// Automatically handles undo.
        /// <param name="state">The new fsm concurrent state.</param>
        /// </summary>
        public static void SetAsConcurrent (InternalStateBehaviour state) {
            // Get the fsm
            var fsm = state.fsm;

            // The fsm is valid and the state is not the start state?
            if (fsm != null && fsm.concurrentState != state) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(fsm, "Concurrent State");
                #else
                Undo.RecordObject(fsm, "Concurrent State");
                #endif

                fsm.concurrentState = state;
                EditorUtility.SetDirty(fsm);

                // EditorUtility.SetDirty(state); // Repaint state inspector
            }
        }

        /// <summary>
        /// Sets the state as not concurrent.
        /// Automatically handles undo.
        /// <param name="fsm">The fsm to remove the concurrent state.</param>
        /// </summary>
        public static void RemoveConcurrentState (InternalStateMachine fsm) {
            // The fsm is valid and the state is not the start state?
            if (fsm != null && fsm.concurrentState != null) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(fsm, "Concurrent State");
                #else
                Undo.RecordObject(fsm, "Concurrent State");
                #endif

                fsm.concurrentState = null;
                EditorUtility.SetDirty(fsm);

                // EditorUtility.SetDirty(state); // Repaint state inspector
            }
        }

        /// <summary>
        /// Adds a new transition to the state.
        /// Automatically handles undo.
        /// <param name="state">The state to add a new transition.</param>
        /// <param name="eventID">The event id of the new transition.</param>
        /// </summary>
        public static void AddTransition (InternalStateBehaviour state, int eventID) {
            // Register undo
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            Undo.RegisterUndo (state, "Create Transition");
            #else
            Undo.RecordObject (state, "Create Transition");
            #endif

            state.AddTransition(eventID);
            EditorUtility.SetDirty(state);
        }

        /// <summary>
        /// Sets a new event id in the supplied transition.
        /// <param name="state">The state that owns the target transition.</param>
        /// <param name="transition">The transition to set the new event id.</param>
        /// <param name="eventId">The new event id.</param>
        /// </summary>
        public static void SetNewEvent (InternalStateBehaviour state, StateTransition transition, int eventId) {
            // Validate members
            if (state != null && transition != null) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo (state, "Transition Event");
                #else
                Undo.RecordObject (state, "Transition Event");
                #endif

                // Set transition event
                transition.eventID = eventId;

                // Set state dirty flag
                EditorUtility.SetDirty(state);
            }
        }


        /// <summary>
        /// Sets a new destination state to the supplied transition.
        /// <param name="state">The state that owns the target transition.</param>
        /// <param name="transition">The transition to set the new destination.</param>
        /// <param name="destination">The new destination state.</param>
        /// </summary>
        public static void SetNewDestination (InternalStateBehaviour state, StateTransition transition, InternalStateBehaviour destination) {
            // Validate members
            if (state != null && transition != null) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(state,"Transition Destination");
                #else
                Undo.RecordObject(state,"Transition Destination");
                #endif

                // Create a connection to the destination
                transition.destination = destination;

                // Set state dirty flag
                EditorUtility.SetDirty(state);
            }
        }

        /// <summary>
        /// Removes the transition from the state.
        /// <param name="state">The state that owns the target transition.</param>
        /// <param name="transition">The transition to  be removed.</param>
        /// </summary>
        public static void RemoveTransition (InternalStateBehaviour state, StateTransition transition) {
            // Validate members
            if (state != null && transition != null) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo (state, "Delete Transition");
                #else
                Undo.RecordObject (state, "Delete Transition");
                #endif

                // Remove transition
                state.RemoveTransition(transition);

                // Set state dirty flag
                EditorUtility.SetDirty(state);
            }
        }

        /// <summary> 
        /// Copy all selected states.
        /// </summary>
        public static void CopySelectedStates () {

            var states = new List<InternalStateBehaviour>();

            for (int i = 0; i < Selection.objects.Length; i++) {
                var state = Selection.objects[i] as InternalStateBehaviour;
                
                if (state != null)
                    states.Add(state);
            }

            statesToPaste = states.ToArray();
        }


        /// <summary> 
        /// Paste the state in StateUtility.stateToPaste in the supplied fsm.
        /// <param name="gameObject">The target gameObject.</param>
        /// <param name="originalStates">The original states.</param>
        /// <param name="parent">Optionally parent for the cloned states.</param>
        /// </summary>
        public static void CloneStates (GameObject gameObject, InternalStateBehaviour[] originalStates, ParentBehaviour parent) {
            if (gameObject != null && originalStates != null && originalStates.Length > 0) {
                var orginalClone = new Dictionary<InternalStateBehaviour, InternalStateBehaviour>();
                var originalFsm = parent != null ? originalStates[0].parent as InternalStateMachine : null;
                var newFsm = parent as InternalStateMachine;
                InternalStateBehaviour startState = null, concurrentState = null;
                InternalAnyState anyState = null;

                // Copy blackboard data?
                var newBlackboard = gameObject.GetComponent<InternalBlackboard>();
                if (newBlackboard == null) {
                    // Get the original blackboard
                    InternalBlackboard originalBlackboard = originalStates[0].GetComponent<InternalBlackboard>();

                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterSceneUndo("Paste State");
                    // Create the new blacbkoard
                    newBlackboard = gameObject.AddComponent(originalBlackboard.GetType()) as InternalBlackboard;
                    #else
                    // Create the new blacbkoard
                    newBlackboard = gameObject.AddComponent(originalBlackboard.GetType()) as InternalBlackboard;
                    if (newBlackboard != null)
                        Undo.RegisterCreatedObjectUndo(newBlackboard, "Paste State");
                    #endif

                    // Copy serialized values
                    EditorUtility.CopySerialized(originalBlackboard, newBlackboard);
                }

                foreach (InternalStateBehaviour state in originalStates) {
                    // Don't clone AnyState in StateMachines
                    if (state != null && (newFsm == null || !(state is InternalAnyState) || newFsm.anyState == null)) {
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        Undo.RegisterSceneUndo("Paste State");
                        // Create a new state
                        var newState = gameObject.AddComponent(state.GetType()) as InternalStateBehaviour;
                        #else
                        // Create a new state
                        var newState = gameObject.AddComponent(state.GetType()) as InternalStateBehaviour;
                        if (newState != null)
                            Undo.RegisterCreatedObjectUndo(newState, "Paste State");
                        #endif

                        if (newState != null) {
                            // Store state
                            orginalClone.Add(state, newState);

                            // Copy serialized values
                            EditorUtility.CopySerialized(state, newState);
                            
                            // Update blackboard
                            if (state.gameObject != newState.gameObject) {
                                var serialObj = new SerializedObject(newState);
                                serialObj.FindProperty("m_Blackboard").objectReferenceValue = newBlackboard;
                                serialObj.ApplyModifiedProperties();
                                serialObj.Dispose();
                            }

                            // Update the AnyState, StartState and ConcurrentState
                            if (newState is InternalStateMachine) {
                                var fsm = newState as InternalStateMachine;
                                fsm.startState = null;
                                fsm.concurrentState = null;
                                fsm.anyState = null;
                            }

                            EditorUtility.SetDirty(newState);

                            // Set new parent
                            if (parent != null) {
                                newState.parent = parent;

                                // Update position
                                if (parent == state.parent)
                                    newState.position += new Vector2(20f, 20f);
                            }
                            else
                                newState.parent = null;

                            // Saves state and sets dirty flag
                            INodeOwner nodeOwner = newState as INodeOwner;
                            if (nodeOwner != null) {
                                nodeOwner.LoadNodes();
                                StateUtility.SetDirty(nodeOwner);
                            }
                            else
                                EditorUtility.SetDirty(newState);

                            // Try to get the StartState, AnyState and ConcurrentState
                            if (originalFsm != null) {
                                if (originalFsm.startState == state)
                                    startState = newState;
                                if (anyState == null)
                                    anyState = newState as InternalAnyState;
                                if (originalFsm.concurrentState == state)
                                    concurrentState = newState;
                            }
                        }
                    }
                }

                // Set StartState, AnyState and ConcurrentState
                if (newFsm != null) {
                    if (newFsm.startState == null)
                        newFsm.startState = startState;
                    if (newFsm.anyState == null)
                        newFsm.anyState = anyState;
                    if (newFsm.concurrentState == null)
                        newFsm.concurrentState = concurrentState;
                    EditorUtility.SetDirty(newFsm);
                }

                // Try to update the transitions' destination
                foreach (KeyValuePair<InternalStateBehaviour, InternalStateBehaviour> pair in orginalClone) {
                    InternalStateBehaviour state = pair.Key;
                    InternalStateBehaviour newState = pair.Value;

                    // Update the newState transition
                    for (int i = 0; i < newState.transitions.Length && i < state.transitions.Length; i++) {
                        // The original destination is valid?
                        if (state.transitions[i].destination != null && orginalClone.ContainsKey(state.transitions[i].destination))
                            newState.transitions[i].destination = orginalClone[state.transitions[i].destination];
                    }

                    if (newState is ParentBehaviour) {
                        var stateAsParent = state as ParentBehaviour;
                        
                        // Removes the newState from the children state to avoid an infinite loop
                        List<InternalStateBehaviour> children = stateAsParent.states;
                        if (children.Contains(newState))
                            children.Remove(newState);

                        StateUtility.CloneStates(newState.gameObject, children.ToArray(), newState as ParentBehaviour);
                    }

                    EditorUtility.SetDirty(newState);
                }

                EditorUtility.SetDirty(gameObject);
            }
        }

        /// <summary> 
        /// Paste the state in StateUtility.stateToPaste in the supplied fsm.
        /// <param name="parent">The target parent.</param>
        /// </summary>
        public static void PasteStates (ParentBehaviour parent) {
            if (parent != null)
                CloneStates(parent.gameObject, statesToPaste, parent);
        }

        /// <summary>
        /// Destroys the supplied state.
        /// Automatically handles undo.
        /// <param name="state">The state to be destroyed.</param>
        /// </summary> 
        public static void Destroy (InternalStateBehaviour state) {
            // its a valid state
            if (state != null) {
                var gameObject = state.gameObject;                  // stores the gameObject to set dirty flag
                var isPrefab = FileUtility.IsPrefab(gameObject);    
                var monoState = state as InternalMonoState;                 // its a mono state?

                // It is a fsm?
                if (state is ParentBehaviour) {
                    var parent = state as ParentBehaviour;
                    foreach (var child in parent.states)
                        StateUtility.Destroy(child);
                }

                if (Application.isPlaying && !isPrefab) {
                    // Its a MonoState and the user wants to destroy mono behaviour to?
                    if (monoState != null && monoState.monoBehaviour != null && EditorUtility.DisplayDialog("Destroy MonoBehaviour?", "Do you want to destroy the " + monoState.monoBehaviour.GetType().ToString() + "?", "Ok", "Cancel")) {
                        var monoStateGO = monoState.gameObject;
                        Object.Destroy(monoState.monoBehaviour);
                        EditorUtility.SetDirty(monoStateGO);
                    }
                    Object.Destroy(state);
                }
                else {
                    // Register scene undo
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterSceneUndo("Delete");
                    #endif

                    // Its a MonoState and the user wants to destroy the MonoBehaviour to?
                    if (monoState != null && monoState.monoBehaviour != null && EditorUtility.DisplayDialog("Destroy MonoBehaviour?", "Do you want to destroy the " + monoState.monoBehaviour.GetType().ToString() + "?", "Ok", "Cancel")) {
                        // Gets the  MonoState game object
                        var monoStateGO = monoState.gameObject;

                        // Destroy the mono behaviour
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        Object.DestroyImmediate(monoState.monoBehaviour, true);
                        #else
                        Undo.DestroyObjectImmediate(monoState.monoBehaviour);
                        #endif

                        // Set game object dirty flag
                        EditorUtility.SetDirty(monoStateGO);
                    }

                    // Destroys the state
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Object.DestroyImmediate(state, true);
                    #else
                    Undo.DestroyObjectImmediate(state);
                    #endif
                }

                EditorUtility.SetDirty(gameObject);
            }
        }
        #endregion State

        #region Parent
        /// <summary>
        /// Adds a state to the supplied game object.
        /// Automatically handles undo. 
        /// <param name="gameObject">The game object to add a new state.</param>
        /// <param name="type">The new state type.</param>
        /// <returns>The new created state.<returns>
        /// </summary> 
        public static InternalStateBehaviour AddState (GameObject gameObject, System.Type type) {
            // Validate parameters
            if (gameObject != null && type.IsSubclassOf(typeof(InternalStateBehaviour))) {
                 // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterSceneUndo("Add Component");
                // Create a new parent
                var newState = gameObject.AddComponent(type) as InternalStateBehaviour;
                #else
                // Create a new parent
                var newState = gameObject.AddComponent(type) as InternalStateBehaviour;
                if (newState != null)
                    Undo.RegisterCreatedObjectUndo(newState, "Add Component");
                #endif

                // Set game object dirty flag
                EditorUtility.SetDirty(gameObject);

                return newState;
            }
            return null;
        }

        /// <summary>
        /// Adds a state to the supplied parent.
        /// Automatically handles undo. 
        /// <param name="parent">The ParentBehaviour to add the new state.</param>
        /// <param name="type">The new state type.</param>
        /// <returns>The new created state.<returns>
        /// </summary> 
        public static InternalStateBehaviour AddState (ParentBehaviour parent, System.Type type) {
            // Validate parameters
            if (type != null && parent != null) {

                // Create and register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterSceneUndo("Create State (" + type.Name + ")");
                #endif

                InternalStateBehaviour newState = parent.AddState(type);

                
                if (newState != null) {
                    // Register undo
                    #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2
                    Undo.RegisterCreatedObjectUndo(newState, "Create State (" + type.Name + ")");
                    #endif

                    // The parent is a FSM?
                    var fsm = parent as InternalStateMachine;
                    if (fsm != null) {
                        // The newState is an AnyState?
                        if (newState is InternalAnyState) {
                            // The fsm already has an AnyState?
                            if (fsm.anyState != null)
                                // Destroy the curren anyState
                                StateUtility.Destroy(fsm.anyState);

                            // Add the new anyState
                            fsm.anyState = newState as InternalAnyState;
                        }
                        // The start state is null?
                        else if (fsm.startState == null) {
                            // Set the new state as the start state
                            fsm.startState = newState;
                            EditorUtility.SetDirty(fsm);
                        }
                    }

                    // Sets dirty flag
                    EditorUtility.SetDirty(parent.gameObject);
                }

                return newState;
            }
            return null;
        }
        #endregion Parent


        #region State Owner
        /// <summary> 
        /// Marks the state dirty flag; if the state is a prefab instance then disconnects the m_NodeSerialization property.
        /// <param name="owner">The target owner to mark the dirty flag.</param>
        /// </summary>
        public static void SetDirty (INodeOwner owner) {
            var unityObject = owner as UnityEngine.Object;
            if (!Application.isPlaying && unityObject != null) {
                // its a prefab Instance?
                var prefabType = UnityEditor.PrefabUtility.GetPrefabType(unityObject);
                if (prefabType != UnityEditor.PrefabType.None && prefabType != UnityEditor.PrefabType.Prefab && prefabType != UnityEditor.PrefabType.ModelPrefab) {
                    PropertyUtility.DisconnectPropertyFromPrefab(unityObject, "m_NodeSerialization");

                    // Workaround to disconnect ArraySize properties
                    owner.Clear();
                    PrefabUtility.RecordPrefabInstancePropertyModifications(unityObject);
                }
            }

            owner.SaveNodes();
            EditorUtility.SetDirty(unityObject);
        }

        /// <summary>
        /// Reset the supplied node properties.
        /// <param name="node">The node to be reseted.</param>
        /// </summary>
        public static void ResetNode (ActionNode node) {
            // Get the owner as an Uniyt object
            var ownerUnityObj = node != null ? node.owner as UnityEngine.Object : null;
            // Validate parameters
            if (ownerUnityObj != null) {

                // Register Undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(ownerUnityObj, "Reset Node");
                #else
                Undo.RecordObject(ownerUnityObj, "Reset Node");
                #endif

                node.name = node.GetType().Name;
                node.Reset();
                node.OnValidate();
                StateUtility.SetDirty(node.owner);
            }
        }
        #endregion State Owner


        #region State Extension Methods
        public static int GetStateMachineDepth (this InternalStateBehaviour state) {
            int depth = 0;
            InternalStateMachine fsm = state.fsm;
            while (fsm != null) {
                fsm = fsm.fsm;
                depth++;
            }
            return depth;
        } 

        public static int GetBehaviourTreeDepth (this InternalStateBehaviour state) {
            int depth = 0;
            InternalBehaviourTree tree = state.tree;
            while (tree != null) {
                tree = tree.tree;
                depth++;
            }
            return depth;
        } 
        #endregion State Extension Methods
    }
}