using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_Easing_EaseManager : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Evaluate_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==5){
				DG.Tweening.Tween a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.Core.Easing.EaseManager.Evaluate(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==6){
				DG.Tweening.Ease a1;
				checkEnum(l,1,out a1);
				DG.Tweening.EaseFunction a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.Core.Easing.EaseManager.Evaluate(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToEaseFunction_s(IntPtr l) {
		try {
			DG.Tweening.Ease a1;
			checkEnum(l,1,out a1);
			var ret=DG.Tweening.Core.Easing.EaseManager.ToEaseFunction(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.Easing.EaseManager");
		addMember(l,Evaluate_s);
		addMember(l,ToEaseFunction_s);
		createTypeMetatable(l,null, typeof(DG.Tweening.Core.Easing.EaseManager));
	}
}
