using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UniRx;

public class InitializeService : SystemServiceMonoBehavior {
	
	public override IEnumerator SetupAsync()
    {   
		yield return base.SetupAsync ();

		// yield return StartCoroutine(AssetBundles.AssetBundleManager.Initialize());

		var loader = new UniversalResourceLoader();

		ResourceMgr.SetResourceLoader(loader);
	}

}
