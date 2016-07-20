/*************************************************************************
 *  FileName: InitSceneController.cs
 *  Author: xClouder
 *  Create Time: 07/20/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class InitSceneController : SceneController
{
	
	protected override void SceneLoaded()
	{
		base.SceneLoaded();

		var updateService = uFrameKernel.Container.Resolve<GameUpdateService>();
		
		StartCoroutine(updateService.CheckUpdate((type) => {
			Debug.Log("need update, type:" + type);

			StartCoroutine(updateService.UpdateAssetBundles((progress) => {

				Debug.Log("update progress:" + progress);
			}, 
			(updateErr) =>{
				Debug.LogError("update error:" + updateErr.Message);
			}
			));
		}, 
		(err) => {
			Debug.LogError("check update error:" + err.Message);
		}));
	}
}