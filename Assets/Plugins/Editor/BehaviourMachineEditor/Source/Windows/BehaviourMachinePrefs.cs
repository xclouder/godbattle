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
    /// Used to store the position of the {b} in the Hierarchy view.
    /// </summary>
    public enum LogoPosition {
        None = 0,
        Position1 = 1,
        Position2 = 2,
        Position3 = 3
    }

    /// <summary> 
    /// Behaviour Machine Preferences.
    /// Stores the plugins preferences data and adds items to the Unity preferences window.
    /// </summary>
    public class BehaviourMachinePrefs {

        #region Styles
        static Styles s_Styles;

        /// <summary>
        /// A class that holds GUIStyles used by the BehaviourMachinePrefs.
        /// </summary>
        class Styles {
            public readonly GUIStyle line = "sv_iconselector_sep";
        }
        #endregion Styles

        #region Preferences Members
        static bool s_PrefsLoaded = false;
        static bool s_EnabledStateName;
        static bool s_EditorOnGUI;
        static float s_SnapMove;
        static bool s_ShowScrollView = false;
        static LogoPosition s_LogoPosition = LogoPosition.None;
        static int s_SelectedOption = 0;
        #endregion Preferences Members


        #region events
        public static event System.Action preferencesChanged;
        #endregion events
        
        #region Properties
        /// <summary> 
        /// Returns true if the enabled state name gizmo should be displayed.
        /// </summary>
        public static bool enabledStateName {
            get {
                if (!s_PrefsLoaded)
                    LoadPreferencesMembers();
                return s_EnabledStateName;
            }
        }

        /// <summary> 
        /// Returns true if the OnGUI nodes should be called in editor mode.
        /// </summary>
        public static bool editorOnGUI {
            get {
                if (!s_PrefsLoaded)
                    LoadPreferencesMembers();
                return s_EditorOnGUI;
            }
        }

        /// <summary> 
        /// Returns the state snap move value.
        /// </summary>
        public static float snapMove {
            get {
                if (!s_PrefsLoaded)
                    LoadPreferencesMembers();
                return s_SnapMove;
            }
        }

        /// <summary> 
        /// Returns true if the OnGUI nodes should be called in editor mode.
        /// </summary>
        public static bool showScrollView {
            get {
                if (!s_PrefsLoaded)
                    LoadPreferencesMembers();
                return s_ShowScrollView;
            }
        }

        /// <summary> 
        /// Returns the selected option for the position of the {b} logo in the Hierarchy view.
        /// </summary>
        public static LogoPosition logoPosition {
            get {
                if (!s_PrefsLoaded)
                    LoadPreferencesMembers();
                return s_LogoPosition;
            }
        }
        #endregion Properties

        
        #region Private Methods
        /// <summary> 
        /// Retrieves the preferences members in the EditorPrefs.
        /// </summary>
        static void LoadPreferencesMembers () {
            s_PrefsLoaded = true;
            s_EnabledStateName = EditorPrefs.GetBool ("BM.EnabledStateName", true);
            s_EditorOnGUI = EditorPrefs.GetBool ("BM.EditorOnGUI", true);
            s_SnapMove = EditorPrefs.GetFloat ("BM.SnapMove", 10f);
            s_ShowScrollView = EditorPrefs.GetBool ("BM.ShowScrollView", false);
            s_LogoPosition = (LogoPosition)EditorPrefs.GetInt ("BM.LogoPosition", 0);
        } 

        /// <summary> 
        /// Saves the preferences members in the EditorPrefs.
        /// </summary>
        static void SavePreferencesMembers () {
            EditorPrefs.SetBool("BM.EnabledStateName", s_EnabledStateName);
            EditorPrefs.SetBool("BM.EditorOnGUI", s_EditorOnGUI);
            EditorPrefs.SetFloat("BM.SnapMove", s_SnapMove);
            EditorPrefs.SetBool("BM.ShowScrollView", s_ShowScrollView);
            EditorPrefs.SetInt("BM.LogoPosition", (int)s_LogoPosition);

            // Call the preferences changed callback
            if (preferencesChanged != null)
                preferencesChanged();
        } 

        /// <summary> 
        /// Reset preferences.
        /// </summary>
        static void ResetToDefaults () {
            EditorPrefs.DeleteKey("BM.EnabledStateName");
            EditorPrefs.DeleteKey("BM.EditorOnGUI");
            EditorPrefs.DeleteKey("BM.SnapMove");
            EditorPrefs.DeleteKey("BM.ShowScrollView");
            EditorPrefs.DeleteKey("BM.LogoPosition");
            LoadPreferencesMembers();

            // Call the preferences changed callback
            if (preferencesChanged != null)
                preferencesChanged();
        }
        #endregion Private Methods

        
        #region Unity Callbacks
        [PreferenceItem ("Behaviour Machine")]
        static void BehaviourMachinePreferencesGUI () {
            if (s_Styles == null)
                s_Styles = new BehaviourMachinePrefs.Styles();
            if (!s_PrefsLoaded)
                LoadPreferencesMembers();

            // Draw preferences gui
            s_EnabledStateName = EditorGUILayout.Toggle (new GUIContent("Show States Name Gizmo", "The name of the enabled states should be shown as a gizmo?"), s_EnabledStateName);
            s_EditorOnGUI = EditorGUILayout.Toggle (new GUIContent("OnGUI nodes in the Editor", "WYSIWYG option. If True you can see your Unity GUI controls while editing an ActionState or BehaviourTree"), s_EditorOnGUI);
            s_SnapMove = Mathf.Max(0f, EditorGUILayout.FloatField (new GUIContent("State Snap Move", "The value to snap the states in the {b}'s window grid"), s_SnapMove));
            s_ShowScrollView = EditorGUILayout.Toggle (new GUIContent("Show Scroll View?", "If True the {b} window will show the scroll view"), s_ShowScrollView);
            s_LogoPosition = (LogoPosition)EditorGUILayout.EnumPopup(new GUIContent("{b} Logo Position", "Used for the {b} logo in the Hierarchy view"), s_LogoPosition);

            // Save preferences?
            if (GUI.changed)
                SavePreferencesMembers();

            // Reset preferences?
            EditorGUILayout.Space();
            if (GUILayout.Button("Use Defaults", GUILayout.Width(120f))) {
                ResetToDefaults();
            }

            // Updater
            EditorGUILayout.Space();
            EditorGUILayout.LabelField(string.Empty, s_Styles.line);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Auto Update");
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button(new GUIContent("FsmEvent", "Use this update when the FsmEvents in this project are using an older serialization (version 1.2 or previous) data and need to be updated"))) {
                s_SelectedOption = 1;
                EditorApplication.delayCall += OnDelayCall;
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }

        static void OnDelayCall () {
            EditorApplication.delayCall -= OnDelayCall;
            if (s_SelectedOption == 1) {
                s_SelectedOption = 0;
                AutoUpdate.UpdateFSMEvent();
            }
        }
        #endregion Unity Callbacks
    }

}
