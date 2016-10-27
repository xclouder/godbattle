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

	public void Write(byte[] bytes)
	{
		var len = bytes.Length;
		if (bytes == null || len == 0)
		{
			throw new System.Exception("bytes is empty");
		}

		if (len > short.MaxValue)
		{
			throw new System.Exception("packet size is out of limit");
		}

		short len_ = (short)len;
		var data = GetNetworkOrderBytes(len_);

		buff.Write(data, 0, data.Length);
		buff.Write(bytes, 0, len);
	}

	//Obsolute
	public void WriteInt(int val)
	{
		var data = GetNetworkOrderBytes(val);
		buff.Write(data, 0, data.Length);
	}

	//Obsolute
	public void WriteBytes(byte[] bytes)
	{
		buff.Write(bytes, 0, bytes.Length);
	}

	protected byte[] GetNetworkOrderBytes(int val)
	{
		var v = System.Net.IPAddress.HostToNetworkOrder(val);
		return System.BitConverter.GetBytes(v);
	}

	protected byte[] GetNetworkOrderBytes(short val)
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
