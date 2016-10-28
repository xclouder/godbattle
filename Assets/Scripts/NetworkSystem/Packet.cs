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
		var headData = GetNetworkOrderBytes(len_);

		Debug.Log("c# get len:" + len);
		Debug.Log("c# head len:" + headData.Length);
		Debug.Log("c# get data present:" + GetDataPresent(bytes));

		buff.Write(headData, 0, headData.Length);
		buff.Write(bytes, 0, len);

//		Debug.Log("c# packed data present(with head):" + GetDataPresent(bytes));

		Debug.Log("c# buffer len now:" + buff.Length);
		var arr = buff.ToArray();
		Debug.Log("c# buffer now:" + GetDataPresent(arr));
	}

	private string GetDataPresent(byte[] d)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		for (int i = 0; i < d.Length; i++)
		{
			sb.Append(d[i].ToString());
			sb.Append(" ");
		}

		return sb.ToString();
	}

	//Obsolute
	// public void WriteInt(int val)
	// {
	// 	var data = GetNetworkOrderBytes(val);
	// 	buff.Write(data, 0, data.Length);
	// }

	// //Obsolute
	// public void WriteBytes(byte[] bytes)
	// {
	// 	buff.Write(bytes, 0, bytes.Length);
	// }

	// protected byte[] GetNetworkOrderBytes(int val)
	// {
	// 	var v = System.Net.IPAddress.HostToNetworkOrder(val);
	// 	return System.BitConverter.GetBytes(v);
	// }

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

	protected int ReadBodyLen()
	{
		return (int)reader.ReadInt16();
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
