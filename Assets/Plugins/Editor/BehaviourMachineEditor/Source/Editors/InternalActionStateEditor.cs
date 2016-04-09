//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Custom inspector for ActionStates.
    /// <seealso cref="BehaviourMachine.InternalActionState" />
    /// </summary>
    [CustomEditor(typeof(InternalActionState))]
    public class InternalActionStateEditor : Editor {

        #region Styles
        static InternalActionStateEditor.Styles s_Styles;

        /// <summary>
        /// Store GUIStyles and Colors used by ActionStateEditor objects.
        /// </summary>
        class Styles {

            public readonly GUIStyle label = new GUIStyle("label");
            public readonly GUIStyle ping = new GUIStyle("PR Ping");
            public readonly Color textColor;

            public Styles() {
                textColor = label.normal.textColor;
                label.padding = new RectOffset(0,0,0,0);
                ping.padding.top -= 1;
                ping.padding.bottom -= 1;
            }
        }
        #endregion Styles


        #region Members
        private InternalActionState m_ActionState;
        private ReorderableList m_NodeList = null;
        NodeEditor m_NodeEditor;
        Dictionary<int, NodeStatusTime> m_NodeStatusTime = new Dictionary<int, NodeStatusTime>();
        #endregion Members

        
        #region Behaviour Machine Callback
        /// <summary>
        /// A callback invoked whenever a node change its status.
        /// <param name="node">The target node.</param>
        /// </summary>
        private void OnNodeTick (ActionNode node) {
            // The node belongs to the active tree?
            if (node.owner as InternalActionState == m_ActionState && node.status != Status.Ready) {
                // The node status is already been tracked?
                if (m_NodeStatusTime.ContainsKey(node.instanceID)) {
                    // Update time
                    m_NodeStatusTime[node.instanceID].Update(node.status);
                }
                else {
                    // Create a new entry
                    m_NodeStatusTime.Add(node.instanceID, new NodeStatusTime(node.status));
                }
            }
        }

        /// <summary>
        /// Returns the active node.
        /// <returns>The active node.</returns>
        /// </summary>
        private ActionNode GetActiveNode () {
            if (m_ActionState != null) {
                // Get the active node id
                int activeNodeID = BehaviourWindow.activeNodeID;

                // Searchs for the node
                foreach (ActionNode n in m_ActionState.GetNodes()) {
                    if (n.instanceID == activeNodeID)
                        return n;
                }
            }
            return null;
        }

        /// <summary>
        /// Behaviour Machine callback called whenever the active node changes.
        /// </summary>
        private void ActiveNodeChanged () {
            // Get the active node
            ActionNode activeNode = this.GetActiveNode();
            
            if (activeNode != null)
                // Create an editor node for the active node
                m_NodeEditor = activeNode == null ? null : NodeEditor.CreateEditor(activeNode.GetType());
            
            // Repaint this inspector
            this.Repaint();
        }
        #endregion Behaviour Machine Callback

        
        #region List Callbacks
        /// <summary>
        /// Show the node menu.
        /// <param name="node">The target node.</param>
        /// </summary>
        void NodeContextMenu (ActionNode node) {
            // Validate Paramenters
            if (node == null)
                return;
            
            // Create the menu
            var menu = new UnityEditor.GenericMenu();

            // Copy/Cut/Paste/Duplicate
            menu.AddItem(new GUIContent("Copy"), false, delegate () {BehaviourTreeUtility.nodeToPaste = node;});
            menu.AddItem(new GUIContent("Cut"), false, delegate () {BehaviourTreeUtility.nodeToPaste = node; OnDestroyNode(node);});

            ActionNode[] nodesToPaste = ActionStateUtility.GetActionsAndConditions(BehaviourTreeUtility.nodeToPaste != null ? new ActionNode[] {BehaviourTreeUtility.nodeToPaste} : new ActionNode[0]);
            if (nodesToPaste.Length > 0)
                menu.AddItem(new GUIContent("Paste"), false, delegate () {ActionStateUtility.PasteNodes(m_ActionState, nodesToPaste);});
            else
                menu.AddDisabledItem(new GUIContent("Paste"));

            menu.AddItem(new GUIContent("Duplicate"), false, delegate () {ActionStateUtility.PasteNodes(m_ActionState, new ActionNode[] {node});});

            // Separator
            menu.AddSeparator("");

            // Delete
            menu.AddItem(new GUIContent("Delete"), false, delegate () {this.OnDestroyNode(node);});

            // Show the context menu
            menu.ShowAsContext();
        }

        /// <summary>
        /// Callback to add a new node.
        /// </summary>
        private void OnAddNode (ReorderableList list) {
            // Get all node scripts
            var nodeTypes = new List<System.Type>();
            foreach (System.Type type in BehaviourTreeUtility.GetNodeTypes()) {
                if (!type.IsSubclassOf(typeof(BranchNode)))
                    nodeTypes.Add(type);
            }

            // Create the menu
            var menu = new UnityEditor.GenericMenu();

            // Add node types to the menu
            for (int i = 0; i < nodeTypes.Count; i++) {
                var nodeType = nodeTypes[i];
                var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(nodeType, false) ?? new NodeInfoAttribute();
                menu.AddItem(new GUIContent(nodeInfo.category + nodeType.Name), false, delegate () {ActionStateUtility.AddNode(m_ActionState, nodeType); RegisterEditorOnGUI();});
            }

            // Show the context menu
            menu.ShowAsContext();
        }

        /// <summary>
        /// Callback to remove the selected node.
        /// <param name="list">The target list.</param>
        /// </summary>
        private void OnRemoveSelectedNode (ReorderableList list) {
            // Get the selected node
            var selectedNode = m_ActionState.GetNodes()[m_NodeList.index];
            // Destroy selected node
            OnDestroyNode(selectedNode);
        }

        /// <summary>
        /// Callback to destroy a node.
        /// <param name="node">The node to be destroyed.</param>
        /// </summary>
        void OnDestroyNode (ActionNode node) {
            // It's not the Update node?
            if (node != null && !(node is Update))
                ActionStateUtility.DestroyNode(node);

            RegisterEditorOnGUI();
        }

        /// <summary>
        /// Callback to update the selected node.
        /// <param name="list">The target list.</param>
        /// </summary>
        private void OnSelectNode (ReorderableList list) {
            int index = list.index;
            ActionNode[] nodes = m_ActionState.GetNodes();
            if (index >= 0 && index < nodes.Length)
                BehaviourWindow.activeNodeID = nodes[index].instanceID;
        }

        /// <summary>
        /// Callback called whenever the supplied list changes its order.
        /// <param name="list">The target list.</param>
        /// </summary>
        private void OnReorderNode (ReorderableList list) {
            // Register Undo
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            Undo.RegisterUndo(m_ActionState,"Move Node");
            #else
            Undo.RecordObject(m_ActionState,"Move Node");
            #endif

            // Set dirty flag
            StateUtility.SetDirty(m_ActionState);

            m_ActionState.HierarchyChanged();

            RegisterEditorOnGUI();
        }

        /// <summary>
        /// Draw a node.
        /// <param name="rect">The rect to draw the node.</param>
        /// <param name="index">The index of the node to be drawn.</param>
        /// <param name="selected">The node is selected?</param>
        /// <param name="focused">The node is being focused?</param>
        /// </summary>
        private void DrawNode (Rect rect, int index, bool selected, bool focused) {
            ActionNode[] nodes = m_ActionState.GetNodes();

            if (index < 0 || index >= nodes.Length)
                return;

            // Get the node
            ActionNode node = nodes[index];

            Event current = Event.current;

            switch (current.type) {
                case EventType.Repaint:
                    // Get the node id
                    int nodeId = node.instanceID;
                    // Create the gui content
                    var guiContent = new GUIContent(node.name, IconUtility.GetIcon(node.GetType()));
                    // Get the guiStyle
                    var guiStyle = InternalActionStateEditor.s_Styles.label;

                    // Set style color
                    if (node is ConditionNode) {
                        guiStyle.normal.textColor = TreeGUI.Yellow;
                        guiStyle.focused.textColor = TreeGUI.Yellow;
                    }
                    else if (node is MissingNode) {
                        guiStyle.normal.textColor = TreeGUI.Red;
                        guiStyle.focused.textColor = TreeGUI.Red;
                    }
                    else if (node is BranchNode) {
                        guiStyle.normal.textColor = s_Styles.textColor;
                        guiStyle.focused.textColor = s_Styles.textColor;
                    }
                    // else if (node is ICallbackNode) {
                    //     guiStyle.normal.textColor = TreeGUI.Blue;
                    //     guiStyle.focused.textColor = TreeGUI.Blue;
                    // }
                    else {
                        guiStyle.normal.textColor = TreeGUI.Green;
                        guiStyle.focused.textColor = TreeGUI.Green;
                    }

                    // Draw the node name and icon
                    Rect nodeRect = rect;
                    nodeRect.yMin += 1;
                    nodeRect.yMax -= 4;
                    guiStyle.Draw(nodeRect, guiContent, focused, focused, selected, focused);

                    // Draw visual debugging?
                    if (Application.isPlaying && m_NodeStatusTime.ContainsKey(nodeId)) {
                        var pingStyle = InternalActionStateEditor.s_Styles.ping;
                        var pingRect = nodeRect;
                        pingRect.xMax = pingStyle.CalcSize(guiContent).x + (guiContent.image.height > 16f ? 0f : 28f);
                        pingRect.xMin -= 8f;
                        pingRect.yMin += 1f;
                        pingRect.yMax -= 1f;
                        // pingRect.y += 1f;
                        // pingRect.height -= 2f;

                        // Get the delta time
                        var dt = (float) (EditorApplication.timeSinceStartup - m_NodeStatusTime[nodeId].time);

                        // Set gui color
                        Color oldColor = GUI.color;
                        switch (m_NodeStatusTime[nodeId].status) {
                            case Status.Success:
                                GUI.color = new Color(0f, .8f, 0f, 1f - dt);    // green
                                break;
                            case Status.Failure:
                                GUI.color = new Color(.8f, .8f, 0f, 1f - dt);   // yellow
                                break;
                            case Status.Error:
                                GUI.color = new Color(.8f, 0f, 0f, 1f - dt);    // red
                                break;
                            case Status.Running:
                                GUI.color = new Color(0f, 0f, 1f, .6f - dt);    // blue
                                break;
                        }

                        // Draw ping for one second
                        if (dt >= 1f)
                            m_NodeStatusTime.Remove(nodeId);

                        // Draw ping
                        pingStyle.Draw(pingRect, guiContent, false, false, false, false);
                        // Restore old gui color
                        GUI.color = oldColor;
                    }
                    break;

                case EventType.MouseDown:
                    if (current.button == 1 && rect.Contains(current.mousePosition)) {
                        NodeContextMenu(node);
                        current.Use();
                    }
                    break;
            }
        }

        /// <summary>
        /// Update the selected/active node.
        /// </summary>
        private void UpdateActiveNode () {
            if (m_NodeList != null && m_ActionState != null) {
                m_NodeList.list = m_ActionState.GetNodes();
                ActionNode activeNode = this.GetActiveNode();
                if (activeNode != null)
                    m_NodeList.index = activeNode.GetIndex();
                else
                    this.OnSelectNode(m_NodeList);
            }
        }
        #endregion List Callbacks


        /// </summary>
        /// Register OnGUI node in editor mode.
        /// </summary>
        void RegisterEditorOnGUI () {
            if (!EditorApplication.isPlayingOrWillChangePlaymode) {
                if (m_ActionState.onGUINode != null && ((m_ActionState.isRoot && BehaviourWindow.activeState == null) || m_ActionState == BehaviourWindow.activeState)) {
                    GUICallback.ResetCallbacks();
                    GUICallback.onGUI += m_ActionState.onGUINode.EditorOnTick;
                }
            }
        }


        #region Unity Callbacks
        /// <summary>
        /// A Unity callback called when the object is loaded.
        /// </summary>
        private void OnEnable () {
            m_ActionState = target as InternalActionState;
            BehaviourWindow.activeNodeChanged += this.ActiveNodeChanged;

            // Try to create an editor for the current active node
            this.ActiveNodeChanged();

            // Register the visual debugging callback
            ActionNode.onNodeTick += OnNodeTick;

            // Register Update
            if (Application.isPlaying) {
                EditorApplication.update += this.Update;
            }
            else {
                m_ActionState.LoadNodes();
                RegisterEditorOnGUI();
            }
        }

        /// <summary>
        /// A Unity callback called when the object goes out of scope.
        /// </summary>
        private void OnDisable () {
            BehaviourWindow.activeNodeChanged -= this.ActiveNodeChanged;

            // Unregister the callback for visual debugging
            ActionNode.onNodeTick -= OnNodeTick;

            // Register Update
            if (Application.isPlaying)
                EditorApplication.update -= this.Update;
            else
                GUICallback.ResetCallbacks();
        }

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update () {
            this.Repaint();
        }

        /// <summary> 
        /// Unity callback to draw a custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            // Create styles?
            if (s_Styles == null)
                s_Styles = new InternalActionStateEditor.Styles();

            // Workaround to update nodes
            if (Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed") {
                GUIUtility.hotControl = 0;
                GUIUtility.keyboardControl = 0;
                m_ActionState.LoadNodes();
                UpdateActiveNode();
                return;
            }

            // Reload nodes?
            if (m_ActionState.isDirty) {
                m_ActionState.LoadNodes();
                UpdateActiveNode();
            }

            // Register OnGUI node?
            if (!Application.isPlaying && m_ActionState.onGUINode != null && !GUICallback.HasCallbacks()) {
                this.RegisterEditorOnGUI();
            }

            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            EditorGUIUtility.LookLikeInspector();
            #endif

            // Draw default inspector
            DrawDefaultInspector();

            // Shows the node editor?
            bool showNodeEditor = m_ActionState.parent == null || BehaviourWindow.activeState == m_ActionState;

            // Draw Action List
            if (m_NodeList == null) {
                // m_NodeList = new ReorderableList(this.serializedObject, this.serializedObject.FindProperty("m_UpdateActions"));
                m_NodeList = new ReorderableList(m_ActionState.GetNodes(), typeof(ActionNode));
                m_NodeList.drawHeaderCallback += delegate (Rect rect) {EditorGUI.LabelField(rect, "Nodes");};
                m_NodeList.drawElementCallback += DrawNode;
                m_NodeList.onAddCallback += this.OnAddNode;
                m_NodeList.onRemoveCallback += this.OnRemoveSelectedNode;
                m_NodeList.onSelectCallback += this.OnSelectNode;
                m_NodeList.onReorderCallback += this.OnReorderNode;

                // Select the active node
                UpdateActiveNode();

                #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3
                m_NodeList.list = m_ActionState.GetNodes();
                m_NodeList.DoLayoutList();
                #else
                this.Repaint();
                #endif
            }
            else if (showNodeEditor) {
                m_NodeList.list = m_ActionState.GetNodes();
                m_NodeList.DoLayoutList();
            }

            if (showNodeEditor) {
                GUILayout.Space(6f);
                
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                EditorGUIUtility.LookLikeControls();
                #endif

                // Get the active node
                ActionNode activeNode = m_ActionState.isRoot ? this.GetActiveNode() : BehaviourWindow.activeNode;

                // Draw node properties
                if (m_NodeEditor != null) {
                    // Is there an active node?
                    if (activeNode != null && activeNode.owner as InternalActionState == m_ActionState) {
                        // It's an Update node
                        var oldGUIEnabled = GUI.enabled;
                        GUI.enabled = !(activeNode is Update);
                        m_NodeEditor.DrawNode(activeNode);
                        GUI.enabled = oldGUIEnabled;
                        GUILayout.Space(4f);
                    }
                }


                // Copy/Paste/Cut/Duplicate/Delete keyboard shortcuts
                Event current = Event.current;
                if (current.type == EventType.ValidateCommand) {
                    // Use event to call event ExecuteCommand
                    if (current.commandName == "Paste") {
                        ActionNode[] nodesToPaste = ActionStateUtility.GetActionsAndConditions(BehaviourTreeUtility.nodeToPaste != null ? new ActionNode[] {BehaviourTreeUtility.nodeToPaste} : new ActionNode[0]);
                        if (nodesToPaste.Length > 0)
                            current.Use();
                    }
                    if (activeNode != null) {
                        if (current.commandName == "Copy")
                            current.Use();
                        else if (current.commandName == "Duplicate")
                            current.Use();
                        else if (current.commandName == "Delete")
                            current.Use();
                        else if (current.commandName == "Cut")
                            current.Use();
                    }
                }
                else if (Event.current.type == EventType.ExecuteCommand) {
                    if (current.commandName == "Paste") {
                        ActionNode[] nodesToPaste = ActionStateUtility.GetActionsAndConditions(BehaviourTreeUtility.nodeToPaste != null ? new ActionNode[] {BehaviourTreeUtility.nodeToPaste} : new ActionNode[0]);
                        ActionStateUtility.PasteNodes(m_ActionState, nodesToPaste);
                    }
                    else if (current.commandName == "Copy")
                        BehaviourTreeUtility.nodeToPaste = activeNode;
                    else if (current.commandName == "Duplicate")
                        ActionStateUtility.PasteNodes(m_ActionState, new ActionNode[] {activeNode});
                    else if (current.commandName == "Delete")
                        this.OnDestroyNode(activeNode);
                    else if (current.commandName == "Cut") {
                        BehaviourTreeUtility.nodeToPaste = activeNode;
                        this.OnDestroyNode(activeNode);
                    }
                }
            }
        }
        #endregion Unity Callbacks
    }
}