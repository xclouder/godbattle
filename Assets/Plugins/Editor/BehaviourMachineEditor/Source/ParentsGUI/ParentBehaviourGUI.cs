//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BehaviourMachineEditor {
    /// <summary> 
    /// A base class used to draw a ParentBehaviour in the BehaviourWindow.
    /// </summary>
    [System.Serializable]
    public abstract class ParentBehaviourGUI : ScriptableObject {

        #region Properties
        /// <summary>
        /// The position to draw the content.
        /// </summary>
        public Rect position {
            get {
                if (BehaviourWindow.Instance != null) {
                    var windowPos = BehaviourWindow.Instance.position;
                    return new Rect(0f, 0f, windowPos.width, windowPos.height - 16f);
                }
                return new Rect(0,0,0,0);
            }
        }
        #endregion Properties

        #region Virtual Methods
        #region Unity Callbacks
        /// <summary> 
        /// A Unity callback called when the object is loaded.
        /// </summary>
        protected virtual void OnEnable () {
            hideFlags = HideFlags.HideAndDontSave;  // Hide from inspector and do not Save in the scene.
            BehaviourWindow.activeParentChanged += Refresh;
        }

        /// <summary> 
        /// A Unity callback called when the object goes out of scope.
        /// </summary>
        protected virtual void OnDisable () {
            BehaviourWindow.activeParentChanged -= Refresh;
        }
        #endregion Unity Callbacks

        /// <summary> 
        /// A method to be called before EditorWindow.BeginWindows.
        /// </summary>
        public virtual void OnGUIBeforeWindows () {}

        /// <summary> 
        /// A method to be called between EditorWindow.BeginWindows and EditorWindow.EndWindows.
        /// </summary>
        public virtual void OnGUIWindows () {}

        /// <summary> 
        /// A method to be called after EditorWindow.EndWindows.
        /// </summary>
        public virtual void OnGUIAfterWindows () {}

        /// <summary> 
        /// Refresh the content of this object.
        /// </summary>
        public abstract void Refresh ();

        /// <summary> 
        /// Repaints the BehaviourWindow.
        /// </summary>
        public void Repaint () {
            if (BehaviourWindow.Instance != null)
                BehaviourWindow.Instance.Repaint();
        }
        #endregion Virtual Methods
    }
}