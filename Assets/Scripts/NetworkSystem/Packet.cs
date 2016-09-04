using UnityEngine;
using System.Collections;
using System.IO;

public class Packet {

	protected MemoryStream buff;
	protected BinaryReader reader;
	public Packet()
	{
		buff = new MemoryStream();
	}

	public void WriteInt(int val)
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

	public void SetBytes(byte[] bytes)
	{
//		buff.Seek(0, SeekOrigin.Begin);
//		WriteBytes(bytes);

		buff = new MemoryStream(bytes);
		reader = new BinaryReader(buff);
	}

	public int ReadInt()
	{
		return (int)reader.ReadInt32();
	}

	public byte[] ReadBytes(int len)
	{
		return reader.ReadBytes(len);
	}

	public byte[] ToBytes()
	{
		return buff.ToArray();
	}
}
