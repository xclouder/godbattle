using UnityEngine;
using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_DG_Tweening_Core_Extensions : LuaObject {
	static public void reg(IntPtr l) {
		getTypeTable(l,"DG.Tweening.Core.Extensions");
		createTypeMetatable(l,null, typeof(DG.Tweening.Core.Extensions));
	}
}
