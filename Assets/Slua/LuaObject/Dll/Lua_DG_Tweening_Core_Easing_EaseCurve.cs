using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_Easing_EaseCurve : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Core.Easing.EaseCurve o;
			UnityEngine.AnimationCurve a1;
			checkType(l,2,out a1);
			o=new DG.Tweening.Core.Easing.EaseCurve(a1);
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Evaluate(IntPtr l) {
		try {
			DG.Tweening.Core.Easing.EaseCurve self=(DG.Tweening.Core.Easing.EaseCurve)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			System.Single a4;
			checkType(l,5,out a4);
			var ret=self.Evaluate(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.Easing.EaseCurve");
		addMember(l,Evaluate);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Core.Easing.EaseCurve));
	}
}
