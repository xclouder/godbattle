using UnityEngine;
using System.Collections;

public class MsgPacker : IMsgPacker {

	public MsgPacker()
	{
		this.m_SendBufferArray = new byte[NetworkConfig.MaxPacketSize];
		this.m_TdrSendBufferWriter = new DrWriteBuf(m_SendBufferArray, NetworkConfig.MaxPacketSize);
		this.m_HeadReader = new DrReadBuf();
	}

	private byte[] m_SendBufferArray;
	private DrWriteBuf m_TdrSendBufferWriter;

	#region IMsgPacker implementation
	public byte[] Pack (IMsg msg, out int len)
	{

		m_TdrSendBufferWriter.Set(m_SendBufferArray, NetworkConfig.MaxPacketSize, NetworkConfig.PacketHeaderSize);
		DrError.ErrorType Error = msg.Pack(m_TdrSendBufferWriter, 0);

		if (Error == DrError.ErrorType.DR_NO_ERROR)
		{
			len = m_TdrSendBufferWriter.GetUsedSize();
			byte[] bySendData = m_TdrSendBufferWriter.GetBeginPtr();

			WriteCSMsgHeader((ushort)(len - NetworkConfig.PacketHeaderSize));
			return bySendData;

		}
		else
		{
			Debug.LogError("pack msg data error!");
			len = 0;
			return null;
		}

	}

	private void WriteCSMsgHeader(ushort msgLen)
	{
		
		m_TdrSendBufferWriter.SetPosition(0);
		NetMsgHead head;
		head.unMsgLen = (ushort)System.Net.IPAddress.HostToNetworkOrder((short)msgLen);
		head.byCmd = 0;
		head.byFlag = 0;

		head.uiUid = 0u;//(uint)System.Net.IPAddress.HostToNetworkOrder((int)GameDataMgr.Instance.UID);// (uint)System.Net.IPAddress.HostToNetworkOrder((int)msg.stHead.uiUid);

		m_TdrSendBufferWriter.WriteUInt16(head.unMsgLen);
		m_TdrSendBufferWriter.WriteUInt8(head.byCmd);
		m_TdrSendBufferWriter.WriteUInt8(head.byFlag);
		m_TdrSendBufferWriter.WriteUInt32(head.uiUid);
	}


	private DrReadBuf m_HeadReader;
	public static DRCSMsg CSPkgInstance = GenerateMsgPkg();
	public IMsg Unpack (byte[] data, int len)
	{
		var msg = CSPkgInstance;

		m_HeadReader.Set(data, len);
		if (msg.stHead.unpack(m_HeadReader, 0) == DrError.ErrorType.DR_NO_ERROR)
		{
			Debug.Log(">>recv msgid:" + msg.stHead.unMsgID);

			int iPkgLen = 0;
			msg.stBody.construct((int)msg.stHead.unMsgID);

			DrError.ErrorType eRet = msg.unpack(data, len, ref iPkgLen, 0);

			if (DrError.ErrorType.DR_NO_ERROR == eRet)
			{
				return msg;
			}
		}

		return null;
	}
	#endregion

	private static DRCSMsg GenerateMsgPkg()
	{
		var pkg = new DRCSMsg();
		return pkg;
	}
}
