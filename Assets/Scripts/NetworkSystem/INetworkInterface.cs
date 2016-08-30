using UnityEngine;
using System.Collections;

public enum ConnectionState
{
	NotConnected,
	Connecting,
	Connected
}

public interface INetworkInterface {

	ConnectionState State {get;}
	void Send(byte[] data);

}
