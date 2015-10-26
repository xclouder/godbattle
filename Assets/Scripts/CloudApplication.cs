using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudApplication {

	private GameObject globalAppObject;
	static private CloudApplication ins;

	public static void Initialize()
	{
		ins = new CloudApplication();

		globalAppObject = new GameObject("Application");
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
