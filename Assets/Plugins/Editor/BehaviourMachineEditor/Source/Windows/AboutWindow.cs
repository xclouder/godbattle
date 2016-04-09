//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;

namespace BehaviourMachineEditor {
    /// <summary> 
    /// Window that shows the plugin's about information.
    /// </summary>
    [System.Serializable]
    public class AboutWindow : EditorWindow {

    	#region Styles
        static AboutWindow.Styles s_Styles;

        /// <summary> 
        /// Hold GUIStyles and Colors used by AddNodeWindow.
        /// </summary>
        class Styles {
            public readonly GUIStyle bigTitle = "TL Selection H1";
            public readonly GUIStyle licenseLabel = "AboutWIndowLicenseLabel";
            public readonly Texture unitylogo = EditorGUIUtility.FindTexture("unitylogo");
    	}
        #endregion Styles

        
        #region Constants
        const double c_frequenceToRepaint = 0.15;
        const float c_DevelopersHeigth = 32f;
        const float c_DevelopersWindowHeigth = 80f;
        #endregion Constants

        
        #region Members
    	[SerializeField]
    	float m_DevelopersPosition = c_DevelopersWindowHeigth + 8f;
    	[SerializeField]
    	Rect m_LastRect;
        [SerializeField]
        Texture m_Icon;
    	[System.NonSerialized]
    	double m_Timer = 0f;
    	#endregion Members

    	
        #region Private Methods
    	/// <summary> 
        /// Draws the developers name.
        /// </summary>
    	void GUIDevelopers () {
    		if(Event.current.type == EventType.Repaint) 
    			m_LastRect = GUILayoutUtility.GetLastRect();
    		GUILayout.BeginArea(new Rect(0, m_LastRect.y + m_LastRect.height, position.width, c_DevelopersWindowHeigth + 200f));
    		GUI.BeginGroup(new Rect(0, 0, position.width, c_DevelopersWindowHeigth)); {
    			GUI.Label(new Rect(4,m_DevelopersPosition, position.width - 4, c_DevelopersHeigth),"Anderson Campos Cardoso");
    		} GUI.EndGroup();
    		GUILayout.EndArea();
    	}
    	#endregion Private Methods

    	
        #region Unity
    	/// <summary> 
        /// A Unity callback called when the window is loaded.
        /// </summary>
    	void OnEnable () {
    		// Not resizable.
    		minSize = new Vector2(440, 280);
    		maxSize = new Vector2(440, 280);

    		// Set timer
    		m_Timer = EditorApplication.timeSinceStartup +  c_frequenceToRepaint;

            // Get icon
            m_Icon = EditorGUIUtility.isProSkin ? Resources.Load("Icons/{b}LogoDark") as Texture : Resources.Load("Icons/{b}LogoLight") as Texture;
    	}

    	/// <summary> 
        /// Called 100 times per second.
        /// Updates the developers name position.
        /// </summary>
    	void Update () {
    		if (EditorApplication.timeSinceStartup >= m_Timer) {
    			m_Timer = EditorApplication.timeSinceStartup + c_frequenceToRepaint;
    			m_DevelopersPosition -= 1;
    			
    			// Restart
    			if (m_DevelopersPosition <= -c_DevelopersHeigth)
    				m_DevelopersPosition = c_DevelopersWindowHeigth + 8;
    				
    			Repaint ();
    		}
    	}
    	
    	/// <summary> 
    	/// Unity callback used to draw controls in the window.
        /// Draws the plugin icon, developers names and logos.
        /// </summary> 
    	void OnGUI () {
    		// Create style
    		if (s_Styles == null)
                s_Styles = new AboutWindow.Styles();
    		
    		// Icon, name and version
    		GUILayout.BeginHorizontal(); {

    			GUILayout.Label(new GUIContent(m_Icon), GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
    			
    			// GUILayout.Label(m_logo, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
    			
    			GUILayout.BeginVertical(); {
    				GUILayout.Space(-12);
    				GUILayout.Label("Behaviour Machine", s_Styles.bigTitle, GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
    				GUILayout.Label("Version: 1.4.1", GUILayout.ExpandWidth(false));
    			} GUILayout.EndVertical();
    			
    		} GUILayout.EndHorizontal();


    		// Draw developers
    		GUILayout.Space (20f);
    		GUIDevelopers ();
    		GUILayout.Space (20f);
    		
    		// Unity Logo
    		GUILayout.Space(s_Styles.unitylogo.height);
    		GUILayout.BeginHorizontal(); {
    			GUILayout.Label(new GUIContent(s_Styles.unitylogo), GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false));
    			GUILayout.Label(new GUIContent("Engine powered by Unity\n\n(c) 2012 Unity Technologies"), s_Styles.licenseLabel);
    		} GUILayout.EndHorizontal();

    		// Footnote, license and rights
    		GUILayout.FlexibleSpace();
    		GUILayout.BeginHorizontal(); {
    			GUILayout.Label(new GUIContent("cardoso.anderson.campos@gmail.com. All rights reserved."), s_Styles.licenseLabel);
    			GUILayout.FlexibleSpace();
    			GUILayout.Label(new GUIContent("License Type: One per seat"), s_Styles.licenseLabel);
    		} GUILayout.EndHorizontal();
    		GUILayout.Space(10);
    	}
    	#endregion Unity
    }
}