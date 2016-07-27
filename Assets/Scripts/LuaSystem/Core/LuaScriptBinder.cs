using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class LuaScriptBinder {

	private LuaService luaService;
	private string LuaScript {get;set;}

	public LuaScriptBinder(string script)
	{
		luaService = uFrameKernel.Container.Resolve<LuaService>();
		LuaScript = script;
	}

	protected void RequireLuaScript(string scriptName)
	{
		var o = luaService.RunString("require(\"" + LuaScript + "\")");
		//TODO get module name from o
	}

	public void Bind()
	{
		RequireLuaScript(LuaScript);
	}
	
	public object CallMethod(string methodName, params object[] args)
	{
		return luaService.CallFunction(GetFuncName(methodName), args);
	}

	private string GetFuncName(string methodName)
	{
		return LuaScript + "." + methodName;
	}
}