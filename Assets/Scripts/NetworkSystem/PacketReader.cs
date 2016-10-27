using UnityEngine;
using System.Collections;

public class PacketReader {

	private const int HEAD_LEN = 2;

	private enum ReceiveState
	{
		ReadHead,
		ReadBody
	}

	private ReceiveState state;

	public PacketReader()
	{
		state = ReceiveState.ReadHead;
	}

	private int currentBodyLength;
	private byte[] headBuffer = new byte[HEAD_LEN];

	public bool IsDataEngoughToRead(int len)
	{
		if (state == ReceiveState.ReadHead)
			return len >= HEAD_LEN;

		return len >= currentBodyLength;
	}

	public delegate void OnReceivePacket(Packet packet);
	public event OnReceivePacket onReceivePacket;
	public int Read(SocketBuffer buffer, int offset, int len)
	{
		if (state == ReceiveState.ReadHead)
		{
			if (len >= HEAD_LEN)
			{
				buffer.CopyData(headBuffer, 0, offset, HEAD_LEN);

				//read packetLen
				currentBodyLength = GetInt16InNetworkOrderBytes(headBuffer);//System.BitConverter.ToInt32(headBuffer, 0);

				state = ReceiveState.ReadBody;

				return HEAD_LEN;
			}

			return 0;
		}
		else
		{
			if (len >= currentBodyLength)
			{
				byte[] bodyData = new byte[currentBodyLength];
				buffer.CopyData(bodyData, 0, offset, currentBodyLength);

				var packet = new LuaPacket();
				packet.SetBytes(bodyData);

				state = ReceiveState.ReadHead;

				if (onReceivePacket != null)
				{
					onReceivePacket(packet);
				}

				return currentBodyLength;
			}

			return 0;
		}
	}

	protected int GetInt32InNetworkOrderBytes(byte[] bytes)
	{
		var val = System.BitConverter.ToInt32(bytes, 0);

		return System.Net.IPAddress.NetworkToHostOrder(val);
	}

	protected int GetInt16InNetworkOrderBytes(byte[] bytes)
	{
		var val = System.BitConverter.ToInt16(bytes, 0);

		return System.Net.IPAddress.NetworkToHostOrder(val);
	}
}
