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
    /// A helper class used to create connections between states.
    /// </summary>
    public class TransitionDragAndDrop {

        #region Menbers
        static TransitionGUI s_CandidateForDrag;
        static StateTransition s_Dragging;
        static StateGUI s_StateGUI;
        static TransitionGUI s_TransitionGUI;
        #endregion Menbers

        #region Properties
        /// <summary> 
        /// Returns true if a transition dragging has been performed; false otherwise.
        /// </summary>
        public static bool isDragging {get {return s_Dragging != null;}}

        /// <summary> 
        /// Retrieve the transition candidate for drag.
        /// Use StartDrag to actually start dragging.
        /// </summary>
        public static TransitionGUI candidateForDrag {get {return s_CandidateForDrag;}}

        /// <summary> 
        /// Retrieve the transition being dragged.
        /// </summary>
        public static StateTransition dragging {get {return s_Dragging;}}

        /// <summary> 
        /// Returns the StateGUI that owns the candidateForDrag transition.
        /// </summary>
        public static StateGUI guiState {get {return s_StateGUI;}}

        /// <summary> 
        /// Returns the TransitionGUI being dragged.
        /// </summary>
        public static TransitionGUI transitionGUI {get {return s_TransitionGUI;}}

        /// <summary> 
        /// Returns the InternalStateBehaviour that owns the transition being dragged.
        /// </summary>
        public static InternalStateBehaviour state {get {return s_StateGUI != null ? s_StateGUI.state : null;}}
        #endregion Properties
        // public static StateTransition dragged;

        #region Methods

        /// <summary> 
        /// Clears the current dragging transition and prepares for initiating a drag operation.
        /// <param name="transitionGUI">The transition gui candidate for dragging. You can access it later using the candidateForDrag property.</param>
        /// <param name="guiState">The StateGUI that has the transitionGui.</param>
        /// </summary>
        public static void PrepareStartDrag (TransitionGUI transitionGUI, StateGUI guiState) {
            s_CandidateForDrag = transitionGUI;
            s_StateGUI = guiState;
            s_Dragging = null;
        }

        /// <summary> 
        /// Initiates a drag operation using the candidateForDrag transition supplied by PrepareStartDrag.
        /// </summary>
        public static void StartDrag () {
            s_Dragging = s_CandidateForDrag.transition;
            s_TransitionGUI = s_CandidateForDrag;
            s_CandidateForDrag = null;
        }

        /// <summary> 
        /// Clears everything stored in the drag & drop.
        /// </summary>
        public static void AcceptDrag () {
            s_CandidateForDrag = null;
            s_TransitionGUI = null;
            s_Dragging = null;
            s_StateGUI = null;
        }
        #endregion Methods
    }
}
