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
			var bundle = req1.assetBundle;
			var req2 = bundle.LoadAssetAsync(assetName);
			yield return req2;

			var obj = req2.asset;

			if (!cancellationToken.IsCancellationRequested)
			{
				observer.OnNext(obj as T); // push 100%
				observer.OnCompleted();
			}
		}
	}

	private class MyResourceProtocol : ResourceProtocol
	{
		public override bool GetResourceDetail(string name, out string bundleName, out string assetName)
		{
			bool isFromBundle = name.StartsWith("ab_");

			if (isFromBundle)
			{
				var index = name.IndexOf ('/');
				bundleName = name.Substring (0, index);
				assetName = name.Substring(index + 1);
			}
			else
			{
				bundleName = null;
				assetName = name;
			}
			
			return isFromBundle;
		} 
	}
	public override void Setup ()
	{
		base.Setup ();

		var loader = new UniversalResourceLoader();
		loader.ResourceProtocol = new MyResourceProtocol();

		ResourceMgr.SetResourceLoader(loader);
	}

}
