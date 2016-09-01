using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaComponent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaComponent o;
			o=new LuaComponent();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetLuaObject(IntPtr l) {
		try {
			LuaComponent self=(LuaComponent)checkSelf(l);
			var ret=self.GetLuaObject();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int KernelLoaded(IntPtr l) {
		try {
			LuaComponent self=(LuaComponent)checkSelf(l);
			self.KernelLoaded();
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
			LuaComponent self=(LuaComponent)checkSelf(l);
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
			LuaComponent self=(LuaComponent)checkSelf(l);
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
		getTypeTable(l,"LuaComponent");
		addMember(l,GetLuaObject);
		addMember(l,KernelLoaded);
		addMember(l,"luaScript",get_luaScript,set_luaScript,true);
		createTypeMetatable(l,constructor, typeof(LuaComponent),typeof(uFrame.Kernel.uFrameComponent));
	}
}
