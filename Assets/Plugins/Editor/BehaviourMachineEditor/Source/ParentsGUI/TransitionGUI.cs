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
    /// A class used to draw a StateTransition event in the GUI.
    /// </summary>
    public class TransitionGUI {

        public const float defaultHeight = 18f;

        #region Styles
        static TransitionGUI.Styles m_Styles;

        /// <summary> 
        /// Store GUIStyles used by TransitionGUIs.
        /// </summary>
        class Styles {
            public readonly GUIStyle label = "ProjectBrowserGridLabel";
            public readonly GUIStyle pin = "flow triggerPin out";
            public readonly GUIStyle name = "toggle";
            public readonly GUIStyle ping = "PR Ping";
        }
        #endregion Styles

        
        #region Members
        FsmEvent m_FsmEvent;
        StateTransition m_Transition;
        InternalStateBehaviour m_Destination;
        float m_VerticalOffset;
        double m_PerformedTime = 0f;
        bool m_TransitionPerformed = false;
        #endregion Members

        
        #region Properties
        /// <summary> 
        /// Returns the target transition.
        /// </summary>
        public StateTransition transition {get {return m_Transition;}}

        /// <summary> 
        /// Returns the transition event.
        /// </summary>
        public FsmEvent fsmEvent {get {return m_FsmEvent;}}

        /// <summary> 
        /// The vertical offset of to draw the transition.
        /// </summary>
        public float verticalOffset {get {return m_VerticalOffset;} set {m_VerticalOffset = value;}}
        #endregion Properties


        #region Constructor
        /// <summary>
        /// Class constructor.
        /// <param name="stateTransition">The target transition.</param>
        /// <param name="destination">The target destination.</param>
        /// <param name="index">The transition index.</param>
        /// <param name="blackboard">The state blackboard.</param>
        /// </summary>
        public TransitionGUI (StateTransition stateTransition, InternalStateBehaviour destination, int index, InternalBlackboard blackboard) {
            m_Transition = stateTransition;
            m_Destination = destination;

            // It's a global event?
            if (m_Transition.eventID < 0) {
                 if (InternalGlobalBlackboard.Instance != null)
                     m_FsmEvent = InternalGlobalBlackboard.Instance.GetFsmEvent(m_Transition.eventID);
            }
            // It's a local variable and the blackboard is not null?
            else if (m_Transition.eventID > 0 && blackboard != null)
                m_FsmEvent = blackboard.GetFsmEvent(m_Transition.eventID);

            // Get the transition arrow vertical offset
            m_VerticalOffset = StateGUI.defaultHeight + TransitionGUI.defaultHeight * (index + .35f);
        }
        #endregion Constructor


        /// <summary>
        /// Draws the event name in the supplied rect.
        /// <param name="position">The position in the screen to draw the event name.</param>
        /// </summary>
        public void DrawEventName (Rect position) {
            // It's not a repaint event?
            if (Event.current.type != EventType.Repaint) 
                return;

            // Is there a valid styles?
            if (m_Styles == null)
                m_Styles = new TransitionGUI.Styles();

            // It's the active transition?
            bool on = m_Transition == BehaviourWindow.activeTransition;
            // Stores the event name
            string eventName;

            // Has errors?
            if (m_FsmEvent == null || m_FsmEvent.isInvalid) {
                eventName = "None";

                var oldGUIColor = GUI.color;
                
                GUI.color = on ? GUI.skin.settings.selectionColor : Color.red;
                var pingRect = position;
                pingRect.yMax -= 4f;

                m_Styles.ping.Draw(pingRect, "", false, false, false, false);

                GUI.color = oldGUIColor;
            }
            else
                eventName = m_FsmEvent.name;

            // Draw event name
            m_Styles.label.Draw(position, eventName, false, false,  on, on);

            // Draw pins
            bool hasDestination = m_Destination != null;
            m_Styles.pin.Draw(new Rect(4, position.y, 2, defaultHeight), false, false, hasDestination, false);
            m_Styles.pin.Draw(new Rect(StateGUI.defaultWidth + 2, position.y, 2, defaultHeight), false, false, hasDestination, false);
        }

        /// <summary>
        /// Draws the transition arrow.
        /// </summary>
        public void DrawDestinationArrow (Rect stateRect) {
            // The destination state is valid and the user is not performing a dragging in the target transition?
            if (m_Destination != null && TransitionDragAndDrop.dragging != m_Transition) {
                // Get the destination rect
                var destRect = new Rect (m_Destination.position.x, m_Destination.position.y, StateGUI.defaultWidth, StateGUI.defaultHeight + TransitionGUI.defaultHeight * m_Destination.transitions.Length);
                
                this.DrawArrow(stateRect, destRect, StateGUI.defaultHeight * .5f);
            }
        }

        /// <summary>
        /// Draws the transition arrow from fromRect to destRect. 
        /// <param name="fromRect">The initial rect of the arrow.</param>
        /// <param name="destRect">The end rect of the arrow.</param>
        /// <param name="destYOffset">An y offset for the destination rect.</param>
        /// </summary>
        public void DrawArrow (Rect fromRect, Rect destRect, float destYOffset) {
            // Its not a repaint event?
            if (Event.current.type != EventType.Repaint) 
                return;
                
            // Get arrow color
            var color = Color.white;

            if (BehaviourWindow.activeTransition == m_Transition)
                color = GUI.skin.settings.selectionColor;
            else if (m_FsmEvent == null || m_FsmEvent.isInvalid)
                color = Color.red;

            // Color alpha is always 1
            color.a = 1f;

            // The transition was performed?
            if (m_TransitionPerformed) {
                // Draw visual debugging
                // Get delta time
                var dt = (float) (EditorApplication.timeSinceStartup - m_PerformedTime); 

                // Change alpha color
                color = Color.Lerp(Color.green, color, dt);

                // Draw for one second
                if (dt >= 1f)
                    m_TransitionPerformed = false; 
            }

            LineGUI.Bezier(fromRect, m_VerticalOffset, destRect, destYOffset, color, 2f, true);
        }

        /// <summary>
        /// Call this when the transition is performed.
        /// Used for visual debugging.
        /// </summary>
        public void OnTransitionPerformed () {
            m_TransitionPerformed = true;
            m_PerformedTime = EditorApplication.timeSinceStartup;
        }
    }
}