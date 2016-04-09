//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Used by the BehaviourWindow to describe the states of the Unity editor.
    /// </summary>
    public enum PlayModeState { 
                                /// <summary>
                                /// Default state, propably you are not registered in the EditorApplication.playmodeStateChanged callback.
                                /// </summary>
                                Unknow,

                                /// <summary>
                                /// The editor application is in playmode.
                                /// </summary>
                                Playing, 

                                /// <summary>
                                /// The editor application is not in the playmode.
                                /// </summary>
                                Editor, 

                                /// <summary>
                                /// The editor will enter in the playmode; the views are darkening.
                                /// </summary>
                                SwitchingToPlaymode, 

                                /// <summary>
                                /// The editor will exit the playmode; the views are returning to the normal color.
                                /// </summary>
                                SwitchingToEditor
                            }

    /// <summary>
    /// The BehaviourMachine main window, shows the states and trees of the selected game object. 
    /// It also stores the parent selection, the list of visible nodes and draws the blackboard view.
    /// </summary>
    [System.Serializable]
    public class BehaviourWindow : EditorWindow {

        public const float blackboardHeaderHeight = 22f;
        const float c_BlackboardHeaderButtonWidth = 23f;

        #region Styles
        static BehaviourWindow.Styles s_Styles;

        /// <summary> 
        /// A class to store GUIStyles that are used by the BehaviourWindow.
        /// </summary>
        class Styles {
            public readonly GUIStyle blackboardBox = "flow overlay box";
            public readonly GUIStyle blackboardHeader = "flow overlay header lower left";
            public readonly GUIStyle lockButton = "IN LockButton";
            public GUIContent iconToolbarPlus = new GUIContent(EditorGUIUtility.FindTexture("Toolbar Plus"), "Add New Variable");
        }
        #endregion Styles

        
        #region Singleton
        /// <summary>
        /// Returns a reference for the current instance of the active BehaviourWindow.
        /// </summary>
        public static BehaviourWindow Instance {get {return s_Instance;} private set {s_Instance = value;}}
        static BehaviourWindow s_Instance;
        #endregion Singleton

        
        #region Members
        [SerializeField]
        ParentBehaviourGUI m_ParentGUI;
        [SerializeField]
        int m_SerializedParentID = 0;
        [SerializeField]
        int m_SerializedNodeID = 0;
        [SerializeField]
        int m_ActiveBlackboardID = 0;
        [SerializeField]
        bool m_Lock = false;
        [SerializeField]
        bool m_BlackboardViewIsExpanded = false;
        [SerializeField]
        float m_BlackboardScroll;
        [SerializeField]
        PlayModeState m_PlayModeState;
        [SerializeField]
        GUICallback m_GUICallback;
        [SerializeField]
        List<int> m_NotVisible = new List<int>();
        #endregion Members

        #region Properties
        /// <summary> 
        /// Returns the current state of the Unity editor application.
        /// </summary>
        public PlayModeState playModeState {get {return m_PlayModeState;}}
        #endregion Properties

        
        #region Selection
        static StateTransition s_ActiveTransition;
        static int s_ActiveNodeID = 0, s_ActiveParentID = 0;
        static List<int> s_NotVisible = new List<int>();

        /// <summary> 
        /// Callback raised whenever the active parent changes.
        /// </summary>
        public static event EditorApplication.CallbackFunction activeParentChanged;

        /// <summary> 
        /// Callback raised whenever the active node changes.
        /// </summary>
        public static event EditorApplication.CallbackFunction activeNodeChanged;

        /// <summary>
        /// The active ParentBehaviour. The one shown in the BehaviourWindow.
        /// </summary>
        public static ParentBehaviour activeParent {get {return EditorUtility.InstanceIDToObject(s_ActiveParentID) as ParentBehaviour;} 
            set {
                // New parent?
                if (value != activeParent && (value == null || value.root != null)) {
                    TransitionDragAndDrop.AcceptDrag();
                    s_ActiveParentID = value != null ? value.GetInstanceID() : 0;

                    // Raise event
                    if (activeParentChanged != null) 
                        activeParentChanged();

                    GUIUtility.keyboardControl = 0;
                }
            }
        }

        /// <summary>
        /// The active ParentBehaviour instance id.
        /// </summary>
        public static int activeParentID {get {return s_ActiveParentID;}}

        /// <summary>
        /// The active state. The one shown on the Inspector.
        /// </summary>
        public static InternalStateBehaviour activeState {
            get {
                var state = Selection.objects.Length > 0 ? Selection.objects[0] as InternalStateBehaviour : null;
                return state != null ? state : null;
            }
            set {
                activeTransition = null;
                Selection.objects = value != null ? new UnityEngine.Object[] {value} : new UnityEngine.Object[0];
                GUIUtility.keyboardControl = 0;
            }
        }

        /// <summary>
        /// The active states. The states shown on the Inspector.
        /// </summary>
        public static InternalStateBehaviour[] activeStates {
            get {
                var states = new List<InternalStateBehaviour>();

                // Get active states
                foreach (var obj in Selection.objects) {
                    var state = obj as InternalStateBehaviour;
                    if (state != null)
                        states.Add(state);
                }

                return states.ToArray();
            }
            set {
                if (value == null)
                    Selection.objects = new UnityEngine.Object[0];
                else {
                    Selection.objects = value;
                }
            }
        }

        /// <summary>
        /// The active StateTransition. The one highlighted in the BehaviourWindow.
        /// </summary>
        public static StateTransition activeTransition {get {return s_ActiveTransition;} 
            set {
                TransitionDragAndDrop.AcceptDrag();
                s_ActiveTransition = value;
                GUIUtility.keyboardControl = 0;
            }
        }

        /// <summary>
        /// The active fsm. The one shown in the BehaviourWindow.
        /// </summary>
        public static InternalStateMachine activeFsm {get {return EditorUtility.InstanceIDToObject(s_ActiveParentID) as InternalStateMachine;} set {activeParent = value;}}

        /// <summary>
        /// The active BehaviourTree. The one shown in the BehaviourWindow.
        /// </summary>
        public static InternalBehaviourTree activeTree {get {return EditorUtility.InstanceIDToObject(s_ActiveParentID) as InternalBehaviourTree;} set {activeParent = value;}}

        /// <summary>
        /// The active ActionNode index. The one shown in the BehaviourTree inspector and highlighted in the BehaviourWindow.
        /// </summary>
        public static int activeNodeID {
            get {return s_ActiveNodeID;} 
            set {
                s_ActiveNodeID = value;
                // Raise event
                if (activeNodeChanged != null) activeNodeChanged();
                GUIUtility.keyboardControl = 0;
            }
        }

        /// <summary>
        /// The active node. The one shown in the BehaviourTree inspector and highlighted in the BehaviourWindow.
        /// </summary>
        public static ActionNode activeNode {
            get {
                if (activeTree != null)
                    return activeTree.GetNode(s_ActiveNodeID);
                else {
                    var activeActionState = activeState as InternalActionState;
                    if (activeActionState != null)
                        return activeActionState.GetNode(s_ActiveNodeID);
                }

                return null;
            } 
            set {
                activeNodeID = value != null ? value.instanceID : 0;
                GUIUtility.keyboardControl = 0;
            }
        }

        /// <summary>
        /// Stores if a node with the supplied id should be visible or not.
        /// <param name="nodeID">The id of the target node.</param>
        /// <param name="visible">True to set visible; Flase otherwise.</param>
        /// </summary>
        public static void SetVisible (int nodeID, bool visible) {
            if (visible) {
                if (BehaviourWindow.s_NotVisible.Contains(nodeID)) {
                    BehaviourWindow.s_NotVisible.Remove(nodeID);
                }
            }
            else if (!BehaviourWindow.s_NotVisible.Contains(nodeID)) {
                BehaviourWindow.s_NotVisible.Add(nodeID);
            }
        }
        
        /// <summary>
        /// Returns whenever the node with the supplied id is expanded.
        /// <param name="nodeID">The id of the target node.</param>
        /// <returns>True if the node with the supplied id is visible, False otherwise.</returns>
        /// </summary>
        public static bool IsVisible (int nodeID) {
            return !BehaviourWindow.s_NotVisible.Contains(nodeID);
        }
        #endregion Selection


        #region Private Methods
        /// <summary>
        /// Creates a a new GUICallback. 
        /// <returns>A new GUICallback.</returns>
        /// </summary> 
        GUICallback CreateGUICallback () {
            // Create game object
            GameObject go = UnityEditor.EditorUtility.CreateGameObjectWithHideFlags("GUI Object", HideFlags.HideAndDontSave, new System.Type[] {typeof(GUICallback)});
            // Get GUICallback component
            return go.GetComponent<GUICallback>();
        }

        /// <summary> 
        /// Registered in the BehviourWindow.activeParentChanged to update the serialized parent and blackboard id.
        /// Un-/Registered in the OnDisable/OnEnable. 
        /// </summary>
        void OnParentSelectionChange () {
            var parentToSerialize = activeParent;
            m_SerializedParentID = parentToSerialize != null ? parentToSerialize.GetInstanceID() : 0;
            m_ActiveBlackboardID = parentToSerialize != null ? parentToSerialize.blackboard.GetInstanceID() : 0;
            SetParentGUI();
            Repaint();
        }

        /// <summary> 
        /// Called whenever a new scene is loaded. 
        /// Registered in LoadSceneUtility.onLoadScene to update the active parent if the parent is not an asset.
        /// Un-/Registered in the OnDisable/OnEnable. 
        /// </summary>
        void OnLoadScene () {
            var parent = activeParent;
            if (parent != null && !AssetDatabase.Contains(parent))
                activeParent = null;
        }

        /// <summary> 
        /// Registered in the BehviourWindow.activeNodeChanged to update the serialized node id. 
        /// Un-/Registered in the OnDisable/OnEnable. 
        /// </summary>
        void OnNodeSelectionChange () {
            m_SerializedNodeID = activeNodeID;
        }

        /// <summary>
        /// Updates the ParentBehaviourGUI that is showed by the BehaviourWindow.
        /// The new ParentBehaviourGUI is chosen depending on the serialized parent.
        /// </summary>
        void SetParentGUI () {
            var serializedParent = EditorUtility.InstanceIDToObject(m_SerializedParentID) as ParentBehaviour;
            // If the type of the serializedParent changed, creates a new GUIController and stores in m_ParentGUI member.
            if (serializedParent == null)
                return;
            else if (serializedParent is InternalStateMachine && (m_ParentGUI == null || !(m_ParentGUI is FsmGUI))) {
                if (m_ParentGUI != null)
                    ScriptableObject.DestroyImmediate(m_ParentGUI);

                m_ParentGUI = ScriptableObject.CreateInstance(typeof(BehaviourMachineEditor.FsmGUI)) as ParentBehaviourGUI;
                m_ParentGUI.Refresh();
                if (activeNodeChanged != null)
                    activeNodeChanged();
            }
            else if (serializedParent is InternalBehaviourTree && (m_ParentGUI == null || !(m_ParentGUI is TreeGUI))) {
                if (m_ParentGUI != null)
                    ScriptableObject.DestroyImmediate(m_ParentGUI);

                m_ParentGUI = ScriptableObject.CreateInstance(typeof(BehaviourMachineEditor.TreeGUI)) as ParentBehaviourGUI;
                m_ParentGUI.Refresh();
                if (activeNodeChanged != null)
                    activeNodeChanged();
            }
        }

        /// <summary>
        /// Shows the window toolbar.
        /// </summary>
        void DoStatusBarGUI () {
            GUILayout.BeginHorizontal(EditorStyles.toolbar); {
                if (activeParent != null && activeParent.root != null) {
                    // Select the gameobject?
                    if (GUILayout.Button(new GUIContent(activeParent.root.gameObject.name, "The target game object"), EditorStyles.toolbarButton, GUILayout.ExpandWidth(false))) {
                        // Left mouse button?
                        if (Event.current.button == 0) {
                            Selection.activeGameObject = activeParent.root.gameObject;
                            // EditorGUIUtility.PingObject(activeParent.root.gameObject);
                        }
                        else
                            ShowRootParentsSelectiontMenu();
                    }

                    // Build the controller list
                    var parents = new List<ParentBehaviour>();
                    for (var parent = activeParent; parent != null; parent = parent.parent)
                        parents.Add(parent);

                    // The active parent is selected?
                    bool selected = activeParent == parents[parents.Count - 1];
                    
                    // Add a small space
                    GUILayout.Space(12f);

                    // Show the parent menu selection?
                    var toggleValue = GUILayout.Toggle (selected, parents[parents.Count - 1].stateName, "GUIEditor.BreadcrumbLeft", GUILayout.ExpandWidth(false));
                    if (toggleValue != selected) {
                        // Left mouse button?
                        if (Event.current.button == 0) {
                            Selection.objects = new UnityEngine.Object[] {parents[parents.Count - 1]};
                            activeParent = parents[parents.Count - 1];
                        }
                        else
                           ShowStateSelectionMenu(parents[parents.Count - 1]);
                    }

                    // Show the state hierarchy
                    for (int i = parents.Count - 2; i >= 0; i--) {
                        var targetParent = parents[i];
                        selected = activeParent == targetParent;
                        toggleValue = GUILayout.Toggle (selected, targetParent.stateName, "GUIEditor.BreadcrumbMid", GUILayout.ExpandWidth(false));
                        if (toggleValue != selected) {
                            // Left mouse button?
                            if (Event.current.button == 0) {
                                activeParent = targetParent;
                                Selection.objects = new UnityEngine.Object[] {activeParent};
                            }
                            else
                                ShowStateSelectionMenu(targetParent);
                        }
                    }
                }
                GUILayout.FlexibleSpace();
            } GUILayout.EndHorizontal();
            GUILayout.Space(-1 * EditorStyles.toolbar.fixedHeight);
        }

        #region Context Menu
        /// <summary>
        /// Shows a context menu with all game objects that owns a ParentBehaviour root.
        /// </summary>
        void ShowRootParentsSelectiontMenu () {
            var menu = new GenericMenu();

            var objs = Resources.FindObjectsOfTypeAll(typeof(ParentBehaviour)); // get parents
            var gameObjectsInMenu = new List<GameObject>(); // Game objects already added to the menu
            var uniqueNames = new List<string>();           // Game objects names in the menu
            var activeGameObject = activeParent != null ? activeParent.gameObject : null; 

            int i = 0;
            foreach (ParentBehaviour parent in objs) {
                // Is a root parent?
                if (parent.isRoot) {
                    var gameObject = parent.gameObject;
                    // The game object is not null and it is not yet in the menu?
                    if (gameObject != null && !gameObjectsInMenu.Contains(gameObject)) {
                        gameObjectsInMenu.Add(gameObject);
                        uniqueNames.Add(StringHelper.GetUniqueNameInList(uniqueNames, gameObject.name + (AssetDatabase.Contains(gameObject) ? " (Prefab)" : string.Empty)));
                        menu.AddItem(new GUIContent(uniqueNames[i]), activeGameObject == gameObject, delegate () {Selection.activeObject = gameObject;} );
                        ++i;
                    }
                }
            }

            menu.ShowAsContext();
        }

        /// <summary>
        /// Shows a menu to select states that are in the same parent as the supplied state.
        /// <param name="state">The target state.</param>
        /// </summary>
        void ShowStateSelectionMenu (InternalStateBehaviour state) {
            var menu = new GenericMenu();
            var states = state.GetComponents<InternalStateBehaviour>();
            var uniqueNames = new List<string>();

            // Build the menu
            for (int i = 0; i < states.Length; i++) {
                // Get the current state
                var currentState = states[i];

                // The current state has the same parent as the supplied state?
                if (currentState.parent == state.parent) {
                    string currentName = StringHelper.GetUniqueNameInList(uniqueNames, currentState.stateName);
                    uniqueNames.Add(currentName);
                    menu.AddItem(new GUIContent(currentName), state == currentState, delegate () {activeParent = currentState as ParentBehaviour ?? currentState.parent; Selection.objects = new UnityEngine.Object[] {currentState};});
                }
            }

            menu.ShowAsContext();
        }

        /// <summary>
        /// Shows a context menu to add a new parent.
        /// </summary>
        void OnContextMenu () {

            var menu = new UnityEditor.GenericMenu();
            // Get the active game object
            var gameObject = Selection.activeGameObject;

            // The selected game object is not null?
            if (gameObject != null) {
                // Gets all scripts that inherits from ParentBehaviour class
                MonoScript[] scripts = FileUtility.GetScripts<ParentBehaviour>();
                for (int i = 0; i < scripts.Length; i++) {
                    var type = scripts[i].GetClass();
                    
                    // Get the component path
                    string componentPath = "Add Parent/";
                    AddComponentMenu componentMenu = AttributeUtility.GetAttribute<AddComponentMenu>(type, false);
                    if (componentMenu == null || componentMenu.componentMenu != string.Empty) {
                        componentMenu = AttributeUtility.GetAttribute<AddComponentMenu>(type, true);
                        if (componentMenu != null && componentMenu.componentMenu != string.Empty)
                            componentPath += componentMenu.componentMenu;
                        else
                            componentPath += type.ToString().Replace('.','/');

                        // Add to menu
                        menu.AddItem(new GUIContent(componentPath), false, delegate () {BehaviourWindow.activeParent = StateUtility.AddState(gameObject, type) as ParentBehaviour;});
                    }
                }
            }
            else {
                menu.AddDisabledItem(new GUIContent("Add Parent/"));
                ShowNotification(new GUIContent("Select a Game Object and right click in this window!"));
            }

            // Add option to paste states
            if (Selection.activeGameObject != null && StateUtility.statesToPaste != null && StateUtility.statesToPaste.Length > 0)
                menu.AddItem(new GUIContent("Paste State"), false, delegate () {StateUtility.CloneStates(Selection.activeGameObject, StateUtility.statesToPaste, null);});
            else
                menu.AddDisabledItem(new GUIContent("Paste State"));

            // Refresh window?
            // menu.AddSeparator("");
            // menu.AddItem(new GUIContent("Refresh"), false ,Refresh);    

            // Shows the controller menu
            menu.ShowAsContext();
        }
        #endregion Context Menu

        #region Unity Callbacks
        /// <summary>
        /// A Unity callback called when the window is loaded.
        /// </summary>
        void OnEnable () {
            // Set window name
            this.name = Print.GetLogo() + " Behaviour";
            // Update singleton instance
            Instance = this;

            // Update NotVisible value
            BehaviourWindow.s_NotVisible = this.m_NotVisible;

            // Set playmode state
            if (m_PlayModeState == PlayModeState.Unknow) {
                m_PlayModeState = EditorApplication.isPlaying ? PlayModeState.Playing : PlayModeState.Editor;

                // The guiCallback is null and the unity application is not playing or changing playmode?
                if (m_GUICallback == null && !EditorApplication.isPlayingOrWillChangePlaymode) {
                    // Create game object
                    GameObject go = EditorUtility.CreateGameObjectWithHideFlags("GUI Object", HideFlags.HideAndDontSave, new System.Type[] {typeof(GUICallback)});
                    // Get GUICallback component
                    m_GUICallback = go.GetComponent<GUICallback>();
                }
            }

            // Set callbacks
            activeParentChanged += OnParentSelectionChange;
            activeNodeChanged += OnNodeSelectionChange;
            EditorApplication.playmodeStateChanged += OnPlaymodeChange;
            EditorApplication.delayCall += OnDelayCall;
            LoadSceneUtility.onLoadScene += this.OnLoadScene;
            BehaviourMachinePrefs.preferencesChanged += this.Repaint;

            // The minimum size of this window
            base.minSize = new Vector2(200f, 150f);

            // Forces selection update
            activeParent = EditorUtility.InstanceIDToObject(m_SerializedParentID) as ParentBehaviour;
            OnSelectionChange();
            activeNodeID = m_SerializedNodeID;

            // Set guiController
            SetParentGUI();

            // Automatically repaint window whenever the scene has change
            base.autoRepaintOnSceneChange = true;
        }

        /// <summary>
        /// A Unity callback called when the window goes out of scope.
        /// </summary>
        void OnDisable () {
            // Update singleton instance
            Instance = null;

            // Store the NoVisible list
            this.m_NotVisible = BehaviourWindow.s_NotVisible;

            // Remove callbacks
            activeParentChanged -= OnParentSelectionChange;
            activeNodeChanged -= OnNodeSelectionChange;
            EditorApplication.playmodeStateChanged -= OnPlaymodeChange;
            EditorApplication.delayCall -= OnDelayCall;
            LoadSceneUtility.onLoadScene -= this.OnLoadScene;
            BehaviourMachinePrefs.preferencesChanged -= this.Repaint;

            // Force selection update
            if (activeParentChanged != null) 
                activeParentChanged();
        }

        /// <summary>
        /// A Unity callback called when the EditorWindow is closed.
        /// Destroys the gui parent.
        /// </summary>
        void OnDestroy () {
            if (m_ParentGUI != null)
                ScriptableObject.DestroyImmediate(m_ParentGUI);

            // Destroy guiCallback
            if (m_GUICallback != null) 
                DestroyImmediate(m_GUICallback, true);
        }

        /// <summary>
        /// Unity callback called after compilation.
        /// Un-/Registered in the OnDisable/OnEnable. 
        /// Recreates guiCallback if the Unity is in the editor mode.
        /// </summary>
        void OnDelayCall () {
            switch (m_PlayModeState) {
                case PlayModeState.Editor:
                    if (m_GUICallback == null)
                        m_GUICallback = this.CreateGUICallback();
                    break;
            }
        }

        /// <summary>
        /// Unity callback called when playmode changes. 
        /// Un-/Registered in the OnDisable/OnEnable. 
        /// Updates the m_PlayModeState member and the activeParent.
        /// Creates or destroy the guiCallback.
        /// </summary>
        void OnPlaymodeChange () {

            // Update playmode
            if (EditorApplication.isPlaying)
                m_PlayModeState = !EditorApplication.isPlayingOrWillChangePlaymode ? PlayModeState.SwitchingToEditor : PlayModeState.Playing;
            else
                m_PlayModeState = EditorApplication.isPlayingOrWillChangePlaymode ? PlayModeState.SwitchingToPlaymode : PlayModeState.Editor;

            // if (/*!EditorApplication.isPaused &&*/ (EditorApplication.isPlayingOrWillChangePlaymode && EditorApplication.isPlaying || !EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)) {
            if (m_PlayModeState == PlayModeState.Playing || m_PlayModeState == PlayModeState.Editor) {
                var parentID = m_SerializedParentID;
                activeParent = null;
                activeParent = EditorUtility.InstanceIDToObject(parentID) as ParentBehaviour;
                GUIUtility.hotControl = 0;
                GUIUtility.keyboardControl = 0;
            }

            // Create guiCallback?
            if (m_PlayModeState == PlayModeState.SwitchingToEditor && m_GUICallback == null) {
                m_GUICallback = this.CreateGUICallback();
            }
            // Destroy guiCallback?
            else if (m_PlayModeState == PlayModeState.SwitchingToPlaymode && m_GUICallback != null) {
                DestroyImmediate(m_GUICallback.gameObject, true);
            }
        }

        /// <summary>
        /// A Unity callback called when the window gets keyboard focus.
        /// Workaround to set Instance in fullscreen (Space or Shift + Space in Unity 4.3+).
        /// </summary>
        void OnFocus () {
            Instance = this;
            Refresh();
        }

        /// <summary>
        /// Unity callback used to draw controls in the window.
        /// Draws the toolbar, the gui parent and the blackboard view.
        /// </summary>
        void OnGUI () {
            // Debug.Log(Event.current);

            // Create style?
            if (s_Styles == null)
                s_Styles = new BehaviourWindow.Styles();

            // Refresh active objects during UndoRedoPerformed command
            if (!EditorApplication.isPlaying && Event.current.type == EventType.ValidateCommand && Event.current.commandName == "UndoRedoPerformed") {
                // Reload tree
                var tree = BehaviourWindow.activeTree;
                if (tree != null) {
                    tree.LoadNodes();
                    // Force node selection update
                    activeNodeID = activeNodeID;
                }

                // Update the active parent
                var lastSelectedParent = activeParent;
                var selectedState = Selection.activeObject as InternalStateBehaviour;
                if (lastSelectedParent == null || (selectedState != null  && selectedState.parent != lastSelectedParent)) {
                    var selectedParent = selectedState as ParentBehaviour;
                    if (selectedParent != null)
                        activeParent = selectedParent;
                }

                Refresh();
                // Repaint();
                return;
            }

            // Refresh window?
            if (InternalStateBehaviour.refresh) {
                // Workaround for the missing revert prefab button Unity callback...
                Refresh();
            }

            // Draw toolbar
            DoStatusBarGUI();

            // Draw the gui parent and the blackboard view
            GUI.BeginGroup(new Rect(0, EditorStyles.toolbar.fixedHeight - 2, position.width, position.height), ""); {
                if (m_ParentGUI != null && activeParent != null) {
                    // Get the blackboard
                    InternalBlackboard activeBlackboard = EditorUtility.InstanceIDToObject(m_ActiveBlackboardID) as InternalBlackboard;

                    // Get the blackboard view rect and height
                    float blackboardHeight = BlackboardGUIUtility.GetHeight(activeBlackboard) + 2f;
                    float blackboardViewHeight = GetBlackboardViewHeight(blackboardHeight);
                    Rect blackboardViewRect = new Rect (0f, position.height - blackboardViewHeight - 17f, 260f, blackboardViewHeight); 
                    // Show Scroll View?
                    if (BehaviourMachinePrefs.showScrollView)
                        blackboardViewRect.y -= 16f;

                    // Get event type
                    EventType eventType = Event.current.type;
                    // Should ignore event?
                    if (ShouldIgnoreEvent(blackboardViewRect)) {
                        Event.current.type = EventType.Ignore;
                    }

                    m_ParentGUI.OnGUIBeforeWindows();
                    BeginWindows();
                    m_ParentGUI.OnGUIWindows();
                    EndWindows();
                    m_ParentGUI.OnGUIAfterWindows();

                    // Restore event?
                    if (Event.current.type != EventType.Used)
                        Event.current.type = eventType;

                    // Draw variables
                    if (activeBlackboard != null)
                        DrawBlackboardView(blackboardViewRect, activeBlackboard, blackboardHeight);
                }
                // Show notification message
                else if (Event.current.type == EventType.MouseDown && Event.current.button == 0) {
                    ShowNotification(new GUIContent("Select a Game Object and right click in this window"));
                }
            } GUI.EndGroup();

            // Show context menu?
            if (Event.current.type == EventType.ContextClick) {
                OnContextMenu();
                Event.current.Use();
            }
        }

        /// <summary>
        /// A Unity callback called whenever the selection has changed.
        /// Updates the active parent if necessary. 
        /// </summary>
        void OnSelectionChange () {
            // Selection option is unlocked or the active parent is null?
            if (!m_Lock || s_ActiveParentID == 0) {
                // Get the active game object
                var selectedGameObject = Selection.activeObject as GameObject;

                // Get the first ParentBehaviour in the selectedGameObject.
                ParentBehaviour selectedParent = selectedGameObject != null ? selectedGameObject.GetComponent<ParentBehaviour>() : null;

                // There is no activeParent or the activeParent game object is not the active game object?
                if (activeParent == null || (selectedGameObject != null && selectedGameObject != activeParent.gameObject))
                    activeParent = selectedParent;
            }

            Repaint();
        }

        /// <summary>
        /// Undocumented Unity callback to draw a button in the window tab.
        /// Draws the selection lock button.
        /// <param name="rect">The button rect.</param>
        /// </summary> 
        void ShowButton (Rect rect) {
            // Create style?
            if (s_Styles == null)
                s_Styles = new BehaviourWindow.Styles();

            // Shows the lock icon
            if (GUI.Toggle(rect, m_Lock, GUIContent.none, s_Styles.lockButton) != m_Lock) {
                // Ping game object
                ParentBehaviour parent = activeParent;
                if (parent != null)
                    EditorGUIUtility.PingObject(parent.gameObject);

                // Toggle lock
                m_Lock = !m_Lock;
                // The selection is not locked?
                if (!m_Lock) {
                    // Update selection
                    OnSelectionChange();
                }
            }
        }
        #endregion Unity Callbacks

        
        #region Blackboard View
        /// <summary>
        /// Draw the blackboard view.
        /// <param name="rect">The position to draw the variables.</param>
        /// <param name="blackboard">The blackboard to be drawn.</param>
        /// <param name="blackboardHeight">The size needed to show all variables in the blackboard.</param>
        /// </summary>
        void DrawBlackboardView (Rect rect, InternalBlackboard blackboard, float blackboardHeight) {
            // Draw header
            Rect headerRect = new Rect (rect.x, rect.y, rect.width, blackboardHeaderHeight);
            if (GUI.Button(headerRect, new GUIContent( "Variables [" + blackboard.GetSize().ToString() + "]","Click to expand/collapse"), s_Styles.blackboardHeader)) {
                if (Event.current.mousePosition.x >= headerRect.xMax - c_BlackboardHeaderButtonWidth) {
                    BlackboardGUIUtility.OnAddContextMenu(blackboard);
                    m_BlackboardViewIsExpanded = true;
                }
                else
                    m_BlackboardViewIsExpanded = !m_BlackboardViewIsExpanded;
            }

            // Draw plus button
            headerRect.y += 2f;
            headerRect.xMin = headerRect.width - c_BlackboardHeaderButtonWidth;
            GUI.Label(headerRect, s_Styles.iconToolbarPlus);

            // The blackboard is expanded
            if (m_BlackboardViewIsExpanded && rect.height - headerRect.height > 0f) {
                rect.yMin += headerRect.height;

                // Draw background
                if (Event.current.type == EventType.Repaint)
                    s_Styles.blackboardBox.Draw(rect, false, false, false, false);

                // Do scroll bar?
                bool doScroll = blackboardHeight > rect.height;

                // Scroll bar logic
                if (doScroll) {
                    // Create a gui group
                    rect.yMin += 2f;
                    rect.yMax -= 2f;
                    GUI.BeginGroup(rect);
                    rect.y = rect.x = 0f;

                    // Get scroll event
                    if (Event.current.type == EventType.ScrollWheel) {
                        m_BlackboardScroll += Event.current.delta.y * 10f;
                        Event.current.Use();
                    }
                    
                    // Update rect
                    rect.y -= m_BlackboardScroll;
                    rect.width -= 12f;
                }

                // Draw variables
                BlackboardGUIUtility.DrawVariables(rect, blackboard);

                // Draw scroll bar
                if (doScroll) {
                    rect.y += m_BlackboardScroll;
                    rect.width += 12f;
                    var scrollPosition = new Rect (rect.x + rect.width - 16f, rect.y, 16f, rect.height);
                    m_BlackboardScroll = GUI.VerticalScrollbar(scrollPosition, m_BlackboardScroll, rect.height, 0f, blackboardHeight);
                    GUI.EndGroup();
                }
            }
        }

        /// <summary>
        /// Returns the blackboard view height.
        /// <param name="blackboardHeight">The size needed to show all variables in the blackboard.</param>
        /// <returns>The blackboard view height.</returns>
        /// </summary>
        float GetBlackboardViewHeight (float blackboardHeight) {
            if (!m_BlackboardViewIsExpanded || blackboardHeight < 10f)
                return blackboardHeaderHeight;
            return Mathf.Min(blackboardHeight, (position.height - 17f) * .5f) + blackboardHeaderHeight;
        }

        /// <summary>
        /// Returns true if the current gui event should be ignored by the gui parent and only used by the blackboard view.
        /// <param name="blackboardViewRect">The blackboard view position.</param>
        /// <returns>True if the event should be used by the blackboard view; False otherwise.</returns>
        /// </summary>
        bool ShouldIgnoreEvent (Rect blackboardViewRect) {
            EventType eventType = Event.current.type;
            return StateGUI.draggedWindow == -1 && (
                                                    (blackboardViewRect.Contains(Event.current.mousePosition) && (eventType == EventType.MouseDown || eventType == EventType.ScrollWheel)) 
                                                    || ((eventType == EventType.KeyDown || eventType == EventType.ValidateCommand || eventType == EventType.ExecuteCommand) 
                                                        && GUIUtility.keyboardControl != 0 && GUI.GetNameOfFocusedControl() != "TreeGUIRename")
                                                 );
        }
        #endregion Blackboard View
        #endregion Private Methods

        
        #region Public Methods
        /// <summary>
        /// Refresh the window content.
        /// </summary>
        public void Refresh () {
            OnSelectionChange();
            if (m_ParentGUI != null)
                m_ParentGUI.Refresh();
            InternalStateBehaviour.ResetRefresh();
        }
        #endregion Public Methods
    }
}
