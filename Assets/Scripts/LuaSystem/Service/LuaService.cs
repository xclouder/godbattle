/*************************************************************************
 *  FileName: LuaService.cs
 *  Author: xClouder
 *  Create Time: 07/21/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using SLua;
using UniRx;

public class LuaService : SystemServiceMonoBehavior
{
	private LuaSvr l;

	public override IEnumerator SetupAsync ()
	{
		Debug.Log ("~~~ setup Lua Service");

		yield return base.SetupAsync ();

		l = new LuaSvr();
		bool _isLoaded = false;

		LuaState.loaderDelegate = LoadLuaFile;

		l.init (null, () => {
			_isLoaded = true;	
		});

		while (!_isLoaded)
			yield return null;

		//TODO:在这里调用lua环境初始化脚本有一点问题，线上的版本assetbundle可能存在于两个地方:StreammingAssets or PersistentDataPath
		//在UpdateService执行完更新逻辑之前，任何调用可热更资源都可能造成读脏数据

		//Init lua libs
		RunString("require \"core/Init\"");

		//net msg callback
		var luaNetMgr = (LuaTable)RunString("return NetMgr");
		var func = luaNetMgr["OnReceiveMessage"] as LuaFunction;
//		OnEvent<Packet>().ObserveOnMainThread().Subscribe((packet) => {
//			//Debug.Log("call lua networkService:OnReceivePacket");
//			func.call(luaNetMgr, packet);
//		});


		Debug.Log ("Lua Service setup completed.");

	}

	private byte[] LoadLuaFile(string name)
	{
		var path = name.IndexOf('/') < 0 ? "AssetBundles/lua/default/" + name : "AssetBundles/lua/" + name; 

		var asset = ResourceMgr.Get<TextAsset>(path);
		return asset.bytes;
	}

	public object RunFile(string name)
	{
		return l.luaState.doFile(name);
	}

	public object CallFunction(string funcName, params object[] args)
	{
		LuaFunction func = l.luaState.getFunction(funcName);

		if (func != null) {
			return func.call(args);
		}

		return null;
	}

	public object RunString(string code)
	{
		return l.luaState.doString(code);
	}
}