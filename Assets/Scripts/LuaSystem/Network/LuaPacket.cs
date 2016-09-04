using UnityEngine;
using System.Collections;

[SLua.CustomLuaClass]
/// <summary>
/// Packet Struct:||PktLen|HeadLen|Head|Body||
/// PktLen = HeadLen.len + Head.len + Body.len
/// HeadLen = Head.len
/// </summary>
public class LuaPacket : Packet {

	public void WriteHead(SLua.ByteArray head)
	{
		WriteInt(head.data.Length);
		WriteBytes(head.data);
	}

	public void WriteBody(SLua.ByteArray body)
	{
		WriteBytes(body.data);
	}

	private int headLength = -1;
	public SLua.ByteArray ReadHead()
	{
		headLength = ReadInt();
		headLength = System.Net.IPAddress.NetworkToHostOrder(headLength);
		var head = ReadBytes(headLength);

		return new SLua.ByteArray(head);
	}

	public SLua.ByteArray ReadBody()
	{
		if (headLength < 0)
			throw new System.Exception("please ReadHead first");

		var bodyLen = (int)buff.Length - headLength - 4;

		if (bodyLen > 0)
		{
			var body = ReadBytes(bodyLen);
			return new SLua.ByteArray(body);
		}
		else
		{
			return null;
		}
	}
}
