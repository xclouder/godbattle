using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_DOVirtual : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Float_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.TweenCallback<System.Single> a4;
			LuaDelegation.checkDelegate(l,4,out a4);
			var ret=DG.Tweening.DOVirtual.Float(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int EasedValue_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(float),typeof(float),typeof(float),typeof(UnityEngine.AnimationCurve))){
				System.Single a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.AnimationCurve a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOVirtual.EasedValue(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(float),typeof(float),typeof(float),typeof(DG.Tweening.Ease))){
				System.Single a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Ease a4;
				checkEnum(l,4,out a4);
				var ret=DG.Tweening.DOVirtual.EasedValue(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==5){
				System.Single a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Ease a4;
				checkEnum(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.DOVirtual.EasedValue(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==6){
				System.Single a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.Ease a4;
				checkEnum(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.DOVirtual.EasedValue(a1,a2,a3,a4,a5,a6);
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
	static public int DelayedCall_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenCallback a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.DOVirtual.DelayedCall(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.DOVirtual");
		addMember(l,Float_s);
		addMember(l,EasedValue_s);
		addMember(l,DelayedCall_s);
		createTypeMetatable(l,null, typeof(DG.Tweening.DOVirtual));
	}
}
