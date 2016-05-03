using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitSceneOrigin : MonoBehaviour {

	public Text loadingTip;
	public ProgressBar progressBar;
	private InitTaskQueue taskQueue;

	// Use this for initialization
	void Start () {

		taskQueue = new InitTaskQueue();
		taskQueue.onComplete += OnInitCompleted;
		taskQueue.onProgress += UpdateProgress;
		taskQueue.onError += OnError;

		taskQueue.Add(new CoroutineTaskPhase(0f, 10f, "Init Game Resource Manager...", DoInitGameResourceMgr));
		taskQueue.Add(new CoroutineTaskPhase(10f, 15f, "Checking Update...", DoCheckUpdate));
		taskQueue.Add(new LoadResourceTaskPhase(15f, 100f, "Loading..."));
		taskQueue.Start();

	}

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

	#endregion
	
	#region CompleteHandler
	private void OnInitCompleted()
	{
		UpdateProgress(100f, "Update Completed.");
		SceneMgr.LoadScene("Login");
	}

	private void OnError(TaskPhase t, System.Exception e)
	{
		Debug.LogError(t.Message + " failed");
	}

	#endregion

	private void UpdateProgress(float percent, string msg)
	{
		if (!string.IsNullOrEmpty(msg))
			loadingTip.text = msg;

		progressBar.value = percent / 100f;
	}

}
