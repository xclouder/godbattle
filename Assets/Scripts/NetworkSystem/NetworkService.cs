using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using uFrame.Kernel;

public class NetworkService : SystemServiceMonoBehavior {

	/// <summary>
	/// NetworkInterface
	/// NetworkService
	/// PacketReceiver
	/// ByteBuffer
	/// </summary>


//	public delegate void PacketHandlerDelegate(Packet p);
//	public PacketHandlerDelegate PacketHandler;

	public string ip = "127.0.0.1";
	public int port = 8888;

	public override IEnumerator SetupAsync ()
	{
		return base.SetupAsync();
	}

//	public void Send(Packet packet)
//	{
//		
//	}
//
//	private void OnReceivePacket(Packet packet)
//	{
//		//for test
//		Publish(packet);
//	}

	protected override void OnDestroy()
	{
		base.OnDestroy();

	}
}
