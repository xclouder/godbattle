using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SF_XInput : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetTouch_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetTouch(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAxis_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetAxis(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAxisRaw_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetAxisRaw(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetButton_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetButton(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetButtonDown_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetButtonDown(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetButtonUp_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.GetButtonUp(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AxisExists_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.AxisExists(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ButtonExists_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=SF.XInput.ButtonExists(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterVirtualAxis_s(IntPtr l) {
		try {
			SF.VirtualAxis a1;
			checkType(l,1,out a1);
			SF.XInput.RegisterVirtualAxis(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnregisterVirtualAxis_s(IntPtr l) {
		try {
			SF.VirtualAxis a1;
			checkType(l,1,out a1);
			SF.XInput.UnregisterVirtualAxis(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterVirtualButton_s(IntPtr l) {
		try {
			SF.VirtualButton a1;
			checkType(l,1,out a1);
			SF.XInput.RegisterVirtualButton(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int UnregisterVirtualButton_s(IntPtr l) {
		try {
			SF.VirtualButton a1;
			checkType(l,1,out a1);
			SF.XInput.UnregisterVirtualButton(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TouchCount(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,SF.XInput.TouchCount);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SF.XInput");
		addMember(l,GetTouch_s);
		addMember(l,GetAxis_s);
		addMember(l,GetAxisRaw_s);
		addMember(l,GetButton_s);
		addMember(l,GetButtonDown_s);
		addMember(l,GetButtonUp_s);
		addMember(l,AxisExists_s);
		addMember(l,ButtonExists_s);
		addMember(l,RegisterVirtualAxis_s);
		addMember(l,UnregisterVirtualAxis_s);
		addMember(l,RegisterVirtualButton_s);
		addMember(l,UnregisterVirtualButton_s);
		addMember(l,"TouchCount",get_TouchCount,null,false);
		createTypeMetatable(l,null, typeof(SF.XInput));
	}
}
