//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Base class to derive custom Node Editors from.
    /// Use this to create your own custom inspectors and editors for your nodes.
    /// <seealso cref="BehaviourMachine.ActionNode" />
    /// </summary>
    public class NodeEditor {

        #region Custom Editors
        static Dictionary<Type, Type> s_CustomEditors;

        /// <summary>
        /// Creates a new editor for the supplied node type.
        /// <param name="nodeType">The type of the node to be inspected.</param>
        /// <returns>An editor for the supplied type.</returns>
        /// </summary>
        public static NodeEditor CreateEditor (Type nodeType) {
            // Create type
            if (s_CustomEditors == null) {
                s_CustomEditors = new Dictionary<Type, Type>();

                foreach (Type editorType in EditorTypeUtility.GetDerivedTypes(typeof(NodeEditor))) {
                    var customEditorAttr = AttributeUtility.GetAttribute<CustomNodeEditorAttribute>(editorType, true);
                    if (customEditorAttr != null) {
                        if (s_CustomEditors.ContainsKey(customEditorAttr.inspectedType))
                            s_CustomEditors[customEditorAttr.inspectedType] = editorType;
                        else
                            s_CustomEditors.Add(customEditorAttr.inspectedType, editorType);

                        // Add derived types?
                        if (customEditorAttr.editorForChildClasses) {
                            foreach (var childType in TypeUtility.GetDerivedTypes(customEditorAttr.inspectedType)) {
                                if (!s_CustomEditors.ContainsKey(childType))
                                    s_CustomEditors.Add(childType, editorType);
                            }
                        }
                    }
                }
            }

            // Try get custom nodeeditor attribute
            Type customEditorType = null;
            s_CustomEditors.TryGetValue(nodeType, out customEditorType);
            if (customEditorType != null) {
                var nodeEditor = Activator.CreateInstance(customEditorType) as NodeEditor;
                if (nodeEditor != null)
                    return nodeEditor;
            }

            return new NodeEditor();
        }
        #endregion Custom Editors


        #region Styles
        static NodeEditor.Styles s_Styles;

        /// <summary>
        /// A class that holds GUIStyles used by the NodeEditor...
        /// </summary>
        class Styles {
            public readonly int titleHash = "{b}NodeTitleBar".GetHashCode();
            public readonly GUIStyle line = "sv_iconselector_sep";
            public readonly GUIStyle titlebar = "IN Title";
            public readonly GUIStyle titlebarText = "IN TitleText";
            public readonly GUIContent popupContent = new GUIContent(EditorGUIUtility.FindTexture("_Popup"));
            public readonly GUIContent helpContent = new GUIContent(EditorGUIUtility.FindTexture("_Help"), "Open Reference");
        }
        #endregion Styles

        #region Members
        ActionNode m_Target = null;
        SerializedNode m_SerializedNode = null;
        GUIContent m_TargetContent;
        GUIContent m_TargetIconContent;
        string m_TargetType = string.Empty;
        #endregion Members


        #region Properties
        /// <summary>
        /// The node that is being inspected.
        /// </summary>
        public ActionNode target {get {return m_Target;}}

        /// <summary>
        /// The serialized node of the the target object.
        /// </summary>
        public SerializedNode serializedNode {get {return m_SerializedNode;}}
        #endregion Properties


        #region Private Methods
        /// <summary>
        /// Shows the node generic menu.
        /// </summary>
        void ShowNodeContextMenu () {
            var menu = new GenericMenu();

            menu.AddItem(new GUIContent("Reset"), false, delegate {StateUtility.ResetNode(target); m_SerializedNode = new SerializedNode(target); m_SerializedNode.Update();});
            menu.AddSeparator(string.Empty);
            menu.AddItem(new GUIContent("Copy"), false, delegate {BehaviourTreeUtility.nodeToPaste = target;});
            menu.AddSeparator(string.Empty);
            if (target != null) {
                menu.AddItem(new GUIContent("Find Script"), false, delegate {
                    MonoScript script = BehaviourTreeUtility.GetNodeScript(target.GetType());
                    if (script != null)
                        EditorGUIUtility.PingObject(script);
                });
                menu.AddItem(new GUIContent("Edit Script"), false, delegate {
                    MonoScript script = BehaviourTreeUtility.GetNodeScript(target.GetType());
                    if (script != null)
                        AssetDatabase.OpenAsset(script);
                });
            }
            else {
                menu.AddDisabledItem(new GUIContent("Find Script"));
                menu.AddDisabledItem(new GUIContent("Edit Script"));
            }

            menu.ShowAsContext();
        }

        /// <summary>
        /// Reset target node.
        /// </summary>
        void OpenNodeReference () {
            var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(target.GetType(), false) ?? new NodeInfoAttribute();
            Application.OpenURL(nodeInfo.url);
        }
        #endregion Private Methods


        #region Public Methods
        /// <summary>
        /// Draws the node inspector.
        /// <param name="target">The node that is being inspected.</param>
        /// </summary>
        public void DrawNode (ActionNode target) {
            // Create style?
            if (s_Styles == null)
                s_Styles = new NodeEditor.Styles();

            if (target == null) {
                m_SerializedNode = null;
                m_Target = null;
                m_TargetContent = GUIContent.none;
                m_TargetIconContent = GUIContent.none;
                m_TargetType = string.Empty;
            }
            // The target node has changed?
            else if (m_SerializedNode == null || m_SerializedNode.target != target) {
                m_SerializedNode = new SerializedNode(target);
                m_Target = target;

                Type targetType = m_Target.GetType();
                m_TargetType = " (" + targetType.Name + ")";
                var nodeInfo = AttributeUtility.GetAttribute<NodeInfoAttribute>(targetType, false) ?? new NodeInfoAttribute();
                m_TargetContent = new GUIContent(target.name + m_TargetType, null, nodeInfo.description);
                m_TargetIconContent = new GUIContent(IconUtility.GetIcon(targetType));

                // Update Values
                m_SerializedNode.Update();
            }

            // The serialized node is not null?
            if (m_SerializedNode != null) {
                // Draw node title
                this.DrawTitle();

                if (m_Target != null && BehaviourWindow.IsVisible(m_Target.instanceID)) {
                    // Draw node properties
                    this.OnInspectorGUI();

                    // Update target content?
                    if (Event.current.type == EventType.Used && m_Target != null) {
                        m_TargetContent.text = m_Target.name + m_TargetType;
                    }
                }
            }
        }

        /// <summary>
        /// Override this function to create your own custom title.
        /// </summary>
        public virtual void DrawTitle () {
            EditorGUI.BeginChangeCheck ();

            // Get a rect for the title
            Rect position = GUILayoutUtility.GetRect (GUIContent.none, s_Styles.titlebar);

            // Get a control id for the title
            int controlID = GUIUtility.GetControlID (s_Styles.titleHash, EditorGUIUtility.native, position);

            GUIStyle titlebar = s_Styles.titlebar;
            GUIStyle titlebarText = s_Styles.titlebarText;
            Rect rect = new Rect (position.x + (float)titlebar.padding.left, position.y + (float)titlebar.padding.top, 16f, 16f);
            Rect gearRect = new Rect (position.xMax - (float)titlebar.padding.right - 2f - 16f, rect.y, 16f, 16f);
            Rect referenceRect = gearRect;
            referenceRect.x -= 18f;

            Rect position2 = new Rect (rect.xMax + 2f + 2f + 16f, rect.y, 100f, rect.height);
            position2.xMax = referenceRect.xMin - 2f;
            
            // This node is visible?
            bool isVisible = BehaviourWindow.IsVisible(m_Target.instanceID);

            // Get the current event
            Event current = Event.current;

            if (current.type == EventType.Repaint) {
                GUIStyle.none.Draw(rect, m_TargetIconContent, controlID, isVisible);
                titlebarText.Draw (position2, m_TargetContent, controlID, isVisible);
                titlebarText.Draw (referenceRect, s_Styles.helpContent, controlID, isVisible);
                titlebarText.Draw (gearRect, s_Styles.popupContent, controlID, isVisible);
                titlebar.Draw (position, GUIContent.none, controlID, isVisible);
            }
            else if (current.type == EventType.MouseDown) {
                if (position.Contains(current.mousePosition)) {
                    // Show online help?
                    if (referenceRect.Contains(current.mousePosition)) {
                        this.OpenNodeReference();
                        current.Use();
                    }
                    // Not left mouse button or clicked on the gear?
                    else if (current.button != 0 || gearRect.Contains(current.mousePosition)) {
                        // Show context menu
                        this.ShowNodeContextMenu();
                        current.Use();
                    }
                    // Foldout focus
                    else {
                        GUIUtility.hotControl = controlID;
                        GUIUtility.keyboardControl = controlID;
                        current.Use();
                    }
                }
            }
            // Foldout logic; toggle the value of isVisible
            else if (current.type == EventType.MouseUp) {
                if (GUIUtility.hotControl == controlID) {
                    GUIUtility.hotControl = 0;
                    GUIUtility.keyboardControl = 0;

                    BehaviourWindow.SetVisible(m_Target.instanceID, !isVisible);

                    current.Use();
                }
            }

            EditorGUI.EndChangeCheck ();
        }

        public void DrawDefaultInspector () {
            // Get an iterator
            var iterator = m_SerializedNode.GetIterator();

            // Cache the indent level
            int indentLevel = EditorGUI.indentLevel;

            while (iterator.Next(iterator.current == null || (iterator.current.propertyType != NodePropertyType.Variable && !iterator.current.hideInInspector))) {
                SerializedNodeProperty current = iterator.current;
                if (!current.hideInInspector) {
                    EditorGUI.indentLevel = indentLevel + iterator.depth;
                    GUILayoutHelper.DrawNodeProperty(new GUIContent(current.label, current.tooltip), current, m_Target);
                }
            }

            // Restore the indent level
            EditorGUI.indentLevel = indentLevel;
        }

        /// <summary>
        /// Implement this function to make a custom inspector.
        /// </summary>
        public virtual void OnInspectorGUI () {
            // Update serialized node data
            if (Event.current.type == EventType.Layout)
                m_SerializedNode.Update();

            this.DrawDefaultInspector();

            // Apply modified properties
            m_SerializedNode.ApplyModifiedProperties();
        }
        #endregion Public Methods
    }
}