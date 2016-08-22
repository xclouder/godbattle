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

		if (luaObj != null)
			CallLuaMethod("Init", false, this, gameObject);
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