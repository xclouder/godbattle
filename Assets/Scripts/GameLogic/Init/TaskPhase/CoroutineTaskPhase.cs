using System;
using System.Collections;

public class CoroutineTaskPhase : TaskPhase {

	private IEnumerator taskTodo;
	private Exception e;

	public CoroutineTaskPhase() {}
	public CoroutineTaskPhase (float startPercent, float toPercent, string msg, Func<IEnumerator> taskBodyFunc)
	{
		InitProgressFrom = startPercent;
		InitProgressTo = toPercent;
		Message = msg;
		taskTodo = taskBodyFunc();
	}

	private IEnumerator InternalRoutine(IEnumerator coroutine){
		while(true){
			try{
				if(!coroutine.MoveNext()){
					yield break;
				}
			}
			catch(Exception e){
				this.e = e;
				Status = State.Failed;

				FireOnFail(this.e);
				yield break;

			}

			yield return coroutine.Current;
		}
	}

	protected IEnumerator CreateRealTaskBody(IEnumerator myTask)
	{
		Status = State.Started;
		if (myTask != null)
		{
			yield return TaskMgr.StartCoroutineOnGlobalObject(InternalRoutine(myTask));
		}
		else
		{
			Status = State.Failed;
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
