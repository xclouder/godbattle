using UnityEngine;
using System.Collections;
using SLua;

public class SLuaCustomClassExport : ICustomExportPost {

	public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
	{
		Debug.Log("OnAddCustomClass:SluaCustomClassExport");
		add(typeof(ResourceMgr), null);
		add(typeof(System.Action<UnityEngine.Object>), null);
		add(typeof(System.Action<LuaTable>), null);

		//uframe export to lua
		add(typeof(uFrame.Kernel.uFrameKernel), null);
		add(typeof(uFrame.IOC.UFrameContainer), null);
		add(typeof(NetworkService), null);
	}
}
