using System;
using System.Collections;
using System.Collections.Generic;

public class InitTaskQueue {

	public delegate void OnProgressHandler(float progress, string msg);
	public delegate void OnErrorHandler(string msg, Exception exp);
	public delegate void OnCompleteHandler();

	public event OnCompleteHandler onComplete;
	public event OnProgressHandler onProgress;
	public event OnErrorHandler onError;

	public Queue<TaskPhase> taskPhases = new Queue<TaskPhase>();

	public void Add(TaskPhase t)
	{
		taskPhases.Enqueue(t);
	}

	public void Start()
	{
		RunNextTask();
	}

	private void RunNextTask()
	{
		if (taskPhases.Count > 0)
		{
			var t = taskPhases.Dequeue();
			t.onProgress += (float progress, string msg) => {
				if (onProgress != null)
				{
					onProgress(progress, msg);
				}
			};
			t.onComplete += () => {
				RunNextTask();
			};
			t.onFailed += (Exception e)=> {
				if (onError != null)
				{
					onError(t.Message, e);
				}
			};

			t.Start();

		}
		else
		{
			if (onComplete != null)
			{
				onComplete();
			}
		}
	}

}
