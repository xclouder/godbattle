/*************************************************************************
 *  FileName: GameUpdateService.cs
 *  Author: xClouder
 *  Create Time: 07/20/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using uFrame.Kernel;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GameUpdateService : SystemServiceMonoBehavior
{
	public enum UpdateType
	{
		NoNeed,
		DynamicUpdate,
		ForceUpdate
	}

	public static string ASSET_VERSION_KEY = "__local_asset_version";
	public override IEnumerator SetupAsync()
	{
		var nativeAssetVersion = GetNativeAssetVersion();
		var dynamicAssetVersion = GetDynamicAssetVersion();
		Debug.Log("native asset version:" + nativeAssetVersion);
		Debug.Log("dynamic asset version:" + dynamicAssetVersion);

		if (nativeAssetVersion > dynamicAssetVersion)
		{
			//clean dynamic asset folder
			var dynamicAssetDir = GetDynamicAssetPath();
			var nativeAssetDir = GetNativeAssetPath();
			if (Directory.Exists(dynamicAssetDir))
			{
				var di = new DirectoryInfo(dynamicAssetDir);
				di.Delete(true);

				Directory.CreateDirectory(dynamicAssetDir);
			}
			
			string platformName = BundleUtility.GetPlatformName();
			
			//copy files to dynamic asset folder
			var dynamic_platfromAssetDir = Path.Combine(dynamicAssetDir, platformName);
			var native_platformAssetDir = Path.Combine(nativeAssetDir, platformName);
			
			Debug.Log("dynamic_assetDir:" + dynamic_platfromAssetDir);
			Debug.Log("native_platformAssetDir:" + native_platformAssetDir);
			
			Debug.Log("Copy AssetBundles to dynamic asset folder");
			//TODO:this may occurs error
			CopyDir.Copy(native_platformAssetDir, dynamic_platfromAssetDir);

			dynamicAssetVersion = nativeAssetVersion;
			PlayerPrefs.SetString(ASSET_VERSION_KEY, dynamicAssetVersion.ToString());

			PlayerPrefs.Save();
		}

		GameVersion = dynamicAssetVersion;

		yield break;
	}

	private string GetDynamicAssetPath()
	{
		return System.IO.Path.Combine(Application.persistentDataPath, ASSET_BUNDLE_DOWNLOAD_DIR);
	}

	private string GetNativeAssetPath()
	{
		return System.IO.Path.Combine(Application.streamingAssetsPath, ASSET_BUNDLE_DOWNLOAD_DIR);
	}

	private System.Version GetNativeAssetVersion()
	{
		try 
		{
			var strNativeVer = System.IO.File.ReadAllText(GetNativeAssetVersionFilePath());
			return new System.Version(strNativeVer);
		}
		catch(System.Exception e)
		{
			Debug.LogException(e);
			return new System.Version(0,0,0,0);
		}
	}
	private System.Version GetDynamicAssetVersion()
	{
		string verStr = PlayerPrefs.GetString(ASSET_VERSION_KEY);
		if (string.IsNullOrEmpty(verStr))
		{
			return new System.Version(0,0,0,0);
		}
		else
		{
			return new System.Version(verStr);
		}
	}

	private static string ASSET_BUNDLE_DOWNLOAD_DIR = "AssetBundles";
	private string GetNativeAssetVersionFilePath()
	{
		var nativeBundleDir = System.IO.Path.Combine(Application.streamingAssetsPath, ASSET_BUNDLE_DOWNLOAD_DIR);
		return System.IO.Path.Combine(nativeBundleDir, versionFile);
	}

	public System.Version GameVersion { get;set; }
	public System.Version NewestVersion { get;set; }

	public IEnumerator CheckUpdate(System.Action<UpdateType> resultCallback, System.Action<System.Exception> fail)
	{
		var w = new WWW(updateURL + versionFile);
		yield return w;

		if (!string.IsNullOrEmpty(w.error))
        {
			if (fail != null)
				fail(new System.Exception("download version file error:" + w.error));

            yield break;
        }

		var strServerVersion = w.text;
		if (string.IsNullOrEmpty(strServerVersion))
		{
			if (fail != null)
				fail(new System.Exception("invalid version file. content is empty"));
			
			yield break;
		}

		NewestVersion = new System.Version(strServerVersion);
		
		Debug.Assert(GameVersion != null);
		
		//normally, it's impossible. we do a check and log
		if (NewestVersion < GameVersion)
		{
			Debug.LogWarning("Server Version is lower then Local Version");
		}

		UpdateType type = UpdateType.NoNeed;
		if (NewestVersion > GameVersion)
		{
			if (NewestVersion.Major > GameVersion.Major)
				type = UpdateType.ForceUpdate;
			else
				type = UpdateType.DynamicUpdate;
		}

		if (resultCallback != null)
			resultCallback(type);
	}

	public IEnumerator UpdateAssetBundles(System.Action<float> progressCallback, System.Action<System.Exception> fail)
	{
		if (NewestVersion == null)
			throw new System.InvalidOperationException("you should CheckVersion before call this method");

		if (NewestVersion == GameVersion)
		{
			Debug.LogError("no need to update");
			yield break;
		}

		var platformName = BundleUtility.GetPlatformName();
		var localAssetRooPath = Path.Combine(GetDynamicAssetPath(), platformName);
		var localManifestPath = Path.Combine(localAssetRooPath, platformName);

		var remoteDownloadRootPath = string.Concat(updateURL, platformName, "/"); 
		var remoteManifestPath = string.Concat(remoteDownloadRootPath, platformName);

		Debug.Log("localManifestPath:" + localManifestPath);
		Debug.Log("remoteManifestPath:" + remoteManifestPath);
		
		var localBundleReq = AssetBundle.LoadFromFileAsync(localManifestPath);
		yield return localBundleReq;

		//error handle for loading bundle.
		if (localBundleReq.assetBundle == null)
		{
			if (fail!=null)
				fail(new System.Exception("load local manifest error"));

			yield break;
		}

		var req1 = localBundleReq.assetBundle.LoadAssetAsync("assetbundlemanifest");
		yield return req1;
		var localManifest = req1.asset as AssetBundleManifest;
		localBundleReq.assetBundle.Unload(true);

		var w2 = new WWW(remoteManifestPath);
		yield return w2;

		if (!string.IsNullOrEmpty(w2.error))
        {
			if (fail!=null)
				fail(new System.Exception("load remote manifest error:" + w2.error));

			yield break;
		}

		var req2 = w2.assetBundle.LoadAssetAsync("assetbundlemanifest");
		yield return req2;
		var remoteManifest = req2.asset as AssetBundleManifest;
		w2.assetBundle.Unload(true);
		w2.Dispose();

		var downloadList = GetAssetbundlesNeedsUpdate(remoteManifest, localManifest);
		var downloadUrl = string.Empty;
		
		int downloadCount = downloadList.Length;
		int currentDownload = 1;
		foreach (var bundleName in downloadList)
		{
			downloadUrl = remoteDownloadRootPath + bundleName;
			Debug.Log("download bundle:" + bundleName + " from " + downloadUrl);

			var www = new WWW(downloadUrl);
			yield return www;

			if (!string.IsNullOrEmpty(www.error))
			{
				if (fail!=null)
					fail(new System.Exception("downlaod assetbundle '" + downloadUrl + "' error:" + www.error));

				yield break;
			}

			try 
			{
				var savePath = Path.Combine(localAssetRooPath, bundleName);
				FileInfo fi = new FileInfo(savePath);
				if (!fi.Directory.Exists)
				{
					fi.Directory.Create();
				}

				File.WriteAllBytes(savePath, www.bytes);
			}
			catch (System.Exception e)
			{
				if (fail != null)
					fail(e);
			}


			if (progressCallback!=null)
				progressCallback((float)currentDownload / downloadCount);

			currentDownload++;
		}
	}

	private string[] GetAssetbundlesNeedsUpdate(AssetBundleManifest servermanifest, AssetBundleManifest localmanifest)
    {
        List<string> result = new List<string>();
        var allassets = servermanifest.GetAllAssetBundles();
        for (int i = 0; i < allassets.Length; i++)
        {
            if (localmanifest.GetAssetBundleHash(allassets[i]).ToString() != servermanifest.GetAssetBundleHash(allassets[i]).ToString())
                result.Add(allassets[i]);
        }

        return result.ToArray();
    }

	private string versionFile = "asset_version.txt";
	private string updateURL = "http://localhost:8080/";
	
	public string UpdateURL {get { return updateURL; } set {updateURL = value;}}

	
	class CopyDir
	{
		public static void Copy(string sourceDirectory, string targetDirectory)
		{
			DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
			DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

			CopyAll(diSource, diTarget);
		}

		public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			Directory.CreateDirectory(target.FullName);

			// Copy each file into the new directory.
			foreach (FileInfo fi in source.GetFiles())
			{
				// Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
			}

			// Copy each subdirectory using recursion.
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
			{
				DirectoryInfo nextTargetSubDir =
					target.CreateSubdirectory(diSourceSubDir.Name);
				CopyAll(diSourceSubDir, nextTargetSubDir);
			}
		}

		public static void Main()
		{
			string sourceDirectory = @"c:\sourceDirectory";
			string targetDirectory = @"c:\targetDirectory";

			Copy(sourceDirectory, targetDirectory);
		}

		// Output will vary based on the contents of the source directory.
	}
}