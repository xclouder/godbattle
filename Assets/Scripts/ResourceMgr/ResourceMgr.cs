/*************************************************************************
 *  FileName: ResourceMgr.cs
 *  Author: xClouder
 *  Create Time: 06/21/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;

public class ResourceMgr
{
	private static IResourceCache _resourceCache = new DefaultResourceCache();
	private static IResourceLoader _resourceLoader = new ResourceLoader();

	public static void SetCache(IResourceCache cache)
	{
		_resourceCache = cache;
	}

	public static void SetResourceLoader(IResourceLoader resourceLoader)
	{
		_resourceLoader = resourceLoader;
	}

	/// <summary>
	/// 同步获取资源，如果资源之前没有被缓存，则会有警告
	/// </summary>
	/// <returns>The resource.</returns>
	/// <param name="name">Name.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T Get<T>(string name) where T : UnityEngine.Object
	{
		if (_resourceCache.Contains (name))
			return _resourceCache.Get(name) as T;
		else {
			Debug.LogWarning ("res:'" + name + "' not cached, now Load it synchronously.");
			return Resources.Load<T> (name);
		}
	}

	public static void GetAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		T val = null;
		if (_resourceCache.Contains (name))
		{
			val = _resourceCache.Get(name) as T;
		}
		else {
			_resourceLoader.LoadAsync(name, onComplete);
		}

		if (onComplete != null)
			onComplete(val);
		
	}

	/// <summary>
	/// 同步获取资源并创建实例，如果资源之前没有被缓存，则会有警告
	/// </summary>
	/// <returns>The instance.</returns>
	/// <param name="name">Name.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T CreateInstance<T>(string name) where T : UnityEngine.Object
	{
		var obj = Get<T> (name);
		if (obj != null)
			return GameObject.Instantiate(obj) as T;
		else
			return null;
	}

	public static void CreateInstanceAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		GetAsync<T> (name, obj => {

			var ins = obj == null ? null : GameObject.Instantiate(obj);

			if (onComplete != null)
				onComplete(ins);
			
		});
	}



}