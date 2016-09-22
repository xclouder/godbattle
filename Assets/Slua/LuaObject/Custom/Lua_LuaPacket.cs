﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LuaPacket : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LuaPacket o;
			o=new LuaPacket();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteHead(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			SLua.ByteArray a1;
			checkType(l,2,out a1);
			self.WriteHead(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteBody(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			SLua.ByteArray a1;
			checkType(l,2,out a1);
			self.WriteBody(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReadHead(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			var ret=self.ReadHead();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ReadBody(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			var ret=self.ReadBody();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaPacket");
		addMember(l,WriteHead);
		addMember(l,WriteBody);
		addMember(l,ReadHead);
		addMember(l,ReadBody);
		createTypeMetatable(l,constructor, typeof(LuaPacket),typeof(Packet));
	}
}