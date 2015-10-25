using UnityEngine;
using System.Collections;
using NUnit.Framework;

[TestFixture]
[Category("Event Dispatch Test")]
public class TestEventDispatcher {
	
	[Test]
	public void TestBaseListenAndFire()
	{
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
	
}
