using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_ResourceMgr : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			ResourceMgr o;
			o=new ResourceMgr();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetCache_s(IntPtr l) {
		try {
			IResourceCache a1;
			checkType(l,1,out a1);
			ResourceMgr.SetCache(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetResourceLoader_s(IntPtr l) {
		try {
			IResourceLoader a1;
			checkType(l,1,out a1);
			ResourceMgr.SetResourceLoader(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Get_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=ResourceMgr.Get(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<UnityEngine.Object> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			ResourceMgr.GetAsync(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateInstance_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=ResourceMgr.CreateInstance(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int createInstanceAsync_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			System.Action<UnityEngine.Object> a2;
			LuaDelegation.checkDelegate(l,2,out a2);
			ResourceMgr.createInstanceAsync(a1,a2);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Cache_s(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==2){
				System.String a1;
				checkType(l,1,out a1);
				System.Action<UnityEngine.Object> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				ResourceMgr.Cache(a1,a2);
				pushValue(l,true);
				return 1;
			}
			else if(argc==3){
				System.Collections.Generic.List<System.String> a1;
				checkType(l,1,out a1);
				System.Action<UnityEngine.Object,System.Single> a2;
				LuaDelegation.checkDelegate(l,2,out a2);
				System.Action a3;
				LuaDelegation.checkDelegate(l,3,out a3);
				ResourceMgr.Cache(a1,a2,a3);
				pushValue(l,true);
				return 1;
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
		getTypeTable(l,"ResourceMgr");
		addMember(l,SetCache_s);
		addMember(l,SetResourceLoader_s);
		addMember(l,Get_s);
		addMember(l,GetAsync_s);
		addMember(l,CreateInstance_s);
		addMember(l,createInstanceAsync_s);
		addMember(l,Cache_s);
		createTypeMetatable(l,constructor, typeof(ResourceMgr));
	}
}
