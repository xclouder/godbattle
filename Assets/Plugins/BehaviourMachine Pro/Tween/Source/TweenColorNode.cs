using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Base class for tween color nodes.
    /// </summary>
    [NodeInfo(  category = "Action/Tween/",
                icon = "Tween",
                description = "Base class for tween color nodes")]
    public abstract class TweenColorNode : TweenGameObjectNode {

        /// <summary>
        /// The type of easing.
        /// </summary>
        [Tooltip("The type of easing")]
        public EaseType easeType = TweenNode.EaseType.easeInQuad;

        /// <summary>
        /// The color to fade the object to.
        /// </summary>
        [VariableInfo(tooltip = "The color to fade the object to")]
        public ColorVar color;

        public Color currentColor {
            get {
                // Get the initial color
                GameObject target = gameObject.Value ?? self;
                
                if (target != null) {
                    Renderer renderer = target.GetComponent<Renderer>();
                    if (renderer != null)
                        return renderer.material.color;
                    else {
                        GUITexture guiTexture = target.GetComponent<GUITexture>();
                        if (target.GetComponent<GUITexture>() != null)
                            return guiTexture.color;
                        else {
                            GUIText guiText = target.GetComponent<GUIText>();
                            if (guiText != null)
                                return guiText.material.color;
                            else {
                                Light light = target.GetComponent<Light>();
                                if (light != null)
                                    return light.color;
                            }
                        }
                    }
                }

                return Color.white;
            }

            set {
                // Set the current to
                GameObject target = gameObject.Value ?? self;
                
                if (target != null) {
                    Renderer renderer = target.GetComponent<Renderer>();
                    if (renderer != null)
                        renderer.material.color = value;
                    else {
                        GUITexture guiTexture = target.GetComponent<GUITexture>();
                        if (guiTexture != null)
                            guiTexture.color = value;
                        else {
                            GUIText guiText = target.GetComponent<GUIText>();
                            if (guiText != null)
                                guiText.material.color = value;
                            else {
                                Light light = target.GetComponent<Light>();
                                if (light != null)
                                    light.color = value;
                            }
                        }
                    }
                }
            }
        }

        public override void Reset () {
            base.Reset();
            easeType = TweenNode.EaseType.easeInQuad;
            color = new ConcreteColorVar();
        }

        public override void OnValidate () {
            UpdateEasingFunction(easeType);
        }
    }
}