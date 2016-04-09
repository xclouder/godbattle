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
    /// Draws the {b} logo in the Hierarchy view.
    /// </summary>
    [InitializeOnLoad]
    public sealed class HierarchyAndProjectGUI {


        #region Styles
        static HierarchyAndProjectGUI.Styles s_Styles;

        /// <summary> 
        /// Class that store GUIStyles used by the HierarchyAndProjectGUI.
        /// </summary>
        class Styles {
            public readonly GUIStyle label;
            public GUIContent logoContent = new GUIContent(Print.bmColoredStringLogo);

            public Styles () {
                label = new GUIStyle ("Label");
                label.richText = true;
                label.padding = new RectOffset();
            }
        }
        #endregion Styles


        #region Members
        static float s_XOffset = 0f;
        #endregion Members

        #region Unity Callbacks
        /// <summary>
        /// Static constructor.
        /// </summary>
        static HierarchyAndProjectGUI () {
            BehaviourMachinePrefs.preferencesChanged += OnPreferencesChanged;
            OnPreferencesChanged();
        }

        /// <summary>
        /// Called by Unity for each GameObject in the scene.
        /// Used to draw the {b} logo in the Hierarchy view.
        /// <param name = "instanceID">The instanceID of the target game object.</param>
        /// <param name = "selectionRect">The Rect of the GameObject name in the Hierarchy view.</param>
        /// </summary>
        static void OnHierarchyWindowItemOnGUI (int instanceID, Rect selectionRect) {
            // Create Styles
            if (s_Styles == null)
                s_Styles = new HierarchyAndProjectGUI.Styles();

            // This is the repaint event and the the GameObject has a Blackboard in it?
            if (Event.current.type == EventType.Repaint && BlackboardTracker.ContainsSceneObject(instanceID)) {
                // Set rect
                selectionRect.xMin += selectionRect.width - s_XOffset;
                selectionRect.width = 20f;

                // Draw the {b} logo
                s_Styles.label.Draw(selectionRect, s_Styles.logoContent, false, false, false, false);
            }
        }

        /// <summary>
        /// Called by Unity for each asset in the project.
        /// Used to draw the {b} logo in the Project view.
        /// <param name = "guid">The guid of the target asset.</param>
        /// <param name = "selectionRect">The Rect of the GameObject name in the Project view.</param>
        /// </summary>
        // static void OnProjectWindowItemOnGUI (string guid, Rect selectionRect) {
        //     // Create Styles
        //     if (s_Styles == null)
        //         s_Styles = new HierarchyAndProjectGUI.Styles();

        //     // This is the repaint event and the the GameObject has a Blackboard in it?
        //     if (Event.current.type == EventType.Repaint && BlackboardTracker.ContainsAsset(guid)) {
        //         // Set rect
        //         selectionRect.xMin += selectionRect.width - s_XOffset;
        //         selectionRect.width = 16f;
        //         // Draw the {b} logo
        //         s_Styles.label.Draw(selectionRect, s_Styles.logoContent, false, false, false, false);
        //     }
        // }
        #endregion Unity Callbacks


        #region BehaviourMachine Callbacks
        /// <summary>
        /// Called by BehaviourMachine when the Preferences has changed.
        /// </summary>
        static void OnPreferencesChanged () {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyWindowItemOnGUI;
            // EditorApplication.projectWindowItemOnGUI -= OnProjectWindowItemOnGUI;

            switch (BehaviourMachinePrefs.logoPosition) {
                case LogoPosition.Position1:
                    s_XOffset = 18f + 4f;
                    EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
                    // EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
                    break;
                case LogoPosition.Position2:
                    s_XOffset = 36f + 4f;
                    EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
                    // EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
                    break;
                case LogoPosition.Position3:
                    s_XOffset = 54f + 4f;
                    EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
                    // EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
                    break;
            }

            // Repaint the Hierarchy and the Project window
            EditorApplication.RepaintHierarchyWindow();
            // EditorApplication.RepaintProjectWindow();
        }
        #endregion BehaviourMachine Callbacks

    }
}