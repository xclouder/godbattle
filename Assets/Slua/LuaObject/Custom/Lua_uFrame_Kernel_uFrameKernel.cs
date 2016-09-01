using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_uFrame_Kernel_uFrameKernel : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnDestroy(IntPtr l) {
		try {
			uFrame.Kernel.uFrameKernel self=(uFrame.Kernel.uFrameKernel)checkSelf(l);
			self.OnDestroy();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ResetKernel(IntPtr l) {
		try {
			uFrame.Kernel.uFrameKernel self=(uFrame.Kernel.uFrameKernel)checkSelf(l);
			self.ResetKernel();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int InstantiateSceneAsyncAdditively_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			var ret=uFrame.Kernel.uFrameKernel.InstantiateSceneAsyncAdditively(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int DestroyKernel_s(IntPtr l) {
		try {
			System.String a1;
			checkType(l,1,out a1);
			uFrame.Kernel.uFrameKernel.DestroyKernel(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_IsKernelLoaded(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,uFrame.Kernel.uFrameKernel.IsKernelLoaded);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_IsKernelLoaded(IntPtr l) {
		try {
			bool v;
			checkType(l,2,out v);
			uFrame.Kernel.uFrameKernel.IsKernelLoaded=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Instance(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,uFrame.Kernel.uFrameKernel.Instance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_Instance(IntPtr l) {
		try {
			uFrame.Kernel.uFrameKernel v;
			checkType(l,2,out v);
			uFrame.Kernel.uFrameKernel.Instance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Container(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,uFrame.Kernel.uFrameKernel.Container);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_EventAggregator(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,uFrame.Kernel.uFrameKernel.EventAggregator);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_EventAggregator(IntPtr l) {
		try {
			uFrame.Kernel.IEventAggregator v;
			checkType(l,2,out v);
			uFrame.Kernel.uFrameKernel.EventAggregator=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_SystemLoaders(IntPtr l) {
		try {
			uFrame.Kernel.uFrameKernel self=(uFrame.Kernel.uFrameKernel)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.SystemLoaders);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_Services(IntPtr l) {
		try {
			uFrame.Kernel.uFrameKernel self=(uFrame.Kernel.uFrameKernel)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.Services);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"uFrame.Kernel.uFrameKernel");
		addMember(l,OnDestroy);
		addMember(l,ResetKernel);
		addMember(l,InstantiateSceneAsyncAdditively_s);
		addMember(l,DestroyKernel_s);
		addMember(l,"IsKernelLoaded",get_IsKernelLoaded,set_IsKernelLoaded,false);
		addMember(l,"Instance",get_Instance,set_Instance,false);
		addMember(l,"Container",get_Container,null,false);
		addMember(l,"EventAggregator",get_EventAggregator,set_EventAggregator,false);
		addMember(l,"SystemLoaders",get_SystemLoaders,null,true);
		addMember(l,"Services",get_Services,null,true);
		createTypeMetatable(l,null, typeof(uFrame.Kernel.uFrameKernel),typeof(UnityEngine.MonoBehaviour));
	}
}
