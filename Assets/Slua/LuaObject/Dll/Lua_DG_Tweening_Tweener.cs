using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Tweener : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ChangeStartValue(IntPtr l) {
		try {
			DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Single a2;
			checkType(l,3,out a2);
			var ret=self.ChangeStartValue(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ChangeEndValue(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.ChangeEndValue(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
				System.Object a1;
				checkType(l,2,out a1);
				System.Single a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				var ret=self.ChangeEndValue(a1,a2,a3);
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
	static public int ChangeValues(IntPtr l) {
		try {
			DG.Tweening.Tweener self=(DG.Tweening.Tweener)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			System.Object a2;
			checkType(l,3,out a2);
			System.Single a3;
			checkType(l,4,out a3);
			var ret=self.ChangeValues(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Tweener");
		addMember(l,ChangeStartValue);
		addMember(l,ChangeEndValue);
		addMember(l,ChangeValues);
		createTypeMetatable(l,null, typeof(DG.Tweening.Tweener),typeof(DG.Tweening.Tween));
	}
}
