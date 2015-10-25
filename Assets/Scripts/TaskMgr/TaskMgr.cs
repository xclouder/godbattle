using UnityEngine;
using System.Collections;

public class TaskMgr : MonoBehaviour {

	public static void Init(GameObject gameObjectToAttach)
	{
		gameObjectToAttach.AddComponent<TaskMgr>();
	}

	private static TaskMgr ins;
	public static TaskMgr Instance
	{
		get {

			if (ins == null)
			{
				throw new System.InvalidOperationException("You should call Init(obj) first before get singleton");
			}

			return ins;
		}
	}

	public static Coroutine StartCoroutine(IEnumerator routine)
	{
		return StartCoroutine(routine);
	}
}
