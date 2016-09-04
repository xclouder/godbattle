using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using Network.ImprovedInterface;

public class NetworkService : SystemServiceMonoBehavior {

	/// <summary>
	/// NetworkInterface
	/// NetworkService
	/// PacketReceiver
	/// ByteBuffer
	/// </summary>

	private NetworkInterface netInterface;
	private PacketSender packetSender;
	private PacketReceiver packetReceiver;

	public delegate void PacketHandlerDelegate(Packet p);
	public PacketHandlerDelegate PacketHandler;

	public override IEnumerator SetupAsync ()
	{
		netInterface = new NetworkInterface();
		packetSender = new PacketSender();
		packetReceiver = new PacketReceiver(netInterface);
		packetReceiver.AddPacketListener(OnReceivePacket);

		netInterface.ConnectTo("127.0.0.1", 50001);

		while (netInterface.State == ConnectionState.Connecting)
		{
			yield return null;
		}

		Debug.Log("Connected!");

		var data = System.Text.Encoding.ASCII.GetBytes("hello~");

		netInterface.Send(data);
		netInterface.StartReceive();
	}

	public void Send(Packet packet)
	{
		packetSender.Send(netInterface, packet);
	}

	private void OnReceivePacket(Packet packet)
	{
		//for test
		Publish(packet);
	}

	void OnDestroy()
	{
		if (netInterface != null)
		{
			netInterface.Dispose();
		}
	}
}
