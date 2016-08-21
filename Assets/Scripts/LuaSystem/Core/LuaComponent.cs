/*************************************************************************
 *  FileName: LuaComponent.cs
 *  Author: xClouder
 *  Create Time: 07/22/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using SLua;

public class LuaComponent : uFrameComponent
{
	private LuaService luaService;
	private LuaScriptBinder luaScriptBinder;

	public string luaScript = null;

	virtual protected void Awake()
	{
		if (string.IsNullOrEmpty(luaScript))
			luaScript = name;
	}

	virtual protected void BindLuaScript(string scriptName)
	{
		luaScriptBinder = new LuaScriptBinder(scriptName);
		luaScriptBinder.Bind();
	}

	private void InitIfNeeds()
	{
		if (luaScriptBinder != null)
			return;

		BindLuaScript(luaScript);

		CallLuaMethod("OnInit");
	}

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		InitIfNeeds();

		CallLuaMethod("KernelLoaded", false, this);
	}

	virtual protected void Update()
	{
		if (uFrameKernel.IsKernelLoaded)
			CallLuaMethod("Update");
	}

	override protected void OnDestroy()
	{
		base.OnDestroy();

		CallLuaMethod("OnDestroy", false, this);
	}

	public LuaService GetLuaService()
	{
		return luaService;
	}

	protected object CallLuaMethod(string methodName, bool warnIfNotExist = false, params object[] args)
	{
		InitIfNeeds();

		return luaScriptBinder.CallMethod(methodName, warnIfNotExist, args);
	}
}