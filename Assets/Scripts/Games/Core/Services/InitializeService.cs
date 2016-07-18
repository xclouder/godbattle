using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UniRx;

public class InitializeService : SystemServiceMonoBehavior {
	
	public override IEnumerator SetupAsync()
    {   
		yield return base.SetupAsync ();

		// yield return StartCoroutine(AssetBundles.AssetBundleManager.Initialize());

		var bundleResourceLoader = new BundleResourceLoader();
		yield return bundleResourceLoader.InitializeAsync();

		var loader = new UniversalResourceLoader();
		loader.BundleResourceLoader = bundleResourceLoader;

		ResourceMgr.SetResourceLoader(loader);
	}

}
