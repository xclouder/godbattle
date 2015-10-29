using UnityEngine;
using System.Collections;

public class SceneMgr : MonoBehaviour {

	private static string TRANSITION_DIR = "Transitions/";

	public static void LoadScene(string sceneName, string transition = "FadeTransition")
	{
		var path = TRANSITION_DIR + transition;
		TaskMgr.StartCoroutineOnGlobalObject(DoLoadScene(sceneName, path, null));
	}

	public static void LoadScene(string sceneName, IEnumerator coroutineWhileLoading, string transition = "FadeTransition")
	{
		var path = TRANSITION_DIR + transition;
		TaskMgr.StartCoroutineOnGlobalObject(DoLoadScene(sceneName, path, coroutineWhileLoading));
	}

	private static IEnumerator DoLoadScene(string sceneName, string transitionPath, IEnumerator corutineWhileLoading)
	{
		var req = Resources.LoadAsync<GameObject>(transitionPath);
		yield return req;
		var prefab = req.asset as GameObject;

		var transitionObj = GameObject.Instantiate<GameObject>(prefab);
		var tr = transitionObj.GetComponent<SceneTransition>();
		tr.targetSceneName = sceneName;
	}
}
