using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class SdkManagerEditorWindow : EditorWindow {

	[MenuItem ("Window/SdkManager")]
	static void CreateWindow () {
		// Get existing open window or if none, make a new one:
		SdkManagerEditorWindow window = EditorWindow.GetWindow<SdkManagerEditorWindow> ("SDK Manager", true);
		window.Init();

		window.Show();
	}

	private void Init()
	{
		scrollStyle.margin = new RectOffset(10, 10, 10, 10);
		cellStyle.fixedHeight = 50f;

		ReloadSdkList();
	}

	private IList<SDKInfo> _sdkList;
	private void ReloadSdkList()
	{
		_sdkList = SdkManager.Instance.GetInstalledSDKs();
	}

//	private string searchTxt = string.Empty;
	private Vector2 scrollPos = Vector2.zero;
//	private int selectedIndex = 0;
	private GUIStyle scrollStyle = new GUIStyle();
	private GUIStyle cellStyle = new GUIStyle();
	void OnGUI()
	{
		bool didListHaveChanged = false;

		GUILayout.BeginVertical();

		GUILayout.Label("Installed SDKs");

		//if we manage many sdks, give a searchBox maybe a better experience
//		GUI.SetNextControlName("SearchTextField");
//		GUILayout.Label("Search:");
//		searchTxt = GUILayout.TextField(searchTxt, new GUILayoutOption[] { GUILayout.ExpandWidth(true) });

		//--start draw scroll
		scrollPos = GUILayout.BeginScrollView(scrollPos, scrollStyle, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });
//		 = GUILayout.SelectionGrid(selectedIndex, CreateSDKListContent(searchTxt), 1, cellStyle, new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true) });

		if (_sdkList != null && _sdkList.Count > 0)
		{
			foreach (var sdk in _sdkList)
			{
				GUILayout.BeginHorizontal();
				RenderSDKCell(sdk, out didListHaveChanged);
				GUILayout.EndHorizontal();
			}
		}
		GUILayout.EndScrollView();

		GUILayout.BeginHorizontal();

		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Install", new GUILayoutOption[] { GUILayout.Width(80)}))
		{
			//open sdk folder
			string path = EditorUtility.OpenFolderPanel("Install SDK From", null, null);
			if (!string.IsNullOrEmpty(path) && System.IO.Directory.Exists(path))
			{
				Debug.Log("choosed sdk path:" + path);
				SDKInfo installedSDK = null;
				try{
					installedSDK = SdkManager.Instance.InstallSDK(path);
					ReloadSdkList();
				}
				catch (System.IO.IOException ioe)
				{
					try
					{
						if (installedSDK != null)
							SdkManager.Instance.UninstallSDK(installedSDK);
					}catch(System.Exception ioe2)
					{
						EditorUtility.DisplayDialog("Remove Failed", ioe2.ToString(), "ok");
					}
				}
				catch (System.Exception e)
				{
					EditorUtility.DisplayDialog("Install Failed", e.ToString(), "ok");
				}

			}
		}

		GUILayout.Space(10f);

		GUILayout.EndHorizontal();

		GUILayout.Space(10f);
		GUILayout.EndVertical();

		if (didListHaveChanged)
		{
			ReloadSdkList();
		}
	}

	private GUIContent _succeededBtn;
	private void RenderSDKCell(SDKInfo sdk, out bool didListHaveChanged)
	{
		didListHaveChanged = false;

		bool wantEnable = GUILayout.Toggle(sdk.Enabled, sdk.Name);
		if (wantEnable != sdk.Enabled)
		{
			//todo
			if (wantEnable)
			{
				try {
					SdkManager.Instance.EnableSDK(sdk);
					sdk.Enabled = wantEnable;

					didListHaveChanged = true;
				}catch(System.Exception e)
				{
					EditorUtility.DisplayDialog("Enable SDK failed", e.ToString(), "ok");
				}
			}
			else
			{
				try {
					SdkManager.Instance.DisableSDK(sdk);
					sdk.Enabled = wantEnable;
				}
				catch(System.Exception e)
				{
					EditorUtility.DisplayDialog("Disable SDK failed", e.ToString(), "ok");
				}
			}


			sdk.Enabled = wantEnable;
		}

		GUILayout.FlexibleSpace();
		if (GUILayout.Button("Uninstall"))
		{
			int confirmState = EditorUtility.DisplayDialogComplex("Confirm", "Are you sure to delete this sdk?", "sure", "cancel", null);
			if (confirmState == 0)
			{
				try {
					SdkManager.Instance.UninstallSDK(sdk);
					didListHaveChanged = true;
				}
				catch (System.Exception e)
				{
					EditorUtility.DisplayDialog("Uninstall failed", e.ToString(), "ok");
				}
			}

		}
	}

	private GUIContent[] CreateSDKListContent(string searchTxt)
	{
		var list = SdkManager.Instance.GetInstalledSDKs();
		if (list == null)
			return new GUIContent[]{};


		//if search
		//...

		var listContent = new GUIContent[list.Count];

		int i = 0;
		foreach (var sdk in list)
		{
			listContent[i] = CreateCell(sdk);
			i++;
		}

		return listContent;

	}

	private GUIContent CreateCell(SDKInfo sdk)
	{
		
		return new GUIContent(sdk.Name);
	}


}
