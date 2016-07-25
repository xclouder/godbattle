/*************************************************************************
 *  FileName: UniversalResourceLoader.cs
 *  Author: xClouder
 *  Create Time: 07/15/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// 统一资源加载器，支持Resources、Bundles的资源加载。
/// 接口上不必明确区分是否为Bundle资源，通过资源名name进行识别该从哪里加载。
/// 和URL概念一致，具体协议可以自己定义。比如：
/// bundle://asset@bundlename
/// res://asset
/// 
/// 默认提供一个简单的协议实现
/// </summary>
public class UniversalResourceLoader : IResourceLoader
{

	public IBundleResourceLoader BundleResourceLoader {get;set;}
	public IResourceLoader ResourceLoader {get;set;}

	private ResourceProtocol resourceProtocol = new DefaultResourceProtocol();
	public ResourceProtocol ResourceProtocol { get;set; }

	public UniversalResourceLoader()
	{
		BundleResourceLoader = new BundleResourceLoader();
		ResourceLoader = new ResourceLoader();
	}

	public T Load<T>(string name) where T : UnityEngine.Object
	{
		string bundleName = null;
		string assetName = null;

		bool isBundleAsset = resourceProtocol.GetResourceDetail(name, out bundleName, out assetName);

		if (isBundleAsset)
		{
			return GetBundleResourceLoader().Load<T>(bundleName, assetName);
		}
		else
		{
			return ResourceLoader.Load<T>(assetName);
		}
	}

	private IBundleResourceLoader m_simulateLoader = new BundleResourceSimulateLoader(); 
	private IBundleResourceLoader GetBundleResourceLoader()
	{
		#if UNITY_EDITOR
		if (IsSimulateMode)
		{
			return m_simulateLoader;
		}
		#endif

		return BundleResourceLoader;
	}

	public void LoadAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		string bundleName = null;
		string assetName = null;

		bool isBundleAsset = resourceProtocol.GetResourceDetail(name, out bundleName, out assetName);

		if (isBundleAsset)
		{
			GetBundleResourceLoader().LoadAsync(bundleName, assetName, onComplete);
		}
		else
		{
			ResourceLoader.LoadAsync(assetName, onComplete);
		}
	}

	#if UNITY_EDITOR
	const string kSimulateModeFlag = "is_asset_bundle_use_simulate_mode";
	public static bool IsSimulateMode
	{
		get { return EditorPrefs.GetBool(kSimulateModeFlag, false); }
		set { EditorPrefs.SetBool(kSimulateModeFlag, value); }
	}

	#endif
}

public abstract class ResourceProtocol
{
	/// <summary>
    /// 根据名称获取相应资源的信息，这个方法可能访问频率比较高，为了效率 参数使用out方式传递
    /// </summary>
    /// <param name="name">统一资源名称</param>
    /// <param name="bundleName">解析后的bundle，如果不是bundle资源，为null</param>
    /// <param name="assetName">解析后的资源名，如果不是bundle资源，为name</param>
    /// <returns>是否为bundle资源</returns>
	public abstract bool GetResourceDetail(string name, out string bundleName, out string assetName);

}

public class DefaultResourceProtocol : ResourceProtocol
{
	private static string PREFIX = "AssetBundles/";
	public override bool GetResourceDetail(string name, out string bundleName, out string assetName)
	{
		if (!name.StartsWith(PREFIX))
		{
			assetName = name;
			bundleName = null;

			return false;
		}
		
		var left = name.Substring(PREFIX.Length);
		var index = left.LastIndexOf('/');
		if (index < 0)
			throw new System.ArgumentException("invalid bundle location name:" + name); 

		assetName = left.Substring(index + 1);
		bundleName = left.Substring(0, index);
		return true;
	}

}