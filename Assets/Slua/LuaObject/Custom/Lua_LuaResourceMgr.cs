using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaResourceMgr : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaResourceMgr o;
			o=new LuaResourceMgr();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetObjectAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<UnityEngine.Object> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			LuaResourceMgr.GetObjectAsync(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaResourceMgr");
		addMember(l,GetObjectAsync_s);
		createTypeMetatable(l,constructor, typeof(LuaResourceMgr));
	}
}
