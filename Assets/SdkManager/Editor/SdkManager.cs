using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class SdkManager {

	private static SdkManager _ins;
	public static SdkManager Instance
	{
		get {
			if (_ins == null)
			{
				_ins = new SdkManager();
				_ins.Init();
			}

			return _ins;
		}
	}

	//store the origin sdk assets
	private static string DIR_SDK_ASSET_STORE = ".SdkStore";

	//store the soft link of sdk assets
	private static string DIR_MANAGED_SDKS = "ManagedSDKs";

	private string managedSDKsDir;
	private string sdkStoreDir;

	public string GetSdkStoreDir()
	{
		return sdkStoreDir;
	}

	private void Init()
	{
		//init dir related
		sdkStoreDir = Path.Combine(Application.dataPath, DIR_SDK_ASSET_STORE);
		managedSDKsDir = Path.Combine(Application.dataPath, DIR_MANAGED_SDKS);

		//scan the local installed SDKs
		LoadSdkInfos(false);

	}

	private bool hasLoadedSdkInfos = false;
	public void LoadSdkInfos(bool force)
	{
		if (!force && hasLoadedSdkInfos)
		{
			return;
		}

		if (!Directory.Exists(sdkStoreDir))
		{
			Debug.Log("sdk store dir not exist");
			return;
		}

		string[] directories = Directory.GetDirectories(sdkStoreDir);
		foreach (var dir in directories)
		{
			try {
				var sdk = ParseSdkInfoFromDirectory(dir);
				AddSdk(sdk);
			}
			catch (System.Exception e)
			{
				Debug.LogWarning("error:" + e.ToString());
				continue;
			}
		}

		directories = Directory.GetDirectories(managedSDKsDir);
		foreach (var dir in directories)
		{
			try {
				var sdk = ParseSdkInfoFromDirectory(dir);
				if (IsSdkExists(sdk))
				{
					var realSdkInfo = GetSDKInfo(sdk.Id);
					realSdkInfo.Enabled = true;
				}
			}
			catch (System.Exception e)
			{
				Debug.LogWarning("error:" + e.ToString());
				continue;
			}
		}

		hasLoadedSdkInfos = true;
	}

	public SDKInfo GetSDKInfo(string infoId)
	{
		if (sdkInfoDict == null)
			return null;

		if (sdkInfoDict.ContainsKey(infoId))
		{
			return sdkInfoDict[infoId];
		}

		return null;
	}

	public SDKInfo InstallSDK(string sdkDirectory)
	{
		if (!IsValidSdkDir(sdkDirectory))
		{
			throw new System.InvalidOperationException("not a valid sdk directory");
		}

		var sdkInfo = ParseSdkInfoFromDirectory(sdkDirectory);

		//add module into list,duplicate will throw exception
		AddSdk(sdkInfo);

		//copy from sourceDir to sdkStore
		string destDir = Path.Combine(sdkStoreDir, sdkInfo.Name);
//		DirectoryCopy(sdkDirectory, destDir, true);
		FileUtil.CopyFileOrDirectory(sdkDirectory, destDir);

		return sdkInfo;

	}

	public void UninstallSDK(SDKInfo sdk)
	{
		//if enabled, disable it first
		if (sdk.Enabled)
		{
			DisableSDK(sdk);
		}

		var path = Path.Combine(sdkStoreDir, sdk.Dir);
		bool succ = FileUtil.DeleteFileOrDirectory(path);
		if (!succ)
		{
			throw new IOException("delete path failed:" + path);
		}

		sdkInfos.Remove(sdk);
		sdkInfoDict.Remove(sdk.Id);
	}

	public void EnableSDK(SDKInfo sdk)
	{
		if (!Directory.Exists(managedSDKsDir))
		{
			Directory.CreateDirectory(managedSDKsDir);
		}

		if (!IsSdkExists(sdk)){
			throw new System.InvalidOperationException("sdk not exist:" + sdk.Name);
		}

		if (sdk.Enabled)
		{
			Debug.Log("sdk: " + sdk.Name + "is enabled");
			return;
		}

		string srcPath = Path.Combine(sdkStoreDir, sdk.Dir);
		string link = Path.Combine(managedSDKsDir, sdk.Dir);

		if ((Directory.Exists(srcPath) || File.Exists(srcPath))
			&&
			(!File.Exists(link) && !Directory.Exists(link))
			&&
			FileLinkUtil.CreateSymbol(srcPath, link))
		{

			Debug.Log("link:" + srcPath + " -> " + link);
		}
		else{
			Debug.LogWarning("link fail:" + srcPath + " -> " + link);
		}

		AssetDatabase.Refresh();
	}

	public void DisableSDK(SDKInfo sdk)
	{
		if (!IsSdkExists(sdk)){
			throw new System.InvalidOperationException("sdk not exist:" + sdk.Name);
		}

		if (!sdk.Enabled)
		{
			Debug.Log("sdk: " + sdk.Name + "has already disabled");
			return;
		}

		string link = Path.Combine(managedSDKsDir, sdk.Dir);
		if (File.Exists(link) || Directory.Exists(link)){
			FileLinkUtil.RemoveSymbol(link);
			Debug.Log("RemoveSymbol:" + link);
		}
		else{
			Debug.Log("no link file:" + link);
		}

		AssetDatabase.Refresh();
	}

	//get a copy of the list
	public List<SDKInfo> GetInstalledSDKs()
	{
		if (sdkInfos == null)
			return null;
		
		var list = new List<SDKInfo>();
		list.AddRange(sdkInfos);
		return list;
	}

	#region Private 
	//SdkInfos cache
	private List<SDKInfo> sdkInfos;
	private IDictionary<string, SDKInfo> sdkInfoDict;

	private void AddSdk(SDKInfo sdk)
	{
		if (sdkInfos == null)
		{
			sdkInfos = new List<SDKInfo>();
			sdkInfoDict = new Dictionary<string, SDKInfo>();
		}

		if (IsSdkExists(sdk))
		{
			throw new System.InvalidOperationException("installing duplicate SDK, please uninstall old sdk first");
		}

		sdkInfos.Add(sdk);
		sdkInfoDict.Add(sdk.Id, sdk);
	}

	private bool IsSdkExists(SDKInfo sdk)
	{
		return sdkInfoDict.ContainsKey(sdk.Id);
	}
	#endregion


	#region Util
	private static SDKInfo ParseSdkInfoFromDirectory(string dir)
	{
		if (!IsValidSdkDir(dir))
		{
			throw new System.InvalidOperationException("dir is not a valid sdkdir");
		}
		var info = new SDKInfo();
		DirectoryInfo di = new DirectoryInfo(dir);
		info.Dir = di.Name;
		info.Enabled = false;

		//temp
		info.Version = "1.0";
		info.Id = info.Dir;
		info.Name = info.Dir;

		return info;
		
	}

	private static bool IsValidSdkDir(string sdkDir)
	{
		return Directory.Exists(sdkDir);
	}

	#endregion
}
