using UnityEngine;
using System.Collections;


public class PacketReceiver : IPacketReceiver {


	private PacketReader packetReader;

	public void AddPacketListener(PacketReader.OnReceivePacket onReceivePkt)
	{
		packetReader.onReceivePacket += onReceivePkt;
	}

	private INetworkInterface netInterface;

	public PacketReceiver(INetworkInterface netInterface)
	{
		packetReader = new PacketReader();

		this.netInterface = netInterface;
		netInterface.onReceive += OnReceiveData;
	}

	public void Process()
	{
//		netInterface.pro
	}


	private void OnReceiveData(SocketBuffer buffer, int offset, int length)
	{
		var currLen = length;
		var currOffset = offset;
		while (packetReader.IsDataEngoughToRead(currLen))
		{
			int readCount = packetReader.Read(buffer, currOffset, currLen);
			buffer.SetBytesUsed(readCount);

			currLen -= readCount;
			currOffset += readCount;
		}
	}

}
