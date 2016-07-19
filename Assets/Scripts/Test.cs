/*************************************************************************
 *  FileName: Test.cs
 *  Author: xClouder
 *  Create Time: 07/13/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class Test : uFrameComponent
{
	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		ResourceMgr.CreateInstanceAsync<GameObject>("AssetBundles/characters/Sphere", (go)=>{
			Debug.Assert(go != null, "go is null");
			go.transform.position = Vector3.zero;
		});

		// StartCoroutine(ManualLoad("Sphere", (go) => {
		// 	var o = GameObject.Instantiate(go);
		// 	o.transform.position = Vector3.right;
		// }));
	}

	private IEnumerator ManualLoad(string name, System.Action<GameObject> cb)
	{
		var dir = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles/");
		var req1 = AssetBundle.LoadFromFileAsync(dir + "characters");
		yield return req1;

		var req2 = AssetBundle.LoadFromFileAsync(dir + "materials");
		yield return req2;

		var req3 = AssetBundle.LoadFromFileAsync(dir + "shader");
		yield return req3;
	
		var req4 = AssetBundle.LoadFromFileAsync(dir + "textures");
		yield return req4;

		var _r1 = req3.assetBundle.LoadAssetAsync(dir + "tt");
		yield return _r1;

		var _r2 = req2.assetBundle.LoadAssetAsync(dir + "m1");
		yield return _r2;

		var _r3 = req4.assetBundle.LoadAssetAsync(dir + "unityLogo 1");
		yield return _r3;

		var req = req1.assetBundle.LoadAssetAsync(name);
		yield return req;

		if (cb != null)
			cb(req.asset as GameObject);
	}

}