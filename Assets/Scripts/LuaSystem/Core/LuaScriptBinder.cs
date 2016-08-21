using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using SLua;

public class LuaScriptBinder {

	private LuaService luaService;
	private LuaTable luaTable;
	private string LuaScript {get;set;}

	public LuaScriptBinder(string script)
	{
		luaService = uFrameKernel.Container.Resolve<LuaService>();
		LuaScript = script;
	}

	public void Bind()
	{
		var result = luaService.RunString("return require(\"" + LuaScript + "\")");
		Debug.Assert(result != null, "lua result is null");

		var _luaTable = result as LuaTable;
		Debug.Assert(_luaTable != null, "luaTable is null");

		var newFuncObj = _luaTable["New"];
		if (newFuncObj != null)
		{
			var newTableObj = (newFuncObj as LuaFunction).call(this);
			_luaTable = newTableObj as LuaTable;
		}

		luaTable = _luaTable;
	}
	
	public object CallMethod(string methodName, bool warnIfNotExist = false, params object[] args)
	{
		Debug.Assert (luaService != null);
		Debug.Assert(!string.IsNullOrEmpty(methodName), "method name is null");

		var _luaFuncObj = luaTable[methodName];
		if(_luaFuncObj == null)
		{
			if (warnIfNotExist)
				Debug.LogWarning(string.Format("Method {0} not exist, ignore.", methodName));

			return null;
		}

		if (args.Length == 0)
			return (_luaFuncObj as LuaFunction).call(luaTable);
		else if (args.Length == 1)
			return (_luaFuncObj as LuaFunction).call(luaTable, args[0]);
		else
		{
			if (args.Length > 2)
				Debug.LogWarning("args > 2 not supported now.");
			
			return (_luaFuncObj as LuaFunction).call(luaTable, args[0], args[1]);
		}
	}
}