using UnityEngine;
using System.Collections;

[SLua.CustomLuaClass]
/// <summary>
/// Packet Struct:||PktLen|HeadLen|Head|Body||
/// PktLen = HeadLen.len + Head.len + Body.len
/// HeadLen = Head.len
/// </summary>
public class LuaPacket : Packet {

	// public void WriteHead(SLua.ByteArray head)
	// {
	// 	WriteInt(head.data.Length);
	// 	WriteBytes(head.data);
	// }

	public void Write(SLua.ByteArray body)
	{
		this.Write(body.data);
	}

	public SLua.ByteArray ReadBody()
	{
		// var len = this.ReadBodyLen();
		// var body = this.ReadBytes(len);
		
		return new SLua.ByteArray(this.ToBytes());
	}
}
