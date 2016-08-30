using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaSceneController : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaSceneController o;
			o=new LuaSceneController();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int KernelLoaded(IntPtr l) {
		try {
			LuaSceneController self=(LuaSceneController)checkSelf(l);
			self.KernelLoaded();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PublishEvent(IntPtr l) {
		try {
			LuaSceneController self=(LuaSceneController)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.PublishEvent(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_luaScript(IntPtr l) {
		try {
			LuaSceneController self=(LuaSceneController)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.luaScript);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_luaScript(IntPtr l) {
		try {
			LuaSceneController self=(LuaSceneController)checkSelf(l);
			System.String v;
			checkType(l,2,out v);
			self.luaScript=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaSceneController");
		addMember(l,KernelLoaded);
		addMember(l,PublishEvent);
		addMember(l,"luaScript",get_luaScript,set_luaScript,true);
		createTypeMetatable(l,constructor, typeof(LuaSceneController),typeof(SceneController));
	}
}
