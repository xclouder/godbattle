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
    public string BundleRootDirectory { get;set; }
	public string SecondaryBundleRootDirectory {get;set;}
	
	public BundleResourceLoader()
	{
		BundleRootDirectory = System.IO.Path.Combine(Application.persistentDataPath, "AssetBundles/");
		SecondaryBundleRootDirectory = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles/");

		Debug.Log("== BUNDLE ROOT DIR:" + BundleRootDirectory);
		Debug.Log("== SECONDARY BUNDLE ROOT DIR:" + SecondaryBundleRootDirectory);

		m_assetBundleImages = new Dictionary<string, AssetBundleImage>();
	}

	public void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object
    {
        // AssetBundleManager
        var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => LoadInternal(bundleName, assetName, observer, cancellationToken));
		observable.Subscribe(res => {

			if (onComplete != null)
				onComplete(res);

		});

    }

	private Dictionary<string, AssetBundleImage> m_assetBundleImages;
	private AssetBundleImage CreateAssetBundleImage(string bundleName)
	{
		return null;
	}

    private IEnumerator LoadInternal<T>(string bundleName, string assetName, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		AssetBundleImage image = null;
		if (!m_assetBundleImages.ContainsKey(bundleName))
		{
			image = CreateAssetBundleImage(bundleName);
		}

		AssetBundleRequest assetReq = null;
		
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

