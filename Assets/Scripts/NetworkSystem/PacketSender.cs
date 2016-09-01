using UnityEngine;
using System.Collections;

public class PacketSender {

	public void Send(INetworkInterface i, Packet packet)
	{
		var buffer = new Packet();

		var data = packet.ToBytes();
		var len = data.Length;

		Debug.Log("send data with len:" + len);

		buffer.WriteInt(len);
		buffer.WriteBytes(data);

		i.Send(buffer.ToBytes());
	}

	private Packet GetBuffer()
	{
		return new Packet();
	}
}
