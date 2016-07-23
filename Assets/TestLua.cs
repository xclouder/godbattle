/*************************************************************************
 *  FileName: TestLua.cs
 *  Author: xClouder
 *  Create Time: 07/22/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using SLua;
using uFrame.Kernel;

public class TestLua : uFrameComponent
{
	public string luaFile = "hello";
	LuaSvr l;

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		l = new LuaSvr();

		LuaState.loaderDelegate = (name) => {

			var path = name.IndexOf('/') < 0 ? "AssetBundles/lua/default/" + name : "AssetBundles/lua/" + name; 
			var asset = ResourceMgr.Get<TextAsset>(path);
			return asset.bytes;

		};

		l.init(null,()=>{
			l.start(luaFile);
		});
	}
}