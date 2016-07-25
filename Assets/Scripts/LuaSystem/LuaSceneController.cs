using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class LuaSceneController : SceneController {

	private LuaScriptBinder luaBinder;

	public string luaScript;

	public override void KernelLoaded()
	{
		base.KernelLoaded();

		luaBinder = new LuaScriptBinder(luaScript);
		luaBinder.Bind();

		luaBinder.CallMethod("KernelLoaded");
	}

	protected override void SceneLoaded() {

		luaBinder.CallMethod("SceneLoaded");

	}

}
