using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Plugins_Options_StringOptions : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions o;
			o=new DG.Tweening.Plugins.Options.StringOptions();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_richTextEnabled(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.richTextEnabled);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_richTextEnabled(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			System.Boolean v;
			checkType(l,2,out v);
			self.richTextEnabled=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrambleMode(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.scrambleMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrambleMode(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			DG.Tweening.ScrambleMode v;
			checkEnum(l,2,out v);
			self.scrambleMode=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scrambledChars(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.scrambledChars);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scrambledChars(IntPtr l) {
		try {
			DG.Tweening.Plugins.Options.StringOptions self;
			checkValueType(l,1,out self);
			System.Char[] v;
			checkArray(l,2,out v);
			self.scrambledChars=v;
			setBack(l,self);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Plugins.Options.StringOptions");
		addMember(l,"richTextEnabled",get_richTextEnabled,set_richTextEnabled,true);
		addMember(l,"scrambleMode",get_scrambleMode,set_scrambleMode,true);
		addMember(l,"scrambledChars",get_scrambledChars,set_scrambledChars,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Plugins.Options.StringOptions),typeof(System.ValueType));
	}
}
