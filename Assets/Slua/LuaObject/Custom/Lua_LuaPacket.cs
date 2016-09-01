using UnityEngine;
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
	static public int WriteInt(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			System.Int32 a1;
			checkType(l,2,out a1);
			self.WriteInt(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int WriteBlob(IntPtr l) {
		try {
			LuaPacket self=(LuaPacket)checkSelf(l);
			SLua.ByteArray a1;
			checkType(l,2,out a1);
			self.WriteBlob(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LuaPacket");
		addMember(l,WriteInt);
		addMember(l,WriteBlob);
		createTypeMetatable(l,constructor, typeof(LuaPacket),typeof(Packet));
	}
}
