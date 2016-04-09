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
    /// Class used to draw a BehaviourTree in the BehaviourWindow.
    /// </summary>
    public class TreeGUI : ParentBehaviourGUI {

        const float c_NodeHeigth = 16f;
        const float c_IndentSize = 16f;
        const float c_FoldoutSize = 12f;
        const string c_DraggedNode = "Dragged Node";

        #region Node Colors
        /// <summary>
        /// The red color of the node label.
        /// </summary>
        public static readonly Color Red = new Color (.55f, 0f, 0f);

        /// <summary>
        /// The green color of the node label.
        /// </summary>
        public static readonly Color Green = new Color (0f, .55f, 0f);

        /// <summary>
        /// The blue color of the node label.
        /// </summary>
        public static readonly Color Blue = new Color (.2f, .2f, .8f);

        /// <summary>
        /// The yellow color of the node label.
        /// </summary>
        public static readonly Color Yellow = new Color (.55f, .55f, 0f);

        /// <summary>
        /// The pink color of the node label.
        /// </summary>
        public static readonly Color Pink = new Color (.55f, .0f, .55f);

        /// <summary>
        /// The cyan color of the node label.
        /// </summary>
        public static readonly Color Cyan = new Color (0f, .55f, .55f);
        #endregion Node Colors

        
        #region Styles
        static TreeGUI.Styles s_Styles;

        /// <summary>
        /// Store GUIStyles and Colors used by TreeGUI objects.
        /// </summary>
        class Styles {
            public readonly GUIStyle foldout = "IN Foldout";
            public readonly GUIStyle insertion = new GUIStyle("PR Insertion");
            public readonly GUIStyle label = new GUIStyle("PR Label");
            public readonly GUIStyle hiLabel = "HI Label";
            public readonly GUIStyle ping = new GUIStyle("PR Ping");
            public readonly GUIStyle nameEdit = "PR TextField";
            public readonly Texture2D emptyIcon = Resources.Load("Icons/Empty") as Texture2D;

            public readonly Color textColor;

            public Styles() {
                // insertion.richText = true;
                label.richText = true;

                textColor = label.normal.textColor;

                ping.richText = true;
                ping.padding.top -= 1;
                ping.padding.bottom -= 1;
            }
        }
        #endregion Styles

        
        #region Members
        [SerializeField]
        List<int> m_Expanded;
        [SerializeField]
        Vector2 m_ScrollView;
        [System.NonSerialized]
        int m_LasTreeInstanceID = 0;

        BehaviourTreeProperty m_TreeProperty = new BehaviourTreeProperty();
        int m_LastClickedID = 0, m_EditNameID = 0;
        string m_NameEditString;
        Rect m_NameEditRect;
        DropDrag m_DropDrag = new DropDrag();
        Dictionary<int, NodeStatusTime> m_NodeStatusTime = new Dictionary<int, NodeStatusTime>();
        #endregion Members

        
        #region Private Methods
        /// <summary>
        /// A callback invoked whenever a node change its status.
        /// <param name="node">The target node.</param>
        /// </summary>
        void OnNodeTick (ActionNode node) {
            // The node belongs to the active tree?
            if (node.tree != null && node.tree.GetInstanceID() == BehaviourWindow.activeParentID && node.status != Status.Ready) {
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

        #region Context Menu
        /// <summary>
        /// Creates and shows a tree context menu.
        /// </summary>
        void OnTreeContextMenu () {
            var menu = new UnityEditor.GenericMenu();
            var activeTree = BehaviourWindow.activeTree;

            if (activeTree != null) {
                System.Type[] nodeTypes = BehaviourTreeUtility.GetNodeTypes();

                // Add function node
                for (int i = 0; i < nodeTypes.Length; i++) {
                    var nodeType = nodeTypes[i];
                    var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(nodeType, false) ?? new NodeInfoAttribute();
                    menu.AddItem(new GUIContent("Add Node/" + nodeInfo.category + nodeType.Name), false, delegate () {this.OnAddNewNode(nodeType, null);});
                }
            }
            else
                menu.AddDisabledItem(new GUIContent("Add Node"));

            // Show the Add Node window?
            menu.AddItem(new GUIContent("Add Node Window"), false, delegate () {EditorApplication.ExecuteMenuItem("Tools/BehaviourMachine/Add Node Window");});

            // Separator
            menu.AddSeparator("");

            menu.AddDisabledItem(new GUIContent("Copy"));
            menu.AddDisabledItem(new GUIContent("Cut"));
            if (BehaviourTreeUtility.nodeToPaste != null)
                menu.AddItem(new GUIContent("Paste"), false, delegate () {this.OnPasteNode(null);});
            else
                menu.AddDisabledItem(new GUIContent("Paste"));
            menu.AddDisabledItem(new GUIContent("Duplicate"));

            menu.AddSeparator("");

            menu.AddDisabledItem(new GUIContent("Soft Delete"));
            menu.AddDisabledItem(new GUIContent("Delete"));

            // menu.AddSeparator("");  // Separator

            // if (BehaviourWindow.Instance != null)
            //     menu.AddItem(new GUIContent("Refresh"), false, BehaviourWindow.Instance.Refresh);
            // else
            //     menu.AddDisabledItem(new GUIContent("Refresh"));

            // Shows the context menu
            menu.ShowAsContext();
        }

        /// <summary>
        /// Creates and shows a node context menu.
        /// <param name="node">The target node of the context menu.</param>
        /// </summary>
        void OnBehaviourContextMenu (ActionNode node) {
            var menu = new UnityEditor.GenericMenu();
            var branch = node as BranchNode;
            var nodeTypes = BehaviourTreeUtility.GetNodeTypes();

            // The node is a branch?
            if (branch != null) {
                // Add entries to the menu
                for (int i = 0; i < nodeTypes.Length; i++) {
                    System.Type childType = nodeTypes[i];
                    var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(childType, false) ?? new NodeInfoAttribute();
                    menu.AddItem(new GUIContent("Add Node/" + nodeInfo.category + childType.Name), false, delegate () {this.OnAddNewNode(childType, branch);});
                }
            }
            else
                menu.AddDisabledItem(new GUIContent("Add Node"));

            // Show the Add Node window?
            menu.AddItem(new GUIContent("Add Node Window"), false, delegate () {EditorApplication.ExecuteMenuItem("Tools/BehaviourMachine/Add Node Window");});

            // Separator
            menu.AddSeparator("");

            // Copy/Cut/Paste/Duplicate
            menu.AddItem(new GUIContent("Copy"), false, delegate () {BehaviourTreeUtility.nodeToPaste = node;});
            menu.AddItem(new GUIContent("Cut"), false, delegate () {BehaviourTreeUtility.nodeToPaste = node; OnDestroyNode(node);});
            if (BehaviourTreeUtility.nodeToPaste != null)
                menu.AddItem(new GUIContent("Paste"), false, delegate () {this.OnPasteNode(node as BranchNode);});
            else
                menu.AddDisabledItem(new GUIContent("Paste"));
            menu.AddItem(new GUIContent("Duplicate"), false, delegate () {BehaviourTreeUtility.nodeToPaste = node; this.OnPasteNode(node.branch);});


            // Separator
            menu.AddSeparator("");

            // The node is a branch and has less than one child or its not a root and the parent is not a decorator?
            if (branch != null && (branch.children.Length < 2 || (branch.branch != null && !(branch.branch is DecoratorNode)))) {
                menu.AddItem(new GUIContent("Soft Delete"), false, delegate () {this.OnRemoveBranch(branch);});
            }
            else {
                menu.AddItem(new GUIContent("Soft Delete"), false, delegate () {this.OnDestroyNode(node);});
            }

            menu.AddItem(new GUIContent("Delete"), false, delegate () {this.OnDestroyNode(node);});

            // Shows the context menu
            menu.ShowAsContext();
        }

        /// <summary>
        /// Callback to create a new child node.
        /// <param name="type">The new node type.</param>
        /// <param name="branch">The branch of the new node; or null if its a root node.</param>
        /// </summary>
        void OnAddNewNode (System.Type type, BranchNode branch) {
            ActionNode newNode = null;
            InternalBehaviourTree activeTree = BehaviourWindow.activeTree;

            // Add node
            if (branch != null)
                newNode = BehaviourTreeUtility.AddNode(branch, type);
            else if (activeTree != null)
                newNode = BehaviourTreeUtility.AddNode(activeTree, type);

            if (newNode != null) {
                // Is the new node a child of the branch?
                if (branch != null && newNode.branch == branch)
                    SetExpanded(branch.instanceID, true);   // Expand branch

                // Select newNode
                BehaviourWindow.activeNodeID = newNode.instanceID;

                // Update data
                Refresh();
            }
        }

        /// <summary>
        /// Callback to paste a node.
        /// <param name="parent">The parent node to be pasted or null to paste as a root node.</param>
        /// </summary>
        void OnPasteNode (BranchNode parent) {
            var newNode = BehaviourTreeUtility.PasteNode(BehaviourWindow.activeTree, parent);

            if (newNode != null) {
                // Select newNode
                BehaviourWindow.activeNodeID = newNode.instanceID;
                // Update data
                Refresh();
            }
        }

        /// <summary>
        /// Callback to destroy a node.
        /// <param name="node">The node to be destroyed.</param>
        /// </summary>
        void OnDestroyNode (ActionNode node) {
            if (node != null && BehaviourTreeUtility.DestroyNode(node)) {
                // Save tree and marks dirty flag
                StateUtility.SetDirty(node.tree);

                // Forces node selection update
                BehaviourWindow.activeNodeID = 0;

                // Removes behaviour from expanded list
                if (m_Expanded.Contains(node.instanceID))
                    SetExpanded(node.instanceID, false);

                Refresh();
            }
        }

        /// <summary>
        /// Callback to remove a branch.
        /// <param name="branch">The target branch to be removed.</param>
        /// </summary>
        void OnRemoveBranch (BranchNode branch) {
            if (branch != null && BehaviourTreeUtility.RemoveBranch(branch)) {
                // Forces node selection update
                BehaviourWindow.activeNodeID = 0;

                // Removes branch from expanded list
                if (m_Expanded.Contains(branch.instanceID))
                    SetExpanded(branch.instanceID, false);

                Refresh();
            }
        }
        #endregion Context Menu

        #region Name Editing
        /// <summary>
        /// Draw the edit name field.
        /// </summary>
        void GUIEditName () {
            // its editing a name?
            if (m_EditNameID <= 0)
                return;

            Event current = Event.current;
            if (current.type == EventType.KeyDown) {
                if (current.keyCode == KeyCode.Escape) {
                    current.Use();
                    this.CancelNameEditing();
                    GUIUtility.ExitGUI();
                }
                if (current.keyCode == KeyCode.Return || current.keyCode == KeyCode.KeypadEnter) {
                    current.Use ();
                    this.EndNameEditing();
                    GUIUtility.ExitGUI();
                }
            }

            GUI.SetNextControlName ("TreeGUIRename");

            Rect nameEditRect = this.m_NameEditRect;
            this.m_NameEditString = EditorGUI.TextField (nameEditRect, this.m_NameEditString, s_Styles.nameEdit);

            GUI.FocusControl ("TreeGUIRename");

            if (current.type == EventType.ScrollWheel)
                current.Use();
        }

        /// <summary>
        /// End name editing and save the new object name.
        /// </summary>
        void EndNameEditing () {
            //  Its editing an object name?
            if (m_EditNameID > 0) {
                // Get active tree
                var activeTree = BehaviourWindow.activeTree;
                // Get nodes
                var target = activeTree != null ? activeTree.GetNode(m_EditNameID) : null;

                // The object name has changed?
                if (target != null && target.name != m_NameEditString) {
                    // Register undo
                    #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                    Undo.RegisterUndo(activeTree, "Rename Node");
                    #else
                    Undo.RecordObject(activeTree, "Rename Node");
                    #endif
                    target.name = m_NameEditString;
                    StateUtility.SetDirty(activeTree);
                }
                m_EditNameID = 0;
                GUIUtility.keyboardControl = 0;
                GUIUtility.hotControl = 0;
            }
        }

        /// <summary>
        /// Cancel the current object name editing.
        /// </summary>
        void CancelNameEditing () {
            EditorGUIUtility.hotControl = 0;
            EditorGUIUtility.keyboardControl = 0;
            m_EditNameID = 0;
        }

        /// <summary>
        /// Begin an object name editing.
        /// </summary>
        void BeginNameEditing (ActionNode target, Rect rect) {
            if (target != null) {
                EditorGUIUtility.hotControl = 0;
                EditorGUIUtility.keyboardControl = 0;
                m_EditNameID = target.instanceID;
                m_NameEditString = target.name;
                m_NameEditRect = rect;
            }
        }
        #endregion Name Editing

        #region Expanded
        /// <summary>
        /// Expands or collapses recursively the branch hierarchy.
        /// <param name="id">The target branch id.</param>
        /// <param name="expand">If true expands hierarchy; collapses hierarchy otherwise.</param>
        /// </summary>
        void SetExpandedRecurse (int id, bool expand) {
            // Creates a new BehaviourTreeProperty
            var treePropertyAux = new BehaviourTreeProperty();
            treePropertyAux.tree = BehaviourWindow.activeTree;

            // Find the target property
            if (treePropertyAux.Find(id, m_Expanded)) {
                SetExpanded(id, expand);
                int depth = treePropertyAux.currentNodeDepth;

                // Expand children
                while (treePropertyAux.Next(null) && treePropertyAux.currentNodeDepth > depth) {
                    SetExpanded(treePropertyAux.currentNodeID, expand);
                }
            }
        }

        /// <summary>
        /// Expands or collapses the branch hierarchy.
        /// <param name="id">The target branch id.</param>
        /// <param name="expand">If true expands; collapses otherwise.</param>
        /// </summary>
        void SetExpanded (int id, bool expand) {
            if (expand) {
                if (!m_Expanded.Contains(id))
                    m_Expanded.Add(id);
            }
            else {
                if (m_Expanded.Contains(id))
                    m_Expanded.Remove(id);
            }
        }
        #endregion Expanded

        /// <summary>
        /// Process the keyboard events.
        /// </summary>
        void ProcessKeyboardEvent () {

            // Its not a key down event or there is node names being edited?
            if (Event.current.type != EventType.KeyDown || m_EditNameID > 0)
                return;

            // Is there a valid active tree?
            var activeNode = BehaviourWindow.activeNode;
            if (activeNode != null) {
                var activeNodeIndex = activeNode.GetIndex();
                // Process key
                switch (Event.current.keyCode) {
                    // Expand selected node property or select next node
                    case KeyCode.RightArrow:
                        if (activeNode is BranchNode && !m_Expanded.Contains(activeNode.instanceID))
                            SetExpanded(activeNode.instanceID, true);
                        else
                            SelectNextNode(activeNodeIndex);

                        Event.current.Use();
                        break;
                    // Collapses the selected node property or select the previus one
                    case KeyCode.LeftArrow:
                        if (activeNode is BranchNode && m_Expanded.Contains(activeNode.instanceID))
                            SetExpanded(activeNode.instanceID, false);
                        else
                            SelectPreviousNode(activeNodeIndex);

                        Event.current.Use();
                        break;
                    // Select the next node
                    case KeyCode.DownArrow:
                        SelectNextNode(activeNodeIndex);
                        Event.current.Use();
                        break;
                    // Select the previous node
                    case KeyCode.UpArrow:
                        SelectPreviousNode(activeNodeIndex);
                        Event.current.Use();
                        break;
                }
            }
        }

        /// <summary>
        /// Select the next node in the activeTree.
        /// </summary>
        void SelectNextNode (int currentIndex) {
            var nodes = BehaviourWindow.activeTree.GetNodes();
            while (++currentIndex < nodes.Count) {
                m_TreeProperty.Reset();
                if (m_TreeProperty.FindByIndex(currentIndex, m_Expanded)) {
                    BehaviourWindow.activeNodeID = nodes[currentIndex].instanceID;
                    break;
                }
            }
        }
        /// <summary>
        /// Select the previous node in the activeTree.
        /// </summary>
        void SelectPreviousNode (int currentIndex) {
            var nodes = BehaviourWindow.activeTree.GetNodes();
            while (--currentIndex >= 0) {
                m_TreeProperty.Reset();
                if (m_TreeProperty.FindByIndex(currentIndex, m_Expanded)) {
                    BehaviourWindow.activeNodeID = nodes[currentIndex].instanceID;
                    break;
                }
            }
        }
        #endregion Private Methods

        #region Unity Callbakcs
        /// <summary>
        /// A Unity callback called when the object is loaded.
        /// </summary>
        protected override void OnEnable () {
            base.OnEnable();

            if (m_Expanded == null)
                m_Expanded = new List<int>();

            // Register the visual debugging callback
            ActionNode.onNodeTick += OnNodeTick;
        }

        /// <summary>
        /// A Unity callback called when the object will be destroyed.
        /// </summary>
        protected override void OnDisable () {
            base.OnDisable();

            // Unregister the callback for visual debugging
            ActionNode.onNodeTick -= OnNodeTick;

            // Disconnect OngUI nodes
            if (BehaviourWindow.Instance != null && BehaviourWindow.Instance.playModeState != PlayModeState.Playing)
                GUICallback.ResetCallbacks();
        }

        /// <summary>
        /// A Unity callback called when the object will be destroyed.
        /// </summary>
        void OnDestroy () {
            m_Expanded.Clear();
        }
        #endregion Unity Callbakcs

        
        #region Public Methods
        /// <summary>
        /// A method called before EditorWindow.BeginWindows.
        /// </summary>
        public override void OnGUIBeforeWindows () {
            // Create styles?
            if (s_Styles == null)
                s_Styles = new TreeGUI.Styles();

            var current = Event.current;

            // Update tree and go to the first node
            InternalBehaviourTree tree = BehaviourWindow.activeTree;
            bool treeIsSelected = Selection.activeObject == tree;
            m_TreeProperty.tree = tree;

            // Get the current position
            var position = this.position;

            // ScrollView
            var scrollViewPosition = GUILayoutUtility.GetRect(0f, position.width, 0f, position.height);
            scrollViewPosition.yMax += 1f;
            scrollViewPosition.yMin += 2f;
            var viewRect = new Rect (0f, 0f, 0f, m_TreeProperty.CountRemaining(m_Expanded) * c_NodeHeigth + 2f + BehaviourWindow.blackboardHeaderHeight);
            m_ScrollView = GUI.BeginScrollView (scrollViewPosition, m_ScrollView, viewRect);

            var mousePosition = current.mousePosition;
            var y = 0f;
            var hasKeyboardFocus = EditorWindow.focusedWindow == BehaviourWindow.Instance;

            // Draw object edit name
            GUIEditName();

            // Process any keyboard event
            ProcessKeyboardEvent();

            // Event used or ignored?
            if (current.type == EventType.Used || current.type == EventType.Ignore)
                m_LastClickedID = 0;

            // Create isEnabled
            bool isEnabled = true;

            while (m_TreeProperty.Next(m_Expanded)) {
                var node = m_TreeProperty.currentNode;
                var branch = m_TreeProperty.currentBranchNode;
                var nodeId = m_TreeProperty.currentNodeID;
                var depth = m_TreeProperty.currentNodeDepth;
                bool selected = treeIsSelected && nodeId == BehaviourWindow.activeNodeID;
                bool on = m_LastClickedID == 0 ? selected : m_LastClickedID == nodeId;
                var rect = new Rect(0f, y, position.width, c_NodeHeigth);
                var indentSize = 17f + c_IndentSize * depth;

                // Its a root node?
                if (node.branch == null)
                    isEnabled = m_TreeProperty.currentFunctionNode == null || m_TreeProperty.currentFunctionNode.enabled;

                // Edit name?
                if (selected && current.type == EventType.KeyDown && ((Application.platform == RuntimePlatform.OSXEditor && (current.keyCode == KeyCode.Return || current.keyCode == KeyCode.KeypadEnter)) || (Application.platform == RuntimePlatform.WindowsEditor && current.keyCode == KeyCode.F2))) {
                    var editNameRect = rect;
                    editNameRect.xMin += indentSize + c_FoldoutSize + 2f;
                    BeginNameEditing(node, editNameRect);
                    current.Use();
                }

                // Repaint?
                if (current.type == EventType.Repaint) {
                    // Draw name
                    var guiStyle = TreeGUI.s_Styles.label;
                    var guiContent = new GUIContent(node.name, m_TreeProperty.currentNodeIcon);
                    guiStyle.padding.left = (int)indentSize;

                    // Editing name?
                    if (m_EditNameID == nodeId) {
                        // Draw icon if its not a function node...
                        if (m_TreeProperty.currentFunctionNode == null) {
                            // Remove node name
                            guiContent.text = string.Empty;
                            // Draw icon
                            guiStyle.Draw(rect, guiContent, false, false, false, false);
                        }
                    }
                    else {
                        // Set color and draw label
                        if (node is ConditionNode) {
                            guiStyle.normal.textColor = TreeGUI.Yellow;
                            guiStyle.focused.textColor = TreeGUI.Yellow;
                        }
                        else if (node is DecoratorNode) {
                            guiStyle.normal.textColor = TreeGUI.Pink;
                            guiStyle.focused.textColor = TreeGUI.Pink;
                        }
                        else if (node is MissingNode) {
                            guiStyle.normal.textColor = TreeGUI.Red;
                            guiStyle.focused.textColor = TreeGUI.Red;
                        }
                        else if (node is BranchNode) {
                            // Its a function node?
                            if (m_TreeProperty.currentFunctionNode != null)
                                guiContent.image = s_Styles.emptyIcon;

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

                        // Set color for disabled nodes
                        var oldColor = GUI.contentColor;
                        if (!isEnabled) {
                            // Set content color
                            var newContentColor = GUI.contentColor;
                            newContentColor.a *= .55f;
                            GUI.contentColor = newContentColor;
                        }

                        // Draw name
                        var insertInside = m_DropDrag.drop == node;
                        guiStyle.Draw(rect, guiContent, insertInside, insertInside, on, hasKeyboardFocus);

                        // Restore background color
                        GUI.contentColor = oldColor;

                        // Draw visual debugging?
                        if (Application.isPlaying && m_NodeStatusTime.ContainsKey(nodeId)) {
                            // Set indentation and draws the ping
                            var pingStyle = TreeGUI.s_Styles.ping;
                            var pingRect = rect;
                            pingRect.xMax = guiStyle.CalcSize(guiContent).x + 8f;
                            pingRect.xMin = indentSize - 8f;
                            pingRect.yMin += 1f;
                            pingRect.yMax -= 1f;
                            // pingRect.y += 1f;
                            // pingRect.height -= 2f;

                            // Get the delta time
                            var dt = (float) (EditorApplication.timeSinceStartup - m_NodeStatusTime[nodeId].time);

                            // Set gui color
                            oldColor = GUI.color;
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
                    }

                    // Draw insertion?
                    if (m_DropDrag.insertion == node) { // if (insertInside && (mousePosition.y >= rect.y) && (mousePosition.y <= rect.y + 2f)) {
                        var insertionRect = rect;
                        insertionRect.y -= insertionRect.height;
                        insertionRect.xMin += indentSize;
                        s_Styles.insertion.Draw (insertionRect, false, false, false, false);
                    }
                }

                // Draw a foldout for branch nodes.
                if (branch != null) {
                    var foldoutRect = new Rect (indentSize - c_FoldoutSize, y, c_FoldoutSize, c_NodeHeigth);
                    var isExpanded = m_Expanded.Contains(nodeId);

                    // Draws the toggle
                    GUI.changed = false;
                    var toggleReturn = GUI.Toggle (foldoutRect, isExpanded, GUIContent.none, TreeGUI.s_Styles.foldout);

                    // The toggle value changed?
                    if (GUI.changed && toggleReturn != isExpanded && m_EditNameID != nodeId) {
                        // Expand recursively?
                        if (Event.current.alt)
                            SetExpandedRecurse (nodeId, toggleReturn);
                        else
                            SetExpanded(nodeId, toggleReturn);
                    }
                }

                // Draw enabled toggle for function nodes
                if (m_TreeProperty.currentFunctionNode != null) {
                    var enabledRect = new Rect (indentSize + 1f, y - 1f, 16f, c_NodeHeigth);
                    if (GUI.Toggle(enabledRect, isEnabled, GUIContent.none) != isEnabled) {

                        // Register Undo
                        #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                        Undo.RegisterUndo(tree,"Function Enabled");
                        #else
                        Undo.RecordObject(tree,"Function Enabled");
                        #endif

                        // Toggle enabled
                        m_TreeProperty.currentFunctionNode.enabled = !isEnabled;

                        // Call OnValidate to register or unregister function
                        m_TreeProperty.currentFunctionNode.OnValidate();

                        // Set dirty flag
                        StateUtility.SetDirty(tree);
                    }
                }

                // The mouse is in the node property?
                if (rect.Contains(mousePosition)) {
                    switch (current.type) {
                        // Left mouse button down?
                        case EventType.MouseDown:
                            if (current.button == 0) {
                                // Double click?
                                if (current.clickCount >= 2) {
                                    // The node is a StateNode?
                                    if (node is StateNode) {
                                        // Select the state in the StateNode
                                        var stateNode = node as StateNode;
                                        if (stateNode.state != null) {
                                            if (stateNode.state is ParentBehaviour)
                                                BehaviourWindow.activeParent = stateNode.state as ParentBehaviour;
                                            Selection.objects = new UnityEngine.Object[] {stateNode.state};
                                        }
                                    }
                                    current.Use();
                                }
                                else {
                                    EndNameEditing();
                                    m_LastClickedID = nodeId;
                                    current.Use();
                                }
                            }
                            break;
                        // Left mouse button up?
                        case EventType.MouseUp:
                            // Select this node
                            if (current.button == 0 && m_LastClickedID == nodeId) {
                                m_LastClickedID = 0;
                                BehaviourWindow.activeNodeID = nodeId;
                                Selection.objects = new UnityEngine.Object[] {tree};    // Select Tree
                                current.Use();
                            }
                            break;
                        // Show node context menu?
                        case EventType.ContextClick:
                            m_LastClickedID = 0;
                            EndNameEditing();
                            BehaviourWindow.activeNodeID = nodeId;
                            Selection.objects = new UnityEngine.Object[] {tree};    // Select Tree
                            OnBehaviourContextMenu(node);
                            current.Use();
                            break;
                        case EventType.DragUpdated:
                            // Updates the drag and drop logic. The mouse is in the insertion position?
                            if (m_DropDrag.SetDrop(node, (mousePosition.y >= rect.y) && (mousePosition.y <= rect.y + 2f)) && !Application.isPlaying)
                                Repaint();
                            // Show a link icon in the cursor
                            DragAndDrop.visualMode = DragAndDropVisualMode.Link;
                            current.Use();
                            break;
                        case EventType.DragPerform:
                            // Dragged performed in the same object?
                            var draggedNode =  DragAndDrop.GetGenericData(c_DraggedNode) as ActionNode;
                            if (node == draggedNode) {
                                // Ignore drag
                                DragAndDrop.paths = new string[0];
                                DragAndDrop.objectReferences = new UnityEngine.Object[] {};
                                // DragAndDrop.AcceptDrag();
                                current.Use();
                            }
                            else
                                m_DropDrag.SetDrop(node, (mousePosition.y >= rect.y) && (mousePosition.y <= rect.y + 2f));
                            break;
                    }
                }
                // This is the highlight node and the last mouse clicked was in this behaviour?
                else if (on && m_LastClickedID == nodeId) {
                    // Start drag operation?
                    if (current.type == EventType.MouseDrag) {
                        // Clear out drag data
                        DragAndDrop.PrepareStartDrag ();

                        // Set up what we want to drag
                        DragAndDrop.paths = new string[0];
                        DragAndDrop.objectReferences = new UnityEngine.Object [0];
                        DragAndDrop.SetGenericData (c_DraggedNode, node);

                        // Start the actual drag
                        DragAndDrop.StartDrag (node.name);
                        m_DropDrag.target = node;
                        
                        // Make sure no one uses the event after us
                        current.Use();
                    }
                }
                y += c_NodeHeigth;
            }

            // Close scroll view
            GUI.EndScrollView();

            switch (current.type) {
                // Show context menu?
                case EventType.ContextClick:
                    this.OnTreeContextMenu();
                    current.Use();
                    break;
                // Update dropDrag with null
                case EventType.DragUpdated:
                    if (m_DropDrag.SetDrop(null, false) && !Application.isPlaying)
                        Repaint();
                    // Shows a link icon on the cursor
                    DragAndDrop.visualMode = DragAndDropVisualMode.Link;
                    break;
                // Clear selection?
                case EventType.MouseDown:
                    // Left mouse button?
                    if (current.button == 0) {
                        m_LastClickedID = 0;
                        EndNameEditing();
                        BehaviourWindow.activeNodeID = 0;
                        Selection.activeObject = null;
                        GUIUtility.hotControl = 0;
                        GUIUtility.keyboardControl = 0;
                        Repaint();
                    }
                    break;
                // Drag exited
                case EventType.DragExited:
                    m_LastClickedID = 0;
                    m_DropDrag.Reset();
                    Repaint();
                    break;
                // Event ignored
                case EventType.Ignore:
                    goto case EventType.DragExited;
                // Perform a drag operation?
                case EventType.DragPerform:
                    // Do drag
                    m_LastClickedID = 0;

                    // The dragged node is not null and the active tree contains this node
                    var node = DragAndDrop.GetGenericData(c_DraggedNode) as ActionNode;

                    if (node != null) {
                        if (BehaviourTreeUtility.MoveNode(node, m_DropDrag.insertion, m_DropDrag.drop)) {
                            // Update selection
                            BehaviourWindow.activeNodeID = node.instanceID;

                            // Clear Drag And Drop
                            DragAndDrop.paths = new string[0];
                            DragAndDrop.objectReferences = new UnityEngine.Object[] {};
                            DragAndDrop.AcceptDrag();
                            m_DropDrag.Reset();

                            // Use event
                            current.Use();

                            // Refresh
                            Refresh();
                        }
                        else {
                            // Cancel Drag
                            DragAndDrop.paths = new string[0];
                            DragAndDrop.objectReferences = new UnityEngine.Object[] {};
                            m_DropDrag.Reset();

                            // Use event
                            current.Use();
                        }
                    }
                    else  {
                        // Get the mono script
                        var monoScript = DragAndDrop.objectReferences.Length > 0 ? DragAndDrop.objectReferences[0] as MonoScript : null;
                        if (monoScript != null) {
                            var newNodeType = monoScript.GetClass();
                            ActionNode newNode = null;

                            // The script is an ActionNode class?
                            if (newNodeType != null && newNodeType.IsSubclassOf(typeof(ActionNode))) {
                                // No parent branch
                                if (m_DropDrag.drop == null) {
                                    newNode = BehaviourTreeUtility.AddNode(tree, newNodeType);
                                }
                                // The dropDrag object has a parent branch but does not have an insertion node
                                else if (m_DropDrag.insertion == null) {
                                    newNode = BehaviourTreeUtility.AddNode(m_DropDrag.drop, newNodeType);
                                }
                                // Do insertion
                                else {
                                    // Get index
                                    var index = -1;
                                    var children = m_DropDrag.drop.children;
                                    for (int i = 0; i < children.Length; i++) {
                                        if (children[i] == m_DropDrag.insertion) {
                                            index = i;
                                            break;
                                        }
                                    }

                                    // Create and insert the new node
                                    newNode = BehaviourTreeUtility.InsertNode(m_DropDrag.drop, index, newNodeType);
                                }

                                if (newNode != null) {
                                    // Select the new node
                                    BehaviourWindow.activeNodeID = newNode.instanceID;

                                    // Clear Drag And Drop
                                    // DragAndDrop.paths = new string[0];
                                    // DragAndDrop.objectReferences = new UnityEngine.Object[] {};
                                    DragAndDrop.AcceptDrag();

                                    // Use event
                                    // current.Use();

                                    // Refresh
                                    Refresh();
                                }
                                m_DropDrag.Reset();
                            }
                        }
                    }
                    break;
                // Validate Delete, Copy and Paste commands
                case EventType.ValidateCommand:
                    if (current.commandName == "Paste") {
                        current.Use();
                    }
                    else if (BehaviourWindow.activeNodeID > 0) {
                        if (current.commandName == "Delete" || current.commandName == "SoftDelete" || current.commandName == "Copy" || current.commandName == "Cut" || current.commandName == "Duplicate")
                            current.Use();
                    }
                    break;
                // Execute Delete, Copy and Paste commands
                case EventType.ExecuteCommand:
                    if (current.commandName == "Paste") {
                        this.OnPasteNode(BehaviourWindow.activeNode as BranchNode);
                        current.Use();
                    }
                    else if (current.commandName == "Delete" || current.commandName == "SoftDelete") {
                        this.OnDestroyNode(BehaviourWindow.activeNode);
                        current.Use();
                    }
                    else if (current.commandName == "Copy") {
                        BehaviourTreeUtility.nodeToPaste = BehaviourWindow.activeNode;
                        current.Use();
                    }
                    else if (current.commandName == "Duplicate") {
                        ActionNode activeNode = BehaviourWindow.activeNode;
                        BehaviourTreeUtility.nodeToPaste = activeNode; 
                        this.OnPasteNode(activeNode.branch);
                    }
                    else if (current.commandName == "Cut") {
                        var activeNode = BehaviourWindow.activeNode;
                        BehaviourTreeUtility.nodeToPaste = activeNode;
                        this.OnDestroyNode(activeNode);
                        current.Use();
                    }
                    break;
                // Remove the selected branch?
                case EventType.KeyDown:
                    if (BehaviourWindow.activeNodeID > 0 && current.keyCode == KeyCode.Backspace) {
                        var activeNode = BehaviourWindow.activeNode;
                        if (activeNode is BranchNode)
                            this.OnRemoveBranch(activeNode as BranchNode);
                        // Delete the node if its not a branch
                        else
                            this.OnDestroyNode(activeNode);
                        current.Use();
                    }
                    break;
            }
        }

        /// <summary>
        /// Refresh the content of this editor.
        /// </summary>
        public override void Refresh () {
            var activeTree = BehaviourWindow.activeTree;

            CancelNameEditing();
            m_LastClickedID = 0;

            if (activeTree != null) {
                // Workaround to load trees in prefabs and prefabs instances and connect OnGUI nodes.
                if (!EditorApplication.isPlayingOrWillChangePlaymode) {
                    activeTree.LoadNodes();

                    // Reset OnGUI callbacks
                    GUICallback.ResetCallbacks();

                    // Connect OnGUI nodes
                    if (BehaviourWindow.Instance != null && BehaviourWindow.Instance.playModeState != PlayModeState.SwitchingToPlaymode) {
                        var nodes = activeTree.GetNodes();
                        for (int i = 0; i < nodes.Count; i++) {
                            var onGUINode = nodes[i] as OnGUI;
                            if (onGUINode != null)
                                GUICallback.onGUI += onGUINode.EditorOnTick;
                        }
                    }
                }

                // Reseting visual debugging status
                if (activeTree.GetInstanceID() != m_LasTreeInstanceID) {
                    m_NodeStatusTime.Clear();
                    m_LasTreeInstanceID = activeTree.GetInstanceID();
                }
            }
            // Reset OnGUI callbacks if its not playing?
            else if (BehaviourWindow.Instance != null && BehaviourWindow.Instance.playModeState != PlayModeState.Playing) {
                GUICallback.ResetCallbacks();
            }

            m_TreeProperty.tree = activeTree;
            m_DropDrag.Reset();
        }
        #endregion Public Methods

        
        /// <summary>
        /// A helper class used to store the drag and drop logic.
        /// </summary>
        class DropDrag {
            ActionNode m_Target;
            BranchNode m_Drop;
            ActionNode m_Insertion;
            MonoScript m_MonoScript;

            #region Properties
            /// <summary>
            /// The behaviour been dragged.
            /// </summary>
            public ActionNode target { get {return m_Target;} set {m_Target = value;}}

            /// <summary>
            /// The behaviour to drop the dragged behaviour.
            /// </summary>
            public BranchNode drop { get {return m_Drop;}}

            /// <summary>
            /// The behaviour that is in the position to insert the dragged behaviour or null to insert the dragged behaviour as child of drop.
            /// </summary>
            public ActionNode insertion { get {return m_Insertion;}}

            /// <summary>
            /// The behaviour that is in the position to insert the dragged behaviour or null to insert the dragged behaviour as child of drop.
            /// </summary>
            public MonoScript monoScript {set {m_MonoScript = value;} get {return m_MonoScript;}}
            #endregion Properties

            #region Methods
            /// <summary>
            /// Sets a new drop and/or insertion. Changes the drag and drop logic.
            /// <returns>True if the drop target has changed; false otherwise.</returns>
            /// </summary>
            public bool SetDrop (ActionNode drop, bool insertion) {
                if (m_Drop != drop || (insertion && m_Insertion != drop) || (!insertion && m_Insertion != null)) {
                    if (insertion) {
                        m_Insertion = drop;
                        m_Drop = drop.branch;
                    }
                    else {
                        m_Drop = drop as BranchNode;
                        m_Insertion = null;
                    }
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Reset the logic to the default values.
            /// </summary>
            public void Reset () {
                m_Target = null;
                m_Drop = null;
                m_Insertion = null;
                m_MonoScript = null;
            }
            #endregion Methods
        }
    }
}