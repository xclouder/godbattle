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

public class LuaComponent : uFrameComponent
{
	private LuaService luaService;

	public string luaScript = null;

	virtual protected void Awake()
	{
		if (string.IsNullOrEmpty(luaScript))
			luaScript = name;
	}

	virtual protected void BindLuaScript(string scriptName)
	{
		//TODO require File scriptName
		luaService.RunString("require(\"" + luaScript + "\")");
	}

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		luaService = uFrameKernel.Container.Resolve<LuaService> ();

		if (luaService == null)
			throw new System.Exception ("No Lua Service found!");

		BindLuaScript(name);

		CallLuaMethod("KernelLoaded");
	}

	virtual protected void Update()
	{
		if (uFrameKernel.IsKernelLoaded)
			CallLuaMethod("Update");
	}

	override protected void OnDestroy()
	{
		base.OnDestroy();

		CallLuaMethod("OnDestroy");
	}

	public LuaService GetLuaService()
	{
		return luaService;
	}

	protected object CallLuaMethod(string methodName, params object[] args)
	{
		Debug.Assert (luaService != null);
		
		var funcString = name + "." + methodName; 
		return luaService.CallFunction(funcString, args);
	}
}