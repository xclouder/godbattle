/*************************************************************************
 *  FileName: BundleResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 07/15/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

/// <summary>
/// 用来从
/// </summary>
public class BundleResourceLoader : IBundleResourceLoader
{
	private bool isInitialized = false;
	private AssetBundleManifest Manifest {get;set;}
	public IEnumerator InitializeAsync()
	{
		m_assetBundleImages = new Dictionary<string, AssetBundleImage>();


		BundleRootDirectory = System.IO.Path.Combine(Application.persistentDataPath, "AssetBundles/");
		SecondaryBundleRootDirectory = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles/");

		Debug.Log("== BUNDLE ROOT DIR:" + BundleRootDirectory);
		Debug.Log("== SECONDARY BUNDLE ROOT DIR:" + SecondaryBundleRootDirectory);

		//for test
		ManifestFileName = "WebPlayer";

		var req = AssetBundle.LoadFromFileAsync(GetBundlePath(ManifestFileName));
		yield return req;

		var req2 = req.assetBundle.LoadAssetAsync("AssetBundleManifest");
		yield return req2;

		Manifest = req2.asset as AssetBundleManifest;
		if (Manifest == null)
			Debug.LogError("bundle manifest is null");

		isInitialized = true;
	}

	private string GetBundlePath(string bundleName)
	{
		var path = BundleRootDirectory + bundleName;
		if (!System.IO.File.Exists(path))
		{
			Debug.LogWarning("bundle:" + bundleName + " not found in path:" + path);
			path = SecondaryBundleRootDirectory + bundleName;

			Debug.LogWarning("use path:" + path);
		}

		return path;
	}

	public string ManifestFileName { get;set; }
    public string BundleRootDirectory { get;set; }
	public string SecondaryBundleRootDirectory {get;set;}

	public void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		if (!isInitialized)
			throw new System.InvalidOperationException("you should initalize this instance first by calling InitializeAsync()");

		_LoadAsync<T>(bundleName, assetName, onComplete);
	}

	public void _LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object
    {
        var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => LoadInternal(bundleName, assetName, observer, cancellationToken));
		observable.Subscribe(res => {

			if (onComplete != null)
				onComplete(res);

		});

    }

	private Dictionary<string, AssetBundleImage> m_assetBundleImages;
	private AssetBundleImage CreateAssetBundleImage(string bundleName)
	{
		var image = new AssetBundleImage(bundleName);

		image.BundlePath = GetBundlePath(bundleName);
		var dep_list = Manifest.GetAllDependencies(bundleName);

		if (dep_list != null && dep_list.Length > 0)
		{
			foreach (var d in dep_list)
			{
				var dep = m_assetBundleImages.ContainsKey(d) ? m_assetBundleImages[d] : CreateAssetBundleImage(d);

				image.AddDependency(dep);
			}
		}

		m_assetBundleImages.Add(bundleName, image);
		return image;
	}

    private IEnumerator LoadInternal<T>(string bundleName, string assetName, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		AssetBundleImage image = null;
		if (!m_assetBundleImages.ContainsKey(bundleName))
		{
			image = CreateAssetBundleImage(bundleName);
		}

		AssetBundleRequest assetReq = null;

		image.IncreaseReferenceCount();

		if (image.State == AssetBundleImage.ImageState.Unloaded)
		{
			image.LoadAsync();
		}

		while (image.State != AssetBundleImage.ImageState.Loaded)
		{
			yield return null;
		}

		//image loaded
		assetReq = image.LoadAssetAsync(assetName);

		while (!assetReq.isDone && !cancellationToken.IsCancellationRequested)
		{
			yield return null;
		}

		if (!cancellationToken.IsCancellationRequested)
		{
            observer.OnNext(assetReq.asset as T);
			observer.OnCompleted();
        }

		yield return null;

		image.DecreaseReferenceCount();

		//xvar req = AssetBundleManager.LoadAssetAsync(bundleName, assetName, typeof(T));
		/*
		var path = BundleRootDirectory + bundleName;
		if (!System.IO.File.Exists(path))
		{
			Debug.LogWarning("bundle:" + bundleName + " not found in path:" + path);
			path = SecondaryBundleRootDirectory + bundleName;

			Debug.LogWarning("use path:" + path);
		}
		
		var req = AssetBundle.LoadFromFileAsync(path);

		while (!req.isDone && !cancellationToken.IsCancellationRequested)
		{
			yield return null;
		}

		var bundle = req.assetBundle;
		var req2 = bundle.LoadAssetAsync(assetName);

		while (!req2.isDone && !cancellationToken.IsCancellationRequested)
		{
			yield return null;
		}

        if (!cancellationToken.IsCancellationRequested)
		{
            observer.OnNext(req2.asset as T);
			observer.OnCompleted();
        }
		*/
        
	}



    //todo load level
}

