//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using BehaviourMachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourMachineEditor {


    /// <summary> 
    /// Class for auto update BehaviourMachine.
    /// </summary>
    [InitializeOnLoad]
    public sealed class AutoUpdate {

        delegate void BlackboardEditDelegate(InternalBlackboard blackboard, bool isPrefab); 
        static int version {get {return 1;}}

        static AutoUpdate () {
            EditorApplication.update += AutoUpdate.CheckVersion;
            EditorApplication.update += AutoUpdate.CheckGlobalBlackboard;
        }

        static void CheckGlobalBlackboard () {    
            // Remove callback
            EditorApplication.update -= AutoUpdate.CheckGlobalBlackboard;

            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            if (InternalGlobalBlackboard.Instance == null) {
                EditorApplication.ExecuteMenuItem("Tools/BehaviourMachine/Global Blackboard");
                Print.Log("No GlobalBlackboard found, creating one...", InternalGlobalBlackboard.Instance);
            }
        }

        static void CheckVersion () {
            // Remove callback
            EditorApplication.update -= AutoUpdate.CheckVersion;

            // The editor is not switching from playmode?
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            // Get the current version
            int currentVersion = EditorPrefs.GetInt(Application.dataPath + "BM.version");

            // Need to update?
            if (currentVersion < version) {
                UpdateFSMEvent();
                // Print.LogWarning("If you are upgrading BehaviourMachine from the 1.2 (or previous) version you should to manually use to FsmEvent update to upgrade your Blackboard events.\n\nFrom the Preferences window (Unity -> Preferences -> BehaviourMachine) select the FsmEvent update button.\n");
                // Update version
                EditorPrefs.SetInt(Application.dataPath + "BM.version", 1);
            }
        }

        #region Public Methods
        public static void UpdateFSMEvent () {
            if (!EditorUtility.DisplayDialog("FsmEvent Update", "If you choose \'Go Ahead\', BehaviourMachine will automatically upgrade all FsmEvents in your project (it includes all game objects in your scenes and prefabs). You should make a backup before proceeding.\n\nYou can always run the FsmEvent Updater manually through the preferences window.", "I Made a Backup. Go Ahead!", "No Thanks"))
                return;

            // save the current opened scene
            string originalScene = EditorApplication.currentScene;
            // Saves the current scene if user wants
            EditorApplication.SaveCurrentSceneIfUserWantsTo();

            UpdateAllBlackboards(AutoUpdate.FsmEvent2ConcreteFsmEvent);

            // Opens the original scene
            if (!string.IsNullOrEmpty(originalScene))
                EditorApplication.OpenScene(originalScene);
            else
                EditorApplication.NewScene();
        }
        #endregion Public Methods


        #region Update Methods
        static void UpdateAllBlackboards (BlackboardEditDelegate blackboardDelegate) {
            // Update GameObjects in all scenes
            List<string> sceneNames = FileUtility.SearchFiles (Application.dataPath, "*.unity");
            foreach (string sceneName in sceneNames) {
                // Open scene
                EditorApplication.OpenScene(sceneName);

                // Get all GameObjects in the scene
                var objects = GameObject.FindObjectsOfType(typeof(GameObject)).Where(g => !AssetDatabase.Contains(g.GetInstanceID())).ToArray();
                int objectsLength = objects.Length;

                for (int i = 0; i < objectsLength; i++) {
                    var gameObject = objects[i] as GameObject;
                    EditorUtility.DisplayProgressBar("Updating Scene:" + sceneName, gameObject.name, (float)(i + 1)/objectsLength);

                    // Try to get a blackboard on the gameObject
                    var blackboard = gameObject.GetComponent<InternalBlackboard>();
                    if (blackboard != null) {
                        blackboardDelegate(blackboard, false);
                    }
                }

                EditorApplication.SaveScene();
            }

            // Update Prefabs
            List<string> prefabNames = FileUtility.SearchFiles (Application.dataPath, "*.prefab");
            int dataPathLength = Application.dataPath.Length - 6; // 6 == "Assets".Length
            EditorApplication.NewScene();
            for (int i = 0; i < prefabNames.Count; i++) {
                // Get the prefab
                var prefab = AssetDatabase.LoadAssetAtPath(prefabNames[i].Remove(0, dataPathLength), typeof(GameObject)) as GameObject;
                var prefabInstance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

                EditorUtility.DisplayProgressBar("Updating Prefab", prefab.name, (float)(i + 1)/prefabNames.Count);

                // Try to get a Blackboard in children
                foreach (InternalBlackboard blackboard in prefabInstance.GetComponentsInChildren<InternalBlackboard>(true)) {
                    blackboardDelegate(blackboard, true);
                }

                PrefabUtility.ReplacePrefab(prefabInstance, prefab);
            }

            EditorUtility.ClearProgressBar();
        }

        static void FsmEvent2ConcreteFsmEvent (InternalBlackboard blackboard, bool isPrefab) {
            // Get the target serialized object
            var serializedBlackboard = new SerializedObject(blackboard);
            // Get the m_FsmEvents property
            var fsmEventProperty = serializedBlackboard.FindProperty("m_FsmEvents");
            // Get the m_ConcreteFsmEvents property
            var concreteFsmEventProperty = serializedBlackboard.FindProperty("m_ConcreteFsmEvents");

            // Copy data
            if (fsmEventProperty != null && concreteFsmEventProperty != null && (isPrefab || !fsmEventProperty.isInstantiatedPrefab || fsmEventProperty.prefabOverride)) {

                for (int i = 0; i < fsmEventProperty.arraySize; i++) {
                    // Add new FsmEvent
                    concreteFsmEventProperty.InsertArrayElementAtIndex(i);
                    // Get the new FsmEvent
                    SerializedProperty newFsmProperty = concreteFsmEventProperty.GetArrayElementAtIndex(i);
                    // Get the old FsmEvent
                    SerializedProperty oldFsmProperty = fsmEventProperty.GetArrayElementAtIndex(i);

                    // Update the new FsmEvent properties
                    newFsmProperty.FindPropertyRelative("m_ID").intValue = oldFsmProperty.FindPropertyRelative("m_ID").intValue;
                    newFsmProperty.FindPropertyRelative("m_Name").stringValue = oldFsmProperty.FindPropertyRelative("m_Name").stringValue;
                    newFsmProperty.FindPropertyRelative("m_Blackboard").objectReferenceValue = oldFsmProperty.FindPropertyRelative("m_Blackboard").objectReferenceValue;
                    newFsmProperty.FindPropertyRelative("m_IsConstant").boolValue = oldFsmProperty.FindPropertyRelative("m_IsConstant").boolValue;
                    newFsmProperty.FindPropertyRelative("m_EventId").intValue = oldFsmProperty.FindPropertyRelative("m_EventId").intValue;
                    newFsmProperty.FindPropertyRelative("m_IsSystem").boolValue = oldFsmProperty.FindPropertyRelative("m_IsSystem").boolValue;
                }

                // Clear the fsmEvent event property
                fsmEventProperty.ClearArray();
            }

            // Dispose properties
            fsmEventProperty.Dispose();
            concreteFsmEventProperty.Dispose();
            // Update serialized data
            serializedBlackboard.ApplyModifiedProperties();
        }
        #endregion Update Methods
    }
}
