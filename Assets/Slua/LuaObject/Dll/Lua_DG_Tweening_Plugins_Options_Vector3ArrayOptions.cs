using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_Vector3ArrayOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.Vector3ArrayOptions o;
			o=new DG.Tweening.Plugins.Options.Vector3ArrayOptions();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_axisConstraint(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.Vector3ArrayOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.axisConstraint);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_axisConstraint(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.Vector3ArrayOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.AxisConstraint v;
			checkEnum(l,2,out v);
			self.axisConstraint=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_snapping(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.Vector3ArrayOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.snapping);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_snapping(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.Vector3ArrayOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.snapping=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.Vector3ArrayOptions");
		addMember(l,"axisConstraint",get_axisConstraint,set_axisConstraint,true);
		addMember(l,"snapping",get_snapping,set_snapping,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.Vector3ArrayOptions),typeof(System.ValueType));
	}
}
