using UnityEngine;
using System.Collections;
using SLua;

[CustomLuaClass]
public class LuaResourceMgr {

	public static void GetAsync<T>(string name, System.Action<T> onComplete) where T : UnityEngine.Object
	{
		ResourceMgr.GetAsync<T>(name, onComplete);
	}

	public static void GetObjectAsync(string name, System.Action<UnityEngine.Object> onComplete)
	{
		ResourceMgr.GetAsync<UnityEngine.Object>(name, onComplete);
	}
}
