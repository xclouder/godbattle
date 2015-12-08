using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudApplication {

	public static string GLOBAL_OBJECT_NAME = "Application";
	public static GameObject globalAppObject;
	static private CloudApplication ins;

	public static void Initialize(GameObject globalObj)
	{
		ins = new CloudApplication();

		globalAppObject = globalObj;
		GameObject.DontDestroyOnLoad(globalAppObject);

		//init Managers
		TaskMgr.Init(globalAppObject);
	}

	public static CloudApplication Instance{
		get {
			if (ins == null)
			{
				throw new System.InvalidOperationException("you should call Initialize first.");
			}
			return ins;
		}
	}

	private CloudApplication() {}
}
