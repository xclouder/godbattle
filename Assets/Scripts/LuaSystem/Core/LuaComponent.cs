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
	private LuaTable luaTable;

	public string luaScript = null;

	virtual protected void Awake()
	{
		if (string.IsNullOrEmpty(luaScript))
			luaScript = name;
	}

	virtual protected void BindLuaScript(string scriptName)
	{
		var result = luaService.RunFile(luaScript);
		Debug.Assert(result != null, "lua result is null");
		
		var _luaTable = result as LuaTable;
		Debug.Assert(_luaTable != null, "luaTable is null");

		var newFuncObj = _luaTable["New"]; // if a New function exist, new a table!
		if (newFuncObj != null)
		{
			var newTableObj = (newFuncObj as LuaFunction).call(this);
			_luaTable = newTableObj as LuaTable;
		}

		luaTable = _luaTable;
	}

	private void InitIfNeeds()
	{
		if (luaTable != null)
			return;

		luaService = uFrameKernel.Container.Resolve<LuaService> ();
		if (luaService == null)
			throw new System.Exception ("No Lua Service found!");

		BindLuaScript(luaScript);

		CallLuaMethod("OnInit");
	}

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		CallLuaMethod("KernelLoaded");
	}

	virtual protected void Update()
	{
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

	protected object CallLuaMethod(string methodName, bool warnIfNotExist = false, params object[] args)
	{
		Debug.Assert (luaService != null);
		Debug.Assert(!string.IsNullOrEmpty(methodName), "method name is null");

		var _luaFuncObj = luaTable[methodName];
		if(_luaFuncObj == null)
		{
			if (warnIfNotExist)
				Debug.LogWarning(string.Format("Method {0} not exist, ignore.", methodName));
			
			return;
		}

		var luaObj = (_luaFuncObj as LuaFunction).call(luaTable, this);
		return luaObj;
	}
}