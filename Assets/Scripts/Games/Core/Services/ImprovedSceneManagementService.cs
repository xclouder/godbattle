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

		Debug.Assert (toScene != null, "toscene should not be none");
		UnloadScene(fromScene);
		LoadScene (toScene, settings, restrictToSingleScene);

		// OnEvent<SceneLoaderEvent>().Where(_ => 
		// 	_.State == SceneState.Loaded && _.SceneRoot.Name == toScene
		// ).Subscribe((_)=>{
		// 	if (!string.IsNullOrEmpty (fromScene)) {
		// 		UnloadScene (fromScene);
		// 	}
		// });


	}

}
