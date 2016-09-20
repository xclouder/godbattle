using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_PathOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions o;
			o=new DG.Tweening.Plugins.Options.PathOptions();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_mode(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.mode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_mode(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.PathMode v;
			checkEnum(l,2,out v);
			self.mode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_orientType(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.orientType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_orientType(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.Plugins.Options.OrientType v;
			checkEnum(l,2,out v);
			self.orientType=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lockPositionAxis(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.lockPositionAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lockPositionAxis(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.AxisConstraint v;
			checkEnum(l,2,out v);
			self.lockPositionAxis=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lockRotationAxis(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.lockRotationAxis);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lockRotationAxis(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.AxisConstraint v;
			checkEnum(l,2,out v);
			self.lockRotationAxis=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isClosedPath(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.isClosedPath);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_isClosedPath(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.isClosedPath=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAtPosition(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lookAtPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAtPosition(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			UnityEngine.Vector3 v;
			checkType(l,2,out v);
			self.lookAtPosition=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAtTransform(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lookAtTransform);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAtTransform(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.lookAtTransform=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_lookAhead(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.lookAhead);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_lookAhead(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			System.Single v;
			checkType(l,2,out v);
			self.lookAhead=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_hasCustomForwardDirection(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.hasCustomForwardDirection);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_hasCustomForwardDirection(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.hasCustomForwardDirection=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_forward(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.forward);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_forward(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			UnityEngine.Quaternion v;
			checkType(l,2,out v);
			self.forward=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useLocalPosition(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.useLocalPosition);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useLocalPosition(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.useLocalPosition=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_parent(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.parent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_parent(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.PathOptions self;
			checkValueType(l,1,out self);
			UnityEngine.Transform v;
			checkType(l,2,out v);
			self.parent=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.PathOptions");
		addMember(l,"mode",get_mode,set_mode,true);
		addMember(l,"orientType",get_orientType,set_orientType,true);
		addMember(l,"lockPositionAxis",get_lockPositionAxis,set_lockPositionAxis,true);
		addMember(l,"lockRotationAxis",get_lockRotationAxis,set_lockRotationAxis,true);
		addMember(l,"isClosedPath",get_isClosedPath,set_isClosedPath,true);
		addMember(l,"lookAtPosition",get_lookAtPosition,set_lookAtPosition,true);
		addMember(l,"lookAtTransform",get_lookAtTransform,set_lookAtTransform,true);
		addMember(l,"lookAhead",get_lookAhead,set_lookAhead,true);
		addMember(l,"hasCustomForwardDirection",get_hasCustomForwardDirection,set_hasCustomForwardDirection,true);
		addMember(l,"forward",get_forward,set_forward,true);
		addMember(l,"useLocalPosition",get_useLocalPosition,set_useLocalPosition,true);
		addMember(l,"parent",get_parent,set_parent,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.PathOptions),typeof(System.ValueType));
	}
}
