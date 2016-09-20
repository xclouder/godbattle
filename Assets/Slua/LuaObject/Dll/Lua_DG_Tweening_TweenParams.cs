using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenParams : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.TweenParams o;
			o=new DG.Tweening.TweenParams();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			var ret=self.Clear();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetAutoKill(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.SetAutoKill(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetId(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.SetId(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTarget(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			var ret=self.SetTarget(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetLoops(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			System.Nullable<DG.Tweening.LoopType> a2;
			checkNullable(l,3,out a2);
			var ret=self.SetLoops(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetEase(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,2,typeof(DG.Tweening.EaseFunction))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				DG.Tweening.EaseFunction a1;
				LuaDelegation.checkDelegate(l,2,out a1);
				var ret=self.SetEase(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.AnimationCurve))){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				UnityEngine.AnimationCurve a1;
				checkType(l,2,out a1);
				var ret=self.SetEase(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				DG.Tweening.Ease a1;
				checkEnum(l,2,out a1);
				System.Nullable<System.Single> a2;
				checkNullable(l,3,out a2);
				System.Nullable<System.Single> a3;
				checkNullable(l,4,out a3);
				var ret=self.SetEase(a1,a2,a3);
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
	static public int SetRecyclable(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.SetRecyclable(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetUpdate(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				System.Boolean a1;
				checkType(l,2,out a1);
				var ret=self.SetUpdate(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
				DG.Tweening.UpdateType a1;
				checkEnum(l,2,out a1);
				System.Boolean a2;
				checkType(l,3,out a2);
				var ret=self.SetUpdate(a1,a2);
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
	static public int OnStart(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnStart(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPlay(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnPlay(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnRewind(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnRewind(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnUpdate(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnUpdate(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnStepComplete(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnStepComplete(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnComplete(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnComplete(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnKill(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnKill(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnWaypointChange(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			DG.Tweening.TweenCallback<System.Int32> a1;
			LuaDelegation.checkDelegate(l,2,out a1);
			var ret=self.OnWaypointChange(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetDelay(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Single a1;
			checkType(l,2,out a1);
			var ret=self.SetDelay(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetRelative(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.SetRelative(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetSpeedBased(IntPtr l) {
		try {
			DG.Tweening.TweenParams self=(DG.Tweening.TweenParams)checkSelf(l);
			System.Boolean a1;
			checkType(l,2,out a1);
			var ret=self.SetSpeedBased(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Params(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.TweenParams.Params);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.TweenParams");
		addMember(l,Clear);
		addMember(l,SetAutoKill);
		addMember(l,SetId);
		addMember(l,SetTarget);
		addMember(l,SetLoops);
		addMember(l,SetEase);
		addMember(l,SetRecyclable);
		addMember(l,SetUpdate);
		addMember(l,OnStart);
		addMember(l,OnPlay);
		addMember(l,OnRewind);
		addMember(l,OnUpdate);
		addMember(l,OnStepComplete);
		addMember(l,OnComplete);
		addMember(l,OnKill);
		addMember(l,OnWaypointChange);
		addMember(l,SetDelay);
		addMember(l,SetRelative);
		addMember(l,SetSpeedBased);
		addMember(l,"Params",get_Params,null,false);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.TweenParams));
	}
}
