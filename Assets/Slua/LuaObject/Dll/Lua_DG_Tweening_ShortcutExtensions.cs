using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_ShortcutExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOFade_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(float),typeof(float))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.AudioSource),typeof(float),typeof(float))){
				UnityEngine.AudioSource a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOFade(a1,a2,a3,a4);
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
	static public int DOPitch_s(IntPtr l) {
		try {
			UnityEngine.AudioSource a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOPitch(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOAspect_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOAspect(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOColor_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Light),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.Light a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Camera),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.Camera a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Color),typeof(string),typeof(float))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.LineRenderer),typeof(DG.Tweening.Color2),typeof(DG.Tweening.Color2),typeof(float))){
				UnityEngine.LineRenderer a1;
				checkType(l,1,out a1);
				DG.Tweening.Color2 a2;
				checkValueType(l,2,out a2);
				DG.Tweening.Color2 a3;
				checkValueType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOColor(a1,a2,a3,a4);
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
	static public int DOFarClipPlane_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOFarClipPlane(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOFieldOfView_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOFieldOfView(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DONearClipPlane_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DONearClipPlane(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOOrthoSize_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOOrthoSize(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPixelRect_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			UnityEngine.Rect a2;
			checkValueType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOPixelRect(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DORect_s(IntPtr l) {
		try {
			UnityEngine.Camera a1;
			checkType(l,1,out a1);
			UnityEngine.Rect a2;
			checkValueType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DORect(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOShakePosition_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Camera),typeof(float),typeof(UnityEngine.Vector3),typeof(int),typeof(float))){
				UnityEngine.Camera a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakePosition(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Camera),typeof(float),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Camera a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakePosition(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(UnityEngine.Vector3),typeof(int),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Boolean a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.ShortcutExtensions.DOShakePosition(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(int),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Boolean a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.ShortcutExtensions.DOShakePosition(a1,a2,a3,a4,a5,a6);
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
	static public int DOShakeRotation_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeRotation(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(UnityEngine.Vector3),typeof(int),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeRotation(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Camera),typeof(float),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Camera a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeRotation(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Camera),typeof(float),typeof(UnityEngine.Vector3),typeof(int),typeof(float))){
				UnityEngine.Camera a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeRotation(a1,a2,a3,a4,a5);
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
	static public int DOIntensity_s(IntPtr l) {
		try {
			UnityEngine.Light a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOIntensity(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOShadowStrength_s(IntPtr l) {
		try {
			UnityEngine.Light a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOShadowStrength(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOFloat_s(IntPtr l) {
		try {
			UnityEngine.Material a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOFloat(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOOffset_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOOffset(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOOffset(a1,a2,a3,a4);
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
	static public int DOTiling_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==3){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOTiling(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Vector2 a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOTiling(a1,a2,a3,a4);
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
	static public int DOVector_s(IntPtr l) {
		try {
			UnityEngine.Material a1;
			checkType(l,1,out a1);
			UnityEngine.Vector4 a2;
			checkType(l,2,out a2);
			System.String a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOVector(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOMove_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMove(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(UnityEngine.Vector3),typeof(float),typeof(bool))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMove(a1,a2,a3,a4);
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
	static public int DOMoveX_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveX(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveX(a1,a2,a3,a4);
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
	static public int DOMoveY_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveY(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveY(a1,a2,a3,a4);
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
	static public int DOMoveZ_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveZ(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(float),typeof(float),typeof(bool))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Boolean a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOMoveZ(a1,a2,a3,a4);
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
	static public int DORotate_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3),typeof(float),typeof(DG.Tweening.RotateMode))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.RotateMode a4;
				checkEnum(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DORotate(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(UnityEngine.Vector3),typeof(float),typeof(DG.Tweening.RotateMode))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.RotateMode a4;
				checkEnum(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DORotate(a1,a2,a3,a4);
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
	static public int DOLookAt_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3),typeof(float),typeof(DG.Tweening.AxisConstraint),typeof(System.Nullable<UnityEngine.Vector3>))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.AxisConstraint a4;
				checkEnum(l,4,out a4);
				System.Nullable<UnityEngine.Vector3> a5;
				checkNullable(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOLookAt(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(UnityEngine.Vector3),typeof(float),typeof(DG.Tweening.AxisConstraint),typeof(System.Nullable<UnityEngine.Vector3>))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				DG.Tweening.AxisConstraint a4;
				checkEnum(l,4,out a4);
				System.Nullable<UnityEngine.Vector3> a5;
				checkNullable(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOLookAt(a1,a2,a3,a4,a5);
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
	static public int DOJump_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3),typeof(float),typeof(int),typeof(float),typeof(bool))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Boolean a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.ShortcutExtensions.DOJump(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Rigidbody),typeof(UnityEngine.Vector3),typeof(float),typeof(int),typeof(float),typeof(bool))){
				UnityEngine.Rigidbody a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				System.Boolean a6;
				checkType(l,6,out a6);
				var ret=DG.Tweening.ShortcutExtensions.DOJump(a1,a2,a3,a4,a5,a6);
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
	static public int DOResize_s(IntPtr l) {
		try {
			UnityEngine.TrailRenderer a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Single a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOResize(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOTime_s(IntPtr l) {
		try {
			UnityEngine.TrailRenderer a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOTime(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalMove_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalMove(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalMoveX_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalMoveX(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalMoveY_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalMoveY(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalMoveZ_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalMoveZ(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DORotateQuaternion_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DORotateQuaternion(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalRotate_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.RotateMode a4;
			checkEnum(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalRotate(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalRotateQuaternion_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Quaternion a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalRotateQuaternion(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOScale_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOScale(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(UnityEngine.Vector3),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOScale(a1,a2,a3);
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
	static public int DOScaleX_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOScaleX(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOScaleY_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOScaleY(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOScaleZ_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOScaleZ(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPunchPosition_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			System.Boolean a6;
			checkType(l,6,out a6);
			var ret=DG.Tweening.ShortcutExtensions.DOPunchPosition(a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPunchScale_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			var ret=DG.Tweening.ShortcutExtensions.DOPunchScale(a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPunchRotation_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			var ret=DG.Tweening.ShortcutExtensions.DOPunchRotation(a1,a2,a3,a4,a5);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOShakeScale_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(UnityEngine.Vector3),typeof(int),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				UnityEngine.Vector3 a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeScale(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Transform),typeof(float),typeof(float),typeof(int),typeof(float))){
				UnityEngine.Transform a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				System.Int32 a4;
				checkType(l,4,out a4);
				System.Single a5;
				checkType(l,5,out a5);
				var ret=DG.Tweening.ShortcutExtensions.DOShakeScale(a1,a2,a3,a4,a5);
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
	static public int DOLocalJump_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Int32 a4;
			checkType(l,4,out a4);
			System.Single a5;
			checkType(l,5,out a5);
			System.Boolean a6;
			checkType(l,6,out a6);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalJump(a1,a2,a3,a4,a5,a6);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOPath_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3[] a2;
			checkArray(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.PathType a4;
			checkEnum(l,4,out a4);
			DG.Tweening.PathMode a5;
			checkEnum(l,5,out a5);
			System.Int32 a6;
			checkType(l,6,out a6);
			System.Nullable<UnityEngine.Color> a7;
			checkNullable(l,7,out a7);
			var ret=DG.Tweening.ShortcutExtensions.DOPath(a1,a2,a3,a4,a5,a6,a7);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOLocalPath_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3[] a2;
			checkArray(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.PathType a4;
			checkEnum(l,4,out a4);
			DG.Tweening.PathMode a5;
			checkEnum(l,5,out a5);
			System.Int32 a6;
			checkType(l,6,out a6);
			System.Nullable<UnityEngine.Color> a7;
			checkNullable(l,7,out a7);
			var ret=DG.Tweening.ShortcutExtensions.DOLocalPath(a1,a2,a3,a4,a5,a6,a7);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOBlendableColor_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOBlendableColor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Light),typeof(UnityEngine.Color),typeof(float))){
				UnityEngine.Light a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.Single a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOBlendableColor(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(argc==4){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				UnityEngine.Color a2;
				checkType(l,2,out a2);
				System.String a3;
				checkType(l,3,out a3);
				System.Single a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.ShortcutExtensions.DOBlendableColor(a1,a2,a3,a4);
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
	static public int DOBlendableMoveBy_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOBlendableMoveBy(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOBlendableLocalMoveBy_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			System.Boolean a4;
			checkType(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOBlendableLocalMoveBy(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOBlendableRotateBy_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.RotateMode a4;
			checkEnum(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOBlendableRotateBy(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOBlendableLocalRotateBy_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			DG.Tweening.RotateMode a4;
			checkEnum(l,4,out a4);
			var ret=DG.Tweening.ShortcutExtensions.DOBlendableLocalRotateBy(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOBlendableScaleBy_s(IntPtr l) {
		try {
			UnityEngine.Transform a1;
			checkType(l,1,out a1);
			UnityEngine.Vector3 a2;
			checkType(l,2,out a2);
			System.Single a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.ShortcutExtensions.DOBlendableScaleBy(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DOComplete_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(bool))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DOComplete(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component),typeof(bool))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DOComplete(a1,a2);
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
	static public int DOKill_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(bool))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DOKill(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component),typeof(bool))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DOKill(a1,a2);
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
	static public int DOFlip_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOFlip(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOFlip(a1);
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
	static public int DOGoto_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(float),typeof(bool))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOGoto(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component),typeof(float),typeof(bool))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.ShortcutExtensions.DOGoto(a1,a2,a3);
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
	static public int DOPause_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPause(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPause(a1);
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
	static public int DOPlay_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlay(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlay(a1);
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
	static public int DOPlayBackwards_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlayBackwards(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlayBackwards(a1);
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
	static public int DOPlayForward_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlayForward(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOPlayForward(a1);
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
	static public int DORestart_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(bool))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DORestart(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component),typeof(bool))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DORestart(a1,a2);
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
	static public int DORewind_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material),typeof(bool))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DORewind(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component),typeof(bool))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.ShortcutExtensions.DORewind(a1,a2);
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
	static public int DOSmoothRewind_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOSmoothRewind(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOSmoothRewind(a1);
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
	static public int DOTogglePause_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(UnityEngine.Material))){
				UnityEngine.Material a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOTogglePause(a1);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(UnityEngine.Component))){
				UnityEngine.Component a1;
				checkType(l,1,out a1);
				var ret=DG.Tweening.ShortcutExtensions.DOTogglePause(a1);
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
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.ShortcutExtensions");
		addMember(l,DOFade_s);
		addMember(l,DOPitch_s);
		addMember(l,DOAspect_s);
		addMember(l,DOColor_s);
		addMember(l,DOFarClipPlane_s);
		addMember(l,DOFieldOfView_s);
		addMember(l,DONearClipPlane_s);
		addMember(l,DOOrthoSize_s);
		addMember(l,DOPixelRect_s);
		addMember(l,DORect_s);
		addMember(l,DOShakePosition_s);
		addMember(l,DOShakeRotation_s);
		addMember(l,DOIntensity_s);
		addMember(l,DOShadowStrength_s);
		addMember(l,DOFloat_s);
		addMember(l,DOOffset_s);
		addMember(l,DOTiling_s);
		addMember(l,DOVector_s);
		addMember(l,DOMove_s);
		addMember(l,DOMoveX_s);
		addMember(l,DOMoveY_s);
		addMember(l,DOMoveZ_s);
		addMember(l,DORotate_s);
		addMember(l,DOLookAt_s);
		addMember(l,DOJump_s);
		addMember(l,DOResize_s);
		addMember(l,DOTime_s);
		addMember(l,DOLocalMove_s);
		addMember(l,DOLocalMoveX_s);
		addMember(l,DOLocalMoveY_s);
		addMember(l,DOLocalMoveZ_s);
		addMember(l,DORotateQuaternion_s);
		addMember(l,DOLocalRotate_s);
		addMember(l,DOLocalRotateQuaternion_s);
		addMember(l,DOScale_s);
		addMember(l,DOScaleX_s);
		addMember(l,DOScaleY_s);
		addMember(l,DOScaleZ_s);
		addMember(l,DOPunchPosition_s);
		addMember(l,DOPunchScale_s);
		addMember(l,DOPunchRotation_s);
		addMember(l,DOShakeScale_s);
		addMember(l,DOLocalJump_s);
		addMember(l,DOPath_s);
		addMember(l,DOLocalPath_s);
		addMember(l,DOBlendableColor_s);
		addMember(l,DOBlendableMoveBy_s);
		addMember(l,DOBlendableLocalMoveBy_s);
		addMember(l,DOBlendableRotateBy_s);
		addMember(l,DOBlendableLocalRotateBy_s);
		addMember(l,DOBlendableScaleBy_s);
		addMember(l,DOComplete_s);
		addMember(l,DOKill_s);
		addMember(l,DOFlip_s);
		addMember(l,DOGoto_s);
		addMember(l,DOPause_s);
		addMember(l,DOPlay_s);
		addMember(l,DOPlayBackwards_s);
		addMember(l,DOPlayForward_s);
		addMember(l,DORestart_s);
		addMember(l,DORewind_s);
		addMember(l,DOSmoothRewind_s);
		addMember(l,DOTogglePause_s);
		createTypeMetatable(l,null, typeof(DG.Tweening.ShortcutExtensions));
	}
}
