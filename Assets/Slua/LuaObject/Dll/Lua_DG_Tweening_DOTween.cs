using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_DOTween : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.DOTween o;
			o=new DG.Tweening.DOTween();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Init_s(IntPtr l) {
		try {
			System.Nullable<System.Boolean> a1;
			checkNullable(l,1,out a1);
			System.Nullable<System.Boolean> a2;
			checkNullable(l,2,out a2);
			System.Nullable<DG.Tweening.LogBehaviour> a3;
			checkNullable(l,3,out a3);
			var ret=DG.Tweening.DOTween.Init(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTweensCapacity_s(IntPtr l) {
		try {
			System.Int32 a1;
			checkType(l,1,out a1);
			System.Int32 a2;
			checkType(l,2,out a2);
			DG.Tweening.DOTween.SetTweensCapacity(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			DG.Tweening.DOTween.Clear(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ClearCachedTweens_s(IntPtr l) {
		try {
			DG.Tweening.DOTween.ClearCachedTweens();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Validate_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.Validate();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int To_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Quaternion>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Quaternion>),typeof(UnityEngine.Vector3),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Quaternion> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Quaternion> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Vector4>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Vector4>),typeof(UnityEngine.Vector4),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Vector4> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Vector4> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Vector4 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Vector3>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Vector3>),typeof(UnityEngine.Vector3),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Color>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Color>),typeof(UnityEngine.Color),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Color> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Color> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Color a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOSetter<System.Single>),typeof(float),typeof(float),typeof(float))){
				DG.Tweening.Core.DOSetter<System.Single> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.RectOffset>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.RectOffset>),typeof(UnityEngine.RectOffset),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.RectOffset> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.RectOffset> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.RectOffset a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Rect>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Rect>),typeof(UnityEngine.Rect),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Rect> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Rect> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Rect a3;
				checkValueType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<UnityEngine.Vector2>),typeof(DG.Tweening.Core.DOSetter<UnityEngine.Vector2>),typeof(UnityEngine.Vector2),typeof(float))){
				DG.Tweening.Core.DOGetter<UnityEngine.Vector2> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Vector2> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				UnityEngine.Vector2 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.Int32>),typeof(DG.Tweening.Core.DOSetter<System.Int32>),typeof(int),typeof(float))){
				DG.Tweening.Core.DOGetter<System.Int32> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.Int32> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Int32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.Double>),typeof(DG.Tweening.Core.DOSetter<System.Double>),typeof(double),typeof(float))){
				DG.Tweening.Core.DOGetter<System.Double> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.Double> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Double a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.Single>),typeof(DG.Tweening.Core.DOSetter<System.Single>),typeof(float),typeof(float))){
				DG.Tweening.Core.DOGetter<System.Single> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.Single> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.UInt32>),typeof(DG.Tweening.Core.DOSetter<System.UInt32>),typeof(System.UInt32),typeof(float))){
				DG.Tweening.Core.DOGetter<System.UInt32> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.UInt32> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.UInt32 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.String>),typeof(DG.Tweening.Core.DOSetter<System.String>),typeof(string),typeof(float))){
				DG.Tweening.Core.DOGetter<System.String> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.String> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.UInt64>),typeof(DG.Tweening.Core.DOSetter<System.UInt64>),typeof(System.UInt64),typeof(float))){
				DG.Tweening.Core.DOGetter<System.UInt64> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.UInt64> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.UInt64 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.DOGetter<System.Int64>),typeof(DG.Tweening.Core.DOSetter<System.Int64>),typeof(System.Int64),typeof(float))){
				DG.Tweening.Core.DOGetter<System.Int64> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<System.Int64> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Int64 a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.DOTween.To(a1,a2,a3,a4);
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
	static public int ToAxis_s(IntPtr l) {
		try {
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			DG.Tweening.AxisConstraint a5;
			checkEnum(l,5,out a5);
			var ret=DG.Tweening.DOTween.ToAxis(a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ToAlpha_s(IntPtr l) {
		try {
			DG.Tweening.Core.DOGetter<UnityEngine.Color> a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Color> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.DOTween.ToAlpha(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Punch_s(IntPtr l) {
		try {
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			UnityEngine.Vector3 a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			System.Int32 a5;
			checkType(l,5,out a5);
			System.Single a6;
			checkType(l,6,out a6);
			var ret=DG.Tweening.DOTween.Punch(a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Shake_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==6){
				DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				UnityEngine.Vector3 a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.DOTween.Shake(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==7){
				DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
				LuaDelegation.checkDelegate(l,1,out a1);
				DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				System.Int32 a5;
				checkType(l,5,out a5);
				System.Single a6;
				checkType(l,6,out a6);
				System.Boolean a7;
				checkType(l,7,out a7);
				var ret=DG.Tweening.DOTween.Shake(a1,a2,a3,a4,a5,a6,a7);
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
	static public int ToArray_s(IntPtr l) {
		try {
			DG.Tweening.Core.DOGetter<UnityEngine.Vector3> a1;
			LuaDelegation.checkDelegate(l,1,out a1);
			DG.Tweening.Core.DOSetter<UnityEngine.Vector3> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			UnityEngine.Vector3[] a3;
			checkArray(l,3,out a3);
			System.Single[] a4;
			checkArray(l,4,out a4);
			var ret=DG.Tweening.DOTween.ToArray(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Sequence_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.Sequence();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CompleteAll_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.CompleteAll(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Complete_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.Complete(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int FlipAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.FlipAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Flip_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.Flip(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GotoAll_s(IntPtr l) {
		try {
			System.Single a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.GotoAll(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Goto_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Boolean a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.DOTween.Goto(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int KillAll_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Boolean a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.DOTween.KillAll(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				System.Boolean a1;
				checkType(l,1,out a1);
				System.Object[] a2;
				checkParams(l,2,out a2);
				var ret=DG.Tweening.DOTween.KillAll(a1,a2);
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
	static public int Kill_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.Kill(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PauseAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PauseAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Pause_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.Pause(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PlayAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Play_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==1){
				System.Object a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.DOTween.Play(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==2){
				System.Object a1;
				checkType(l,1,out a1);
				System.Object a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.DOTween.Play(a1,a2);
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
	static public int PlayBackwardsAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PlayBackwardsAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayBackwards_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.PlayBackwards(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayForwardAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PlayForwardAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayForward_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.PlayForward(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RestartAll_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.RestartAll(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Restart_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.Object a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.DOTween.Restart(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==3){
				System.Object a1;
				checkType(l,1,out a1);
				System.Object a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.DOTween.Restart(a1,a2,a3);
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
	static public int RewindAll_s(IntPtr l) {
		try {
			System.Boolean a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.RewindAll(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Rewind_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.Rewind(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SmoothRewindAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.SmoothRewindAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SmoothRewind_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.SmoothRewind(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TogglePauseAll_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.TogglePauseAll();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TogglePause_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.TogglePause(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int IsTweening_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			var ret=DG.Tweening.DOTween.IsTweening(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TotalPlayingTweens_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.TotalPlayingTweens();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PlayingTweens_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PlayingTweens();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PausedTweens_s(IntPtr l) {
		try {
			var ret=DG.Tweening.DOTween.PausedTweens();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TweensById_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.TweensById(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TweensByTarget_s(IntPtr l) {
		try {
			System.Object a1;
			checkType(l,1,out a1);
			System.Boolean a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.DOTween.TweensByTarget(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Version(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.Version);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useSafeMode(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.useSafeMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useSafeMode(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.useSafeMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showUnityEditorReport(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.showUnityEditorReport);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showUnityEditorReport(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.showUnityEditorReport=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.timeScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		try {
			System.Single v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.timeScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useSmoothDeltaTime(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.useSmoothDeltaTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useSmoothDeltaTime(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.useSmoothDeltaTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_drawGizmos(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.drawGizmos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_drawGizmos(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.drawGizmos=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultUpdateType(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)DG.Tweening.DOTween.defaultUpdateType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultUpdateType(IntPtr l) {
		try {
			DG.Tweening.UpdateType v;
			checkEnum(l,2,out v);
			DG.Tweening.DOTween.defaultUpdateType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultTimeScaleIndependent(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.defaultTimeScaleIndependent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultTimeScaleIndependent(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.defaultTimeScaleIndependent=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoPlay(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)DG.Tweening.DOTween.defaultAutoPlay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoPlay(IntPtr l) {
		try {
			DG.Tweening.AutoPlay v;
			checkEnum(l,2,out v);
			DG.Tweening.DOTween.defaultAutoPlay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoKill(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.defaultAutoKill);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoKill(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.defaultAutoKill=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultLoopType(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)DG.Tweening.DOTween.defaultLoopType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultLoopType(IntPtr l) {
		try {
			DG.Tweening.LoopType v;
			checkEnum(l,2,out v);
			DG.Tweening.DOTween.defaultLoopType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultRecyclable(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.defaultRecyclable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultRecyclable(IntPtr l) {
		try {
			System.Boolean v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.defaultRecyclable=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseType(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)DG.Tweening.DOTween.defaultEaseType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseType(IntPtr l) {
		try {
			DG.Tweening.Ease v;
			checkEnum(l,2,out v);
			DG.Tweening.DOTween.defaultEaseType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseOvershootOrAmplitude(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseOvershootOrAmplitude(IntPtr l) {
		try {
			System.Single v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.defaultEaseOvershootOrAmplitude=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEasePeriod(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.DOTween.defaultEasePeriod);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEasePeriod(IntPtr l) {
		try {
			System.Single v;
			checkType(l,2,out v);
			DG.Tweening.DOTween.defaultEasePeriod=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logBehaviour(IntPtr l) {
		try {
			pushValue(l,true);
			pushEnum(l,(int)DG.Tweening.DOTween.logBehaviour);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logBehaviour(IntPtr l) {
		try {
			DG.Tweening.LogBehaviour v;
			checkEnum(l,2,out v);
			DG.Tweening.DOTween.logBehaviour=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.DOTween");
		addMember(l,Init_s);
		addMember(l,SetTweensCapacity_s);
		addMember(l,Clear_s);
		addMember(l,ClearCachedTweens_s);
		addMember(l,Validate_s);
		addMember(l,To_s);
		addMember(l,ToAxis_s);
		addMember(l,ToAlpha_s);
		addMember(l,Punch_s);
		addMember(l,Shake_s);
		addMember(l,ToArray_s);
		addMember(l,Sequence_s);
		addMember(l,CompleteAll_s);
		addMember(l,Complete_s);
		addMember(l,FlipAll_s);
		addMember(l,Flip_s);
		addMember(l,GotoAll_s);
		addMember(l,Goto_s);
		addMember(l,KillAll_s);
		addMember(l,Kill_s);
		addMember(l,PauseAll_s);
		addMember(l,Pause_s);
		addMember(l,PlayAll_s);
		addMember(l,Play_s);
		addMember(l,PlayBackwardsAll_s);
		addMember(l,PlayBackwards_s);
		addMember(l,PlayForwardAll_s);
		addMember(l,PlayForward_s);
		addMember(l,RestartAll_s);
		addMember(l,Restart_s);
		addMember(l,RewindAll_s);
		addMember(l,Rewind_s);
		addMember(l,SmoothRewindAll_s);
		addMember(l,SmoothRewind_s);
		addMember(l,TogglePauseAll_s);
		addMember(l,TogglePause_s);
		addMember(l,IsTweening_s);
		addMember(l,TotalPlayingTweens_s);
		addMember(l,PlayingTweens_s);
		addMember(l,PausedTweens_s);
		addMember(l,TweensById_s);
		addMember(l,TweensByTarget_s);
		addMember(l,"Version",get_Version,null,false);
		addMember(l,"useSafeMode",get_useSafeMode,set_useSafeMode,false);
		addMember(l,"showUnityEditorReport",get_showUnityEditorReport,set_showUnityEditorReport,false);
		addMember(l,"timeScale",get_timeScale,set_timeScale,false);
		addMember(l,"useSmoothDeltaTime",get_useSmoothDeltaTime,set_useSmoothDeltaTime,false);
		addMember(l,"drawGizmos",get_drawGizmos,set_drawGizmos,false);
		addMember(l,"defaultUpdateType",get_defaultUpdateType,set_defaultUpdateType,false);
		addMember(l,"defaultTimeScaleIndependent",get_defaultTimeScaleIndependent,set_defaultTimeScaleIndependent,false);
		addMember(l,"defaultAutoPlay",get_defaultAutoPlay,set_defaultAutoPlay,false);
		addMember(l,"defaultAutoKill",get_defaultAutoKill,set_defaultAutoKill,false);
		addMember(l,"defaultLoopType",get_defaultLoopType,set_defaultLoopType,false);
		addMember(l,"defaultRecyclable",get_defaultRecyclable,set_defaultRecyclable,false);
		addMember(l,"defaultEaseType",get_defaultEaseType,set_defaultEaseType,false);
		addMember(l,"defaultEaseOvershootOrAmplitude",get_defaultEaseOvershootOrAmplitude,set_defaultEaseOvershootOrAmplitude,false);
		addMember(l,"defaultEasePeriod",get_defaultEasePeriod,set_defaultEasePeriod,false);
		addMember(l,"logBehaviour",get_logBehaviour,set_logBehaviour,false);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.DOTween));
	}
}
