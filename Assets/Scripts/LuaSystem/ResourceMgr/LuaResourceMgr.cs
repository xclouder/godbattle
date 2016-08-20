using UnityEngine;
using System.Collections;
using SLua;

[CustomLuaClass]
public class LuaResourceMgr {

	public static void GetObjectAsync(string name, System.Action<UnityEngine.Object> onComplete)
	{
		ResourceMgr.GetAsync<UnityEngine.Object>(name, onComplete);
	}

	public static void CreateObjectAsync(string name, System.Action<UnityEngine.Object> onComplete)
	{
		ResourceMgr.CreateInstanceAsync<UnityEngine.Object>(name, onComplete);
	}

}
