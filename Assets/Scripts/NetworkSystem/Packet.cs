using UnityEngine;
using System.Collections;
using System.IO;

public class Packet {

	protected MemoryStream buff;

	public Packet()
	{
		buff = new MemoryStream();
	}

	//TODO luapacket如何不用override就能导出WriteInt方法？
	public virtual void WriteInt(int val)
	{
		var data = GetNetworkOrderBytes(val);
		buff.Write(data, 0, data.Length);
	}

	public void WriteBytes(byte[] bytes)
	{
		buff.Write(bytes, 0, bytes.Length);
	}

	protected byte[] GetNetworkOrderBytes(int val)
	{
		var v = System.Net.IPAddress.HostToNetworkOrder(val);
		return System.BitConverter.GetBytes(v);
	}


	public byte[] ToBytes()
	{
		return buff.ToArray();
	}
}
