using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_Debugger : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Log_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.Log(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogWarning_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogWarning(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogError_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogError(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogReport_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogReport(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogInvalidTween_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogInvalidTween(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogNestedTween_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogNestedTween(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogNullTween_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogNullTween(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogNonPathTween_s(IntPtr l) {
		try {
			DG.Tweening.Tween a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogNonPathTween(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogMissingMaterialProperty_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogMissingMaterialProperty(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int LogRemoveActiveTweenError_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			DG.Tweening.Core.Debugger.LogRemoveActiveTweenError(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLogPriority_s(IntPtr l) {
		try {
			DG.Tweening.LogBehaviour a1;
			checkEnum(l,1,out a1);
			DG.Tweening.Core.Debugger.SetLogPriority(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logPriority(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.Core.Debugger.logPriority);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logPriority(IntPtr l) {
		try {
			System.Int32 v;
			checkType(l,2,out v);
			DG.Tweening.Core.Debugger.logPriority=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.Debugger");
		addMember(l,Log_s);
		addMember(l,LogWarning_s);
		addMember(l,LogError_s);
		addMember(l,LogReport_s);
		addMember(l,LogInvalidTween_s);
		addMember(l,LogNestedTween_s);
		addMember(l,LogNullTween_s);
		addMember(l,LogNonPathTween_s);
		addMember(l,LogMissingMaterialProperty_s);
		addMember(l,LogRemoveActiveTweenError_s);
		addMember(l,SetLogPriority_s);
		addMember(l,"logPriority",get_logPriority,set_logPriority,false);
		createTypeMetatable(l,null, typeof(DG.Tweening.Core.Debugger));
	}
}
