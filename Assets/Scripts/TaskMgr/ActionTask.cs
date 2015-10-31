using System;
using System.Collections;

public class ActionTask : Task {

	private Action action;

	public ActionTask(Action act)
	{
		action = act;
	}

	public override void Start()
	{
		State = Status.Started;

		if (action != null)
		{
			action();
		}

		State = Status.Completed;
	}


}
