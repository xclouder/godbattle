/*************************************************************************
 *  FileName: UpdateChecker.cs
 *  Author: xClouder
 *  Create Time: #CreateTime#
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;

public class UpdateChecker
{
	public void Check(System.Version localVersion, System.Action<UpdateCheckResult> onFinish)
	{
		var res = new UpdateCheckResult();
		onFinish(res);
	}
}

public class UpdateCheckResult
{
	public bool ShouldForceUpdate { get;set; }
	public System.Version NewestVersion {get;set;}
	
}