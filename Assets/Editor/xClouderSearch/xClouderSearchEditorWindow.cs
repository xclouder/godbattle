using UnityEngine;
using UnityEditor;
using System.Collections;

public class XClouderSearchEditorWindow : EditorWindow {

	private string searchTxt = string.Empty;
	private bool isFirstShow = true;

	private int selectedIndex = 0;
	private Vector2 scrollPos = Vector2.zero;

	[MenuItem ("Window/xClouder Search Window %.")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		XClouderSearchEditorWindow window = (XClouderSearchEditorWindow)EditorWindow.GetWindow (typeof (XClouderSearchEditorWindow));
		window.Show();

	}

	void OnGUI () {

		if (EditorWindow.focusedWindow == this)
		{
			Event e = Event.current;
			switch (e.type)
			{
			case EventType.KeyUp:
				{
					if (Event.current.keyCode == (KeyCode.Escape))
					{
						this.Close();
					}
					break;
				}
			}

		}

		//search text
		GUI.SetNextControlName("SearchTextField");
		searchTxt = GUILayout.TextField(searchTxt, new GUILayoutOption[] { GUILayout.ExpandWidth(true) });

		if (isFirstShow)
		{
			GUI.FocusControl("SearchTextField");
			isFirstShow = false;
		}

		if (string.IsNullOrEmpty(searchTxt))
		{
			return;
		}

		var resultList = AssetDatabase.FindAssets(searchTxt);

		scrollPos = GUILayout.BeginScrollView(scrollPos, GUIStyle.none,  new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });

		Debug.Log("result list count:" + resultList.Length);
		if (resultList.Length > 0)
		{
			selectedIndex = GUILayout.SelectionGrid(selectedIndex, resultList, 1, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });
		}

		GUILayout.EndScrollView();


	}

}
