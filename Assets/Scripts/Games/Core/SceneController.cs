/*************************************************************************
 *  FileName: SceneController.cs
 *  Author: xClouder
 *  Create Time: 07/06/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UniRx;
using uFrame.IOC;

[RequireComponent(typeof(uFrame.Kernel.Scene))]
public class SceneController : uFrameComponent
{	
	public override void KernelLoaded()
    {
        base.KernelLoaded();

		//init container
		_sceneContainer = new SceneContainer();
		_CURR_CONTAINER = _sceneContainer;

		//bind events
		string sceneName = GetComponent<uFrame.Kernel.Scene>().GetType().Name;

		this.OnEvent<SceneLoaderEvent>().Where((_) => {
			if (_.SceneRoot == null)
				return false;

			return _.SceneRoot.Name == sceneName && _.State == SceneState.Loaded;
		
		}).Subscribe(_ =>{
            SceneLoaded();
        });
	}

	protected virtual void SceneLoaded() {}

	private SceneContainer _sceneContainer;
	public SceneContainer SceneContainer
	{
		get { return _sceneContainer; }
	}

	private static SceneContainer _CURR_CONTAINER;
	public static SceneContainer CurrentContainer
	{
		get { return _CURR_CONTAINER; }
	}
	protected override void OnDestroy()
	{
		base.OnDestroy();

		_CURR_CONTAINER = null;
	}
}