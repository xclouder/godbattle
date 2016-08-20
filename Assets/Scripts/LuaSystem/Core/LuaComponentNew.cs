using UnityEngine;
using System.Collections;
using uFrame.Kernel;

/// <summary>
/// c#侧负责提供事件回调，逻辑由lua侧实现。
/// 使用上会存在两种情形：
/// 1）LuaComponent静态存在GameObject中，那么需要根据luaScript创建lua侧的对象
/// 2）lua侧调用gameObject:AddComponent动态拼装对象，哪边做lua对象的初始化？
/// </summary>
public class LuaComponentNew : uFrameComponent {

	private LuaService luaService;

	public string luaScript;

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		luaService = uFrameKernel.Container.Resolve<LuaService> ();

		if (luaService == null)
			throw new System.Exception ("No Lua Service found!");

		//创建lua对应的对象

		//回调lua脚本常用事件
	}

	private void CreateLuaObject(string luaScript)
	{
		luaService.RunString("require \""+luaScript+"\"");
		//问题来了，怎么绑定lua对象与c#对象？


	}
}
