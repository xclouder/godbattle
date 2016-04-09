//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Base class for tween nodes that uses a game object.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Base class for tween nodes that uses a game object")]
    public abstract class TweenGameObjectNode : TweenNode {

        [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object to animate")]
        public GameObjectVar gameObject;

        [System.NonSerialized]
        Transform m_Transform = null;

        #region Properties
        public Transform transform {
            get {
                // Get the transform
                if (m_Transform == null || m_Transform.gameObject != gameObject.Value)
                    m_Transform = gameObject.Value != null ? gameObject.Value.transform : self.transform;

                return m_Transform;
            }
        }
        #endregion Properties

        public override void Reset () {
            base.Reset();
            gameObject = new ConcreteGameObjectVar(this.self);
        }
    }
}