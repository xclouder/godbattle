using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_Camera2DFollow : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTarget(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			self.SetTarget(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_target(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.target);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_target(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.target=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_damping(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.damping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_damping(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.damping=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAheadFactor(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lookAheadFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAheadFactor(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lookAheadFactor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAheadReturnSpeed(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lookAheadReturnSpeed);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAheadReturnSpeed(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lookAheadReturnSpeed=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAheadMoveThreshold(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.lookAheadMoveThreshold);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAheadMoveThreshold(IntPtr l) {
		try {
			Camera2DFollow self=(Camera2DFollow)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.lookAheadMoveThreshold=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"Camera2DFollow");
		addMember(l,SetTarget);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"damping",get_damping,set_damping,true);
		addMember(l,"lookAheadFactor",get_lookAheadFactor,set_lookAheadFactor,true);
		addMember(l,"lookAheadReturnSpeed",get_lookAheadReturnSpeed,set_lookAheadReturnSpeed,true);
		addMember(l,"lookAheadMoveThreshold",get_lookAheadMoveThreshold,set_lookAheadMoveThreshold,true);
		createTypeMetatable(l,null, typeof(Camera2DFollow),typeof(UnityEngine.MonoBehaviour));
	}
}
