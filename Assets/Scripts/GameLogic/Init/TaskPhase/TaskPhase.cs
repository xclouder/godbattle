using System;
using System.Collections;

public abstract class TaskPhase {

	public enum State
	{
		WaitToRun,
		Started,
		Failed,
		Completed,
	}

	public float InitProgressFrom { get;set;}
	public float InitProgressTo { get;set;}
	public string Message { get;set; }
	public State Status { get; protected set;}
	public Exception Exceptions { get; protected set;}

	public delegate void OnComplete();
	public delegate void OnFailed(System.Exception e);
	public delegate void OnProgress(float progress, string msg);

	public event OnComplete onComplete;
	public event OnFailed onFailed;
	public event OnProgress onProgress;

	public void Start()
	{
		Status = State.WaitToRun;
		UpdateLocalProgress(0f, Message);

		DoTask();
	}

	protected abstract void DoTask();

	protected void UpdateLocalProgress(float percent, string msg)
	{
		if (onProgress != null)
		{
			var realPercent = InitProgressFrom + (InitProgressTo - InitProgressFrom) * percent / 100f;

			onProgress(realPercent, msg);
		}
	}

	protected void FireOnComplete()
	{
		if (onComplete != null)
			onComplete();
	}

	protected void FireOnFail(System.Exception e)
	{
		if (onComplete != null)
			onFailed(e);
	}

	protected void FireOnProgress(float percent, string msg)
	{
		onProgress(percent, msg);
	}
}
