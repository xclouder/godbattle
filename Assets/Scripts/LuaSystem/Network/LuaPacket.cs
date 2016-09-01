using UnityEngine;
using System.Collections;

[SLua.CustomLuaClass]
public class LuaPacket : Packet {

	public override void WriteInt (int val)
	{
		base.WriteInt (val);
	}

	public void WriteBlob(SLua.ByteArray byteArr)
	{
		WriteBytes(byteArr.data);
	}

}
