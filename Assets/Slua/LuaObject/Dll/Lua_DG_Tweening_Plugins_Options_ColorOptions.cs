using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_ColorOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.ColorOptions o;
			o=new DG.Tweening.Plugins.Options.ColorOptions();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_alphaOnly(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.ColorOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.alphaOnly);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_alphaOnly(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.ColorOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.alphaOnly=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.ColorOptions");
		addMember(l,"alphaOnly",get_alphaOnly,set_alphaOnly,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.ColorOptions),typeof(System.ValueType));
	}
}
