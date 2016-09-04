using UnityEngine;
using System.Collections;

public enum ConnectionState
{
	NotConnected,
	Connecting,
	Connected
}

public delegate void OnReceive(SocketBuffer buffer, int offset, int length);
public interface INetworkInterface {
	event OnReceive onReceive;

	ConnectionState State {get;}

	void Send(byte[] data);

}
