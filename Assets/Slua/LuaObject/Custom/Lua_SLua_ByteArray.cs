using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_SLua_ByteArray : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			SLua.ByteArray o;
			if(argc==1){
				o=new SLua.ByteArray();
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				System.Byte[] a1;
				checkArray(l,2,out a1);
				o=new SLua.ByteArray(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			return error(l,"New object failed.");
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_data(IntPtr l) {
		try {
			SLua.ByteArray self=(SLua.ByteArray)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.data);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_data(IntPtr l) {
		try {
			SLua.ByteArray self=(SLua.ByteArray)checkSelf(l);
			System.Byte[] v;
			checkArray(l,2,out v);
			self.data=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"SLua.ByteArray");
		addMember(l,"data",get_data,set_data,true);
		createTypeMetatable(l,constructor, typeof(SLua.ByteArray));
	}
}
