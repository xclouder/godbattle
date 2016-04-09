using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Changes the color of the Game Object instantly then returns them to the provided properties over time. If a Light, GUIText or GUITexture component is attached, they will become the target of the animation.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Changes the color of the Game Object instantly then returns them to the provided properties over time. If a Light, GUIText or GUITexture component is attached, they will become the target of the animation")]
    public class ColorFrom : TweenColorNode {

        [System.NonSerialized]
        Color to;

        public override void OnStart () {
            Color from = color.Value;
            to = currentColor;

            m_From = new float[] {from.r, from.g, from.b, from.a};
            m_To = new float[] {to.r, to.g, to.b, to.a};
            m_Result = new float[4];
        }

        public override void OnFinish () {
            currentColor = to;
        }

        public override void OnUpdate () {
            // Update ease function?
            if (m_EaseFunction == null)
                UpdateEasingFunction(easeType);

            Apply();
            
            currentColor = new Color(m_Result[0], m_Result[1], m_Result[2], m_Result[3]);
        }
    }
}