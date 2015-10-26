using UnityEngine;
using System.Collections;
using NUnit.Framework;

[TestFixture]
[Category("Event Dispatch Test")]
public class TestEventDispatcher {
	
	[Test]
	public void TestBaseListenAndFire()
	{
		EventDispatcher.Cleanup();

		int callCount = 0;
		EventDispatcher.AddListener("TestEventA", ()=>{
			callCount++;
		});

		EventDispatcher.Fire("TestEvent"); // not increased
		Assert.AreEqual(0, callCount);
		EventDispatcher.Fire("TestEventA"); // increased
		Assert.AreEqual(1, callCount);

		Assert.Throws(typeof(DispatchEventException), () => {
			EventDispatcher.Fire<int>("TestEventA", 1);
		} );

		EventDispatcher.Fire("TestEventA"); // increased
		Assert.AreEqual(2, callCount);

	}

	[Test]
	public void TestRemoveListener()
	{
		EventDispatcher.Cleanup();

		int callCount = 0;

		EventHandler cb = () => {
			callCount++;
		};
		var myDel = EventDispatcher.AddListener("TestEventA", cb);
		
		EventDispatcher.Fire("TestEventA"); // increased
		Assert.AreEqual(1, callCount);

		Debug.Log("myDel name:" +myDel.eventName + ", type:" + myDel.handler.GetType());
		EventDispatcher.RemoveListener(myDel);

		EventDispatcher.Fire("TestEventA"); // increased
		Assert.AreEqual(1, callCount);



		bool f1Called = false;
		bool f2Called = false;
		EventDispatcher.AddListener("A", ()=>{
			f1Called = true;
		});
		var d = EventDispatcher.AddListener("A", ()=>{
			f2Called = true;
		});

		EventDispatcher.RemoveListener(d);
		EventDispatcher.Fire("A");

		Assert.IsTrue(f1Called);
		Assert.IsFalse(f2Called);
	}
	
}
