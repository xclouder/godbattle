using UnityEngine;
using System.Collections;
using SLua;

public class LuaClassExport : ICustomExportPost {

	public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
	{
		Debug.Log("OnAddCustomClass:Game:LuaClassExport");
		add(typeof(SF.XInput), null);

        add(typeof(Camera2DFollow), null);

	}
}
