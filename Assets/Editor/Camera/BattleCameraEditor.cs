using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BattleCamera))]
public class BattleCameraEditor : Editor {
	private float speed = 3f;

	BattleCamera battleCamera;
	GameObject go;

	void OnEnable() {
		battleCamera = (BattleCamera) target;
		go = battleCamera.gameObject;
	}

	public override void OnInspectorGUI () { 
		base.OnInspectorGUI();

		var deltaTime = 0.02f;

		GUILayout.BeginHorizontal();
		GUILayout.Label("Camera Control:");
		GUILayout.EndHorizontal();

		//add button to move the camera as in the game.
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("U", GUILayout.Width(60)))
		{
			go.transform.position += new Vector3(0f, 0f, speed * deltaTime);
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("L", GUILayout.Width(60)))
		{
			go.transform.position -= new Vector3(speed * deltaTime, 0f, 0f);
		}
		if (GUILayout.Button("R", GUILayout.Width(60)))
		{

			go.transform.position += new Vector3(speed * deltaTime, 0f, 0f);
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		if (GUILayout.Button("D", GUILayout.Width(60)))
		{
			go.transform.position -= new Vector3(0f, 0f, speed * deltaTime);
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		Event.current.GetTypeForControl(0);
		GUIUtility.GetControlID(FocusType.Keyboard);

		//Mark positions
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Mark Near LB Point"))
		{
			battleCamera.nearViewLeftBottomPos = go.transform.position;
		}
		if (GUILayout.Button("Mark Near TR Point"))
		{
			battleCamera.nearViewRightTopPos = go.transform.position;
		}
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Mark Far LB Point"))
		{
			battleCamera.farViewLeftBottomPos = go.transform.position;
		}
		if (GUILayout.Button("Mark Far TR Point"))
		{
			battleCamera.farViewRightTopPos = go.transform.position;
		}
		GUILayout.EndHorizontal();

	}
}
