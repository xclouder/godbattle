using UnityEngine;
using System.Collections;
using System.Threading;

public class TaskMgr : MonoBehaviour {

	public static void Init(GameObject gameObjectToAttach)
	{
		if (ins == null)
			ins = gameObjectToAttach.AddComponent<TaskMgr>();
		else
			throw new System.InvalidOperationException("TaskMgr has been initialized before.");
	}

	private static TaskMgr ins;
	public static TaskMgr Instance
	{
		get {

			if (ins == null)
			{
				throw new System.InvalidOperationException("You should call Init(obj) first before get singleton.");
			}

			return ins;
		}
	}

	#region Helper Methods
	public static Coroutine StartCoroutineOnGlobalObject(IEnumerator routine)
	{
		return ins.StartCoroutine(routine);
	}
	#endregion

	public Task CreateTask()
	{
		ThreadPool.QueueUserWorkItem(null);
		return new Task();
	}

}
