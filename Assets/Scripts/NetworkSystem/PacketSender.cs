using UnityEngine;
using System.Collections;

public class PacketSender {

	public void Send(INetworkInterface i, Packet packet)
	{
		i.Send(packet.ToBytes());
	}

	private Packet GetBuffer()
	{
		return new Packet();
	}
}
