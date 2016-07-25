using System;
using System.Collections;
using System.Threading;

public class ConcurrentTaskQueue : TaskQueue {

	public override Task AddTask(CallbackBlock act)
	{
		return AddTask(act, null);
	}

	public virtual Task AddTask(CallbackBlock act, CallbackBlock onComplete, bool completCallbackOnMainThread = false)
	{
//		var t = new ActionTask(act, onComplete);
//		t.ShouldRunCompleteOnMainThread = completCallbackOnMainThread;
//		t.OwningQueue = this;
//
//		ThreadPool.QueueUserWorkItem((object s) => {
//			t.Start();
//		});
//		return t;
		return null;
	}

}
