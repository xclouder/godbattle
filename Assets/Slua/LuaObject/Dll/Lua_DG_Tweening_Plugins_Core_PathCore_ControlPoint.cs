using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Core_PathCore_ControlPoint : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint o;
			UnityEngine.Vector3 a1;
			checkType(l,2,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,3,out a2);
			o=new DG.Tweening.Plugins.Core.PathCore.ControlPoint(a1,a2);
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Addition(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint a1;
			checkValueType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			var ret=a1+a2;
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_a(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.a);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_a(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.a=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_b(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.b);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_b(IntPtr l) {
		try {
			DG.Tweening.Plugins.Core.PathCore.ControlPoint self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.b=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Core.PathCore.ControlPoint");
		addMember(l,op_Addition);
		addMember(l,"a",get_a,set_a,true);
		addMember(l,"b",get_b,set_b,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint),typeof(System.ValueType));
	}
}
