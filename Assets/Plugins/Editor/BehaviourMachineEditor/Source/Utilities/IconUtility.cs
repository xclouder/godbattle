//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

	/// <summary> 
    /// Class that stores and retrieves icons.
    /// </summary>
	public class IconUtility {

		static Dictionary<System.Type,Texture> s_Icons = new Dictionary<System.Type,Texture>();

		/// <summary> 
        /// Returns an icon fot the supplied type.
        /// <param name="type">The type to get the icon.</param>
        /// <param name="obj">Optional paramater to get icon using EditorGUIUtility.ObjectContent.</param>
        /// <returns>The icon for the supplied type.</returns>
        /// </summary>
        public static Texture GetIcon (System.Type type, UnityEngine.Object obj = null) {
            Texture texture;
            s_Icons.TryGetValue(type, out texture);

            if (texture == null) {
            	if (typeof(ActionNode).IsAssignableFrom(type)) {
	                var attribute = AttributeUtility.GetAttribute<NodeInfoAttribute>(type, true) ?? new NodeInfoAttribute();
	                texture = Resources.Load("Icons/" + attribute.icon) as Texture ?? EditorGUIUtility.FindTexture(attribute.icon + " Icon");
                    if (texture == null) 
                        texture = EditorGUIUtility.FindTexture(attribute.icon);
	            }
	            else if (typeof(UnityEngine.Object).IsAssignableFrom(type)) {
                    texture = EditorGUIUtility.ObjectContent(obj, type).image;
                    if (texture == null)
                        EditorGUIUtility.FindTexture(type.Name + " Icon");
                }
                else if (typeof(BehaviourMachine.Variable).IsAssignableFrom(type)) {
                    var customVarAttr = AttributeUtility.GetAttribute<CustomVariableAttribute>(type, false);
                    if (customVarAttr != null) {
                        texture = Resources.Load("Icons/" + customVarAttr.icon) as Texture ?? EditorGUIUtility.FindTexture(customVarAttr.icon + " Icon");
                        if (texture == null) 
                            texture = EditorGUIUtility.FindTexture(customVarAttr.icon);
                    }
                }
                else {
                    texture = EditorGUIUtility.FindTexture(type.Name + " Icon");
                }

                if (texture == null)
                    texture = EditorGUIUtility.FindTexture("DefaultAsset Icon");

                if (texture != null) {
                    if (!s_Icons.ContainsKey(type))
                        s_Icons.Add(type, texture);
                    else
                        s_Icons[type] = texture;
                }
            }

            return texture;
        }
	}
}

// editicon.sml
// _popup
// _help
// checkerfloor

// Toolbar Plus
// Toolbar Plus More
// Toolbar Minus

// unitylogo
// unitylogolarge
// MonoLogo
// AgeiaLogo
// uparrow
// Gear
// FilterByType
// FilterByLabel
// Occlusion
// PlayLoopOn
// PlayLoopOff
// PlaySpeed
// PreAudioPlayOn
// PreAudioPlayOff
// PreAudioLoopOn
// PreAudioLoopOff
// PreTextureAlpha
// PreTextureRGB
// PreTextureMipMapLow
// PreTextureMipMapHigh
// PreMatCylinder
// PreMatCube
// PreMatTorus
// PreMatLight0
// PreMatLight1
// PreMatSphere
// SettingsIcon
// Groove
// RedGroove
// BlueGroove
// curvekeyframeselected
// curvekeyframeselectedoverlay
// Favorite
// Winbtn_win_min_h
// Winbtn_win_max_h
// Winbtn_win_rest
// winbtn_graph_min_h
// winbtn_graph_max_h
// winbtn_graph
// Winbtn_mac_max
// Winbtn_mac_max_a
// Winbtn_mac_min
// Winbtn_mac_min_a
// RightBracket
// LeftBracket
// Curvekeyframesemiselectedoverlay
// in-addcomponentright
// in-addcomponentleft
// icon dropdown
// HorizontalSplit
// Loop

// lightmapping
// lightmeter/lightoff
// lightmeter/redlight
// lightmeter/greenlight
// lightmeter/orangelight
// lightmeter/lightrim

// StepLeftButton
// StepLeftButton-on
// BeginButton
// BeginButton-On
// EndButton
// EndButton-On
// PauseButton Anim
// PlayButton Anim
// StepButton Anim
// PauseButton
// PauseButton On
// PlayButton
// PlayButton On
// StepButton
// StepButton On

// animationvisibilitytoggleoff
// animationvisibilitytoggleon
// animationkeyframe

// VerticalSplit
// Refresh
// ViewToolOrbit
// ViewToolOrbit On
// ViewToolZoom
// ViewToolZoom On
// ViewToolMove
// ViewToolMove On
// ToolHandleLocal
// ToolHandleGlobalBlackboard
// ToolHandleCenter
// ToolHandlePivot
// RotateTool
// RotateTool On
// MoveTool
// MoveTool On
// ScaleTool
// ScaleTool On
// vcs_check
// vcs_edit
// vcs_change
// vcs_local
// vcs_lock
// vcs_refresh
// vcs_sync
// vcs_branch
// vcs_update
// vcs_add
// vcs_delete
// vcs_integrate
// vcs_unresolved
// svn_conflicted
// svn_outofsync
// svn_local
// svn_addlocal
// svn_conflicted
// svn_deletedlocal
// svn_lockedlocal
// vcs_document
// P4_Local
// P4_AddedLocal
// P4_AddedRemote
// P4_CheckoutLocal
// P4_CheckoutRemote
// P4_DeletedLocal
// P4_DeletedRemote
// P4_Conflicted
// P4_LockedLocal
// P4_LockedRemote
// P4_OutOfSync
// sticky_skin
// sticky_arrow
// sticky_p4

// sv_label_0
// sv_label_1
// sv_label_2
// sv_label_3
// sv_label_4
// sv_label_5
// sv_label_6
// sv_label_7

// sv_icon_none

// sv_icon_name0
// sv_icon_name1
// sv_icon_name2
// sv_icon_name3
// sv_icon_name4
// sv_icon_name5
// sv_icon_name6
// sv_icon_name7

// sv_icon_dot0_sml
// sv_icon_dot1_sml
// sv_icon_dot2_sml
// sv_icon_dot3_sml
// sv_icon_dot4_sml
// sv_icon_dot5_sml
// sv_icon_dot6_sml
// sv_icon_dot7_sml
// sv_icon_dot8_sml
// sv_icon_dot9_sml
// sv_icon_dot10_sml
// sv_icon_dot11_sml
// sv_icon_dot12_sml
// sv_icon_dot13_sml
// sv_icon_dot14_sml
// sv_icon_dot15_sml

// Clipboard

// SocialNetworks.FacebookShare
// SocialNetworks.LinkedinShare
// SocialNetworks.UdnOpen
// SocialNetworks.Tweet

// StateMachineEditor.ArrowTip
// StateMachineEditor.ArrowTipSelected
// StateMachineEditor.Background
// StateMachineEditor.State
// StateMachineEditor.StateSub
// StateMachineEditor.StateSubHover
// StateMachineEditor.StateSubSelected
// StateMachineEditor.UpButton
// StateMachineEditor.UpButtonHover

// tree_icon
// tree_icon_frond
// tree_icon_branch
// tree_icon_branch_frond
// TreeEditor.Trash
// TreeEditor.Material
// TreeEditor.Duplicate
// TreeEditor.Distribution
// TreeEditor.Distribution On
// TreeEditor.Branch
// TreeEditor.Branch On
// TreeEditor.BranchTranslate
// TreeEditor.BranchTranslate On
// TreeEditor.BranchRotate
// TreeEditor.BranchRotate On
// TreeEditor.AddBranches
// TreeEditor.Leaf
// TreeEditor.Leaf On
// TreeEditor.LeafTranslate
// TreeEditor.LeafTranslate On
// TreeEditor.LeafScale
// TreeEditor.LeafScale On
// TreeEditor.Geometry
// TreeEditor.Geometry On
// TreeEditor.BranchFreeHand
// TreeEditor.BranchFreeHand On
// TreeEditor.Wind
// TreeEditor.Wind On

// console.warnicon
// console.warnicon.sml
// console.erroricon
// console.erroricon.sml
// console.infoicon
// console.infoicon.sml

// SceneViewAlpha
// SceneViewRGB
// PreTextureRGB
// SceneViewOrtho
// SceneViewAudio
// SceneViewLighting
// SceneViewFx

// Animation.AddKeyframe
// Animation.Record
// Animation.Play

// Profiler.Network
// Profiler.CPU
// Profiler.Rendering
// Profiler.Memory
// Profiler.Audio
// Profiler.Record
// Profiler.FirstFrame
// Profiler.LastFrame
// Profiler.NextFrame
// Profiler.PrevFrame
// PlayButtonProfile
// PlayButtonProfile On

// WelcomeScreen.MainHeader
// WelcomeScreen.UnityForumLogo
// WelcomeScreen.UnityBasicsLogo
// WelcomeScreen.UnityAnswersLogo
// WelcomeScreen.AssetStoreLogo

// ClothInspector.PaintTool
// ClothInspector.ViewValue
// ClothInspector.PaintValue

// TerrainInspector.TerrainToolPlants
// TerrainInspector.TerrainToolPlants On
// TerrainInspector.TerrainToolPlantsAlt 
// TerrainInspector.TerrainToolPlantsAlt On 
// TerrainInspector.TerrainToolSettings
// TerrainInspector.TerrainToolSettings On
// TerrainInspector.TerrainToolSetheight
// TerrainInspector.TerrainToolSetheightAlt
// TerrainInspector.TerrainToolLower
// TerrainInspector.TerrainToolLowerAlt
// TerrainInspector.TerrainToolTrees
// TerrainInspector.TerrainToolTreesAlt
// TerrainInspector.TerrainToolSplat
// TerrainInspector.TerrainToolSplat On
// TerrainInspector.TerrainToolPlants
// TerrainInspector.TerrainToolPlants On

// Aboutwindow.mainheader

// BuildSettings.SelectedIcon
// BuildSettings.StandaloneGLES20Emu.Small
// BuildSettings.Android
// BuildSettings.Android.Small
// BuildSettings.iPhone
// BuildSettings.iPhone.Small
// BuildSettings.BlackBerry
// BuildSettings.BlackBerry.Small
// BuildSettings.WP8
// BuildSettings.WP8.Small
// BuildSettings.StandAlone
// BuildSettings.StandAlone.Small
// BuildSettings.Web
// BuildSettings.Web.Small
// BuildSettings.NaCl
// BuildSettings.NaCl.Small
// BuildSettings.Xbox360
// BuildSettings.Xbox360.Small
// BuildSettings.PS3
// BuildSettings.PS3.Small
// BuildSettings.Wii
// BuildSettings.Wii.Small
// BuildSettings.FlashPlayer
// BuildSettings.FlashPlayer.Small
// BuildSettings.Metro
// BuildSettings.Metro.Small

// Project
// UnityEditor.AsMainWindow
// UnityEditor.ServerView
// UnityEditor.ProfilerWindow
// UnityEditor.SceneView
// UnityEditor.GameView
// UnityEditor.DebugInspectorWindow
// UnityEditor.InspectorWindow
// InspectorLock
// UnityEditor.ConsoleWindow
// UnityEditor.HierarchyWindow
// UnityEditor.AnimationWindow
// UnityEditor.Graphs.AnimatorControllerTool
// cs Script Icon
// js Script Icon
// boo Script Icon
// CGProgram Icon
// ComputeShader Icon
// EditorSettings Icon
// LODGroup Icon
// ScriptableObject Icon
// OcclusionArea Icon
// Search Icon
// Transition Icon
// BlendTree Icon
// State Icon
// PrefabNormal Icon
// Prefab Icom
// GUILayer Icon

// SpeedScale
// Navigation

// WaitSpin00
// WaitSpin01
// WaitSpin02
// WaitSpin03
// WaitSpin04
// WaitSpin05
// WaitSpin06
// WaitSpin07
// WaitSpin08
// WaitSpin09
// WaitSpin10
// WaitSpin11

// Main Light Gizmo
// Light Gizmo
// Projector Gizmo
// SpotLight Gizmo
// DirectionalLight Gizmo
// PointLight Gizmo
// LensFlare Gizmo
// Camera Gizmo

// Animation Icon
// AnimationClip Icon
// Animator Icon
// AnyStateNode Icon
// AreaLight Icon
// AssetStore Icon
// Asset Store
// AudioClip Icon
// AudioDistortionFilter Icon
// AudioEchoFilter Icon
// AudioHighPassFilter Icon
// AudioListner Icon
// AudioLowPassFilter Icon
// AudioReverbFilter Icon
// AudioReverbZone Icon
// Avatar Icon
// AvatarMask Icon
// BlendTree Icon
// BoxCollider Icon
// Camera Icon
// CapsuleCollider Icon
// CharacterController Icon
// CharacterJoint Icon
// ChorusFilter Icon
// ClothRenderer Icon
// ConfigurableJoint Icon
// ConstantForce Icon
// Cubemap Icon
// DefaultAsset Icon
// DefaultsLate Icon
// EchoFilter Icon
// EditorSettings Icon
// Favorite Icon
// FixedJoint Icon
// FlareLayer Icon
// Folder Icon
// FolderEmpty Icon
// FolderFavorite Icon
// Font Icon
// GameManager Icon
// GameObject Icon
// GUILayer Icon
// GUISkin Icon
// GUIText Icon
// GUITexture Icon
// Halo Icon
// HighPassFilter Icon
// HingeJoint Icon
// HumanTemplate Icon
// InteractiveCloth Icon
// LensFlare Icon
// Light Icon
// LightProbeGroup Icon
// LightProbes Icon
// LineRenderer Icon
// LodGroup Icon
// LowPassFilter Icon
// Material Icon
// Mesh Icon
// MeshCollider Icon
// MeshFilter Icon
// MeshParticleEmitter Icon
// MeshRenderer Icon
// Metafile Icon
// Microphone Icon
// Motion Icon
// MovieTexture Icon
// MuscleClip Icon
// NavmeshAgent Icon
// NavmeshObstacle Icon
// NetWorkView Icon
// OcclusionArea Icon
// OcclusionPortal Icon
// OffMeshLink Icon
// ParticleAnimator Icon
// ParticleEmitter Icon
// ParticleRenderer Icon
// ParticleSystem Icon
// PhysicMaterial Icon
// Prefab Icon
// PrefabModel Icon
// PrefabNormal Icon
// ProceduralMaterial Icon
// Projector Icon
// RayCastCollider Icon
// RenderTexture Icon
// ReverbFilter Icon
// Rigidbody Icon
// SceneAsset Icon
// ScriptableObject Icon
// SkinnedCloth Icon
// Search Icon
// Shader Icon
// SkinnedMeshRenderer Icon
// Skybox Icon
// Sphere Collider Icon
// SpotLight Icon
// SpringJoint Icon
// State Icon
// StateMachine Icon
// SubstanceArchive Icon
// Terrain Icon
// TerrainCollider Icon
// TerrainData Icon
// TextAsset Icon
// TextMesh Icon
// Texture Icon
// Texture2D Icon
// TrailRenderer Icon
// Transform Icon
// Transition Icon
// WheelCollider Icon
// WindZone Icon
// WorldParticleCollider Icon
