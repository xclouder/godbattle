//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Utility class to manage files in the project.
    /// </summary>
    public class FileUtility {

        /// <summary>
        /// Store loaded MonoScripts.
        /// </summary>
        static Dictionary<System.Type, MonoScript[]> s_LoadedScripts = new Dictionary<System.Type, MonoScript[]>();

        /// <summary>
        ///  The project's root folder.
        /// </summary>
        public static string projectPath {get {return Application.dataPath.Remove(Application.dataPath.Length - 6);}} // Assets.Length == 6


        /// <summary>
        /// Determines whether the specified file exists.
        /// <param name="path">The file to check.</param>
        /// <returns>True if the file exists; false otherwise.</returns>
        /// </summary>
        public static bool FileExists (string path) {
            return !string.IsNullOrEmpty(path) && File.Exists(projectPath + path);
        }

        /// <summary>
        /// Determines whether the specified directory exists.
        /// <param name="path">The directory to check.</param>
        /// <returns>True if the directory exists; false otherwise.</returns>
        /// </summary>
        public static bool DirectoryExists (string path) {
            return Directory.Exists(projectPath + path);
        }


        /// <summary>
        /// Saves a text file in the Assets folder.
        /// <param name="fileContent">The file content.</param>
        /// <param name="path">The files path.</param>
        /// <returns>The path to the file if it was created; string.Empty otherwise.</returns>
        /// </summary>
        public static string SaveFile (string fileContent, string path) {
            var newPath = string.Empty;
            if (!string.IsNullOrEmpty(fileContent) && !string.IsNullOrEmpty(path)) {
                path = AssetDatabase.GenerateUniqueAssetPath(path);
                using (StreamWriter writer = new StreamWriter (projectPath + path, false)) {
                    try {
                        writer.Write ("{0}", fileContent);
                        newPath = path;
                    }
                    catch (System.Exception e) {
                        Debug.LogException (e);
                    }
                }
                AssetDatabase.Refresh();
            }
            return newPath;
        }

        /// <summary>
        /// Saves a tet file in the Assets folder.
        /// <param name="path">The directory path.</param>
        /// </summary>
        public static void CreateDirectory (string path) {
            if (!string.IsNullOrEmpty(path) && !DirectoryExists(path)) {
                try {
                    System.IO.Directory.CreateDirectory(projectPath + path);
                }
                catch (System.Exception e) {
                    Debug.LogException (e);
                }
                AssetDatabase.Refresh();
            }
        }

        /// <summary>
        /// Returns a collection of MonoScripts whose class inherits from T.
        /// <returns>A collection of MonoScript whose class inherits from T.</returns>
        /// </summary>
        public static MonoScript[] GetScripts<T>() {

            // Try get loaded MonoScripts
            MonoScript[] loadedScripts = null;
            if (s_LoadedScripts.TryGetValue(typeof(T), out loadedScripts))
                return loadedScripts;

            // Load all MonoScripts
            Resources.LoadAll(string.Empty, typeof(MonoScript));

            var scripts = new List<MonoScript>();

            // Get all MonoScripts
            foreach (UnityEngine.Object obj in Resources.FindObjectsOfTypeAll(typeof(MonoScript))) {
                MonoScript mono = obj as MonoScript;
                if (mono != null && mono.GetClass() != null && mono.GetClass().IsSubclassOf(typeof(T)) && !mono.GetClass().IsAbstract) {
                    scripts.Add(mono);
                }
            }

            // Sort scripts by name
            scripts.Sort((MonoScript s1, MonoScript s2) => s1.GetClass().ToString().CompareTo(s2.GetClass().ToString()));

            // Add scripts to dictionary
            loadedScripts = scripts.ToArray();
            s_LoadedScripts.Add(typeof(T), loadedScripts);

            return loadedScripts;
        }

        /// <summary>
        /// Returns the path name relative to the project folder where the asset is stored.
        /// Excludes the asset name from path if its not a folder.
        /// <param name="asset">The asset to get the path.</param>
        /// <returns>The asset path name relative to the project folder.</returns>
        /// </summary>
        public static string GetAssetPath (UnityEngine.Object asset) {
            var path = "Assets";
            // its an asset?
            if (asset != null && AssetDatabase.Contains(asset)) {
                try {
                    // Gets the path
                    var assetPath = AssetDatabase.GetAssetPath(asset);
                    if (!string.IsNullOrEmpty(assetPath)) {
                        if (FileUtility.DirectoryExists(assetPath))
                            path = assetPath;
                        else
                            path = assetPath.Substring(0, assetPath.LastIndexOf("/"));
                    }
                }
                catch (System.Exception e) {
                    Debug.LogException(e);
                }
            }
            return path;
        }

        /// <summary>
        /// Returns true if the object is a prefab.
        /// <param name="obj">The object to test.</param>
        /// <returns>True if the supplied object is a prefab, false otherwise.</returns>
        /// </summary>
        public static bool IsPrefab (UnityEngine.Object obj) {
            var prefabType = PrefabUtility.GetPrefabType(obj);
            return prefabType == PrefabType.Prefab || prefabType == PrefabType.ModelPrefab;
        }

        /// <summary>
        /// Returns all file names with the supplied pattern in the directory.
        /// <param name="directory">The target directory.</param>
        /// <param name="pattern">The pattern to search for.</param>
        /// <returns>All file names with the pattern.</returns>
        /// </summary>
        public static List<string> SearchFiles (string directory, string pattern) {
            List <string> fileNames = new List <string>();
            foreach (string f in Directory.GetFiles(directory, pattern, SearchOption.AllDirectories)) {
                fileNames.Add (f);
            }
            return fileNames;
         }
    }
}
