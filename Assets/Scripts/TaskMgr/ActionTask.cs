using System;
using System.Collections;

public class ActionTask : Task {

	private CallbackBlock action;
	private CallbackBlock completeAction;
	public bool ShouldRunCompleteOnMainThread { get;set; }

	public ActionTask(CallbackBlock act)
	{
		action = act;
	}

	public ActionTask(CallbackBlock act, CallbackBlock onComplete)
	{
		completeAction = onComplete;
	}

	public override void Start()
	{
		State = Status.Started;

		if (action != null)
		{
			action();
		}

		State = Status.Completed;

		if (completeAction != null)
		{
			if (ShouldRunCompleteOnMainThread)
			{
				MainThreadTaskQueue.Instance.AddTask(completeAction);
			}
			else
			{
				completeAction();
			}

		}
	}


}
