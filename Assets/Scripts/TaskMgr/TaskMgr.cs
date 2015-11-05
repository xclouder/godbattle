using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public delegate void CallbackBlock();

public class TaskMgr : MonoBehaviour {

	public MainThreadTaskQueue GetMainThreadTaskQueue()
	{
		return MainThreadTaskQueue.Instance;
	}

	public static void Init(GameObject gameObjectToAttach)
	{
		if (ins == null)
		{
			ins = gameObjectToAttach.AddComponent<TaskMgr>();

			MainThreadWatchdog.Init();
			ins.GetMainThreadTaskQueue().Start();
		}
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

	#region Help Methods
	public static bool IsInMainThread
	{
		get {
			return MainThreadWatchdog.CheckIfMainThread();
		}
	}
	#endregion
	
	#region task related API
	public static Task DispatchOnMainThread(CallbackBlock cb)
	{
		return MainThreadTaskQueue.Instance.AddTask(cb);
	}
	
	public static void Dispatch(CallbackBlock action, CallbackBlock onCompletion, bool callOnCompletionOnMainThread = false)
	{
		ThreadPool.QueueUserWorkItem((object state) => {

			if (action != null)
			{
				action();
			}

			if (onCompletion != null)
			{
				if (callOnCompletionOnMainThread)
				{
					DispatchOnMainThread(onCompletion);	
				}
				else
				{
					onCompletion();
				}
			}

		});
	}
	#endregion


}
