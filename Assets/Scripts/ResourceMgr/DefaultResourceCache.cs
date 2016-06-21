/*************************************************************************
 *  FileName: DefaultResourceCache.cs
 *  Author: xClouder
 *  Create Time: 06/21/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

public class DefaultResourceCache : IResourceCache
{
	private IDictionary<string, UnityEngine.Object> cacheDict = new Dictionary<string, UnityEngine.Object>();
	public void Add(string key, UnityEngine.Object val)
	{
		cacheDict.Add(key, val);
	}

	public void Remove(string key)
	{
		cacheDict.Remove(key);
	}

	public bool Contains(string key)
	{
		return cacheDict.ContainsKey(key);
	}

	public UnityEngine.Object Get(string key)
	{
		return cacheDict[key];
	}

}