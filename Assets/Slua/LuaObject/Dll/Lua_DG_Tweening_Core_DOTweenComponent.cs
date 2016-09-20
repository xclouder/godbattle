using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_DOTweenComponent : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCapacity(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenComponent self=(DG.Tweening.Core.DOTweenComponent)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Int32 a2;
			checkType(l,3,out a2);
			var ret=self.SetCapacity(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_inspectorUpdater(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenComponent self=(DG.Tweening.Core.DOTweenComponent)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.inspectorUpdater);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_inspectorUpdater(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenComponent self=(DG.Tweening.Core.DOTweenComponent)checkSelf(l);
			System.Int32 v;
			checkType(l,2,out v);
			self.inspectorUpdater=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.DOTweenComponent");
		addMember(l,SetCapacity);
		addMember(l,"inspectorUpdater",get_inspectorUpdater,set_inspectorUpdater,true);
		createTypeMetatable(l,null, typeof(DG.Tweening.Core.DOTweenComponent),typeof(UnityEngine.MonoBehaviour));
	}
}
