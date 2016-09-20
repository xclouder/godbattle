using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Tween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.timeScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.timeScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isBackwards(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isBackwards);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isBackwards(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.isBackwards=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_id(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.id);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_id(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Object v;
			checkType(l,2,out v);
			self.id=v;
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
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
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
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Object v;
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
	static public int get_easeOvershootOrAmplitude(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.easeOvershootOrAmplitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easeOvershootOrAmplitude(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.easeOvershootOrAmplitude=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_easePeriod(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.easePeriod);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_easePeriod(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.easePeriod=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_fullPosition(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.fullPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_fullPosition(IntPtr l) {
		try {
			DG.Tweening.Tween self=(DG.Tweening.Tween)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.fullPosition=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Tween");
		addMember(l,"timeScale",get_timeScale,set_timeScale,true);
		addMember(l,"isBackwards",get_isBackwards,set_isBackwards,true);
		addMember(l,"id",get_id,set_id,true);
		addMember(l,"target",get_target,set_target,true);
		addMember(l,"easeOvershootOrAmplitude",get_easeOvershootOrAmplitude,set_easeOvershootOrAmplitude,true);
		addMember(l,"easePeriod",get_easePeriod,set_easePeriod,true);
		addMember(l,"fullPosition",get_fullPosition,set_fullPosition,true);
		createTypeMetatable(l,null, typeof(DG.Tweening.Tween),typeof(DG.Tweening.Core.ABSSequentiable));
	}
}
