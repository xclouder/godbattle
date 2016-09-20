using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Color2 : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Color2 o;
			UnityEngine.Color a1;
			checkType(l,2,out a1);
			UnityEngine.Color a2;
			checkType(l,3,out a2);
			o=new DG.Tweening.Color2(a1,a2);
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
			DG.Tweening.Color2 a1;
			checkValueType(l,1,out a1);
			DG.Tweening.Color2 a2;
			checkValueType(l,2,out a2);
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
	static public int op_Subtraction(IntPtr l) {
		try {
			DG.Tweening.Color2 a1;
			checkValueType(l,1,out a1);
			DG.Tweening.Color2 a2;
			checkValueType(l,2,out a2);
			var ret=a1-a2;
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int op_Multiply(IntPtr l) {
		try {
			DG.Tweening.Color2 a1;
			checkValueType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=a1*a2;
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ca(IntPtr l) {
		try {
			DG.Tweening.Color2 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.ca);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ca(IntPtr l) {
		try {
			DG.Tweening.Color2 self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.ca=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cb(IntPtr l) {
		try {
			DG.Tweening.Color2 self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.cb);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_cb(IntPtr l) {
		try {
			DG.Tweening.Color2 self;
			checkValueType(l,1,out self);
			UnityEngine.Color v;
			checkType(l,2,out v);
			self.cb=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Color2");
		addMember(l,op_Addition);
		addMember(l,op_Subtraction);
		addMember(l,op_Multiply);
		addMember(l,"ca",get_ca,set_ca,true);
		addMember(l,"cb",get_cb,set_cb,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Color2),typeof(System.ValueType));
	}
}
