using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_ABSSequentiable : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.ABSSequentiable");
		createTypeMetatable(l,null, typeof(DG.Tweening.Core.ABSSequentiable));
	}
}
