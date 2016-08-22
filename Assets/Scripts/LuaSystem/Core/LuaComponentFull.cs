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
using SLua;

[CustomLuaClass]
public class LuaComponentFull : LuaComponent
{

	void FixedUpdate()
	{
		if (uFrameKernel.IsKernelLoaded)
			CallLuaMethod("FixedUpdate");
	}

	void LateUpdate()
	{
		if (uFrameKernel.IsKernelLoaded)
			CallLuaMethod("LateUpdate");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (uFrameKernel.IsKernelLoaded)
			CallLuaMethod("OnTriggerEnter2D", false, collider);
	}

}