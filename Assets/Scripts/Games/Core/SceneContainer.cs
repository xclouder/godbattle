/*************************************************************************
 *  FileName: SceneContainer.cs
 *  Author: xClouder
 *  Create Time: 07/11/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

//注册场景内需要被公用的组件，需要的时候  直接从容器取
//容器是局部的，仅仅对当前场景有效，切换场景时，容器被清空需要重新注册
public class SceneContainer
{
	public SceneContainer()
	{
		_dict = new Dictionary<Type, System.Object>();
	}

	private Dictionary<Type, System.Object> _dict; 
	public void Register<T>(T instance) where T : class
	{
		var type = typeof(T);
		if (_dict.ContainsKey(type))
		{
			UnityEngine.Debug.LogWarning("Already contains a key with type:" + typeof(T).ToString());
			return;
		}

		_dict.Add(type, instance);
	}

	public T Get<T>() where T : class
	{
		var type = typeof(T);
		if (!_dict.ContainsKey(type))
		{
			UnityEngine.Debug.LogWarning("Do not contains a key with type:" + typeof(T).ToString());
			return null;
		}

		return (T)_dict[type];
	}
}