using UnityEngine;
using System.Collections;

public class LoadResourceTaskPhase : CoroutineTaskPhase {

	public LoadResourceTaskPhase (float startPercent, float toPercent, string msg)
	{
		InitProgressFrom = startPercent;
		InitProgressTo = toPercent;
		Message = msg;
	}

	protected override void DoTask ()
	{
		TaskMgr.StartCoroutineOnGlobalObject(CreateRealTaskBody(DoLoadAsset()));
	}

	private IEnumerator DoLoadAsset()
	{
		int assetCount = 50;
		for (int i = 0; i < assetCount; i++)
		{
			yield return new WaitForEndOfFrame();
			int n = i + 1;
			UpdateLocalProgress((n * 100f) / assetCount, null);
		}

	}

}
