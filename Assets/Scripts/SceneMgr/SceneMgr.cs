using UnityEngine;
using System.Collections;

public class SceneMgr : MonoBehaviour {

	public static void LoadScene(string sceneName, string transition = "FadeTransition")
	{
		var path = "Transitions/" + transition;
		TaskMgr.StartCoroutineOnGlobalObject(DoLoadScene(sceneName, path));
	}

	private static IEnumerator DoLoadScene(string sceneName, string transitionPath)
	{
		var req = Resources.LoadAsync<GameObject>(transitionPath);
		yield return req;
		var prefab = req.asset as GameObject;

		var transitionObj = GameObject.Instantiate<GameObject>(prefab);
		var tr = transitionObj.GetComponent<SceneTransition>();
		tr.targetSceneName = sceneName;

	}
}
