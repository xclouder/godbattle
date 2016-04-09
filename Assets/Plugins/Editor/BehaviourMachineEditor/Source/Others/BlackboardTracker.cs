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
    /// Keep track of Blackboards.
    /// </summary>
    [InitializeOnLoad]
    public sealed class BlackboardTracker {

        #region Static Members
        static List<int> s_SceneInstanceIDs = new List<int>();
        // static List<int> s_AssetInstanceIDs = new List<int>();
        // static List<string> s_AssetGUIDs = new List<string>();
        #endregion Static Members


        #region Properties
        /// <summary>
        /// Returns the current scene GameObject's instanceIDs that owns a Blackboard.
        /// </summary>
        public static int[] sceneInstanceIDs {get {return s_SceneInstanceIDs.ToArray();}}

        /// <summary>
        /// Returns the current loaded assets' instanceIDs that owns a Blackboard.
        /// </summary>
        // public static int[] assetInstanceIDs {get {return s_AssetInstanceIDs.ToArray();}}
        #endregion Properties


        #region Unity Callbacks
        /// <summary>
        /// Static constructor.
        /// </summary>
        static BlackboardTracker () {
            UpdateSceneInstanceIDs();
            // UpdateAssetInstanceIDs();
            EditorApplication.hierarchyWindowChanged += UpdateSceneInstanceIDs;
            // EditorApplication.projectWindowChanged += UpdateAssetInstanceIDs;
        }
        #endregion Unity Callbacks

        
        /// <summary>
        /// Update the scene blackboard's instance ids.
        /// </summary>
        static void UpdateSceneInstanceIDs () {
            // The HierarchyProperty is an undocumented class very uesfull to get all GameObjects in the scene or assets in the project
            var hierarchyProperty = new HierarchyProperty (HierarchyType.GameObjects);
            // Search for Blackboards
            hierarchyProperty.SetSearchFilter("internalblackboard", (int)SearchableEditorWindow.SearchModeHierarchyWindow.Type);
            // Reset the list of game Object instance ids
            s_SceneInstanceIDs.Clear();

            // Go through all objects
            while (hierarchyProperty.Next(null)) {
                // Populate the GameObject instanceID list
                s_SceneInstanceIDs.Add(hierarchyProperty.instanceID);
            }
        }

        /// <summary>
        /// Update the asset blackboard's instance ids and guids.
        /// </summary>
        // static void UpdateAssetInstanceIDs () {
        //     // The HierarchyProperty is an undocumented class very uesfull to get all GameObjects in the scene or assets in the project
        //     var hierarchyProperty = new HierarchyProperty (HierarchyType.Assets);
        //     // Search for Prefabs
        //     hierarchyProperty.SetSearchFilter("prefab", (int)SearchableEditorWindow.SearchMode.Type);
        //     // Reset the list of assets instance ids and guids
        //     s_AssetInstanceIDs.Clear();
        //     s_AssetGUIDs.Clear();

        //     // Go through all objects
        //     while (hierarchyProperty.Next(null)) {
        //         // Get the instanceID
        //         int instanceID = hierarchyProperty.instanceID;
        //         // Get the prefab
        //         var prefab = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        //         // The prefab has an InternalBlackboard component?
        //         if (prefab != null && prefab.GetComponent<InternalBlackboard>()) {
        //             // Populate the assets instanceID and the guid list
        //             s_AssetInstanceIDs.Add(instanceID);
        //             s_AssetGUIDs.Add(hierarchyProperty.guid);
        //         }
        //     }
        // }


        #region Public Methods
        /// <summary>
        /// Returns whenever the supplied id is in the scene and has a Blackboard in it.
        /// <param name="instanceID">The instanceID to search for.</param>
        /// <returns>True if the supplied id is in the scene and has a Blackboard in it; false otherwise.</returns>
        /// </summary>
        public static bool ContainsSceneObject (int instanceID) {
            return s_SceneInstanceIDs.Contains(instanceID);
        }

        /// <summary>
        /// Returns whenever the supplied id is an asset and has a Blackboard in it.
        /// <param name="instanceID">The instanceID to search for.</param>
        /// <returns>True if the supplied id is an asset and has a Blackboard in it; false otherwise.</returns>
        /// </summary>
        // public static bool ContainsAsset (int instanceID) {
        //     return s_AssetInstanceIDs.Contains(instanceID);
        // }

        // /// <summary>
        // /// Returns whenever the supplied guid has a Blackboard in it.
        // /// <param name="guid">The guid to search for.</param>
        // /// <returns>True if the supplied guid has a Blackboard in it; false otherwise.</returns>
        // /// </summary>
        // public static bool ContainsAsset (string guid) {
        //     return s_AssetGUIDs.Contains(guid);
        // }
        #endregion Public Methods
    }
}
