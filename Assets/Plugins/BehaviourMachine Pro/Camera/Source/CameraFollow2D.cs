//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// The "Camera" will move and follow the "Player".
    /// </summary>
    [NodeInfo ( category = "Action/Camera/",
                icon = "Camera",
                description = "The \"Camera\" will moves and follow the \"Player\"")]
    public class CameraFollow2D : ActionNode {

        /// <summary>
        /// The camera game object.
        /// </summary>
    	[VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The camera game object")]
        public GameObjectVar camera;

        /// <summary>
        /// The player game object. The one that will be followed by the camera.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The player game object. The one that will be followed by the camera")]
        public GameObjectVar player;

        /// <summary>
        /// How much the "Player" can move in the x axis before the "Camera" can follow.
        /// </summary>
        [VariableInfo(tooltip = "How much the \"Player\" can move in the x axis before the \"Camera\" can follows")]
        public FloatVar xMargin;

        /// <summary>
        /// How much the "Player" can move in the y axis before the "Camera" can follow.
        /// </summary>
        [VariableInfo(tooltip = "How much the \"Player\" can move in the y axis before the \"Camera\" can follows")]
        public FloatVar yMargin;

        /// <summary>
        /// How smoothly the camera catches up with its target movement in the x axis.
        /// </summary>
        [VariableInfo(tooltip = "How smoothly the camera catches up with its target movement in the x axis")]
        public FloatVar xSmooth;

        /// <summary>
        /// How smoothly the camera catches up with its target movement in the y axis.
        /// </summary>
        [VariableInfo(tooltip = "How smoothly the camera catches up with its target movement in the y axis")]
        public FloatVar ySmooth;

        /// <summary>
        /// Ammount to look ahead of the player when moving in the x axis.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "Ammount to look ahead of the player when moving in the x axis")]
        public FloatVar xLookAhead;

        /// <summary>
        /// Ammount to look ahead of the player when moving in the y axis.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "Ammount to look ahead of the player when moving in the y axis")]
        public FloatVar yLookAhead;

        /// <summary>
        /// Optionally allows you to clamp the maximum speed in the x axis.
        /// </summary>
        [Tooltip("Optionally allows you to clamp the maximum speed in the x axis")]
        public float XMaxSpeed = Mathf.Infinity;

        /// <summary>
        /// Optionally allows you to clamp the maximum speed in the y axis.
        /// </summary>
        [Tooltip("Optionally allows you to clamp the maximum speed in the y axis")]
        public float YMaxSpeed = Mathf.Infinity;

        [System.NonSerialized]
        Transform m_CamTransform = null;
        [System.NonSerialized]
        Transform m_PlayerTransform = null;

        [System.NonSerialized]
        float m_XVelocity = 0F;
        [System.NonSerialized]
        float m_LastPlayerX = 0f;
        [System.NonSerialized]
        float m_LastCameraX = 0f;
        [System.NonSerialized]
        float m_YVelocity = 0F;
        [System.NonSerialized]
        float m_LastPlayerY = 0f;
        [System.NonSerialized]
        float m_LastCameraY = 0f;

        public override void Reset () {
            camera = new ConcreteGameObjectVar(this.self);
            player = new ConcreteGameObjectVar(this.self);
            xMargin = 0f;
            yMargin = 0f;
            xSmooth = .5f;
            ySmooth = .5f;
            xLookAhead = new ConcreteFloatVar();
            yLookAhead = new ConcreteFloatVar();
            XMaxSpeed = Mathf.Infinity;
            YMaxSpeed = Mathf.Infinity;

            m_CamTransform = null;
            m_PlayerTransform = null;
        }

        public override Status Update () {
            // Get the transform1
            if (m_CamTransform == null || m_CamTransform.gameObject != camera.Value)
                m_CamTransform = camera.Value != null ? camera.Value.transform : null;

            // Get the transform2
            if (m_PlayerTransform == null || m_PlayerTransform.gameObject != player.Value)
                m_PlayerTransform = player.Value != null ? player.Value.transform : null;

            // Validate members
            if (m_CamTransform == null || m_PlayerTransform == null) {
                return Status.Error;
            }

            // Get camera position.x
            float x = m_CamTransform.position.x;

            // The player has moved beyond x margin?
            float dx = m_PlayerTransform.position.x - x;
            if (!xLookAhead.isNone && x != m_LastCameraX && m_PlayerTransform.position.x != m_LastPlayerX) {
                dx += m_LastPlayerX > m_PlayerTransform.position.x ? - xLookAhead.Value : xLookAhead.Value;
                x = Mathf.SmoothDamp(x, x + dx, ref m_XVelocity, xSmooth, XMaxSpeed, owner.deltaTime);
            }
            else if (Mathf.Abs(dx) > xMargin.Value) {
                x = Mathf.SmoothDamp(x, x + dx, ref m_XVelocity, xSmooth, XMaxSpeed, owner.deltaTime);
            }

            m_LastCameraX = m_CamTransform.position.x;
            m_LastPlayerX = m_PlayerTransform.position.x;

            // Get camera position.y
            float y = m_CamTransform.position.y;

            // The player has moved beyond y margin?
            float dy = m_PlayerTransform.position.y - y;
            if (!yLookAhead.isNone && y != m_LastCameraY && m_PlayerTransform.position.y != m_LastPlayerY) {
                dy += m_LastPlayerY > m_PlayerTransform.position.y ? - yLookAhead.Value : yLookAhead.Value;
                y = Mathf.SmoothDamp(y, y + dy, ref m_YVelocity, ySmooth, YMaxSpeed, owner.deltaTime);
            }
            else if (Mathf.Abs(dy) > yMargin.Value) {
                y = Mathf.SmoothDamp(y, y + dy, ref m_YVelocity, ySmooth, YMaxSpeed, owner.deltaTime);
            }

            m_LastCameraY = m_CamTransform.position.y;
            m_LastPlayerY = m_PlayerTransform.position.y;

            // Set the camera's position to the target position with the same z component.
            m_CamTransform.position = new Vector3(x, y, m_CamTransform.position.z);

            return Status.Success;
        }
    }
}