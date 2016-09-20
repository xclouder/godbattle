using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_TweenSettingsExtensions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Append_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.Append(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Prepend_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.Prepend(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Join_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.Tween a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.Join(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Insert_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.Tween a3;
			checkType(l,3,out a3);
			var ret=DG.Tweening.TweenSettingsExtensions.Insert(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendInterval_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.AppendInterval(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrependInterval_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.PrependInterval(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int AppendCallback_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenCallback a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.AppendCallback(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int PrependCallback_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			DG.Tweening.TweenCallback a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			var ret=DG.Tweening.TweenSettingsExtensions.PrependCallback(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InsertCallback_s(IntPtr l) {
		try {
			DG.Tweening.Sequence a1;
			checkType(l,1,out a1);
			System.Single a2;
			checkType(l,2,out a2);
			DG.Tweening.TweenCallback a3;
			LuaDelegation.checkDelegate(l,3,out a3);
			var ret=DG.Tweening.TweenSettingsExtensions.InsertCallback(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetOptions_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion,UnityEngine.Vector3,DG.Tweening.Plugins.Options.QuaternionOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Quaternion,UnityEngine.Vector3,DG.Tweening.Plugins.Options.QuaternionOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector4,UnityEngine.Vector4,DG.Tweening.Plugins.Options.VectorOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector4,UnityEngine.Vector4,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Color,UnityEngine.Color,DG.Tweening.Plugins.Options.ColorOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Color,UnityEngine.Color,DG.Tweening.Plugins.Options.ColorOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3[],DG.Tweening.Plugins.Options.Vector3ArrayOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3[],DG.Tweening.Plugins.Options.Vector3ArrayOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Rect,UnityEngine.Rect,DG.Tweening.Plugins.Options.RectOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Rect,UnityEngine.Rect,DG.Tweening.Plugins.Options.RectOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<System.Single,System.Single,DG.Tweening.Plugins.Options.FloatOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<System.Single,System.Single,DG.Tweening.Plugins.Options.FloatOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3,DG.Tweening.Plugins.Options.VectorOptions>),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3,DG.Tweening.Plugins.Options.VectorOptions>),typeof(DG.Tweening.AxisConstraint),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				DG.Tweening.AxisConstraint a2;
				checkEnum(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3[],DG.Tweening.Plugins.Options.Vector3ArrayOptions>),typeof(DG.Tweening.AxisConstraint),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,UnityEngine.Vector3[],DG.Tweening.Plugins.Options.Vector3ArrayOptions> a1;
				checkType(l,1,out a1);
				DG.Tweening.AxisConstraint a2;
				checkEnum(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions>),typeof(DG.Tweening.AxisConstraint),typeof(DG.Tweening.AxisConstraint))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
				checkType(l,1,out a1);
				DG.Tweening.AxisConstraint a2;
				checkEnum(l,2,out a2);
				DG.Tweening.AxisConstraint a3;
				checkEnum(l,3,out a3);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions>),typeof(DG.Tweening.AxisConstraint),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector2,UnityEngine.Vector2,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				DG.Tweening.AxisConstraint a2;
				checkEnum(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector4,UnityEngine.Vector4,DG.Tweening.Plugins.Options.VectorOptions>),typeof(DG.Tweening.AxisConstraint),typeof(bool))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector4,UnityEngine.Vector4,DG.Tweening.Plugins.Options.VectorOptions> a1;
				checkType(l,1,out a1);
				DG.Tweening.AxisConstraint a2;
				checkEnum(l,2,out a2);
				System.Boolean a3;
				checkType(l,3,out a3);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions>),typeof(bool),typeof(DG.Tweening.AxisConstraint),typeof(DG.Tweening.AxisConstraint))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				DG.Tweening.AxisConstraint a3;
				checkEnum(l,3,out a3);
				DG.Tweening.AxisConstraint a4;
				checkEnum(l,4,out a4);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<System.String,System.String,DG.Tweening.Plugins.Options.StringOptions>),typeof(bool),typeof(DG.Tweening.ScrambleMode),typeof(string))){
				DG.Tweening.Core.TweenerCore<System.String,System.String,DG.Tweening.Plugins.Options.StringOptions> a1;
				checkType(l,1,out a1);
				System.Boolean a2;
				checkType(l,2,out a2);
				DG.Tweening.ScrambleMode a3;
				checkEnum(l,3,out a3);
				System.String a4;
				checkType(l,4,out a4);
				var ret=DG.Tweening.TweenSettingsExtensions.SetOptions(a1,a2,a3,a4);
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
	static public int SetLookAt_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions>),typeof(float),typeof(System.Nullable<UnityEngine.Vector3>),typeof(System.Nullable<UnityEngine.Vector3>))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
				checkType(l,1,out a1);
				System.Single a2;
				checkType(l,2,out a2);
				System.Nullable<UnityEngine.Vector3> a3;
				checkNullable(l,3,out a3);
				System.Nullable<UnityEngine.Vector3> a4;
				checkNullable(l,4,out a4);
				var ret=DG.Tweening.TweenSettingsExtensions.SetLookAt(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions>),typeof(UnityEngine.Transform),typeof(System.Nullable<UnityEngine.Vector3>),typeof(System.Nullable<UnityEngine.Vector3>))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
				checkType(l,1,out a1);
				UnityEngine.Transform a2;
				checkType(l,2,out a2);
				System.Nullable<UnityEngine.Vector3> a3;
				checkNullable(l,3,out a3);
				System.Nullable<UnityEngine.Vector3> a4;
				checkNullable(l,4,out a4);
				var ret=DG.Tweening.TweenSettingsExtensions.SetLookAt(a1,a2,a3,a4);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,1,typeof(DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions>),typeof(UnityEngine.Vector3),typeof(System.Nullable<UnityEngine.Vector3>),typeof(System.Nullable<UnityEngine.Vector3>))){
				DG.Tweening.Core.TweenerCore<UnityEngine.Vector3,DG.Tweening.Plugins.Core.PathCore.Path,DG.Tweening.Plugins.Options.PathOptions> a1;
				checkType(l,1,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,2,out a2);
				System.Nullable<UnityEngine.Vector3> a3;
				checkNullable(l,3,out a3);
				System.Nullable<UnityEngine.Vector3> a4;
				checkNullable(l,4,out a4);
				var ret=DG.Tweening.TweenSettingsExtensions.SetLookAt(a1,a2,a3,a4);
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
		getTypeTable(l,"DG.Tweening.TweenSettingsExtensions");
		addMember(l,Append_s);
		addMember(l,Prepend_s);
		addMember(l,Join_s);
		addMember(l,Insert_s);
		addMember(l,AppendInterval_s);
		addMember(l,PrependInterval_s);
		addMember(l,AppendCallback_s);
		addMember(l,PrependCallback_s);
		addMember(l,InsertCallback_s);
		addMember(l,SetOptions_s);
		addMember(l,SetLookAt_s);
		createTypeMetatable(l,null, typeof(DG.Tweening.TweenSettingsExtensions));
	}
}
