using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_AbstractEventData : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try {
			UnityEngine.EventSystems.AbstractEventData self=(UnityEngine.EventSystems.AbstractEventData)checkSelf(l);
			self.Reset();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Use(IntPtr l) {
		try {
			UnityEngine.EventSystems.AbstractEventData self=(UnityEngine.EventSystems.AbstractEventData)checkSelf(l);
			self.Use();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_used(IntPtr l) {
		try {
			UnityEngine.EventSystems.AbstractEventData self=(UnityEngine.EventSystems.AbstractEventData)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.used);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.AbstractEventData");
		addMember(l,Reset);
		addMember(l,Use);
		addMember(l,"used",get_used,null,true);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.AbstractEventData));
	}
}
