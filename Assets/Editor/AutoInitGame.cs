using UnityEngine;
using UnityEditor;
using System.Collections;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class AutoInitGame {
	/*
	#if UNITY_EDITOR
	static AutoInitGame()
	{
		EditorApplication.playmodeStateChanged = () =>
		{

			if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
			{
				var gameManagerObj = GameObject.Find(CloudApplication.GLOBAL_OBJECT_NAME);
				
				if (gameManagerObj == null)
				{
					Debug.LogWarning("I create 'Application' automatically! When quite playMode, I will destroy the 'Application' when quit, dont worry");
					
					gameManagerObj = new GameObject(CloudApplication.GLOBAL_OBJECT_NAME);
					var setup = gameManagerObj.AddComponent<InitGame>();
					setup.isAutoCreatedInEditorRuntime = true;
				}
			}
			
			if (!EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
			{
				var gameManagerObj = GameObject.Find(CloudApplication.GLOBAL_OBJECT_NAME);
				if (gameManagerObj != null)
				{
					var setup = gameManagerObj.GetComponent<InitGame>();
					if (setup != null && setup.isAutoCreatedInEditorRuntime)
						GameObject.DestroyImmediate(gameManagerObj);
				}
			}
		};
	}
	#endif

*/
	
}