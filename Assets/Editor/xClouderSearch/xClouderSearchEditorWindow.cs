using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class XClouderSearchEditorWindow : EditorWindow {

	private const float ITEM_LINE_HEIGHT = 40f;
	private const float ITEM_SEARCHBOX_HEIGHT = 22f;

	private const float WIN_WIDTH = 500F;
	private const float WIN_HEIGHT = 100F;
	private const float WIN_MAX_HEIGHT = 500F;

	private string searchTxt = string.Empty;
	private bool isFirstShow = true;

	private int selectedIndex = -1;
	private Vector2 scrollPos = Vector2.zero;

	[MenuItem ("Window/xClouder Search Window %.")]
	static void CreateWindow () {
		// Get existing open window or if none, make a new one:
		XClouderSearchEditorWindow window = (XClouderSearchEditorWindow)EditorWindow.GetWindow (typeof (XClouderSearchEditorWindow));

		//window size
		var w = WIN_WIDTH;
		var h = WIN_HEIGHT;
		var maxH = WIN_WIDTH;

		window.maxSize = new Vector2(w, maxH);
		window.minSize = new Vector2(w, h);

		window.Init();

		window.Show();

	}

	private SearchHistoryMgr historyMgr = new SearchHistoryMgr();
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

	private GUIStyle selectedCellStyle = null;
	private GUIStyle evenCellStyle = null;
	private GUIStyle oddCellStyle = null;
	private GUIStyle desLabelStyle = null;
	private GUIStyle titleLabelStyle = null;

	private void CreateCellStyleIfNeeds()
	{
		if (selectedCellStyle != null)
		{
			return;
		}

		selectedCellStyle = new GUIStyle();
		selectedCellStyle.normal.background = Resources.Load<Texture2D>("Textures/table_bg_highlight");
		selectedCellStyle.padding = new RectOffset(5, 5, 5, 5);
		selectedCellStyle.fixedHeight = ITEM_LINE_HEIGHT;
		selectedCellStyle.fixedWidth = WIN_WIDTH - 14f;

		evenCellStyle = new GUIStyle();
		evenCellStyle.normal.background = Resources.Load<Texture2D>("Textures/table_bg_even");
		evenCellStyle.padding = selectedCellStyle.padding;
		evenCellStyle.fixedHeight = ITEM_LINE_HEIGHT;
		evenCellStyle.fixedWidth = WIN_WIDTH - 14f;

		oddCellStyle = new GUIStyle();
		oddCellStyle.normal.background = Resources.Load<Texture2D>("Textures/table_bg_odd");
		oddCellStyle.padding = selectedCellStyle.padding;
		oddCellStyle.fixedHeight = ITEM_LINE_HEIGHT;
		oddCellStyle.fixedWidth = WIN_WIDTH - 14f;

		titleLabelStyle = new GUIStyle();
		titleLabelStyle.normal.textColor = Color.black;
		titleLabelStyle.fontSize = 13;
//		titleLabelStyle.fixedWidth = 240f;

		desLabelStyle = new GUIStyle();
		desLabelStyle.normal.textColor = Color.gray;
//		desLabelStyle.alignment = TextAnchor.LowerRight;
//		desLabelStyle.fixedWidth = 240f;

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

		string[] resultList = null;
		if (string.IsNullOrEmpty(searchTxt))
		{
			if (!string.IsNullOrEmpty(previousText))
			{
				selectedIndex = -1;
			}

			previousText = searchTxt;
			resultListCache = null;

			//show history
			resultList = historyMgr.GetHistory();

			ShowSearchRestult(resultList);
			return;
		}

		if (previousText != searchTxt)
		{
			previousText = searchTxt;

			selectedIndex = -1;

			resultList = GetResult(searchTxt);
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
		scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, new GUILayoutOption[] { GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(true) });

//		Debug.Log( "result:"+ resultList);
		if (resultList.Length > 0)
		{
			AdjustWindowSize(resultList.Length);

			GUI.SetNextControlName("SelectionGrid");

			int i = 0;
			bool isSelected = false;
			foreach (var p in resultList)
			{
				var guid = AssetDatabase.AssetPathToGUID(p);
				isSelected = (i == selectedIndex);
				CreateCell(guid, isSelected, i);

				i++;
			}
				
//			selectedIndex = GUILayout.SelectionGrid(selectedIndex, CreateResultListContent(resultList), 1, mCellStyle_odd, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });

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
								var path = resultList[selectedIndex];
								LocateAsset(path);
							}
							break;
						}
					}
					break;
				}
			}

			if (Event.current.command && Event.current.keyCode == KeyCode.Return)
			{
				if (selectedIndex >= 0 && selectedIndex < resultList.Length)
				{
					var path = resultList[selectedIndex];

					OpenAsset(path);
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
		pos.height = Mathf.Min(WIN_MAX_HEIGHT, resultLen * ITEM_LINE_HEIGHT + ITEM_SEARCHBOX_HEIGHT);

		Debug.Log("set height:" + pos.height);

		pos.x = _origin.x;
		pos.y = _origin.y;
		this.position = pos;
	}

	private void SaveToHistory(string path)
	{
		historyMgr.AddToOrUpdateHistory(path);
	}

	private void LocateAsset(string path)
	{
		SaveToHistory(path);

		Object obj = AssetDatabase.LoadAssetAtPath(path, typeof(Object));
		Selection.activeObject = obj;
	}

	private void OpenAsset(string path)
	{
		SaveToHistory(path);

		if (path.EndsWith(".unity"))
		{
			EditorApplication.OpenScene(path);
		}

		if (path.EndsWith(".cs"))
		{
			UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(path, 1);
		}
	}

	private BaseSearcher searcher;
	private string[] GetResult(string searchKey)
	{
		searcher = searcher ?? new SimpleSearcher();
		return searcher.Search(searchKey);
	}

	private void CreateCell(string resGUID, bool isSelected, int index)
	{
		var path = AssetDatabase.GUIDToAssetPath(resGUID);

		GUIStyle style = null;
		if (isSelected)
		{
			style = selectedCellStyle;
		}
		else
		{
			bool isEven = (index % 2 == 0);
			style = isEven ? evenCellStyle : oddCellStyle;
		}

		GUILayout.BeginHorizontal(style);

		//icon
		//...

		GUILayout.BeginVertical();
		//title
		string fileName = new System.IO.FileInfo(path).Name;
		GUILayout.Label(fileName, titleLabelStyle);

		GUILayout.FlexibleSpace();

		//path
		GUILayout.Label(path, desLabelStyle, GUILayout.Width(240f));
		GUILayout.EndVertical();

		GUILayout.EndHorizontal();

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