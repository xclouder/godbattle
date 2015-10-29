using System;
using System.Collections;
using System.Collections.Generic;

public class GameResourceMgr {

	private static GameResourceMgr ins;

	public static GameResourceMgr Instance {
		get { 
			if (ins == null)
			{
				throw new InvalidOperationException("you should call Initlize first before get instance");
			}
			return ins;
		}
	}

	#region Init
	public static void Initliaze(Action callback)
	{
		ins = new GameResourceMgr();

		ins.Init(callback);
	}

	private void Init(Action callback)
	{
		//TODO: init code here


		TaskMgr.StartCoroutineOnGlobalObject(DoInit(callback));
	}

	private IEnumerator DoInit(Action callback)
	{
		yield return new UnityEngine.WaitForSeconds(0.5f);

		if (callback != null)
		{
			callback();
		}
	}

	#endregion

	public void CheckUpdate(Action<bool> cb)
	{
		UnityEngine.Debug.Log("Check resource update...");
	}

}
