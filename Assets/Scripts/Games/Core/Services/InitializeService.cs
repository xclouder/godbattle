using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UniRx;

public class InitializeService : SystemServiceMonoBehavior {

	class AssetBundleResourceLoader : IResourceLoader
	{
		public void LoadAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
		{
			var observable = Observable.FromCoroutine<T>((observer, cancellationToken) => LoadInternal(name, observer, cancellationToken));
			observable.Subscribe(res => {

				if (onComplete != null)
					onComplete(res);

			});
		}

		private IEnumerator LoadInternal<T>(string name, IObserver<T> observer, CancellationToken cancellationToken) where T : UnityEngine.Object
		{
			var index = name.IndexOf ('/');
			var bundleName = name.Substring (0, index);
			var req1 = AssetBundle.LoadFromFileAsync (Application.dataPath + "/StreamingAssets/AssetBundles/" + bundleName);
			yield return req1;

			var assetName = name.Substring (index + 1);
			var req2 = req1.assetBundle.LoadAssetAsync(assetName);
			yield return req2;

			var obj = req2.asset;

			if (!cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(obj as T); // push 100%
				observer.OnCompleted();
			}
		}
	}

	public override void Setup ()
	{
		base.Setup ();

		ResourceMgr.SetResourceLoader(new AssetBundleResourceLoader());
	}

}
