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
    /// A class used to draw a InternalStateBehaviour in the editor.
    /// <seealso cref="BehaviourMachine.InternalStateBehaviour" />
    /// </summary>
    public class StateGUI {
        public const float defaultWidth = 136f;
        public const float defaultHeight = 46f;
        const float c_WindowTitleHeight = 17f;

        static int s_DraggedWindow = -1;
        static readonly int s_DragNodesControlID = "DragNodes".GetHashCode();
        static readonly Dictionary<InternalStateBehaviour, Vector2> s_InitialDragStatePositions = new Dictionary<InternalStateBehaviour, Vector2> ();
        static Vector2 s_LastMousePosition;
        static Vector2 s_DragNodeDistance;

        /// <summary>
        /// The state dragged window id.
        /// </summary>
        public static int draggedWindow {get {return s_DraggedWindow;}}

        /// <summary>
        /// Resets the dragged state window id.
        /// </summary>
        public static void ResetDraggedWindow () {
            s_DraggedWindow = -1;
        }

        #region Styles
        protected static StateGUI.Styles s_Styles;

        /// <summary> 
        /// Store GUIStyles that are used by a guiState.
        /// </summary>
        protected class Styles {
            public readonly GUIStyle greyWindow = "flow node 0";
            public readonly GUIStyle blueWindow = "flow node 1";
            public readonly GUIStyle cyanWindow = "flow node 2";
            public readonly GUIStyle greenWindow = "flow node 3";
            public readonly GUIStyle yellowWindow = "flow node 4";
            public readonly GUIStyle orangeWindow = "flow node 5";
            public readonly GUIStyle redWindow = "flow node 6";

            public readonly GUIStyle greyWindowOn = "flow node 0 on";
            public readonly GUIStyle blueWindowOn = "flow node 1 on";
            public readonly GUIStyle cyanWindowOn = "flow node 2 on";
            public readonly GUIStyle greenWindowOn = "flow node 3 on";
            public readonly GUIStyle yellowWindowOn = "flow node 4 on";
            public readonly GUIStyle orangeWindowOn = "flow node 5 on";
            public readonly GUIStyle redWindowOn = "flow node 6 on";

            public readonly GUIStyle greyWindowHex = "flow node hex 0";
            public readonly GUIStyle blueWindowHex = "flow node hex 1";
            public readonly GUIStyle cyanWindowHex = "flow node hex 2";
            public readonly GUIStyle greenWindowHex = "flow node hex 3";
            public readonly GUIStyle yellowWindowHex = "flow node hex 4";
            public readonly GUIStyle orangeWindowHex = "flow node hex 5";
            public readonly GUIStyle redWindowHex = "flow node hex 6";

            public readonly GUIStyle greyWindowHexOn = "flow node hex 0 on";
            public readonly GUIStyle blueWindowHexOn = "flow node hex 1 on";
            public readonly GUIStyle cyanWindowHexOn = "flow node hex 2 on";
            public readonly GUIStyle greenWindowHexOn = "flow node hex 3 on";
            public readonly GUIStyle yellowWindowHexOn = "flow node hex 4 on";
            public readonly GUIStyle orangeWindowHexOn = "flow node hex 5 on";
            public readonly GUIStyle redWindowHexOn = "flow node hex 6 on";

            public readonly GUIStyle enabledBarBackground = "MeLivePlayBackground";
            public readonly GUIStyle enabledBar = "MeLivePlayBar";

            public readonly GUIStyle windowTitle;

            public readonly Color activeColor = .75f * Color.white;

            public Styles () {
                windowTitle = new GUIStyle("label");
                windowTitle.alignment = TextAnchor.UpperCenter;
                if (EditorGUIUtility.isProSkin)
                    windowTitle.normal.textColor = Color.white;
            }
        }
        #endregion Styles

        
        #region Members
        InternalStateBehaviour m_State = null;
        int m_Id = -1;
        Texture m_Icon = null;
        protected StateColor m_StateColor;
        bool m_IsStart = false;
        bool m_IsConcurrent = false;
        protected GUIStyle m_WindowStyle;
        protected GUIStyle m_WindowStyleOn;
        protected List<TransitionGUI> m_TransitionGUIs = new List<TransitionGUI>();
        #endregion Members

        
        #region Properties
        /// <summary>
        /// The position of the state window.
        /// </summary>
        public Rect rect {
            get {
                // The state is null?
                if (m_State == null)
                    return new Rect (0f, 0f, defaultWidth, defaultHeight);
                var statePosition = m_State.position;
                
                // Snap settings
                var dx = 0f;
                var dy = 0f;
                var snapMove = BehaviourMachinePrefs.snapMove;
                if (snapMove > 0f) {
                    dx = statePosition.x % snapMove;
                    dy = statePosition.y % snapMove;
                }

                // Create and return the rect
                return new Rect (statePosition.x - dx, statePosition.y - dy, defaultWidth, defaultHeight + (m_State.transitions != null ? m_State.transitions.Length * TransitionGUI.defaultHeight : 0f));
            }
            set {
                m_State.position = new Vector2(value.x, value.y);
            }
        }

        /// <summary>
        /// The state being drawn.
        /// </summary>
        public InternalStateBehaviour state {get {return m_State;}}

        /// <summary>
        /// It's the start state?
        /// </summary>
        public bool isStart {get {return m_IsStart;}}

        /// <summary>
        /// It's the start state?
        /// </summary>
        public bool isConcurrent {get {return m_IsConcurrent;}}
        #endregion Properties

        
        #region Contructor
        /// <summary> 
        /// The constructor.
        /// <param name="id">A unique id for the window.</param>
        /// <param name="state">The state that this object will draw.</param>
        /// </summary>
        public StateGUI (int id, InternalStateBehaviour state) {
            m_State = state;
            m_Id = id;

            // Get state data
            if (m_State != null) {
                m_Icon =  IconUtility.GetIcon(m_State.GetType(), m_State);
                // It's the start state?
                 m_IsStart = m_State.fsm != null && m_State.fsm.startState == m_State;
                 // It's the concurrent state?
                 m_IsConcurrent = m_State.fsm != null && m_State.fsm.concurrentState == m_State;
                // Transition visual debugging
                m_State.onTransitionPerformed += OnTransitionPerformed;
                // Build gui transitions
                CreateTransitionGUIs();
            }
        }
        #endregion Constructors


        #region Private Methods
        /// <summary>
        /// Returns the destination of a transition.
        /// </summary>
        protected InternalStateBehaviour GetDestination (InternalStateMachine fsm, InternalStateBehaviour destination) {
            if (fsm == null || destination == null)
                return null;

            InternalStateMachine currentFsm = destination.fsm;

            if (currentFsm == fsm)
                return destination;

            while (currentFsm != null && fsm != currentFsm.fsm) {
                currentFsm = currentFsm.fsm;
            }

            return currentFsm;
        }


        /// <summary>
        /// Creates the TransitionGUIs list to display the transition event name.
        /// </summary>
        protected virtual void CreateTransitionGUIs () {
            m_TransitionGUIs.Clear();

            if (m_State != null) {
                // Get the blackobard
                var blackboard = m_State.blackboard;
                // Get the transitions list
                var transitions = m_State.transitions;

                for (int i = 0; i < transitions.Length; i++) {
                    // Get the destination
                    InternalStateBehaviour destination = GetDestination(m_State.fsm, transitions[i].destination);
                    if (destination == null && transitions[i].destination != null && GetDestination(transitions[i].destination.fsm, m_State) != null)
                        destination = m_State.fsm;

                    m_TransitionGUIs.Add(new TransitionGUI(transitions[i], destination, i, blackboard));
                }
            }
        }

        /// <summary>
        /// Set the state window color.
        /// </summary>
        protected virtual void SetWindowColor () {
            if (m_State != null) {
                m_StateColor = m_State.color;
                if (m_IsStart) {
                    m_WindowStyle = s_Styles.orangeWindow;
                    m_WindowStyleOn = s_Styles.orangeWindowOn;
                }
                else if (m_State is InternalAnyState || m_IsConcurrent) {
                    m_WindowStyle = s_Styles.cyanWindow;
                    m_WindowStyleOn = s_Styles.cyanWindowOn;
                }
                else {
                    switch (m_StateColor) {
                        case StateColor.Grey:
                            m_WindowStyle = s_Styles.greyWindow;
                            m_WindowStyleOn = s_Styles.greyWindowOn;
                            break;
                        case StateColor.Blue:
                            m_WindowStyle = s_Styles.blueWindow;
                            m_WindowStyleOn = s_Styles.blueWindowOn;
                            break;
                        // case StateColor.Cyan:
                        //     m_WindowStyle = s_Styles.cyanWindow;
                        //     m_WindowStyleOn = s_Styles.cyanWindowOn;
                        //     break;
                        case StateColor.Green:
                            m_WindowStyle = s_Styles.greenWindow;
                            m_WindowStyleOn = s_Styles.greenWindowOn;
                            break;
                        case StateColor.Yellow:
                            m_WindowStyle = s_Styles.yellowWindow;
                            m_WindowStyleOn = s_Styles.yellowWindowOn;
                            break;
                        // case StateColor.Orange:
                        //     m_WindowStyle = s_Styles.orangeWindow;
                        //     m_WindowStyleOn = s_Styles.orangeWindowOn;
                        //     break;
                        case StateColor.Red:
                            m_WindowStyle = s_Styles.redWindow;
                            m_WindowStyleOn = s_Styles.redWindowOn;
                            break;
                    }
                }
            }
            else {
                m_StateColor = StateColor.Red;
                m_WindowStyle = s_Styles.redWindow;
                m_WindowStyleOn = s_Styles.redWindowOn;
            }
        }

        #region Transition Visual Debugging
        /// <summary> 
        /// A callback called whenever a transition is performed.
        /// <param name="transition">The target transition.</param>
        /// </summary>
        void OnTransitionPerformed (StateTransition transition) {
            if (transition != null) {
                // Get the target transitionGUI
                for (int i = 0; i < m_TransitionGUIs.Count; i++) {
                    if (m_TransitionGUIs[i].transition == transition) {
                        // Warns that a transition was performed
                        m_TransitionGUIs[i].OnTransitionPerformed();
                        break;
                    }
                }
            }
        }
        #endregion Transition Visual Debugging

        
        #region Context Menu
        /// <summary>
        /// Shows the context menu.
        /// </summary>
        protected virtual void OnContextMenu () {
            // Create the menu
            var menu = new UnityEditor.GenericMenu();

            if (m_State != null) {

                // Set as start state
                if (m_State.fsm != null && !(m_State is InternalAnyState))
                    menu.AddItem(new GUIContent("Set as Start"), false, delegate () {StateUtility.SetAsStart(m_State); this.Refresh();});
                else
                    menu.AddDisabledItem(new GUIContent("Set as Start"));

                // Set as concurrent state
                if (m_State.fsm != null && !(m_State is InternalAnyState)) {
                    if (m_IsConcurrent)
                        menu.AddItem(new GUIContent("Set as Not Concurrent"), false, delegate () {StateUtility.RemoveConcurrentState(m_State.fsm); this.Refresh();});
                    else
                        menu.AddItem(new GUIContent("Set as Concurrent"), false, delegate () {StateUtility.SetAsConcurrent(m_State); this.Refresh();});
                }
                else
                    menu.AddDisabledItem(new GUIContent("Set as Concurrent"));

                // Set as enabled
                if (m_State.fsm != null /*&& m_State.fsm.enabled*/ && Application.isPlaying && !(m_State is InternalAnyState))
                    menu.AddItem(new GUIContent("Set as Enabled"), false, delegate () {m_State.enabled = true;});
                else
                    menu.AddDisabledItem(new GUIContent("Set as Enabled"));

                // Add Transitions
                // Add none
                menu.AddItem(new GUIContent("Add Transition/None"), false, delegate () {StateUtility.AddTransition(m_State, 0); CreateTransitionGUIs();});

                // Add blackboard events
                var blackboard = m_State.blackboard;
                if (blackboard != null) {
                    foreach (var fsmEvent in blackboard.fsmEvents) {
                        int eventId = fsmEvent.id;
                        menu.AddItem(new GUIContent("Add Transition/" + fsmEvent.name), false, delegate () {StateUtility.AddTransition(m_State, eventId); CreateTransitionGUIs();});
                    }
                }

                // Add GlobalBlackboard events
                // This is not The GlobalBlackboard?
                if (InternalGlobalBlackboard.Instance != null && blackboard != InternalGlobalBlackboard.Instance) {
                    foreach (var globalEvent in InternalGlobalBlackboard.Instance.fsmEvents) {
                        int eventId = globalEvent.id;
                        var eventName = globalEvent.isSystem ? "Add Transition/System/" + globalEvent.name : "Add Transition/Global/" + globalEvent.name;
                        menu.AddItem(new GUIContent(eventName), false, delegate () {StateUtility.AddTransition(m_State, eventId); CreateTransitionGUIs();});
                    }
                }
                
                // Separator
                menu.AddSeparator("");
                
                // Copy
                menu.AddItem(new GUIContent("Copy State"), false, delegate () {StateUtility.CopySelectedStates();});
                
                // Paste
                if (StateUtility.statesToPaste != null && StateUtility.statesToPaste.Length > 0 && m_State.fsm != null)
                    menu.AddItem(new GUIContent("Paste State"), false, delegate () {StateUtility.PasteStates(m_State.fsm);});
                else
                    menu.AddDisabledItem(new GUIContent("Paste State"));
                
                // Duplicate
                if (m_State.fsm != null)
                    menu.AddItem(new GUIContent("Duplicate State"), false, delegate () {
                        
                            var statesToPaste = new List<InternalStateBehaviour>(BehaviourWindow.activeStates);
                            if (!statesToPaste.Contains(m_State))
                                statesToPaste.Add(m_State);
                        
                            StateUtility.CloneStates(m_State.gameObject, statesToPaste.ToArray(), m_State.fsm);
                        }
                    );
                else
                    menu.AddDisabledItem(new GUIContent("Duplicate State"));
                
                // Separator
                menu.AddSeparator("");
                
                // Delete
                menu.AddItem(new GUIContent("Delete"), false, delegate () {StateUtility.Destroy(m_State); this.Refresh();});
            }
            else {
                menu.AddDisabledItem(new GUIContent("Set as Start"));
                menu.AddDisabledItem(new GUIContent("Set as Enabled"));
                menu.AddDisabledItem(new GUIContent("Add Transition"));
                menu.AddSeparator("");
                menu.AddDisabledItem(new GUIContent("Copy State"));
                menu.AddDisabledItem(new GUIContent("Paste State"));
                menu.AddSeparator("");
                menu.AddDisabledItem(new GUIContent("Delete"));
            }

            // Show the context menu
            menu.ShowAsContext();
        }

        /// <summary>
        /// Shows a context menu for the supplied transition.
        /// <param name="transition">The target transition.</param>
        /// </summary>
        void ShowContextMenu (StateTransition transition) {
            var menu = new UnityEditor.GenericMenu();
            var currentEventID = transition.eventID;

            // Add none
            menu.AddItem(new GUIContent("None"), currentEventID == 0, delegate () {StateUtility.SetNewEvent(m_State, transition, 0); this.Refresh();});

            // Add blackboard events
            var blackboard = m_State.blackboard;
            if (blackboard != null) {
                foreach (var fsmEvent in blackboard.fsmEvents) {
                    int eventId = fsmEvent.id;
                    menu.AddItem(new GUIContent(fsmEvent.name), currentEventID == fsmEvent.id, delegate () {StateUtility.SetNewEvent(m_State, transition, eventId); this.Refresh();});
                }
            }

            // Add GlobalBlackboard events
            // This is not The GlobalBlackboard?
            if (InternalGlobalBlackboard.Instance != null && blackboard != InternalGlobalBlackboard.Instance) {
                foreach (var globalEvent in InternalGlobalBlackboard.Instance.fsmEvents) {
                    int eventId = globalEvent.id;
                    var eventName = globalEvent.isSystem ? "System/" + globalEvent.name : "Global/" + globalEvent.name;
                    menu.AddItem(new GUIContent(eventName), currentEventID == globalEvent.id, delegate () {StateUtility.SetNewEvent(m_State, transition, eventId); this.Refresh();});
                }
            }

            menu.AddSeparator("");  // Separator

            menu.AddItem(new GUIContent("Delete"), false, delegate () {StateUtility.RemoveTransition(m_State, transition); this.Refresh();});

            // Shows the context menu
            menu.ShowAsContext();
        }
        #endregion Context Menu

        /// <summary>
        /// Draw the event name of the transitions.
        /// </summary>
        protected virtual void DrawEventName () {
            // Create the rect
            Rect rect = new Rect(0, StateGUI.defaultHeight - 2, StateGUI.defaultWidth, TransitionGUI.defaultHeight);
            
            // Draw transitions event name
            for (int i = 0; i < m_TransitionGUIs.Count; i++) {
                // Draw event name
                m_TransitionGUIs[i].DrawEventName(rect);
                // Update rect.y pos
                rect.y += TransitionGUI.defaultHeight;
            }
        }

        /// <summary> 
        /// Draw the contents of the GUI.Window.
        /// <param name="id">The unique id of the window.</param> 
        /// </summary>
        void StateGUIWindow (int id) {

            // Draw the name and the icon state
            Rect rectName = new Rect(0, 12f, defaultWidth, c_WindowTitleHeight);
            GUI.Label(rectName, new GUIContent(m_State.stateName, m_Icon), s_Styles.windowTitle);

            // If this state is enabled then draw the enabled bar
            if (Application.isPlaying && m_State.enabled && Event.current.type == EventType.Repaint) {
                // Get the background position
                Rect backgroundPos = s_Styles.enabledBarBackground.margin.Remove (new Rect(0f, rectName.yMax + 5f, defaultWidth, 10f));

                // Get the foreground position
                Rect foregroundPos = s_Styles.enabledBarBackground.padding.Remove (backgroundPos);
                foregroundPos.width = foregroundPos.width * Mathf.Repeat(Time.time, 1f);

                // Draw foreground bar
                s_Styles.enabledBar.Draw(foregroundPos, false, false, false, false);
                // Draw background
                s_Styles.enabledBarBackground.Draw(backgroundPos, false, false, false, false);
            }


            if (m_TransitionGUIs != null) {
                // Get the current event
                Event current = Event.current;

                // It's a repaint event?
                if (current.type == EventType.Repaint) {
                    DrawEventName();
                }
                // It's a mouse down event?
                else if (current.type == EventType.MouseDown) {
                    // Create the rect
                    Rect rect = new Rect(0, StateGUI.defaultHeight - 2, StateGUI.defaultWidth, TransitionGUI.defaultHeight);
                    // Get the mouseposition
                    Vector2 mousePos = current.mousePosition;
                    
                    // Logic for mouse click in event names
                    for (int i = 0; i < m_TransitionGUIs.Count; i++) {
                        if (rect.Contains(mousePos)) {
                            if (Event.current.button == 1) {
                                BehaviourWindow.activeState = m_State;
                                BehaviourWindow.activeTransition = m_TransitionGUIs[i].transition;
                                ShowContextMenu(m_TransitionGUIs[i].transition);
                                Event.current.Use();
                            }
                            else if (Event.current.button == 0) {
                                BehaviourWindow.activeState = m_State;
                                BehaviourWindow.activeTransition = m_TransitionGUIs[i].transition;
                                TransitionDragAndDrop.PrepareStartDrag(m_TransitionGUIs[i], this); // Should always be called after BehaviourWindow.activeTransition
                                Event.current.Use();
                            }
                        }
                        // Update rect.y pos
                        rect.y += TransitionGUI.defaultHeight;
                    }
                }
            }

            switch (Event.current.type) {
                // Is mouse button down?
                case EventType.MouseDown:
                    if (Event.current.button == 1) {
                        OnContextMenu();
                        Event.current.Use();
                    }
                    // Is the left mouse button?
                    else if (Event.current.button == 0) {
                        // Focus in this window
                        s_DraggedWindow = id;
                        // Select this state?
                        if (BehaviourWindow.activeStates.Length <= 1)
                            BehaviourWindow.activeState = m_State;
                        // Unselect transition
                        BehaviourWindow.activeTransition = null;

                        // Double click?
                        if (Event.current.clickCount >= 2) {
                            // The state is a parent state?
                            if (m_State is ParentBehaviour) {
                                // Selects the parent state
                                BehaviourWindow.activeParent = m_State as ParentBehaviour;
                                Event.current.Use();
                            }
                            // The state is a MonoScript?
                            else if (m_State is InternalMonoState) {
                                // Selects the MonoBehaviour game object.
                                var monoState = m_State as InternalMonoState;
                                if (monoState.monoBehaviour != null) {
                                    Selection.activeGameObject = monoState.monoBehaviour.gameObject;
                                    Event.current.Use();
                                }
                            }
                            // Opens the state script
                            else {
                                var monoScript = MonoScript.FromMonoBehaviour(m_State); // Gets the script.
                                if (monoScript != null) {
                                    AssetDatabase.OpenAsset(monoScript);    // Opens script in default application.
                                    Event.current.Use();
                                }
                            }
                        }
                    }
                    break;
                // Mouse button up?
                case EventType.MouseUp:
                    if (s_DraggedWindow == id)
                        s_DraggedWindow = -1;
                    break;
            }

            // GUI.DragWindow();
            DragStateGUIs();
        }

        /// <summary>
        /// Drag all selected state nodes.
        /// <summary>
        protected void DragStateGUIs () {
            Event current = Event.current;
            int controlID = GUIUtility.GetControlID (StateGUI.s_DragNodesControlID, FocusType.Passive);
            
            switch (current.GetTypeForControl (controlID)) {
                case EventType.MouseDown:
                    if (current.button == 0) {
                        StateGUI.s_LastMousePosition = GUIClip.Unclip(current.mousePosition);
                        StateGUI.s_DragNodeDistance = Vector2.zero;
                        foreach (InternalStateBehaviour current2 in BehaviourWindow.activeStates) {
                            StateGUI.s_InitialDragStatePositions [current2] = current2.position;
                        }

                        GUIUtility.hotControl = controlID;
                        current.Use ();
                    }
                    break;

                case EventType.MouseUp:
                    if (GUIUtility.hotControl == controlID) {
                        foreach (InternalStateBehaviour current3 in BehaviourWindow.activeStates) {
                            if (current3.position != StateGUI.s_InitialDragStatePositions[current3]) {
                                EditorUtility.SetDirty(current3);
                            }
                        }

                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        // Clear snap shot undo
                        Undo.ClearSnapshotTarget();
                        #endif

                        StateGUI.s_InitialDragStatePositions.Clear ();
                        GUIUtility.hotControl = 0;
                        current.Use();
                    }
                    break;

                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == controlID) {
                        StateGUI.s_DragNodeDistance += GUIClip.Unclip (current.mousePosition) - StateGUI.s_LastMousePosition;
                        StateGUI.s_LastMousePosition = GUIClip.Unclip (current.mousePosition);
                        InternalStateBehaviour[] activeStates = BehaviourWindow.activeStates;

                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        // Set SnapShot for undo
                        Undo.SetSnapshotTarget(activeStates, "Moved State");
                        #else
                        Undo.RecordObjects(activeStates, "Moved State");
                        #endif

                        // Change position
                        foreach (InternalStateBehaviour current4 in activeStates) {
                            current4.position = StateGUI.s_InitialDragStatePositions[current4] + StateGUI.s_DragNodeDistance;
                        }

                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        // Register undo
                        Undo.CreateSnapshot();
                        Undo.RegisterSnapshot();
                        #endif

                        current.Use();
                    }
                    break;

                case EventType.KeyDown:
                    if (GUIUtility.hotControl == controlID && current.keyCode == KeyCode.Escape) {
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        // Cancel undo
                        Undo.RestoreSnapshot();

                        // Restore initial position
                        foreach (InternalStateBehaviour current5 in BehaviourWindow.activeStates) {
                            current5.position = StateGUI.s_InitialDragStatePositions[current5];
                        }
                        
                        #else
                        Undo.RevertAllInCurrentGroup();
                        #endif

                        StateGUI.s_InitialDragStatePositions.Clear ();
                        GUIUtility.hotControl = 0;
                        current.Use();
                    }
                    break;
            }
        }

        /// <summary>
        /// Refresh the state window.
        /// <summary>
        protected void Refresh () {
            if (BehaviourWindow.Instance != null)
                BehaviourWindow.Instance.Refresh();
        }
        #endregion Private Methods

        
        #region Public Methods
        /// <summary> 
        /// Draw the state as a GUI.Window.
        /// </summary>
        public void OnGUIWindow () {
            // Is there a valid styles object?
            if (s_Styles == null)
                s_Styles = new StateGUI.Styles();

            if (m_State != null) {
                // Is there a valid window style?
                if (m_WindowStyle == null || m_WindowStyleOn == null || m_State.color != m_StateColor)
                    SetWindowColor();

                var guiColor = GUI.color;   // cache gui color

                // This is the enabled state?
                // Animate window alpha
                // if (Application.isPlaying && m_State.enabled && Event.current.type == EventType.Repaint)
                //     GUI.color = Color.Lerp(s_Styles.activeColor, guiColor, Mathf.PingPong(Time.time, 1f));

                // Draw state window
                rect = GUI.Window (m_Id, rect, this.StateGUIWindow, GUIContent.none, Selection.Contains(m_State) ? m_WindowStyleOn : m_WindowStyle);

                // Restore gui color
                GUI.color = guiColor;
            }
            else
                this.Refresh(); // Used as a workaround the missing callback in the apply button prefab.

            // Transition connections
            if (Event.current.type == EventType.MouseDrag && TransitionDragAndDrop.candidateForDrag != null && m_TransitionGUIs.Contains(TransitionDragAndDrop.candidateForDrag) && !rect.Contains(Event.current.mousePosition)) {
                TransitionDragAndDrop.StartDrag();
            }
        }

        /// <summary> 
        /// Draw the transition lines.
        /// </summary>
        public virtual void DrawTransitionArrows () {
            // Is there a valid styles object?
            if (s_Styles == null)
                s_Styles = new StateGUI.Styles();

            // The state is not null?
            if (m_State != null) {
                // Get position
                Rect position = this.rect;
                // Draw the transitions arrows
                for(int i = 0; i < m_TransitionGUIs.Count; i++) {
                    m_TransitionGUIs[i].DrawDestinationArrow(position);
                }
            }
        }
        #endregion Public Methods
    }
}