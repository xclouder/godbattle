/*************************************************************************
 *  FileName: Test.cs
 *  Author: xClouder
 *  Create Time: 07/13/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class Test : uFrameComponent
{
	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		ResourceMgr.CreateInstanceAsync<GameObject>("AssetBundles/characters/Sphere", (go)=>{
			Debug.Assert(go != null, "go is null");
			go.transform.position = Vector3.zero;
		});
	}

}