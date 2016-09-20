using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Sequence : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Sequence");
		createTypeMetatable(l,null, typeof(DG.Tweening.Sequence),typeof(DG.Tweening.Tween));
	}
}
