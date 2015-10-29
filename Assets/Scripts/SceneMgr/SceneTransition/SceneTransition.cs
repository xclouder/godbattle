using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	[HideInInspector]
	public string targetSceneName;

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		StartCoroutine(DoTransition());
	}

	protected virtual IEnumerator DoTransition()
	{
		var enterTransitionCoroutine = EnterTransition();
		if (enterTransitionCoroutine != null)
		{
			yield return StartCoroutine(enterTransitionCoroutine);
		}

		//load scene
		var req = Application.LoadLevelAsync(targetSceneName);
		yield return req;

		//do preload actions
		var preloadCoroutine = DoPreloadActions();
		if (preloadCoroutine != null)
		{
			yield return StartCoroutine(preloadCoroutine);
		}

		//show next scene
		req.allowSceneActivation = true;

		var exitTransitionCoroutine = ExitTransition();
		if (exitTransitionCoroutine != null)
		{
			yield return StartCoroutine(exitTransitionCoroutine);
		}

		Destroy(gameObject);
	}

	public static float SmoothProgress(float startOffset, float duration, float time) {
		return Mathf.SmoothStep(0, 1, Progress(startOffset, duration, time));
	}
	
	public static float Progress(float startOffset, float duration, float time) {
		return Mathf.Clamp(time - startOffset, 0, duration) / duration;
	}

	protected virtual IEnumerator EnterTransition()
	{
		return null;
	}

	protected virtual IEnumerator DoPreloadActions()
	{
		return null;
	}

	protected virtual IEnumerator ExitTransition()
	{
		return null;
	}

}
