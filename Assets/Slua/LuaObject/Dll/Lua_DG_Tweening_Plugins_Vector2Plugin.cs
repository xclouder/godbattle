using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Vector2Plugin : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin o;
			o=new DG.Tweening.Plugins.Vector2Plugin();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
			checkType(l,2,out a1);
			self.Reset(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetFrom(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
			checkType(l,2,out a1);
			System.Boolean a2;
			checkType(l,3,out a2);
			self.SetFrom(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ConvertToStartValue(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
			checkType(l,2,out a1);
			UnityEngine.Vector2 a2;
			checkType(l,3,out a2);
			var ret=self.ConvertToStartValue(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRelativeEndValue(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
			checkType(l,2,out a1);
			self.SetRelativeEndValue(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetChangeValue(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
			checkType(l,2,out a1);
			self.SetChangeValue(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetSpeedBasedDuration(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Plugins.Options.VectorOptions a1;
			checkValueType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			UnityEngine.Vector2 a3;
			checkType(l,4,out a3);
			var ret=self.GetSpeedBasedDuration(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EvaluateAndApply(IntPtr l) {
		try {
			DG.Tweening.Plugins.Vector2Plugin self=(DG.Tweening.Plugins.Vector2Plugin)checkSelf(l);
			DG.Tweening.Plugins.Options.VectorOptions a1;
			checkValueType(l,2,out a1);
			DG.Tweening.Tween a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			DG.Tweening.Core.DOGetter<UnityEngine.Vector2> a4;
			LuaDelegation.checkDelegate(l,5,out a4);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector2> a5;
			LuaDelegation.checkDelegate(l,6,out a5);
			System.Single a6;
			checkType(l,7,out a6);
			UnityEngine.Vector2 a7;
			checkType(l,8,out a7);
			UnityEngine.Vector2 a8;
			checkType(l,9,out a8);
			System.Single a9;
			checkType(l,10,out a9);
			System.Boolean a10;
			checkType(l,11,out a10);
			DG.Tweening.Core.Enums.UpdateNotice a11;
			checkEnum(l,12,out a11);
			self.EvaluateAndApply(a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Vector2Plugin");
		addMember(l,Reset);
		addMember(l,SetFrom);
		addMember(l,ConvertToStartValue);
		addMember(l,SetRelativeEndValue);
		addMember(l,SetChangeValue);
		addMember(l,GetSpeedBasedDuration);
		addMember(l,EvaluateAndApply);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Vector2Plugin),typeof(DG.Tweening.Plugins.Core.ABSTweenPlugin<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions>));
	}
}
