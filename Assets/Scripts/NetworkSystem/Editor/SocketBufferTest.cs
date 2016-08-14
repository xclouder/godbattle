using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;

public class SocketBufferTest {

	[Test]
	public void TestAddData()
	{
		var buffer = new SocketBuffer(10);

		Assert.AreEqual(10, buffer.BufferSize);
		Assert.AreEqual(0, buffer.ProducePosition);
		Assert.AreEqual(0, buffer.ConsumePosition);

		var data = System.Text.Encoding.ASCII.GetBytes("hello!");
		var result = buffer.AddData(data);

		Assert.AreEqual(6, buffer.ProducePosition);
		Assert.AreEqual(0, buffer.ConsumePosition);
		Assert.AreEqual(6, buffer.AvailableDataLength);
		Assert.AreEqual(4, buffer.AvailableSpace);
		Assert.IsTrue(result);

		//cannot add
		data = System.Text.Encoding.ASCII.GetBytes("world");

		result = buffer.AddData(data);
		Assert.IsTrue(!result);

		buffer.SetBytesUsed(4);

		data = System.Text.Encoding.ASCII.GetBytes("world123");
		result = buffer.AddData(data);

		Assert.IsTrue(result);
		Assert.AreEqual(4, buffer.ProducePosition);
		Assert.AreEqual(4, buffer.ConsumePosition);
		Assert.AreEqual(10, buffer.AvailableDataLength);
		Assert.AreEqual(0, buffer.AvailableSpace);

		var raw = buffer.RawBuffer;
		var echo = System.Text.Encoding.ASCII.GetString(raw);
		Debug.Log("echo:" + echo);

		buffer.SetBytesUsed(6);

		data = System.Text.Encoding.ASCII.GetBytes("456789");
		buffer.AddData(data);
		Assert.IsTrue(result);

		Assert.AreEqual(0, buffer.ProducePosition);
		Assert.AreEqual(0, buffer.ConsumePosition);
		Assert.AreEqual(10, buffer.AvailableDataLength);
		Assert.AreEqual(0, buffer.AvailableSpace);

		echo = System.Text.Encoding.ASCII.GetString(raw);
		Debug.Log("echo:" + echo);

		buffer.SetBytesUsed(6);

		data = System.Text.Encoding.ASCII.GetBytes("abc");
		buffer.AddData(data);

		Assert.AreEqual(3, buffer.ProducePosition);
		Assert.AreEqual(6, buffer.ConsumePosition);
		Assert.AreEqual(7, buffer.AvailableDataLength);
		Assert.AreEqual(3, buffer.AvailableSpace);

		echo = System.Text.Encoding.ASCII.GetString(raw);
		Debug.Log("echo:" + echo);


	}

	[Test]
	public void TestAddData2()
	{
		var buffer = new SocketBuffer(2048);
		var raw = buffer.RawBuffer;

		Assert.AreEqual(2048, buffer.BufferSize);
		Assert.AreEqual(0, buffer.ProducePosition);
		Assert.AreEqual(0, buffer.ConsumePosition);

		var data = System.Text.Encoding.ASCII.GetBytes("hello~");
		var result = buffer.AddData(data);

		Assert.AreEqual(6, buffer.ProducePosition);
		Assert.AreEqual(0, buffer.ConsumePosition);
		Assert.AreEqual(6, buffer.AvailableDataLength);
		Assert.AreEqual(2042, buffer.AvailableSpace);
		Assert.IsTrue(result);

		buffer.SetBytesUsed(6);

		data = System.Text.Encoding.ASCII.GetBytes("test");
		buffer.AddData(data);

		var desti = new byte[buffer.CurrentPickingDataLength];
		Array.Copy(raw, buffer.ConsumePosition, desti, 0, buffer.CurrentPickingDataLength);

		var text = System.Text.Encoding.ASCII.GetString(desti);
		Assert.AreEqual(text, "test");

		buffer.SetBytesUsed(4);

		data = System.Text.Encoding.ASCII.GetBytes("test");
		buffer.AddData(data);

		Array.Copy(raw, buffer.ConsumePosition, desti, 0, buffer.CurrentPickingDataLength);

		text = System.Text.Encoding.ASCII.GetString(desti);
		Assert.AreEqual(text, "test");

		buffer.SetBytesUsed(4);


	}
}
