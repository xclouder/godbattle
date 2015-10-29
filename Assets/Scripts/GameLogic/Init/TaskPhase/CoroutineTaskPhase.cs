using System;
using System.Collections;

public class CoroutineTaskPhase : TaskPhase {

	private IEnumerator taskTodo;

	public CoroutineTaskPhase (float startPercent, float toPercent, string msg, Func<IEnumerator> taskBodyFunc)
	{
		InitProgressFrom = startPercent;
		InitProgressTo = toPercent;
		Message = msg;
		taskTodo = taskBodyFunc();
	}

	private IEnumerator CreateRealTaskBody(IEnumerator myTask)
	{
		Status = State.Started;
		if (myTask != null)
		{
			yield return TaskMgr.StartCoroutineOnGlobalObject(myTask);
		}
		else
		{
			throw new ArgumentNullException("taskFunc return null");
		}

		Status = State.Completed;

		UpdateLocalProgress(100f, null);
		FireOnComplete();
	}

	protected override void DoTask ()
	{
		if (taskTodo != null)
		{
			TaskMgr.StartCoroutineOnGlobalObject(CreateRealTaskBody(taskTodo));
		}

	}



}
