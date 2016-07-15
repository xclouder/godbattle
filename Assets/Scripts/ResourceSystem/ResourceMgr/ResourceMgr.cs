/*************************************************************************
 *  FileName: ResourceMgr.cs
 *  Author: xClouder
 *  Create Time: 06/21/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

			if (onComplete != null)
				onComplete (val);
		}
		else {
			_resourceLoader.LoadAsync(name, onComplete);
		}
		
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

	public static void Cache<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		if (_resourceCache.Contains(name))
		{
			var obj = _resourceCache.Get(name) as T;
			if (onComplete != null) 
				onComplete(obj);
		}
		else
		{
			_resourceLoader.LoadAsync<T>(name, (o) => {

				if (!_resourceCache.Contains(name))
				{
					_resourceCache.Add(name, o);
				}

				if (onComplete != null) 
					onComplete(o);
			});
		}
	}


	private static HashSet<BatchCacheWorker> BATCH_CACHE_WORKERS = new HashSet<BatchCacheWorker>(); 

	/// <summary>
    /// 根据一个name列表批量缓存 
    /// </summary>
    /// <param name="nameList"></param>
    /// <param name="onCachedOneItem"></param>
    /// <param name="onComplete"></param>
	public static void Cache(List<string> nameList, System.Action<Object, float> onCachedOneItem, System.Action onComplete = null)
	{
		var cacheWorker = new BatchCacheWorker(_resourceCache, _resourceLoader);

		int cachedCount = 0;
		int total = nameList.Count;
		BATCH_CACHE_WORKERS.Add(cacheWorker);

		try {
			cacheWorker.Cache(nameList, (o) => {
				cachedCount++;

				if (onCachedOneItem != null)
					onCachedOneItem(o, (float)cachedCount / total);

				if (cachedCount == total)
				{
					if (onComplete != null)
						onComplete();
					
					BATCH_CACHE_WORKERS.Remove(cacheWorker);
				}
			});

		}
		catch (System.InvalidOperationException e)
		{
			BATCH_CACHE_WORKERS.Remove(cacheWorker);
			throw e;
		}

	}

	internal class BatchCacheWorker
	{
		private bool _isWorking = false; 
		public bool IsWorking { get {return _isWorking;} } 

		private List<string> _list;
		private IResourceCache _cache;
		public BatchCacheWorker(IResourceCache cache, IResourceLoader loader)
		{
			_cache = cache;
		}

		private int _cachedCount = 0;
		public void Cache(List<string> list, System.Action<Object> onCached)
		{
			Debug.Assert(list != null && list.Count > 0);

			if (_isWorking)
				throw new System.InvalidOperationException("this instance is working, please use another instance, or wait until work done.");

			_isWorking = true;

			_list = list;
			_cachedCount = 0;

			DoCache(onCached);

		}

		private void DoCache(System.Action<Object> cb)
		{
			if (_cachedCount == _list.Count)
				return;

			var name = _list[_cachedCount];

			_resourceLoader.LoadAsync<Object>(name, (o) => {
				_cachedCount++;

				cb(o);

				DoCache(cb);
			});

		}

	}

}