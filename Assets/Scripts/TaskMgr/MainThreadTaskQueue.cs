using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainThreadTaskQueue : TaskQueue {

	private IList<Task> taskQueue = new List<Task>();
	private MainThreadTaskQueue() {}

	private static MainThreadTaskQueue ins;
	static MainThreadTaskQueue (){
		ins = new MainThreadTaskQueue();
	}
	public static MainThreadTaskQueue Instance {
		get { return ins; }
	}


	public override Task AddTask (CallbackBlock act)
	{
		var task = new ActionTask(act);
		if (TaskMgr.IsInMainThread)
		{
			task.Start();
		}
		else
		{
			taskQueue.Add(task);
		}

		return task;
	}

	public void Start ()
	{
		TaskMgr.StartCoroutineOnGlobalObject(UpdateQueue());
	}

	private IEnumerator UpdateQueue()
	{
		while (true)
		{
			if (taskQueue.Count > 0)
			{
				foreach (var t in taskQueue)
				{
					t.Start();
				}
			}

			yield return new WaitForSeconds(0.05f);
		}
	}
}
