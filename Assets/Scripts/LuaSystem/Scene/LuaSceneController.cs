using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using SLua;

[CustomLuaClass]
public class LuaSceneController : SceneController {

	private LuaScriptBinder luaBinder;

	public string luaScript;

	public override void KernelLoaded()
	{
		base.KernelLoaded();

		luaBinder = new LuaScriptBinder(luaScript);
		luaBinder.Bind();

		luaBinder.CallMethod("KernelLoaded", this);
	}

	protected override void SceneLoaded() {

		luaBinder.CallMethod("SceneLoaded");

	}

	public void PublishEvent(object eventMsg)
	{
		Publish(eventMsg);
	}

}
