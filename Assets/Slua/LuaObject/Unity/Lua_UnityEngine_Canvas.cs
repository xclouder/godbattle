﻿using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_Canvas : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			UnityEngine.Canvas o;
			o=new UnityEngine.Canvas();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int GetDefaultCanvasMaterial_s(IntPtr l) {
		try {
			var ret=UnityEngine.Canvas.GetDefaultCanvasMaterial();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int ForceUpdateCanvases_s(IntPtr l) {
		try {
			UnityEngine.Canvas.ForceUpdateCanvases();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderMode(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.renderMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_renderMode(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			UnityEngine.RenderMode v;
			checkEnum(l,2,out v);
			self.renderMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_isRootCanvas(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.isRootCanvas);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_worldCamera(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.worldCamera);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_worldCamera(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			UnityEngine.Camera v;
			checkType(l,2,out v);
			self.worldCamera=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pixelRect(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pixelRect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_scaleFactor(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.scaleFactor);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_scaleFactor(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.scaleFactor=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_referencePixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.referencePixelsPerUnit);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_referencePixelsPerUnit(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.referencePixelsPerUnit=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_overridePixelPerfect(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.overridePixelPerfect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_overridePixelPerfect(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.overridePixelPerfect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_pixelPerfect(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.pixelPerfect);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_pixelPerfect(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.pixelPerfect=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_planeDistance(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.planeDistance);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_planeDistance(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			float v;
			checkType(l,2,out v);
			self.planeDistance=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_renderOrder(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.renderOrder);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_overrideSorting(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.overrideSorting);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_overrideSorting(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			bool v;
			checkType(l,2,out v);
			self.overrideSorting=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingOrder(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortingOrder);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingOrder(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.sortingOrder=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_targetDisplay(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.targetDisplay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_targetDisplay(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.targetDisplay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingGridNormalizedSize(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortingGridNormalizedSize);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingGridNormalizedSize(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.sortingGridNormalizedSize=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingLayerID(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortingLayerID);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingLayerID(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			int v;
			checkType(l,2,out v);
			self.sortingLayerID=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_cachedSortingLayerValue(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.cachedSortingLayerValue);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_sortingLayerName(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.sortingLayerName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_sortingLayerName(IntPtr l) {
		try {
			UnityEngine.Canvas self=(UnityEngine.Canvas)checkSelf(l);
			string v;
			checkType(l,2,out v);
			self.sortingLayerName=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Canvas");
		addMember(l,GetDefaultCanvasMaterial_s);
		addMember(l,ForceUpdateCanvases_s);
		addMember(l,"renderMode",get_renderMode,set_renderMode,true);
		addMember(l,"isRootCanvas",get_isRootCanvas,null,true);
		addMember(l,"worldCamera",get_worldCamera,set_worldCamera,true);
		addMember(l,"pixelRect",get_pixelRect,null,true);
		addMember(l,"scaleFactor",get_scaleFactor,set_scaleFactor,true);
		addMember(l,"referencePixelsPerUnit",get_referencePixelsPerUnit,set_referencePixelsPerUnit,true);
		addMember(l,"overridePixelPerfect",get_overridePixelPerfect,set_overridePixelPerfect,true);
		addMember(l,"pixelPerfect",get_pixelPerfect,set_pixelPerfect,true);
		addMember(l,"planeDistance",get_planeDistance,set_planeDistance,true);
		addMember(l,"renderOrder",get_renderOrder,null,true);
		addMember(l,"overrideSorting",get_overrideSorting,set_overrideSorting,true);
		addMember(l,"sortingOrder",get_sortingOrder,set_sortingOrder,true);
		addMember(l,"targetDisplay",get_targetDisplay,set_targetDisplay,true);
		addMember(l,"sortingGridNormalizedSize",get_sortingGridNormalizedSize,set_sortingGridNormalizedSize,true);
		addMember(l,"sortingLayerID",get_sortingLayerID,set_sortingLayerID,true);
		addMember(l,"cachedSortingLayerValue",get_cachedSortingLayerValue,null,true);
		addMember(l,"sortingLayerName",get_sortingLayerName,set_sortingLayerName,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Canvas),typeof(UnityEngine.Behaviour));
	}
}
