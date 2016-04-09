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
    /// Class used to draw the states of a ParentBehaviour.
    /// <seealso cref="BehaviourMachineEditor.BehaviourTreeEditor" />
    /// </summary>
    public class ParentStatesEditor {

        #region Constants
        const float c_HeaderHeight = 18f;
        const float c_FooterHeight = 13f;
        const float c_ElementHeight = 21f;
        #endregion Constants

        #region Styles
        static ParentStatesEditor.Styles s_Styles;

        /// <summary> 
        /// A class to store GUIStyles that are used by a ParentStatesEditor.
        /// </summary>
        class Styles {
            public GUIContent iconToolbarPlus = new GUIContent(EditorGUIUtility.FindTexture("Toolbar Plus"), "Add New State");
            public GUIContent iconToolbarMinus = new GUIContent(EditorGUIUtility.FindTexture("Toolbar Minus"), "Delete/Unparent State");
            public readonly GUIStyle headerBackground = "RL Header";
            public readonly GUIStyle footerBackground = "RL Footer";
            public readonly GUIStyle boxBackground = "RL Background";
            public readonly GUIStyle elementBackground = new GUIStyle ("RL Element");
            public readonly GUIStyle preButton = "RL FooterButton";
        }
        #endregion Styles

        #region Members
        ParentBehaviour m_Parent;
        List<InternalStateBehaviour> m_States;
        int m_ActiveState = -1;
        SerializedProperty m_SerialProp; 
        #endregion Members

        #region Constructor
        /// <summary> 
        /// Class constructor.
        /// <param name="parent">The target parent to draw the states.</param> 
        /// <param name="serializedProperty">The serializedProperty.isExpanded is used to expand or colapse the states.</param> 
        /// </summary>
        public ParentStatesEditor (ParentBehaviour parent, SerializedProperty serializedProperty) {
            m_Parent = parent;
            m_SerialProp = serializedProperty;
        }
        #endregion Constructor

        #region Draw Methods
        /// <summary> 
        /// Draw the header.
        /// </summary>
        void DrawHeader () {
            Rect rect = GUILayoutUtility.GetRect (0f, c_HeaderHeight, new GUILayoutOption[] {GUILayout.ExpandWidth (true)});

            if (Event.current.type == EventType.Repaint) {
                // Draw background
                rect.xMin += 4f;
                rect.xMax -= 4f; 
                s_Styles.headerBackground.Draw (rect, false, false, false, false);
            }

            // Draw header title
            rect.xMin += 6f;
            rect.xMax -= 6f;
            rect.height -= 2f;
            rect.y += 1f;
            #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2
            rect.xMin += 8f;
            #endif
            m_SerialProp.isExpanded = EditorGUI.Foldout (rect, m_SerialProp.isExpanded, "States");
        }

        /// <summary> 
        /// Draw one state.
        /// <param name="rect">The position to draw the state.</param>
        /// <param name="index">The index of the state.</param>
        /// </summary>
        void DrawState (Rect rect, int index) {
            rect.yMin += 1f;
            rect.yMax -= 1f;

            if (Event.current.type == EventType.Repaint) {
                bool selected = index == m_ActiveState;
                s_Styles.elementBackground.Draw (rect, false, selected, selected, true);
            }

            rect.xMin += 6f;
            rect.xMax -= 31f;
            EditorGUI.LabelField (rect, m_States[index].stateName);

            rect = new Rect(rect.x + rect.width, rect.y, 25f, c_FooterHeight);
            if (GUI.Button(rect, s_Styles.iconToolbarMinus, s_Styles.preButton)) {
                OnDeleteUnparentContextMenu(m_States[index]);
            }
        }

        /// <summary> 
        /// Draw the parent states.
        /// </summary>
        void DrawStates () {
            if (Event.current.type == EventType.Layout || m_States == null)
                m_States = m_Parent.states;

            int size = m_States.Count;

            Rect rect = GUILayoutUtility.GetRect (10f, c_ElementHeight * (size == 0 ? 1 : size) + 7f, new GUILayoutOption[] {GUILayout.ExpandWidth (true)});
            
            // Draw background
            rect.xMin += 4f;
            rect.xMax -= 4f;
            if (Event.current.type == EventType.Repaint) {
                s_Styles.boxBackground.Draw (rect, false, false, false, false);
            }

            rect.yMin += 2f;
            rect.yMax -= 3f;
            var rect2 = rect;
            rect2.height = c_ElementHeight;

            // Draw states
            if (size > 0) {
                bool isMouseDown = Event.current.type == EventType.MouseDown;
                for (int i =0; i < size; i++) {
                    rect2.y = rect.y + i * c_ElementHeight;
                    DrawState (rect2, i);
                    if (isMouseDown && rect2.Contains(Event.current.mousePosition)) {
                        if (Event.current.clickCount >= 2) {
                            if (m_States[i] is ParentBehaviour)
                                BehaviourWindow.activeParent = m_States[i] as ParentBehaviour;
                            Selection.objects = new UnityEngine.Object[] {m_States[i]};
                        }
                        else {
                            m_ActiveState = i;
                        }
                        Event.current.Use();
                    }
                }
            }
            else {
                rect2.x += 6f;
                EditorGUI.LabelField (rect2, "List is Empty");
            }
        }

        /// <summary> 
        /// Draw the plus button to add new states.
        /// </summary>
        void DrawFooter () {
            Rect rect = GUILayoutUtility.GetRect (4f, c_FooterHeight, new GUILayoutOption[]{GUILayout.ExpandWidth (true)});
            rect.xMin += 4f;
            rect.xMax -= 4f;
            rect = new Rect (rect.x + rect.width - 33f, rect.y, 33f, rect.height);

            // Draw background
            if (Event.current.type == EventType.Repaint)
                s_Styles.footerBackground.Draw(rect, false, false, false, false);

            rect = new Rect(rect.x + 4f, rect.y - 4f, 25f, c_FooterHeight);
            if (GUI.Button(rect, s_Styles.iconToolbarPlus, s_Styles.preButton))
               OnAddContextMenu();
        }
        #endregion Draw Methods

        #region Context Menu
        /// <summary> 
        /// Shows a context menu to delete or unparent a state.
        /// <param name="state">The state to delete or unparent.</param>
        /// </summary>
        void OnDeleteUnparentContextMenu (InternalStateBehaviour state) {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Unparent"), false, this.OnUnparentState, state);
            menu.AddItem(new GUIContent("Delete"), false, this.OnDeleteState, state);
            menu.ShowAsContext();
        }

        /// <summary> 
        /// Context menu callback to unparent a state.
        /// <param name="userData">The state to unparent.</param>
        /// </summary>
        void OnUnparentState (object userData) {
            var state = userData as InternalStateBehaviour;
            if (state != null) {
                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(state, "Unparent State");
                #else
                Undo.RecordObject(state, "Unparent State");
                #endif

                state.parent = null;
                EditorUtility.SetDirty(state);
            }
        }

        /// <summary> 
        /// Context menu callback to delete a state.
        /// <param name="userData">The state to be deleted.</param>
        /// </summary>
        void OnDeleteState (object userData) {
            var state = userData as InternalStateBehaviour;
            if (state != null) {
                if (Application.isPlaying && !AssetDatabase.Contains(state.gameObject))
                    InternalStateBehaviour.Destroy(state);
                else {
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterSceneUndo("Delete");
                    Object.DestroyImmediate(state, true);
                    #else
                    Undo.DestroyObjectImmediate(state);
                    #endif
                }
            }
        }

        /// <summary> 
        /// Shows a context menu callback to add a new state.
        /// </summary>
        void OnAddContextMenu () {
            var menu = new GenericMenu();

            var stateScripts = FileUtility.GetScripts<InternalStateBehaviour>();
            for (int i = 0; i < stateScripts.Length; i ++) {
                System.Type childStateType = stateScripts[i].GetClass();

                // Get the component path
                string componentPath;
                AddComponentMenu componentMenu = AttributeUtility.GetAttribute<AddComponentMenu>(childStateType, true);
                if (componentMenu != null && componentMenu.componentMenu != string.Empty)
                    componentPath = componentMenu.componentMenu;
                else
                    componentPath = childStateType.ToString().Replace('.','/');

                menu.AddItem(new GUIContent(componentPath), false, delegate () {StateUtility.AddState(m_Parent, childStateType);});
            }

            // Shows the context menu
            menu.ShowAsContext();
        }
        #endregion Context Menu

        #region Public Methods
        /// <summary> 
        /// Call this method to draw the parent states in the gui.
        /// </summary>
        public void OnGUI () {
            if (s_Styles == null)
                s_Styles = new ParentStatesEditor.Styles();

            // Save indentlevel
            int indentLevel = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            this.DrawHeader();
            if (m_SerialProp.isExpanded) {
                this.DrawStates();
                this.DrawFooter();
            }

            // Restore indent level
            EditorGUI.indentLevel = indentLevel;
        }

        /// <summary> 
        /// Call this method to dispose the serializedProperty.
        /// </summary>
        public void DisposeProperty () {
            if (m_SerialProp != null)
                m_SerialProp.Dispose();
        }
        #endregion Public Methods
    }
}