using UnityEngine;
using uFrame.Kernel;
using UniRx;

public class ImprovedSceneManagementService : SceneManagementService {

	public override void Setup()
	{
		base.Setup ();

		this.OnEvent<SwitchSceneCommand>().Subscribe(_ =>
		{
				SwitchScene(_.FromSceneName, _.ToSceneName, _.Settings, _.RestrictToSingleScene, _.TranslateEffectName);
		});

	}


	private void SwitchScene(string fromScene, string toScene, ISceneSettings settings, bool restrictToSingleScene, string translateEffect = null)
	{
		//TODO:translateEffect

		if (!string.IsNullOrEmpty (fromScene)) {
			UnloadScene (fromScene);
		}

		Debug.Assert (toScene != null, "toscene should not be none");


		LoadScene (toScene, settings, restrictToSingleScene);
	}

}
