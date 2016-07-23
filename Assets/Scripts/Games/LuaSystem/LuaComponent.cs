/*************************************************************************
 *  FileName: LuaComponent.cs
 *  Author: xClouder
 *  Create Time: 07/22/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class LuaComponent : uFrameComponent
{
	private LuaService luaService;

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		luaService = uFrameKernel.Container.Resolve<LuaService> ();

		if (luaService == null)
			throw new System.Exception ("No Lua Service found!");
	}

	public object RunFile(string name)
	{
		Debug.Assert (luaService != null);

		return luaService.RunFile (name);
	}
}