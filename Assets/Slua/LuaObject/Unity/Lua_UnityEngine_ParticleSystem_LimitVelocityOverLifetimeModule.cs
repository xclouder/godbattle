using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_ParticleSystem_LimitVelocityOverLifetimeModule : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule o;
			o=new UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.enabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_enabled(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.enabled=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.limitX);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitX(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitX=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.limitY);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitY(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitY=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limitZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.limitZ);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limitZ(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limitZ=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_limit(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.limit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_limit(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystem.MinMaxCurve v;
			checkValueType(l,2,out v);
			self.limit=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.dampen);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_dampen(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			float v;
			checkType(l,2,out v);
			self.dampen=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.separateAxes);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_separateAxes(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			bool v;
			checkType(l,2,out v);
			self.separateAxes=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.space);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_space(IntPtr l) {
		try {
			UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule self;
			checkValueType(l,1,out self);
			UnityEngine.ParticleSystemSimulationSpace v;
			checkEnum(l,2,out v);
			self.space=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule");
		addMember(l,"enabled",get_enabled,set_enabled,true);
		addMember(l,"limitX",get_limitX,set_limitX,true);
		addMember(l,"limitY",get_limitY,set_limitY,true);
		addMember(l,"limitZ",get_limitZ,set_limitZ,true);
		addMember(l,"limit",get_limit,set_limit,true);
		addMember(l,"dampen",get_dampen,set_dampen,true);
		addMember(l,"separateAxes",get_separateAxes,set_separateAxes,true);
		addMember(l,"space",get_space,set_space,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule),typeof(System.ValueType));
	}
}
