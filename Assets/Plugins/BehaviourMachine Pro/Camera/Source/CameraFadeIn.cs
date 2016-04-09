//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Changes the color of a camera fade over time.
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "Changes the color of a camera fade over time")]
    public class CameraFadeIn : ActionNode {

        /// <summary>
        /// The color to fade in.
        /// </summary>
        [VariableInfo(tooltip = "The color to fade in")]
        public ColorVar color;

        /// <summary>
        /// The time in seconds to complete the fade.
        /// </summary>
        [VariableInfo(tooltip = "The time in seconds to complete the fade")]
        public FloatVar time;


        /// <summary>
        /// Optionally store the current time.
        /// You can set this value to zero to restart the fade.
        /// </summary>
        [VariableInfo(requiredField = false, canBeConstant = false, nullLabel = "Don't Store", tooltip = "Optionally store the current time. You can set this value to zero to restart the fade")]
        public FloatVar storeCurrentTime;

        /// <summary>
        /// Event to be sent when the fadeIn finishes.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Send", tooltip = "Event to be sent when the fadeIn finishes")]
        public FsmEvent onFinish;

        /// <summary>
        /// The OnGUI should be executed even if the node has not yet been updated? 
        /// This is useful to avoid flickers if the previous state also uses FadeIn/Out.
        /// </summary>
        [Tooltip("The OnGUI should be executed even if the node has not yet been updated? This is useful to avoid flickers if the previous state also uses FadeIn/Out")]
        public bool guiReady;

        [System.NonSerialized]
        Color m_LerpColor = Color.clear;

        public override void Reset () {
            color = Color.black;
            time = 2f;
            storeCurrentTime = new ConcreteFloatVar();
            onFinish = new ConcreteFsmEvent();
            guiReady = false;
        }

        public override void OnEnable () {
            GUICallback.onGUI += OnGUI;
            this.Start();
        }

        public override void OnDisable () {
            GUICallback.onGUI -= OnGUI;
        }

        public override void Start () {
            storeCurrentTime.Value = 0f;
            m_LerpColor = color.Value;
        }

        public override Status Update () {
            // Validate Members
            if (color.isNone || time.isNone)
                return Status.Error;

            // Update timer
            storeCurrentTime.Value += owner.deltaTime;

            // Update color
            m_LerpColor = Color.Lerp(color.Value, Color.clear, storeCurrentTime.Value / time.Value);

            // Send event?
            if (storeCurrentTime.Value >= time.Value) {
                if (onFinish.id != 0)
                    owner.root.SendEvent(onFinish.id);
                return Status.Success;
            }
            else
                return Status.Running;
        }


        #region GUI
        public CameraFadeIn () {
            // Create guiCallback
            InternalGlobalBlackboard.CreateGUICallback();
        }

        void OnGUI () {
            if (this.status == Status.Running || this.status == Status.Success || (guiReady && this.status == Status.Ready)) {
                Color oldGuiColor = GUI.color;
                GUI.color = m_LerpColor;

                GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height), NodeUtility.whiteTexture);

                GUI.color = oldGuiColor;
            }
        }
        #endregion GUI
    }
}