using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class XClouderSearchEditorWindow : EditorWindow {

	private const float ITEM_LINE_HEIGHT = 50f;
	private const float ITEM_SEARCHBOX_HEIGHT = 22f;

	private string searchTxt = string.Empty;
	private bool isFirstShow = true;

	private int selectedIndex = -1;
	private Vector2 scrollPos = Vector2.zero;

	private GUIStyle mCellStyle = null;
	private GUIStyle mCellStyle_odd = null;

	[MenuItem ("Window/xClouder Search Window %.")]
	static void CreateWindow () {
		// Get existing open window or if none, make a new one:
		XClouderSearchEditorWindow window = (XClouderSearchEditorWindow)EditorWindow.GetWindow (typeof (XClouderSearchEditorWindow));

		//window size
		var w = 500f;
		var h = 100f;
		var maxH = 500f;

		window.maxSize = new Vector2(w, maxH);
		window.minSize = new Vector2(w, h);

		window.Init();

		window.Show();

	}

	public void Init()
	{
		SetHeight(0f);
		previousText = string.Empty;
		this.CenterOnMainWin(new Vector2(0f, -250f));

		CreateCellStyleIfNeeds();
	}

	private void SetHeight(float height)
	{
		var pos = this.position;
		pos.height = height;

		pos.x = _origin.x;
		pos.y = _origin.y;

		this.position = pos;
	}

	private void CreateCellStyleIfNeeds()
	{
		if (mCellStyle != null)
			return;

		mCellStyle = new GUIStyle();//style for cells
		mCellStyle.normal.background = Resources.Load<Texture2D>("Textures/table_bg_even");
		mCellStyle.onNormal.background = Resources.Load<Texture2D>("Textures/table_bg_odd");
//		mCellStyle.focused.background = Resources.Load<Texture2D>("Textures/table_bg_highlight");
//		mCellStyle.fontSize = GUIUtils.GetKegel() - GUIUtils.GetKegel() / 5;
		mCellStyle.border = new RectOffset(7, 7, 7, 7);
		mCellStyle.padding = new RectOffset(5, 5, 5, 5);
		mCellStyle.alignment = TextAnchor.MiddleCenter;
		mCellStyle.wordWrap = true;

		mCellStyle_odd = new GUIStyle(mCellStyle);//style for cells
		mCellStyle_odd.normal.background = Resources.Load<Texture2D>("Textures/table_bg_odd");
		mCellStyle_odd.onNormal.background = Resources.Load<Texture2D>("Textures/table_bg_even");
	}

	private string previousText = string.Empty;
	private string[] resultListCache = null;
	void OnGUI () {

		//search text
		GUI.SetNextControlName("SearchTextField");
		searchTxt = GUILayout.TextField(searchTxt, new GUILayoutOption[] { GUILayout.ExpandWidth(true) });

		GUI.SetNextControlName("HiddenField");
		GUI.TextField(new Rect(-100f, -100f, 1f,1f), "");


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
					else if (Event.current.keyCode == (KeyCode.UpArrow) || Event.current.keyCode == (KeyCode.DownArrow))
					{
						
					}
					else
					{
						EditorGUI.FocusTextInControl("SearchTextField");
					}
					break;
				}
			}

		}


		if (isFirstShow)
		{
			GUI.FocusControl("SearchTextField");
			isFirstShow = false;
		}

		if (string.IsNullOrEmpty(searchTxt))
		{
			previousText = searchTxt;
			resultListCache = null;
			SetHeight(ITEM_SEARCHBOX_HEIGHT);
			return;
		}

		string[] resultList = null;
		if (previousText != searchTxt)
		{
			previousText = searchTxt;

			selectedIndex = -1;

			resultList = AssetDatabase.FindAssets(searchTxt);
			resultListCache = resultList;
		}
		else
		{
			resultList = resultListCache;
		}
		ShowSearchRestult(resultList);

	}

	private void ShowSearchRestult(string[] resultList)
	{

		scrollPos = GUILayout.BeginScrollView(scrollPos, GUIStyle.none,  new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });

		if (resultList.Length > 0)
		{
			AdjustWindowSize(resultList.Length);

			GUI.SetNextControlName("SelectionGrid");
			selectedIndex = GUILayout.SelectionGrid(selectedIndex, CreateResultListContent(resultList), 1, mCellStyle_odd, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });
			Event e = Event.current;

			switch (e.type)
			{
			case EventType.KeyUp:
				{
					switch(Event.current.keyCode)
					{
					case KeyCode.UpArrow:
						{
							if (selectedIndex > 0)
							{
								selectedIndex--;
							}

							break;
						}
					case KeyCode.DownArrow:
						{
							if (selectedIndex < (resultList.Length - 1))
							{
								selectedIndex++;
							}

							break;
						}
					
					case KeyCode.Return:
						{
							if (selectedIndex >= 0 && selectedIndex < resultList.Length)
							{
								var guid = resultList[selectedIndex];
								LocateAsset(guid);
							}
							break;
						}
					}
					break;
				}
			}

			if (Event.current.command && Event.current.keyCode == KeyCode.Return)
			{
				Debug.LogWarning("Cmd+Return");
				if (selectedIndex >= 0 && selectedIndex < resultList.Length)
				{
					var guid = resultList[selectedIndex];
					LocateAsset(guid);

					OpenAsset(guid);
				}
			}
		}
		else
		{
			SetHeight(ITEM_SEARCHBOX_HEIGHT);
		}
		GUILayout.EndScrollView();

		this.Repaint();
	}

	private Vector2 _origin;
	private void AdjustWindowSize(int resultLen)
	{
		var pos = this.position;
		pos.height = Mathf.Min(500f, resultLen * ITEM_LINE_HEIGHT);
		pos.x = _origin.x;
		pos.y = _origin.y;
		this.position = pos;
	}

	private void LocateAsset(string guid)
	{
		var path = AssetDatabase.GUIDToAssetPath(guid);
		Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));

		Selection.activeObject = obj;

	}

	private void OpenAsset(string guid)
	{
		var path = AssetDatabase.GUIDToAssetPath(guid);
		if (path.EndsWith(".unity"))
		{
			EditorApplication.OpenScene(path);
		}

		if (path.EndsWith(".cs"))
		{
			UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(path, 1);
		}
	}

	private GUIContent[] CreateResultListContent(string[] resultListGUIDs)
	{
		var listContent = new GUIContent[resultListGUIDs.Length];

		int i = 0;
		foreach (var guid in resultListGUIDs)
		{
			listContent[i] = CreateCell(guid);
			i++;
		}

		return listContent;
	}

	private GUIContent CreateCell(string resGUID)
	{
		var path = AssetDatabase.GUIDToAssetPath(resGUID);

		return new GUIContent(path);
	}

	private Rect GetEditorMainWindowPos()
	{
		var containerWinType = System.AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(ScriptableObject)).Where(t => t.Name == "ContainerWindow").FirstOrDefault();
		if (containerWinType == null)
			throw new System.MissingMemberException("Can't find internal type ContainerWindow. Maybe something has changed inside Unity");
		var showModeField = containerWinType.GetField("m_ShowMode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
		var positionProperty = containerWinType.GetProperty("position", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
		if (showModeField == null || positionProperty == null)
			throw new System.MissingFieldException("Can't find internal fields 'm_ShowMode' or 'position'. Maybe something has changed inside Unity");
		var windows = Resources.FindObjectsOfTypeAll(containerWinType);
		foreach (var win in windows)
		{
			var showmode = (int)showModeField.GetValue(win);
			if (showmode == 4) // main window
			{
				var pos = (Rect)positionProperty.GetValue(win, null);
				return pos;
			}
		}
		throw new System.NotSupportedException("Can't find internal main window. Maybe something has changed inside Unity");
	}

	public void CenterOnMainWin(Vector2 offset)
	{
		var main = GetEditorMainWindowPos();
		var pos = this.position;
		float w = (main.width - pos.width)*0.5f;
		float h = (main.height - pos.height)*0.5f;
		pos.x = main.x + w + offset.x;
		pos.y = main.y + h + offset.y;

		this.position = pos;

		_origin = new Vector2(pos.x, pos.y);
	}

}

public static class ReflectionHelpers
{
	public static System.Type[] GetAllDerivedTypes(this System.AppDomain aAppDomain, System.Type aType)
	{
		var result = new List<System.Type>();
		var assemblies = aAppDomain.GetAssemblies();
		foreach (var assembly in assemblies)
		{
			var types = assembly.GetTypes();
			foreach (var type in types)
			{
				if (type.IsSubclassOf(aType))
					result.Add(type);
			}
		}
		return result.ToArray();
	}
}