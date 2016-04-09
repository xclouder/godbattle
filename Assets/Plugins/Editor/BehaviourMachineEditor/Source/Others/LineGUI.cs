//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BehaviourMachineEditor {

    /// <summary> 
    /// Class used to draw lines in the GUI.
    /// </summary>
    public class LineGUI {
        #region OpenGL
        static Material s_LineMaterial;

        /// <summary> 
        /// The material used to draw lines.
        /// </summary>
        public static Material lineMaterial {
            get {
                if (!s_LineMaterial) 
                    CreateLineMaterial(); 
                return s_LineMaterial;
            }
        }
        
        /// <summary> 
        /// Creates the material used to draw lines.
        /// </summary>
        private static void CreateLineMaterial () {
           s_LineMaterial = (Material)UnityEditor.EditorGUIUtility.LoadRequired("SceneView/2DHandleLines.mat");
        }

        /// <summary> 
        /// Draws a line using GL functions.
        /// <param name="pointA">The init point of the line.</param>
        /// <param name="pointB">The end point of the line.</param>
        /// <param name="color">The color of the line.</param>
        /// </summary>
        public static void GLLine (Vector2 pointA, Vector2 pointB, Color color) {
            // TODO: check if this is ok
            if (Event.current == null || Event.current.type != EventType.repaint)
                return;

            if (!s_LineMaterial)
                CreateLineMaterial();
            
            GL.PushMatrix();
            s_LineMaterial.SetPass(0);
            GL.Begin(GL.LINES);
            GL.Color(color);
            GL.Vertex3(pointA.x, pointA.y, 0);
            GL.Vertex3(pointB.x, pointB.y, 0);
            GL.End();
            GL.PopMatrix();
        }

        /// <summary> 
        /// Draws quadratic line using GL functions.
        /// <param name="pointA">The init point of the line.</param>
        /// <param name="pointB">The end point of the line.</param>
        /// <param name="color">The color of the line.</param>
        /// </summary>
        public static void GLQuadratic (Vector2 pointA, Vector2 pointB, Color color) {
            // TODO: check if this is ok
            if (Event.current == null || Event.current.type != EventType.repaint)
                return;

            if (!s_LineMaterial)
                CreateLineMaterial();

            GL.PushMatrix();
            s_LineMaterial.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(color);
            
            GL.Vertex3(pointA.x, pointA.y, 0);
            GL.Vertex3((pointA.x + pointB.x) * .5f, pointA.y, 0);
            
            GL.Vertex3((pointA.x + pointB.x) * .5f, pointA.y, 0);
            GL.Vertex3((pointA.x + pointB.x) * .5f, pointB.y, 0);
            
            GL.Vertex3((pointA.x + pointB.x) * .5f, pointB.y, 0);
            GL.Vertex3(pointB.x, pointB.y, 0);
            GL.End();
            GL.PopMatrix();
        }

        /// <summary> 
        /// Helper class used to draw a bezier line.
        /// <param name="s">The start point of the line.</param>
        /// <param name="st">The start tangent point of the line.</param>
        /// <param name="e">The end point of the line.</param>
        /// <param name="et">The end tangent of the line.</param>
        /// <param name="t">The current interval.</param>
        /// </summary>
        static Vector2 cubeBezier (Vector2 s, Vector2 st, Vector2 e, Vector2 et, float t){
            float rt = 1-t;
            float rtt = rt * t;
            return rt*rt*rt * s + 3 * rt * rtt * st + 3 * rtt * t * et + t*t*t* e;
        }

        /// <summary> 
        /// Draws a bezier line using GL functions.
        /// <param name="pointA">The init point of the line.</param>
        /// <param name="pointB">The end point of the line.</param>
        /// <param name="color">The color of the line.</param>
        /// </summary>
        public static void GLBezier (Vector2 pointA, Vector2 pointB, Color color) {
            // TODO: check if this is ok
            if (Event.current == null || Event.current.type != EventType.repaint)
                return;

            if (!s_LineMaterial)
                CreateLineMaterial();

            GL.PushMatrix();
            s_LineMaterial.SetPass(0);
            GL.Begin(GL.LINES);
            GL.Color(color);

            var segments = Mathf.Clamp(Mathf.RoundToInt((pointA - pointB).sqrMagnitude * .0003f), 10, 50) ;
            var startTangent = new Vector2(pointA.x + Mathf.Abs(pointB.x - pointA.x) / 2, pointA.y);
            var endTangent = new Vector2(pointB.x - Mathf.Abs(pointB.x - pointA.x) / 2, pointB.y);

            Vector2 lastV = cubeBezier(pointA, startTangent, pointB, endTangent, 0);

            for (int i = 0; i < segments; i++) {
                Vector2 v = cubeBezier(pointA, startTangent, pointB, endTangent, i/(float)segments);
                GL.Vertex3(lastV.x, lastV.y, 0);
                GL.Vertex3(v.x, v.y, 0);
                lastV = v;
            }
            GL.Vertex3(pointB.x, pointB.y, 0);

            GL.End();
            GL.PopMatrix();
        }

        /// <summary> 
        /// Draws an arrow head using GL functions.
        /// <param name="color">The color of the arrow.</param>
        /// <param name="v1">The first vertice.</param>
        /// <param name="v2">The second vertice.</param>
        /// <param name="v3">The third vertice.</param>
        /// </summary>
        public static void GLTriangle (Color color, Vector3 v1, Vector3 v2, Vector3 v3) {
            GL.PushMatrix();
            lineMaterial.SetPass(0);
            GL.Begin (GL.TRIANGLES);
            GL.Color (color);
            GL.Vertex (v1);
            GL.Vertex (v2);
            GL.Vertex (v3);
            GL.End ();
            GL.PopMatrix();
        }
        #endregion OpenGL

        
        #region Texture
        const float c_ArrowWidth = 14f;
        const float c_ArrowHeight = .4f;
        static Texture2D s_Texture;

        /// <summary> 
        /// The texture used to draw lines in the gui.
        /// </summary>
        static Texture2D texture {
            get {
                if (s_Texture == null) {
                    s_Texture = new Texture2D(1, 3, TextureFormat.ARGB32, true);
                    s_Texture.SetPixel(0, 0, new Color(1, 1, 1, 0));
                    s_Texture.SetPixel(0, 1, Color.white);
                    s_Texture.SetPixel(0, 2, new Color(1, 1, 1, 0));
                    s_Texture.Apply();
                    s_Texture.hideFlags = HideFlags.HideAndDontSave;
                }
                return s_Texture;
            }
        }

        /// <summary> 
        /// Draws a bezier arrow between two rects in the GUI. 
        /// This function is not 100% ok. The best option is Handles.DrawBezier.
        /// <param name="fromRect">The init rect of the line.</param>
        /// <param name="fromYOffset">The fromRect y offset.</param>
        /// <param name="toRect">The end rect of the line.</param>
        /// <param name="toYOffset">The toRect y offset.</param>
        /// <param name="color">The color of the line.</param>
        /// <param name="width">The line thickness.</param>
        /// <param name="shadow">Draw shadow?</param>
        /// </summary>
        public static void Bezier (Rect fromRect, float fromYOffset, Rect toRect, float toYOffset, Color color, float width, bool shadow = false) {
            // TODO: check if this is ok
            if (Event.current == null || Event.current.type != EventType.repaint)
                return;

            var pointA = new Vector3(0f, fromRect.y + fromYOffset, 0f);
            var pointB = new Vector3(0f, toRect.y + toYOffset, 0f);
            int signalA = 0, signalB = 0;
            var destOnRight = true;

            // Dest on right
            if (fromRect.x + fromRect.width < toRect.x) {
                pointA.x = fromRect.x + fromRect.width;
                pointB.x = toRect.x - c_ArrowWidth;
                signalA = 1;
                signalB = -1;
            }
            // Dest on left
            else if (fromRect.x < toRect.x) {
                destOnRight = false;
                pointA.x = fromRect.x + fromRect.width;
                pointB.x = toRect.x + toRect.width + c_ArrowWidth;
                signalA = 1;
                signalB = 1;
            }
            // Dest on right
            else if (fromRect.x < toRect.x + toRect.width) {
                pointA.x = fromRect.x;
                pointB.x = toRect.x - c_ArrowWidth;
                signalA = -1;
                signalB = -1;
            }
            // Dest on left
            else {
                destOnRight = false;
                pointA.x = fromRect.x;
                pointB.x = toRect.x + toRect.width + c_ArrowWidth;
                signalA = -1;
                signalB = 1;
            }

            Vector3 a_b = pointA - pointB;
            var tangentXIncrement = Mathf.Min(a_b.magnitude * 0.6F, 40.0F);
            if (fromRect == toRect) {
                tangentXIncrement = 50.0F;
            }

            Vector3 startTangent = pointA;
            startTangent.x +=  signalA * tangentXIncrement;

            Vector3 endTangent = pointB;
            endTangent.x += signalB * tangentXIncrement;

            // Draw shadow
            if (shadow) {
                var shadowPointA = pointA;
                var shadowPointB = pointB;
                var shadowStartTangent = startTangent;
                var shadowEndTangent = endTangent;
                var shadowColor = new Color(.0f,.0f,.0f, color.a * .5f);
                shadowPointA.y += 4f;
                shadowPointB.y += 4f;
                shadowStartTangent.y += 4f;
                shadowEndTangent.y += 4f;

                // Draw shadow bezier line
                Handles.DrawBezier(shadowPointA, shadowPointB, shadowStartTangent, shadowEndTangent, shadowColor, texture, width * 2f);

                // Draw shadow arrows
                if (destOnRight) {
                    GLTriangle( shadowColor * .85f,
                                new Vector3(shadowPointB.x + c_ArrowWidth, shadowPointB.y, shadowPointB.z),
                                new Vector3(shadowPointB.x, shadowPointB.y + c_ArrowWidth * c_ArrowHeight, shadowPointB.z),
                                new Vector3(shadowPointB.x, shadowPointB.y - c_ArrowWidth * c_ArrowHeight, shadowPointB.z)
                            );
                }
                else {
                    GLTriangle( shadowColor * .85f,
                                new Vector3(shadowPointB.x - c_ArrowWidth, shadowPointB.y, shadowPointB.z),
                                new Vector3(shadowPointB.x, shadowPointB.y + c_ArrowWidth * c_ArrowHeight, shadowPointB.z),
                                new Vector3(shadowPointB.x, shadowPointB.y - c_ArrowWidth * c_ArrowHeight, shadowPointB.z)
                            );
                }
            }

            // Draw bezier line
            Handles.DrawBezier(pointA, pointB, startTangent, endTangent, color, texture, width);

            // Draw arrows
            if (destOnRight) {
                GLTriangle( color * .85f,
                            new Vector3(pointB.x + c_ArrowWidth, pointB.y, pointB.z),
                            new Vector3(pointB.x, pointB.y + c_ArrowWidth * c_ArrowHeight, pointB.z),
                            new Vector3(pointB.x, pointB.y - c_ArrowWidth * c_ArrowHeight, pointB.z)
                            );
            }
            else {
                GLTriangle( color * .85f,
                            new Vector3(pointB.x - c_ArrowWidth, pointB.y, pointB.z),
                            new Vector3(pointB.x, pointB.y + c_ArrowWidth * c_ArrowHeight, pointB.z),
                            new Vector3(pointB.x, pointB.y - c_ArrowWidth * c_ArrowHeight, pointB.z)
                            );
            }
        }
        #endregion Texture
    }
}
