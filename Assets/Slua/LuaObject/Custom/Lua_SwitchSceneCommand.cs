using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SwitchSceneCommand : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			SwitchSceneCommand o;
			o=new SwitchSceneCommand();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_FromSceneName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.FromSceneName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_FromSceneName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.FromSceneName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_ToSceneName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.ToSceneName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_ToSceneName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.ToSceneName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_TranslateEffectName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.TranslateEffectName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_TranslateEffectName(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.TranslateEffectName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Settings(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Settings);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Settings(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			uFrame.Kernel.ISceneSettings v;
			checkType(l,2,out v);
			self.Settings=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RestrictToSingleScene(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.RestrictToSingleScene);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RestrictToSingleScene(IntPtr l) {
		try {
			SwitchSceneCommand self=(SwitchSceneCommand)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.RestrictToSingleScene=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SwitchSceneCommand");
		addMember(l,"FromSceneName",get_FromSceneName,set_FromSceneName,true);
		addMember(l,"ToSceneName",get_ToSceneName,set_ToSceneName,true);
		addMember(l,"TranslateEffectName",get_TranslateEffectName,set_TranslateEffectName,true);
		addMember(l,"Settings",get_Settings,set_Settings,true);
		addMember(l,"RestrictToSingleScene",get_RestrictToSingleScene,set_RestrictToSingleScene,true);
		createTypeMetatable(l,constructor, typeof(SwitchSceneCommand));
	}
}
