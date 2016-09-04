using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_uFrame_IOC_UFrameContainer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer o;
			o=new uFrame.IOC.UFrameContainer();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResolveAll(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			var ret=self.ResolveAll(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Clear(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			self.Clear();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Inject(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Object a1;
			checkType(l,2,out a1);
			self.Inject(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Register(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Type a2;
			checkType(l,3,out a2);
			System.String a3;
			checkType(l,4,out a3);
			self.Register(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterInstance(IntPtr l) {
		try {
			int argc = LuaDLL.lua_gettop(l);
			if(argc==4){
				uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				System.Boolean a3;
				checkType(l,4,out a3);
				self.RegisterInstance(a1,a2,a3);
				pushValue(l,true);
				return 1;
			}
			else if(argc==5){
				uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
				System.Type a1;
				checkType(l,2,out a1);
				System.Object a2;
				checkType(l,3,out a2);
				System.String a3;
				checkType(l,4,out a3);
				System.Boolean a4;
				checkType(l,5,out a4);
				self.RegisterInstance(a1,a2,a3,a4);
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
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Resolve(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.String a2;
			checkType(l,3,out a2);
			System.Boolean a3;
			checkType(l,4,out a3);
			System.Object[] a4;
			checkParams(l,5,out a4);
			var ret=self.Resolve(a1,a2,a3,a4);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int CreateInstance(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Object[] a2;
			checkParams(l,3,out a2);
			var ret=self.CreateInstance(a1,a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InjectAll(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			self.InjectAll();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int RegisterRelation(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Type a2;
			checkType(l,3,out a2);
			System.Type a3;
			checkType(l,4,out a3);
			self.RegisterRelation(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResolveRelation(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			System.Type a1;
			checkType(l,2,out a1);
			System.Type a2;
			checkType(l,3,out a2);
			System.Object[] a3;
			checkParams(l,4,out a3);
			var ret=self.ResolveRelation(a1,a2,a3);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Mappings(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Mappings);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Mappings(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			uFrame.IOC.TypeMappingCollection v;
			checkType(l,2,out v);
			self.Mappings=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Instances(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Instances);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Instances(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			uFrame.IOC.TypeInstanceCollection v;
			checkType(l,2,out v);
			self.Instances=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_RelationshipMappings(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.RelationshipMappings);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_RelationshipMappings(IntPtr l) {
		try {
			uFrame.IOC.UFrameContainer self=(uFrame.IOC.UFrameContainer)checkSelf(l);
			uFrame.IOC.TypeRelationCollection v;
			checkType(l,2,out v);
			self.RelationshipMappings=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"uFrame.IOC.UFrameContainer");
		addMember(l,ResolveAll);
		addMember(l,Clear);
		addMember(l,Inject);
		addMember(l,Register);
		addMember(l,RegisterInstance);
		addMember(l,Resolve);
		addMember(l,CreateInstance);
		addMember(l,InjectAll);
		addMember(l,RegisterRelation);
		addMember(l,ResolveRelation);
		addMember(l,"Mappings",get_Mappings,set_Mappings,true);
		addMember(l,"Instances",get_Instances,set_Instances,true);
		addMember(l,"RelationshipMappings",get_RelationshipMappings,set_RelationshipMappings,true);
		createTypeMetatable(l,constructor, typeof(uFrame.IOC.UFrameContainer));
	}
}
