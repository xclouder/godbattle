using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class Test : uFrameComponent {

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		var t = ResourceMgr.Get<TextAsset>("AssetBundles/lua/core/Init");
		Debug.Log(t.text);
	}

}
