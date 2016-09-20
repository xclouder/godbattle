using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_PathMode : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"DG.Tweening.PathMode");
		addMember(l,0,"Ignore");
		addMember(l,1,"Full3D");
		addMember(l,2,"TopDown2D");
		addMember(l,3,"Sidescroller2D");
		LuaDLL.lua_pop(l, 1);
	}
}
