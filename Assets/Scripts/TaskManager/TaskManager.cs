using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour {

	public static void Init(GameObject gameObjectToAttach)
	{
		gameObjectToAttach.AddComponent<TaskManager>();
	}

	private static TaskManager ins;
	public static TaskManager Instance
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
