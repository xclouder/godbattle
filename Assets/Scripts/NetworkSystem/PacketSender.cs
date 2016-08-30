using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class PacketSender {

//	public bool Send(Message msg, NetworkInterface ni)
//	{
//		var idBytes = GetNetworkOrderBytes(msg.ID);
//
//		var contentBytes = System.Text.Encoding.UTF8.GetBytes(msg.Content);
//
//		var packageLen = idBytes.Length + contentBytes.Length;
//		var packageLenBytes = GetNetworkOrderBytes(packageLen);
//
//		var data = new byte[4 + packageLen];
//
//		Array.Copy(packageLenBytes, 0, data, 0, packageLenBytes.Length);
//		Array.Copy(idBytes, 0, data, packageLenBytes.Length, idBytes.Length);
//		Array.Copy(contentBytes, 0, data, packageLenBytes.Length + idBytes.Length, contentBytes.Length);
//
//		ni.Send(data);
//
//		return true;
//	}

	private byte[] GetNetworkOrderBytes(int val)
	{
		var v = System.Net.IPAddress.HostToNetworkOrder(val);
		return System.BitConverter.GetBytes(v);
	}

}
