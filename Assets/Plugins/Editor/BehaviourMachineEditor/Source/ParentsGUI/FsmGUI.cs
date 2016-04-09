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
    /// Class used to draw a StateMachine in the BehaviourWindow.
    /// <seealso cref="BehaviourMachine.StateMachine" />
    /// </summary>
    public class FsmGUI : ParentBehaviourGUI {

        #region Constants
        static readonly Color c_GridThinColorDark = new Color (0f, 0f, 0f, 0.18f);
        static readonly Color c_GridThickColorDark = new Color (0f, 0f, 0f, 0.28f);
        static readonly Color c_GridThinColorLight = new Color (0f, 0f, 0f, 0.1f);
        static readonly Color c_GridThickColorLight = new Color (0f, 0f, 0f, 0.15f);
        #endregion Constants

        
        /// <summary> 
        /// Returns a Rect that has the supplied points as opposite corners.
        /// <param name="corner1">One corner of the Rect.</param>
        /// <param name="corner1">Another corner of the Rect.</param>
        /// <returns>A Rect created using the supplied points.</returns>
        /// </summary>
        static Rect GetRectFromPoints (Vector2 corner1, Vector2 corner2) {
            Rect rect = new Rect (corner1.x, corner1.y, corner2.x - corner1.x, corner2.y - corner1.y);
            // The width is negative?
            if (rect.width < 0f) {
                rect.x += rect.width;
                rect.width = -rect.width;
            }
            // The height is negative?
            if (rect.height < 0f) {
                rect.y += rect.height;
                rect.height = -rect.height;
            }
            return rect;
        }

        
        #region Styles
        static FsmGUI.Styles s_Styles;

        /// <summary> 
        /// Store GUIStyles that are used by a FsmGUI.
        /// </summary>
        class Styles {
            public readonly GUIStyle background = "flow background";
            public readonly GUIStyle selectionRect = "SelectionRect";
        }
        #endregion Styles

        
        #region Members
        StateGUI[] m_StatesGUI;
        [SerializeField]
        Vector2 m_ScrollView;
        [SerializeField]
        Rect m_ViewRect;
        Vector2 m_LastMousePos;
        Color m_GridThickColor = Color.white;
        Color m_GridThinColor = Color.white;
        Vector2 m_SelectionStartPoint;
        bool m_SelectionRect = false;
    	#endregion Members

        
        #region Private Methods
        /// <summary> 
        /// Calculates the window view rect.
        /// </summary>
        void CalculateViewRect () {
            Rect oldViewRect = m_ViewRect;
            Rect position = this.position;

            if (m_StatesGUI != null && m_StatesGUI.Length > 0) {
                var minX = float.MaxValue;
                var minY = float.MaxValue;
                var maxWidth = float.MinValue;
                var maxHeight = float.MinValue;

                foreach (var guiState in m_StatesGUI) {
                    var guiStateRect = guiState.rect;

                    // Get the min x and y
                    if (guiStateRect.x < minX)
                        minX = guiStateRect.x;
                    if (guiStateRect.y < minY)
                        minY = guiStateRect.y;

                    // Get the max width and height
                    if (guiStateRect.x + guiStateRect.width > maxWidth)
                        maxWidth = guiStateRect.x + guiStateRect.width;
                    if (guiStateRect.y + guiStateRect.height > maxHeight)
                        maxHeight = guiStateRect.y + guiStateRect.height;
                }

                minX -= position.width * .8f;
                minY -= position.height * .8f;
                maxWidth += position.width * .8f;
                maxHeight += position.height * .8f;

                m_ViewRect = new Rect(minX, minY, Mathf.Max(position.width, maxWidth - minX), Mathf.Max(position.height, maxHeight - minY));
            }
            else {
                this.m_ViewRect = new Rect(position.width * -.4f, position.height * -.4f, position.width * 1.8f, position.height * 1.8f);
            }

            m_ScrollView.x += oldViewRect.x - m_ViewRect.x;
            m_ScrollView.y += oldViewRect.y - m_ViewRect.y;
        }

        
        #region Grid
        /// <summary> 
        /// Draws the graph grid.
        /// </summary>
        void DrawGrid () {
            if (Event.current.type != EventType.Repaint) {
                return;
            }

            LineGUI.lineMaterial.SetPass(0);
            GL.PushMatrix ();
            GL.Begin (GL.LINES);

            // Draws grid lines
            var minX = m_ViewRect.x + m_ScrollView.x;
            var minY = m_ViewRect.y + m_ScrollView.y;
            var pos = position; 
            var maxX = minX + pos.width;
            var maxY = minY + pos.height;

            this.DrawGridLines (12f, m_GridThinColor, new Vector2(minX, minY), new Vector2 (maxX, maxY));
            this.DrawGridLines (120f, m_GridThickColor, new Vector2(minX, minY), new Vector2 (maxX, maxY));

            GL.End ();
            GL.PopMatrix ();
        }

        /// <summary> 
        /// Draws the grid lines using GL methods.
        /// <param name="gridSize">Distance from lines.</param> 
        /// <param name="gridColor">The color of the lines.</param> 
        /// <param name="min">The minimum offset.</param> 
        /// <param name="min">The maximum offset.</param> 
        /// </summary>
        void DrawGridLines (float gridSize, Color gridColor, Vector2 min, Vector2 max) {
            GL.Color (gridColor);

            // Vertical lines
            for (float num = min.x - (min.x % gridSize); num < max.x; num += gridSize) {
                GL.Vertex (new Vector2 (num, min.y));
                GL.Vertex (new Vector2 (num, max.y));
            }
            // Horizontal lines
            for (float num2 = min.y - (min.y % gridSize); num2 < max.y; num2 += gridSize) {
                GL.Vertex (new Vector2 (min.x, num2));
                GL.Vertex (new Vector2 (max.x, num2));
            }
        }
        #endregion Grid

        
        #region Context Menu
        /// <summary>
        /// Shows the context menu.
        /// </summary>
        void OnContextMenu () {
            var menu = new GenericMenu();
            var activeFsm = BehaviourWindow.activeFsm;

            if (activeFsm != null) {
                m_LastMousePos = Event.current.mousePosition;
                // Get the states scripts
                MonoScript[] stateScripts = FileUtility.GetScripts<InternalStateBehaviour>();
                for (int i = 0; i < stateScripts.Length; i ++) {
                    System.Type type = stateScripts[i].GetClass();

                    // Get the component path
                    string componentPath = "Add State/";
                    AddComponentMenu componentMenu = AttributeUtility.GetAttribute<AddComponentMenu>(type, false);
                    if (componentMenu == null || componentMenu.componentMenu != string.Empty) {
                        componentMenu = AttributeUtility.GetAttribute<AddComponentMenu>(type, true);
                        if (componentMenu != null && componentMenu.componentMenu != string.Empty)
                            componentPath += componentMenu.componentMenu;
                        else
                            componentPath += type.ToString().Replace('.','/');

                        menu.AddItem(new GUIContent(componentPath), false, delegate () {
                                                                                            InternalStateBehaviour newState = StateUtility.AddState(activeFsm, type); 
                                                                                            // Sets the newState position and dirty flag
                                                                                            if (newState != null) {
                                                                                                newState.position = m_LastMousePos - new Vector2(StateGUI.defaultWidth, StateGUI.defaultHeight) * .5f;
                                                                                                EditorUtility.SetDirty(newState);
                                                                                            }
                                                                                        });
                    }
                }
            }
            else {
                menu.AddDisabledItem(new GUIContent("Add State"));
            } 

            // Separator
            menu.AddSeparator(""); 

            menu.AddItem(new GUIContent("Copy FSM"), false, delegate () {StateUtility.statesToPaste = new InternalStateBehaviour[] {activeFsm};});

            if (StateUtility.statesToPaste != null && StateUtility.statesToPaste.Length > 0 && activeFsm != null)
                menu.AddItem(new GUIContent("Paste State"), false, delegate () {StateUtility.PasteStates(activeFsm);});
            else
                menu.AddDisabledItem(new GUIContent("Paste State")); 

            // Separator
            menu.AddSeparator("");
                
            menu.AddItem(new GUIContent("Delete FSM"), false, delegate () {StateUtility.Destroy(activeFsm);});

            // menu.AddSeparator("");  // Separator

            // if (BehaviourWindow.Instance != null)
            //     menu.AddItem(new GUIContent("Refresh"), false, BehaviourWindow.Instance.Refresh);
            // else
            //     menu.AddDisabledItem(new GUIContent("Refresh"));

            // Shows the context menu
            menu.ShowAsContext();
        }
        #endregion Context Menu


        /// <summary>    
        /// Selects all states inside the supplied rect.
        /// <param name="rect">The selection rect.</param>
        /// </summary>    
        void SelectNodesInRect (Rect rect) {
            var selectedStates = new List<InternalStateBehaviour>();
            foreach (StateGUI currentStateGUI in m_StatesGUI) {
                Rect position = currentStateGUI.rect;
                if (position.xMax >= rect.x && position.x <= rect.xMax && position.yMax >= rect.y && position.y <= rect.yMax)
                    selectedStates.Add (currentStateGUI.state);
            }

            Selection.objects = selectedStates.ToArray();
        }


        /// <summary>  
        /// Returns the states in the supplied fsm hierarchy.  
        /// <prama name=f"fsm">The target fsm.</param>
        /// <prama name=f"exclude">Exclude the supplied StateMachine hierarchy.</param>
        /// <returns>All children in the fsm hierarchy.</returns>
        /// </summary>  
        InternalStateBehaviour[] GetStatesInHierarchy (InternalStateMachine fsm, InternalStateMachine exclude) {
            List<InternalStateBehaviour> states = new List<InternalStateBehaviour>();

            foreach (InternalStateBehaviour state in fsm.states) {
                if (!(state is InternalAnyState)) {
                    states.Add(state);

                    if (state != exclude) {
                        var fsmChild = state as InternalStateMachine;
                        if (fsmChild != null)
                            states.AddRange(GetStatesInHierarchy(fsmChild, exclude));
                    }
                }
            }

            return states.ToArray();
        }
        #endregion Private Methods

        
        #region Unity Callbacks
        /// <summary> 
        /// A Unity callback called when the object is loaded.
        /// Sets the grid line color.
        /// </summary>
        protected override void OnEnable () {
            base.OnEnable();

            // Sets the grid line colors
            if (EditorGUIUtility.isProSkin) {
                m_GridThickColor = c_GridThickColorDark;
                m_GridThinColor = c_GridThinColorDark;
            }
            else {
                m_GridThickColor = c_GridThickColorLight;
                m_GridThinColor = c_GridThinColorLight;
            }
        }

        /// <summary> 
        /// A Unity callback called when the object will be destroyed.
        /// Reset the guiState dragged window to avoid erros in the blackboard view ignore events and the GUIBehaviourTree.
        /// </summary>
        void OnDestroy () {
            StateGUI.ResetDraggedWindow();
        }
        #endregion Unity Callbacks

        
        #region Public Methods
        /// <summary> 
        /// Draw scroolView.
        /// </summary>
        public override void OnGUIBeforeWindows () {
            // Create styles?
            if (s_Styles == null)
                s_Styles = new Styles();

            // Draw the background and create a gui group
            GUI.BeginGroup(position, string.Empty, s_Styles.background);

            // Opens scroolView.
            var posWithoutScrollView = position;
            if (!BehaviourMachinePrefs.showScrollView) {
                posWithoutScrollView.width += 16f;
                posWithoutScrollView.height += 16f;
            }
            m_ScrollView = GUI.BeginScrollView(posWithoutScrollView, m_ScrollView, m_ViewRect);
            DrawGrid();

            // Calculate view rect?
            if (Event.current.type == EventType.Layout && StateGUI.draggedWindow != -1) {
                CalculateViewRect();
            }
            
            // Draw transitions arrows only for repaint events.
            else if (Event.current.type == EventType.Repaint && m_StatesGUI != null) {
                for (int i = 0; i < m_StatesGUI.Length; i++)
                    m_StatesGUI[i].DrawTransitionArrows();
            }
        }

        /// <summary> 
        /// Draw all states of the fsm as a GUI.Window.
        /// </summary>
        public override void OnGUIWindows () {
            // Draw guiState's window
            if (BehaviourWindow.activeFsm != null && m_StatesGUI != null) {
                for (int i = 0; i < m_StatesGUI.Length; i++)
                    m_StatesGUI[i].OnGUIWindow();
            }
        }

        /// <summary> 
        /// Draw the transition arrows.
        /// </summary>
        public override void OnGUIAfterWindows () {
            if (m_StatesGUI != null) {
                // Trying to create connections?
                if (TransitionDragAndDrop.dragging != null) {
                    switch (Event.current.type) {
                        // Mouse Up? Let's try to connect a transition destination...
                        case EventType.MouseUp:
                            // Mouse button left?
                            if (Event.current.button == 0) {
                                var mousePos = Event.current.mousePosition;

                                // The mouse is over a StateGUI?
                                foreach (var guiState in m_StatesGUI) {
                                    if (guiState.rect.Contains(mousePos)) {
                                        StateUtility.SetNewDestination (TransitionDragAndDrop.state, TransitionDragAndDrop.dragging, guiState.state);
                                        Refresh();
                                        Event.current.Use();
                                        break;
                                    }
                                }

                                // Ignores the Transition drag'n & drop operation 
                                TransitionDragAndDrop.AcceptDrag();
                                Repaint();
                            }
                            break;
                        // Cancel drag
                        case EventType.Used:
                            goto case EventType.Ignore;
                        case EventType.Ignore:
                            TransitionDragAndDrop.AcceptDrag();
                            Event.current.Use();
                            Repaint();
                            break;
                        // Draws the transition destination when dragging.
                        case EventType.Repaint:
                            // Is dragging?
                            if (TransitionDragAndDrop.isDragging) {
                                // Validate dragging members
                                var guiState = TransitionDragAndDrop.guiState;
                                if (guiState != null && guiState.state != null) {

                                    // Gets the mouse position and creates a Rect
                                    var mousePos = Event.current.mousePosition;
                                    var destRect = new Rect(mousePos.x, mousePos.y, 0, 0);
                                    var destYOffset = 0f;

                                    // The mouse is over a StateGUI?
                                    foreach (var _guiState in m_StatesGUI) {
                                        if (_guiState.rect.Contains(mousePos)) {
                                            // Updates the destRect and destYOffset.
                                            destRect = _guiState.rect;
                                            destYOffset = StateGUI.defaultHeight * .5f;
                                            break;
                                        }
                                    }

                                    // Draws the bezier line
                                    TransitionDragAndDrop.transitionGUI.DrawArrow(guiState.rect, destRect, destYOffset);
                                }
                            }
                            break;
                        case EventType.MouseDrag:
                            if (TransitionDragAndDrop.isDragging)
                                Repaint();
                            break;
                    }
                }
            }

            // Get the current event
            Event current = Event.current;
            var activeFsm = BehaviourWindow.activeFsm;  // cached activeFsm

            switch (current.type) {
                // Show context menu?
                case EventType.ContextClick:
                    OnContextMenu();
                    Event.current.Use();
                    break;
                case EventType.MouseDown:
                    // If the left mouse button is down then unselect the state and start the dragging rect
                    if (current.button == 0) {
                        BehaviourWindow.activeState = null;
                        EditorGUIUtility.hotControl = 0;
                        GUIUtility.keyboardControl = 0;
                        if (!current.alt && !current.shift) {
                            m_SelectionStartPoint = current.mousePosition;
                            m_SelectionRect = true;
                        }
                        current.Use();
                    }
                    break;
                // Event ignored?
                case EventType.Ignore:
                    // Cancel selection rect?
                    if (m_SelectionRect)
                        goto case EventType.MouseUp;
                    break;
                // Cancel selection rect?
                case EventType.MouseUp:
                    if (m_SelectionRect) {
                        m_SelectionRect = false;
                        GUIUtility.hotControl = 0;
                        SelectNodesInRect(GetRectFromPoints(m_SelectionStartPoint, current.mousePosition));
                        current.Use ();
                    }
                    break;
                // Selection rect?
                case EventType.MouseDrag:
                    if (m_SelectionRect) {
                        current.Use();
                    }
                    else if (current.button == 2) {
                        m_ScrollView -= current.delta;
                        current.Use();
                    }
                    break;
                // Delete selected states?
                case EventType.ValidateCommand:
                    // Use event to call event ExecuteCommand
                    if (current.commandName == "Paste" && activeFsm != null && StateUtility.statesToPaste != null && StateUtility.statesToPaste.Length > 0)
                        current.Use();
                    else if (current.commandName == "Copy" && activeFsm != null && Selection.objects.Length > 0)
                        current.Use();
                    else if (current.commandName == "Duplicate" && activeFsm != null) {
                        // Is there a selected state?
                        foreach (var obj in Selection.objects) {
                            if (obj is InternalStateBehaviour) {
                                current.Use();
                                break;
                            }
                        }
                    }
                    else if ((current.commandName == "Delete" || current.commandName == "SoftDelete") && BehaviourWindow.activeState != null)
                        current.Use();
                    break;
                case EventType.ExecuteCommand:
                    if (current.commandName == "Paste") {
                        StateUtility.PasteStates(activeFsm);
                    }
                    else if (current.commandName == "Copy")
                        StateUtility.CopySelectedStates();
                    else if (current.commandName == "Duplicate") {
                        StateUtility.CopySelectedStates();
                        StateUtility.PasteStates(activeFsm);
                    }
                    else if (current.commandName == "Delete" || current.commandName == "SoftDelete") {
                        foreach (InternalStateBehaviour state in Selection.objects)
                            StateUtility.Destroy(state);
                        Refresh();
                        current.Use();
                    }
                    break;
                // Dragging?
                case EventType.DragUpdated:
                    if (DragAndDrop.objectReferences.Length > 0 && DragAndDrop.objectReferences[0] is MonoScript && BehaviourWindow.activeFsm != null)
                        DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    break;
                // Drag perform?
                case EventType.DragPerform:
                    if (DragAndDrop.objectReferences.Length > 0 && DragAndDrop.objectReferences[0] is MonoScript && BehaviourWindow.activeFsm != null) {
                        var index = 0;                              // index of added states
                        var mousePosition = current.mousePosition - new Vector2(StateGUI.defaultWidth, StateGUI.defaultHeight) * .5f;
                        
                        // Register undo
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        Undo.RegisterSceneUndo("Add States");
                        #endif

                        // Get all GetScripts
                        var scripts = new List<MonoScript>();
                        foreach (var obj in DragAndDrop.objectReferences) {
                            var script = obj as MonoScript;
                            if (script != null)
                                scripts.Add(script);
                        }

                        // Go trough all monoscripts
                        foreach (MonoScript monoScript in scripts) {
                            var type = monoScript.GetClass();
                            // The type is a valid InternalStateBehaviour instance?
                            if (type != null && !type.IsAbstract) {
                                // Add state behaviour
                                if (type.IsSubclassOf(typeof(InternalStateBehaviour))) {
                                    var newState = StateUtility.AddState(activeFsm, type);

                                    // The state is valid?
                                    if (newState != null) {
                                        // Set the newState position
                                        newState.position = mousePosition + new Vector2(StateGUI.defaultWidth * index * .5f, 20f * index);
                                        index++;
                                    }
                                }
                                // Add mono state
                                else if (type.IsSubclassOf(typeof(MonoBehaviour))) {
                                    var newMonoState = StateUtility.AddState(activeFsm,typeof(InternalMonoState)) as InternalMonoState;

                                    // Set the newMonoState position
                                    if (newMonoState != null) {
                                        // Set mono state position
                                        newMonoState.position = mousePosition + new Vector2(StateGUI.defaultWidth * index * .5f, 20f * index);
                                        index++;
                                        newMonoState.monoBehaviour = newMonoState.gameObject.AddComponent(type) as MonoBehaviour;

                                        // Register undo
                                        #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2
                                        if (newMonoState.monoBehaviour != null)
                                            Undo.RegisterCreatedObjectUndo(newMonoState.monoBehaviour, "Add Component");
                                        #endif
                                    }
                                }
                            }
                        }

                        // Sets dirty flag
                        if (activeFsm.gameObject != null)
                            EditorUtility.SetDirty(activeFsm.gameObject);

                        // Accept drag
                        DragAndDrop.AcceptDrag();
                        current.Use();

                        Refresh();
                    }
                    break;
                // Draw the selection rect?
                case EventType.Repaint:
                    if (m_SelectionRect)
                        s_Styles.selectionRect.Draw (GetRectFromPoints (m_SelectionStartPoint, current.mousePosition), false, false, false, false);
                    break;
            }

            GUI.EndScrollView();    // Close scroolView.
            GUI.EndGroup();         // Close group
        }

        /// <summary> 
        /// Refresh all states, recreate the StateGUI list.
        /// </summary>
        public override void Refresh () {
            // Create the guiStates
            m_StatesGUI = null;
            var activeFsm = BehaviourWindow.activeFsm;
            if (activeFsm != null) {
                var guiStates = new List<StateGUI>();

                // Add states
                var states = activeFsm.states;
                if (states != null) {
                    for (int i = 0; i < states.Count; i ++) {
                        // Create and adds a new stateGUI
                        guiStates.Add(new StateGUI(guiStates.Count, states[i]));
                    }
                }

                m_StatesGUI = guiStates.ToArray();
            }
            CalculateViewRect();
            StateGUI.ResetDraggedWindow();
        }
        #endregion Public Methods
    }
}