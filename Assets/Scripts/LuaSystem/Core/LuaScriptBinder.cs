using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class LuaScriptBinder {

	private LuaService luaService;
	private string LuaScript {get;set;}
	private string ModuleName {get;set;}

	public LuaScriptBinder(string script)
	{
		luaService = uFrameKernel.Container.Resolve<LuaService>();
		LuaScript = script;
		ModuleName = GetModuleName(LuaScript);
	}

	protected void RequireLuaScript(string scriptName)
	{
		luaService.RunString("require(\"" + LuaScript + "\")");
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
		return ModuleName + "." + methodName;
	}

	private string GetModuleName(string scriptName)
	{
		var index = scriptName.LastIndexOf('/');
		if (index < 0)
			return scriptName;

		return scriptName.Substring(index + 1);
	}
}