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
    /// Blackboard utility functions.
    /// Also keep track of all scene GameObjects that has a Blackboard in it.
    /// </summary>
    public sealed class BlackboardUtility {

        #region Undo
        /// <summary> 
        /// Register undo before add a new variable.
        /// <param name="blackboard">The blackboard to register undo.</param> 
        /// <param name="name">The name of the undo.</param> 
        /// </summary>
        private static void RegisterVariableUndo (InternalBlackboard blackboard, string name) {
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
            Undo.RegisterUndo(blackboard, name);
            #else
            Undo.RecordObject(blackboard, name);
            #endif
        }
        #endregion Undo


        /// <summary>
        /// Removes the supplied variable from its blackboard.
        /// <param name="variable">The variable to be removed.</param>
        /// <summary>
        public static void RemoveVariable (Variable variable) {
            if (variable != null && variable.blackboard != null) {
                // Get the target blackboard
                InternalBlackboard blackboard = variable.blackboard;

                // Register undo
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2
                Undo.RegisterUndo(blackboard, "Delete Variable");
                #else
                Undo.RecordObject(blackboard, "Delete Variable");
                #endif

                // Remove variable
                blackboard.RemoveVariable(variable);
                // Set dirty
                EditorUtility.SetDirty(blackboard);
            }
        }

        /// <summary> 
        /// Adds a new float var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new FloatVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static FloatVar AddFloatVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Float Variable"); 
            var newVariable = blackboard.AddFloatVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new int var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new IntVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static IntVar AddIntVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Int Variable"); 
            var newVariable = blackboard.AddIntVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new bool var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new BoolVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static BoolVar AddBoolVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Bool Variable"); 
            var newVariable = blackboard.AddBoolVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new string var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new StringVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static StringVar AddStringVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add String Variable"); 
            var newVariable = blackboard.AddStringVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Vector3 var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new Vector3Var.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static Vector3Var AddVector3Var (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Vector3 Variable"); 
            var newVariable = blackboard.AddVector3Var(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Rect var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new RectVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static RectVar AddRectVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Rect Variable"); 
            var newVariable = blackboard.AddRectVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Color var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new ColorVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static ColorVar AddColorVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Color Variable"); 
            var newVariable = blackboard.AddColorVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Quaternion var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new QuaternionVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static QuaternionVar AddQuaternionVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Quaternion Variable"); 
            var newVariable = blackboard.AddQuaternionVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new GameObject var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new GameObjectVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static GameObjectVar AddGameObjectVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add GameObject Variable"); 
            var newVariable = blackboard.AddGameObjectVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Texture var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new TextureVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static TextureVar AddTextureVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Texture Variable"); 
            var newVariable = blackboard.AddTextureVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Material var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new MaterialVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static MaterialVar AddMaterialVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Material Variable"); 
            var newVariable = blackboard.AddMaterialVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new Object var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new ObjectVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static ObjectVar AddObjectVar (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Object Variable"); 
            var newVariable = blackboard.AddObjectVar(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new dynamic list to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new DynamicList.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static DynamicList AddDynamicList (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add Dynamic List"); 
            var newVariable = blackboard.AddDynamicList(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }

        /// <summary> 
        /// Adds a new FsmEvent var to the supplied blackboard.
        /// Automatically handles undo.
        /// <param name="blackboard">The blackboard to add a new FsmEventVar.</param>
        /// <returns>The new variable.</returns>
        /// </summary>
        public static FsmEvent AddFsmEvent (InternalBlackboard blackboard) {
            BlackboardUtility.RegisterVariableUndo(blackboard, "Add FsmEvent"); 
            var newVariable = blackboard.AddFsmEvent(); 
            EditorUtility.SetDirty(blackboard);
            return newVariable;
        }
    }
}