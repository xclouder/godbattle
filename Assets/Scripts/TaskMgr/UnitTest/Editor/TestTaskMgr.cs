using UnityEngine;
using System.Collections;
using NUnit.Framework;

[TestFixture]
[Category("Task Manager Test")]
public class TestTaskMgr {

	[Test]
	public void TestMainThreadDispatch()
	{

		GameObject o = new GameObject("Test_MainThreadDispatch");
		TaskMgr.Init(o);

		TaskMgr.DispatchOnMainThread(()=>{

			Debug.Log("A");

		});
		Debug.Log("A-B");

		bool a = false;

		System.Threading.ThreadPool.QueueUserWorkItem((object s)=>{

			a = true;
			System.Threading.Thread.Sleep(1000);
			Debug.Log("B");
			
			TaskMgr.DispatchOnMainThread(() => {
				Debug.Log("C");
			});
		});


		while (!a)
		{
			System.Threading.Thread.Sleep(200);
			Debug.Log("wait for thread B");
		}

		GameObject.DestroyImmediate(o);

	}
}
