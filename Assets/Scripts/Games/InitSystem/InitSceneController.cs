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
using UniRx;

public class InitSceneController : SceneController
{

	public ProgressBar progressBar;
	public UnityEngine.UI.Text tipLabel;

	protected override void SceneLoaded()
	{
		base.SceneLoaded();

		var updateService = uFrameKernel.Container.Resolve<GameUpdateService>();

		InitUI();
		
		StartCoroutine(updateService.CheckUpdate((type) => {
			Debug.Log("need update, type:" + type);
			if (type == GameUpdateService.UpdateType.NoNeed)
			{
				UpdateFinish();
				return;
			}

			tipLabel.text = "正在更新...";

			StartCoroutine(updateService.UpdateAssetBundles((progress) => {

				Debug.Log("update progress:" + progress);
				progressBar.value = progress;

				if (progress == 1)
				{
					UpdateFinish();
				}
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

	private void InitUI()
	{
		progressBar.value = 0f;
		tipLabel.text = "正在检测更新";
	}

	private void UpdateFinish()
	{
		progressBar.value = 1f;
		tipLabel.text = "祝您游戏愉快";

		Observable.Timer(new System.TimeSpan(1000L)).Subscribe(_ => {

			Publish(new LoadSceneCommand() {

				SceneName = "MainScene"

			});

		});
	}
}