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

[CustomLuaClass]
public class LuaComponent : uFrameComponent
{
	private LuaScriptBinder luaScriptBinder;
	private LuaTable luaObj;

	public string luaScript = null;

	virtual protected void Awake()
	{
		if (string.IsNullOrEmpty(luaScript))
			luaScript = name;

		InitIfNeeds();

		if (luaObj != null)
			CallLuaMethod("Awake", false, this, gameObject);
	}

	public LuaTable GetLuaObject()
	{
		return luaObj;
	}

	virtual protected LuaTable BindLuaScript(string scriptName)
	{
		luaScriptBinder = new LuaScriptBinder(scriptName);
		return luaScriptBinder.Bind();
	}

	private void InitIfNeeds()
	{
		if (luaObj != null)
			return;

		luaObj = BindLuaScript(luaScript);
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

	protected object CallLuaMethod(string methodName, bool warnIfNotExist = false, params object[] args)
	{
		InitIfNeeds();

		return luaScriptBinder.CallMethod(methodName, warnIfNotExist, args);
	}
}