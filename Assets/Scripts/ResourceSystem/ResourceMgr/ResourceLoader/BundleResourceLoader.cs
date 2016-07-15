/*************************************************************************
 *  FileName: BundleResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 07/15/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using AssetBundles;
using UniRx;

public class BundleResourceLoader : IBundleResourceLoader
{
    
	public void LoadAsync<T>(string bundleName, string assetName, System.Action<T> onComplete) where T : UnityEngine.Object
    {
        // AssetBundleManager
        var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => LoadInternal(bundleName, assetName, observer, cancellationToken));
		observable.Subscribe(res => {

			if (onComplete != null)
				onComplete(res);

		});

    }

    private IEnumerator LoadInternal<T>(string bundleName, string assetName, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
	{
		var req = AssetBundleManager.LoadAssetAsync(bundleName, assetName, typeof(T));

		if (req.IsDone() && !cancellationToken.IsCancellationRequested)
		{
			yield return null;
		}

        if (!cancellationToken.IsCancellationRequested)
		{
            observer.OnNext(req.GetAsset<T>());
			observer.OnCompleted();
        }
        
	}

    //todo load level
}

