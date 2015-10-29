using UnityEngine;
using System.Collections;

public class FadeTransition : SceneTransition {
	
	/// <summary>
	///  The fade time.
	/// </summary>
	public float duration = 1f;
	
	/// <summary>
	/// The overlay texture.
	/// </summary>
	public Texture overlayTexture;
	
	private float progress;
	
	void Awake() {
		if (overlayTexture == null) {
			Debug.LogError("Overlay texture is missing");
		}
	}

	protected override IEnumerator EnterTransition()
	{
		float t = 0f;

		while (t < duration)
		{
			progress = SmoothProgress(0f, duration, t);
			t += Time.deltaTime;

			yield return new WaitForEndOfFrame();
		}

	}

	protected override IEnumerator ExitTransition()
	{
		float t = 0f;
		
		while (t < duration)
		{
			progress = 1 - Mathf.Clamp01(t / duration);
			t += Time.deltaTime;
			
			yield return new WaitForEndOfFrame();
		}
	}
	
	public void OnGUI() {
		GUI.depth = 0;
		Color c = GUI.color;
		GUI.color = new Color(1, 1, 1, progress);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), overlayTexture);
		GUI.color = c;
	}	
}