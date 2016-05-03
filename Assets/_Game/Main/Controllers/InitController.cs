using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.IOC;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.Serialization;
using UniRx;
using UnityEngine;

public class InitController : InitControllerBase {
    


	private InitViewModel vm;

	public override void InitializeInit(InitViewModel viewModel) {
        base.InitializeInit(viewModel);
        // This is called when a InitViewModel is created

		vm = viewModel;
    }

	public override void Setup ()
	{
		base.Setup ();

		OnEvent<LoadSceneCommand>().Subscribe(_ => {

			taskQueue = new InitTaskQueue();
			taskQueue.onComplete += OnInitCompleted;
			taskQueue.onProgress += UpdateProgress;
			taskQueue.onError += OnError;

			taskQueue.Add(new CoroutineTaskPhase(0f, 10f, "Init Game Resource Manager...", DoInitGameResourceMgr));
			taskQueue.Add(new CoroutineTaskPhase(10f, 15f, "Checking Update...", DoCheckUpdate));
			taskQueue.Add(new LoadResourceTaskPhase(15f, 90f, "Loading..."));
			taskQueue.Add(new CoroutineTaskPhase(90f, 100f, "Loading...", DoLoadLoginScene));
			taskQueue.Start();

		});
	}

	private InitTaskQueue taskQueue;


	#region Init Logics
	private IEnumerator DoInitGameResourceMgr()
	{

		bool finished = false;

		GameResourceMgr.Initliaze(() => {

			Debug.Log("GameResourceMgr Init Complete.");

			finished = true;

		});

		while (!finished)
		{
			yield return null;
		}

	}

	private IEnumerator DoCheckUpdate()
	{
		yield return new WaitForSeconds(0.5f);

		//		throw new UnityException("Connection failed.");
	}

	private IEnumerator DoLoadLoginScene()
	{
		//TODO LOAD LOGIN SCENE
	}

	#endregion
	#region CompleteHandler
	private void OnInitCompleted()
	{
		//		Publish(new LoadCompleteEvent());
	}

	private void OnError(TaskPhase t, System.Exception e)
	{
		UnityEngine.Debug.LogError(t.Message + " failed");
	}

	private void UpdateProgress(float percent, string msg)
	{
		vm.LoadProgressProperty.Value = percent;
		vm.LoadMessageProperty.Value = msg;
	}

	#endregion
}
