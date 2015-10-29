using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InitScene : MonoBehaviour {

	public Text loadingTip;
	public ProgressBar progressBar;

	// Use this for initialization
	void Start () {

		UpdateProgress(0f, "Initializing...");
		GameResourceMgr.Initliaze(() => {

			Debug.Log("GameResourceMgr Init Complete.");

			CheckUpdate();

		});
	}

	#region Check Resource Update
	private void CheckUpdate()
	{
		UpdateProgress(10f, "Checking update...");
	}

	private void OnResourceLoadCompleted()
	{
		UpdateProgress(100f, "Update Completed.");
	}

	#endregion

	private void UpdateProgress(float percent, string msg)
	{
		loadingTip.text = msg;
		progressBar.value = percent / 100f;
	}

}
