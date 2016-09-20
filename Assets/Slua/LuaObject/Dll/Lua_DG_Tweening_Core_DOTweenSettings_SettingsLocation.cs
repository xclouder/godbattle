using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_DOTweenSettings_SettingsLocation : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.Core.DOTweenSettings.SettingsLocation");
		addMember(l,0,"AssetsDirectory");
		addMember(l,1,"DOTweenDirectory");
		addMember(l,2,"DemigiantDirectory");
		LuaDLL.lua_pop(l, 1);
	}
}
