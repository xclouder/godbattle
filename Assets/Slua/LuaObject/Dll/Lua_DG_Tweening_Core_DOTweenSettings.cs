using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_DOTweenSettings : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings o;
			o=new DG.Tweening.Core.DOTweenSettings();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_AssetName(IntPtr l) {
		try {
			pushValue(l,true);
			pushValue(l,DG.Tweening.Core.DOTweenSettings.AssetName);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useSafeMode(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useSafeMode);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useSafeMode(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useSafeMode=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_timeScale(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.timeScale);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_timeScale(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.timeScale=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_useSmoothDeltaTime(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.useSmoothDeltaTime);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_useSmoothDeltaTime(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.useSmoothDeltaTime=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_showUnityEditorReport(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.showUnityEditorReport);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_showUnityEditorReport(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.showUnityEditorReport=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_logBehaviour(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.logBehaviour);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_logBehaviour(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.LogBehaviour v;
			checkEnum(l,2,out v);
			self.logBehaviour=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_drawGizmos(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.drawGizmos);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_drawGizmos(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.drawGizmos=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultRecyclable(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultRecyclable);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultRecyclable(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.defaultRecyclable=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoPlay(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.defaultAutoPlay);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoPlay(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.AutoPlay v;
			checkEnum(l,2,out v);
			self.defaultAutoPlay=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultUpdateType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.defaultUpdateType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultUpdateType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.UpdateType v;
			checkEnum(l,2,out v);
			self.defaultUpdateType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultTimeScaleIndependent(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultTimeScaleIndependent);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultTimeScaleIndependent(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.defaultTimeScaleIndependent=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.defaultEaseType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.Ease v;
			checkEnum(l,2,out v);
			self.defaultEaseType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEaseOvershootOrAmplitude(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultEaseOvershootOrAmplitude);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEaseOvershootOrAmplitude(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.defaultEaseOvershootOrAmplitude=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultEasePeriod(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultEasePeriod);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultEasePeriod(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Single v;
			checkType(l,2,out v);
			self.defaultEasePeriod=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultAutoKill(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.defaultAutoKill);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultAutoKill(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			System.Boolean v;
			checkType(l,2,out v);
			self.defaultAutoKill=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_defaultLoopType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.defaultLoopType);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_defaultLoopType(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.LoopType v;
			checkEnum(l,2,out v);
			self.defaultLoopType=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_storeSettingsLocation(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			pushValue(l,true);
			pushEnum(l,(int)self.storeSettingsLocation);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_storeSettingsLocation(IntPtr l) {
		try {
			DG.Tweening.Core.DOTweenSettings self=(DG.Tweening.Core.DOTweenSettings)checkSelf(l);
			DG.Tweening.Core.DOTweenSettings.SettingsLocation v;
			checkEnum(l,2,out v);
			self.storeSettingsLocation=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.DOTweenSettings");
		addMember(l,"AssetName",get_AssetName,null,false);
		addMember(l,"useSafeMode",get_useSafeMode,set_useSafeMode,true);
		addMember(l,"timeScale",get_timeScale,set_timeScale,true);
		addMember(l,"useSmoothDeltaTime",get_useSmoothDeltaTime,set_useSmoothDeltaTime,true);
		addMember(l,"showUnityEditorReport",get_showUnityEditorReport,set_showUnityEditorReport,true);
		addMember(l,"logBehaviour",get_logBehaviour,set_logBehaviour,true);
		addMember(l,"drawGizmos",get_drawGizmos,set_drawGizmos,true);
		addMember(l,"defaultRecyclable",get_defaultRecyclable,set_defaultRecyclable,true);
		addMember(l,"defaultAutoPlay",get_defaultAutoPlay,set_defaultAutoPlay,true);
		addMember(l,"defaultUpdateType",get_defaultUpdateType,set_defaultUpdateType,true);
		addMember(l,"defaultTimeScaleIndependent",get_defaultTimeScaleIndependent,set_defaultTimeScaleIndependent,true);
		addMember(l,"defaultEaseType",get_defaultEaseType,set_defaultEaseType,true);
		addMember(l,"defaultEaseOvershootOrAmplitude",get_defaultEaseOvershootOrAmplitude,set_defaultEaseOvershootOrAmplitude,true);
		addMember(l,"defaultEasePeriod",get_defaultEasePeriod,set_defaultEasePeriod,true);
		addMember(l,"defaultAutoKill",get_defaultAutoKill,set_defaultAutoKill,true);
		addMember(l,"defaultLoopType",get_defaultLoopType,set_defaultLoopType,true);
		addMember(l,"storeSettingsLocation",get_storeSettingsLocation,set_storeSettingsLocation,true);
		createTypeMetatable(l,constructor, typeof(DG.Tweening.Core.DOTweenSettings),typeof(UnityEngine.ScriptableObject));
	}
}
