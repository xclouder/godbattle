using UnityEngine;
using UnityEditor;
using System.Collections;

public class AssetBundleBuilder {

	[MenuItem("Tools/Rebuild Asset Bundles")]
	public static void BuildAssetBundle()
	{
		var options = BuildAssetBundleOptions.None;
		BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath + "/AssetBundles", options);

		AssetDatabase.Refresh();
	}
	
}
