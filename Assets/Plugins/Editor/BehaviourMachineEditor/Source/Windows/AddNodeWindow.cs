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
    /// Show all available nodes that can be added to a BehaviourTree or to an ActionState.
    /// </summary>
    [System.Serializable]
    public class AddNodeWindow : EditorWindow {

        const float c_ItemHeight = 20f;

        #region Styles
        static AddNodeWindow.Styles s_Styles;

        /// <summary>
        /// A class that holds GUIStyles and Colors used by AddNodeWindow.
        /// </summary>
        class Styles {
            public readonly GUIStyle bigTitle = "IN BigTitle";
            public readonly GUIStyle titleText = new GUIStyle("IN TitleText");
            public readonly GUIStyle errorLabel = "ErrorLabel";
            public readonly GUIStyle searchTextField = "SearchTextField";
            public readonly GUIStyle searchCancelButtonEmpty = "SearchCancelButtonEmpty";
            public readonly GUIStyle searchCancelButton = "SearchCancelButton";
            public readonly GUIStyle focusCategory = "LODRendererButton";
            public readonly GUIStyle item = new GUIStyle("CN Message");
            public readonly GUIStyle scriptDetailBox = "CN Box";
            public readonly GUIStyle scriptDetailTitle = "IN TitleText";
            public readonly GUIStyle description = new GUIStyle(EditorStyles.label);

            public readonly Color textColor;

            public Styles() {
                textColor = item.normal.textColor;
                description.wordWrap = true;
            }
        }
        #endregion Styles

        #region Members
        [SerializeField]
        string m_SearchFieldValue = string.Empty;
        [SerializeField]
        Vector2 m_ScroolView;

        [System.NonSerialized]
        System.Type m_ActiveNodeType = null;
        [System.NonSerialized]
        string m_ActiveNodeTypeName = string.Empty;
        [System.NonSerialized]
        NodeInfoAttribute m_ActiveNodeInfo = null;
        [System.NonSerialized]
        Texture m_ActiveNodeIcon = null;

        [System.NonSerialized]
        Category m_Root = null;
        [System.NonSerialized]
        Category m_CurrentCategory = null;
        [System.NonSerialized]
        Item m_SelectedItem = null;
        [System.NonSerialized]
        Script m_SelectedScript = null;

        [System.NonSerialized]
        Rect m_LastRect;
        [System.NonSerialized]
        NodeEditor m_NodeEditor;
        [System.NonSerialized]
        ActionNode m_SelectedNodeSample;
        #endregion Members

        #region Private Methods
        /// <summary>
        /// Selects an Item.
        /// <param name="item">The item to be selected.</param>
        /// </summary>
        void SelecteItem (Item item) {
            m_SelectedItem = item;
            m_SelectedScript = item as Script;

            if (m_SelectedScript != null) {
                m_NodeEditor = NodeEditor.CreateEditor(m_SelectedScript.type);
                m_SelectedNodeSample = ActionNode.CreateInstance(m_SelectedScript.type, null, null);
            }
            // It's a Category?
            else if (item is Category) {
                m_CurrentCategory = item as Category;
                m_SelectedScript = null;
            }

            GUIUtility.hotControl = 0;
            GUIUtility.keyboardControl = 0;
        }

        /// <summary>
        /// Updates the active node data.
        /// <param name="activeNode">The active node.</param>
        /// </summary>
        void UpdateActiveNode (ActionNode activeNode) {
            var activeNodeType = activeNode != null ? activeNode.GetType() : null;

            // The active node type has changed?
            if (activeNodeType != m_ActiveNodeType) {
                if (activeNode == null) {
                    m_ActiveNodeType = null;
                    m_ActiveNodeInfo = null;
                    m_ActiveNodeIcon = null;
                    m_ActiveNodeTypeName = string.Empty;
                    return;
                }
                else {
                    m_ActiveNodeType = activeNodeType;
                    m_ActiveNodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(m_ActiveNodeType, true) ?? new NodeInfoAttribute();
                    m_ActiveNodeIcon = IconUtility.GetIcon(m_ActiveNodeType);
                    m_ActiveNodeTypeName = " (" + m_ActiveNodeType.Name + ")";
                }
            }
        }

        /// <summary>
        /// Refresh items.
        /// </summary>
        void Refresh () {
            m_Root = new Category(null, string.Empty);
            m_CurrentCategory = m_Root;

            // Stores all scripts that inherites from ActionNode as child of m_Root
            foreach (var type in BehaviourTreeUtility.GetNodeTypes()) {
                var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(type, false) ?? new NodeInfoAttribute();
                m_Root.AddChild(nodeInfo.category, type, nodeInfo);
            }
        }

        /// <summary>
        /// Draws a category children in the gui.
        /// <param name="category">The category to be drawn.</param>
        /// </summary>
        void DrawCategoryChildren (Category category) {
            var children = category.children;

            for (int i = 0; i < children.Length; i++) {
                DrawItem(children[i]);
            }
        }

        /// <summary>
        /// Draws an Item in the gui.
        /// <param name="item">The item to be drawn.</param>
        /// </summary>
        void DrawItem (Item item) {
            // its not searching or the item name contains the searching value?
            if (m_SearchFieldValue == string.Empty || item.name.ToLower().Contains(m_SearchFieldValue.ToLower())) {
                GUILayout.BeginHorizontal(); {
                    // Draw name
                    var isSelected = m_SelectedItem == item;
                    var guiStyle = s_Styles.item;

                    var script = item as Script;
                    if (script == null || script.nodeType == Script.NodeType.Composite) {
                        guiStyle.normal.textColor = s_Styles.textColor;
                        guiStyle.focused.textColor = s_Styles.textColor;
                    }
                    else {
                        switch (script.nodeType) {
                            case Script.NodeType.Action:
                                guiStyle.normal.textColor = TreeGUI.Green;
                                guiStyle.focused.textColor = TreeGUI.Green;
                                break;
                            case Script.NodeType.Condition:
                                guiStyle.normal.textColor = TreeGUI.Yellow;
                                guiStyle.focused.textColor = TreeGUI.Yellow;
                                break;
                            case Script.NodeType.Decorator:
                                guiStyle.normal.textColor = TreeGUI.Pink;
                                guiStyle.focused.textColor = TreeGUI.Pink;
                                break;
                            case Script.NodeType.MissingNode:
                                guiStyle.normal.textColor = TreeGUI.Red;
                                guiStyle.focused.textColor = TreeGUI.Red;
                                break;
                        }
                    }

                    if (GUILayout.Toggle(isSelected, new GUIContent(item.name, item.GetIcon()), guiStyle, GUILayout.ExpandWidth(true), GUILayout.Height(c_ItemHeight)) != isSelected) {
                        this.SelecteItem(item);
                     }

                     // its a category?
                     if (item is Category) {
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button(GUIContent.none, EditorStyles.foldout, GUILayout.Height(c_ItemHeight)))
                            m_CurrentCategory = item as Category;
                    }
                } GUILayout.EndHorizontal();
            }

            // Is searching and the item is a Category?
            if (m_SearchFieldValue != string.Empty && item is Category) {
                DrawCategoryChildren((Category)item);
            }
        }

        /// <summary>
        /// Draws the script details in the gui.
        /// <param name="script">The script to be drawn.</param>
        /// </summary>
        void DrawScriptDetail (Script script) {
            GUILayout.BeginVertical(s_Styles.scriptDetailBox);

            // Draw disabled inspector
            if (m_NodeEditor != null && m_SelectedNodeSample != null) {
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                EditorGUIUtility.LookLikeInspector();
                #endif

                // Store gui enabled
                var guiEnabled = GUI.enabled;
                GUI.enabled = false;

                GUILayout.Space(-1f);
                m_NodeEditor.DrawNode(m_SelectedNodeSample);
                GUILayout.Space(8f);

                // Restore gui enabled
                GUI.enabled = guiEnabled;

                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                EditorGUIUtility.LookLikeControls();
                #endif
            }

            // Draws description?
            if (script.description != string.Empty) {
                EditorGUILayout.LabelField(string.Empty, "Description: " + script.description, s_Styles.description);
            }

            // Draw parent
            // Update active node
            var activeNode = BehaviourWindow.activeNode;
            UpdateActiveNode(activeNode);

            // Add to a tree
            InternalBehaviourTree activeTree = BehaviourWindow.activeTree;
            
            if (activeTree != null) {
                GUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Parent");
                if (activeNode != null && m_ActiveNodeType != null)
                    EditorGUILayout.LabelField(new GUIContent(activeNode.name + m_ActiveNodeTypeName, m_ActiveNodeIcon, m_ActiveNodeInfo.description), s_Styles.titleText);
                else
                    EditorGUILayout.LabelField("null", s_Styles.errorLabel);
                GUILayout.EndHorizontal();

                var guiEnabled2 = GUI.enabled;
                var activeBranch = BehaviourWindow.activeNode as BranchNode;
                GUI.enabled = activeTree != null;
                if (GUILayout.Button(activeBranch != null ? "Add as Child of " + activeBranch.name : "Add as Root",  GUILayout.ExpandWidth(false))) {
                    ActionNode newNode = null;
                    if (activeBranch != null)
                        newNode = BehaviourTreeUtility.AddNode(activeBranch, script.type);
                    else
                        newNode = BehaviourTreeUtility.AddNode(activeTree, script.type);

                    // Select the new node
                    if (newNode != null)
                        BehaviourWindow.activeNodeID = newNode.instanceID;
                }
                GUI.enabled = guiEnabled2;
            }
            else {
                // Add to an ActionState
                var actionState = BehaviourWindow.activeState as InternalActionState;

                if (actionState != null && GUILayout.Button("Add Node",  GUILayout.ExpandWidth(false))) {
                    ActionNode newNode = ActionStateUtility.AddNode(actionState, script.type);
                    // Select the new node
                    if (newNode != null)
                        BehaviourWindow.activeNodeID = newNode.instanceID;
                }
            }

            GUILayout.EndVertical();

            GUILayout.Space(18f);

            // Workaround to avoid to close the GUIPropertyField on click
            if (Event.current.type == EventType.Repaint)
                m_LastRect = GUILayoutUtility.GetLastRect();
            if (Event.current.type == EventType.mouseDown && m_LastRect.Contains(Event.current.mousePosition))
                Event.current.Use();
        }
        #endregion Private Methods

        #region Unity Callbacks
        /// <summary>
        /// A Unity callback called when the window is loaded.
        /// </summary>
        void OnEnable () {
            Refresh();
            BehaviourWindow.activeNodeChanged += Repaint;
            EditorApplication.playmodeStateChanged += Repaint;
        }

        /// <summary>
        /// A Unity callback called when the window goes out of scope.
        /// </summary>
        void OnDisable () {
            BehaviourWindow.activeNodeChanged -= Repaint;
            EditorApplication.playmodeStateChanged -= Repaint;
        }

        /// <summary>
        /// A Unity callback used to draw controls in the window.
        /// </summary>
        void OnGUI () {
            if (s_Styles == null)
                s_Styles = new AddNodeWindow.Styles();

            // Begin Header
            GUILayout.Space(-1f);   // WTF
            GUILayout.Space(1f);    // WTF
            GUILayout.BeginVertical(s_Styles.bigTitle); {

                // Search
                GUILayout.Space(8);
                GUILayout.BeginHorizontal(); {
                    GUILayout.Space(4f);
                    GUI.SetNextControlName("SearchField");

                    m_SearchFieldValue = GUILayout.TextField(m_SearchFieldValue, s_Styles.searchTextField, GUILayout.ExpandWidth(true), GUILayout.MinWidth(50));

                    if (GUILayout.Button("", (m_SearchFieldValue == string.Empty) ? s_Styles.searchCancelButtonEmpty : s_Styles.searchCancelButton, GUILayout.ExpandWidth(false)) || (Event.current.isKey && Event.current.keyCode == KeyCode.Escape)) {
                        m_SearchFieldValue = string.Empty;
                        GUIUtility.hotControl = 0;
                        GUIUtility.keyboardControl = 0;
                        Event.current.Use();
                        Repaint();
                    }

                GUILayout.Space(4f);
                } GUILayout.EndHorizontal();

                // Focus Category
                GUILayout.BeginHorizontal(); {
                    if (m_CurrentCategory != null) {
                        if (m_CurrentCategory.parent != null && GUILayout.Button("<", s_Styles.focusCategory, GUILayout.ExpandWidth(false))) {
                            m_CurrentCategory = m_CurrentCategory.parent;
                            SelecteItem(null);
                        }
                        GUILayout.Label(m_CurrentCategory.path, s_Styles.focusCategory, GUILayout.ExpandWidth(true));
                    }
                } GUILayout.EndHorizontal();
            }// End Header
            GUILayout.EndVertical();

            // Show category
            GUILayout.Space(-4f);
            if (m_CurrentCategory != null) {
                m_ScroolView = GUILayout.BeginScrollView(m_ScroolView);
                DrawCategoryChildren(m_CurrentCategory);
                GUILayout.EndScrollView();
            }

            // Draw script detail
            if (m_SelectedScript != null)
                DrawScriptDetail(m_SelectedScript);

            // The event has not been used?
            if (Event.current.type == EventType.MouseDown && Event.current.button == 0) {
                SelecteItem(null);
                Event.current.Use();
            }
        }
        #endregion Unity Callbacks
    }
}