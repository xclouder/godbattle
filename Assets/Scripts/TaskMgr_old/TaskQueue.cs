using System;
using System.Collections;

public abstract class TaskQueue {

	public enum State
	{
		WaitForStart,
		Started,
		Paused,
		Completed
	}

	public abstract Task AddTask(CallbackBlock act);

	public static TaskQueue GetMainThreadTaskQueue()
	{
		return MainThreadTaskQueue.Instance;
	}

}
