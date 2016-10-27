using UnityEngine;
using System.Collections;

public class PacketSender {

	public void Send(INetworkInterface i, Packet packet)
	{
		var buffer = new Packet();

		var data = packet.ToBytes();
		var len = data.Length;

		Debug.Log("send data with len:" + len);
		Debug.Log("send data with data:" + data);
		
		buffer.Write(data);

		i.Send(buffer.ToBytes());
	}

	private Packet GetBuffer()
	{
		return new Packet();
	}
}
