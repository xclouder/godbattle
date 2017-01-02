using System;
using Debug = UnityEngine.Debug;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public class NetInterface {

	public static int TcpClientReceiveBufferSize = 256 * 1024;
	public static int TcpClientReceiveTimeout = 10000;

	public static int TcpClientSendBufferSize = 256 * 1024;
	public static int TcpClientSendTimeout = 10000;

	public delegate void NetInterfaceErrorEventHandler(NetInterface net, string errmsg);
	public delegate void NetInterfaceEventHandler(NetInterface net);

	public event NetInterfaceEventHandler onConnectedHandler;
	public event NetInterfaceErrorEventHandler onConnectErrorHandler;
	public event NetInterfaceEventHandler onDisconnectedHandler;

	private Socket m_socket;

	public void Connect(string ip, int port)
	{
		if (m_socket != null) {
			m_socket.Close();
			m_socket = null;
		}

		m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		IPAddress[] ips = Dns.GetHostAddresses(ip);
		var addr = ips[0];
		var hostEndPoint = new IPEndPoint(addr, port);

		var connectEA = new SocketAsyncEventArgs();
		connectEA.Completed += ProcessConnectionCallback;
		connectEA.RemoteEndPoint = hostEndPoint;
		m_socket.ConnectAsync(connectEA);

		//TODO 连接/断开连接超时问题

	}

	public void Disconnect()
	{
		if (m_socket == null)
		{
			return;
		}

		var disconnectEA = new SocketAsyncEventArgs();
		disconnectEA.Completed += ProcessConnectionCallback;

		m_socket.DisconnectAsync(disconnectEA);
	}

	private void ProcessConnectionCallback(object sender, SocketAsyncEventArgs e)
	{
		switch (e.LastOperation)
		{
		case SocketAsyncOperation.Connect:
			{
				if (e.SocketError == SocketError.Success)
				{
					if (onConnectedHandler != null)
					{
						onConnectedHandler(this);
					}
				}
				else
				{
					if (onConnectErrorHandler != null)
					{
						onConnectErrorHandler(this, e.SocketError.ToString());
					}
				}

				break;
			}
		case SocketAsyncOperation.Disconnect:
			{
				if (onDisconnectedHandler != null)
				{
					onDisconnectedHandler(this);
				}
				break;
			}
		default:
			throw new ArgumentException("The last operation completed on the socket was not a connect/disconnect");
		}

		e.Dispose();
	}
		
	private SocketAsyncEventArgs m_sendEA;
	public void Send(byte[] data)
	{
		bool shouldStartSend = false;
		lock(m_sendQueue)
		{
			shouldStartSend = (m_sendQueue.Count == 0);

			m_sendQueue.Enqueue(data);
		}

		if (shouldStartSend)
		{
			StartSend();
		}

	}

	private void StartSend()
	{

		m_sendEA = m_sendEA ?? CreateSAEA(new EventHandler<SocketAsyncEventArgs>(OnSendComplete));

		byte[] raw = null;
		lock(m_sendQueue)
		{
			raw = m_sendQueue.Dequeue();
		}

		if (raw != null)
		{
			m_sendEA.SetBuffer(raw, 0, raw.Length);
			m_socket.SendAsync(m_sendEA);
			UnityEngine.Debug.Log("Start Send");
		}

	}

	private void OnSendComplete(object sender, SocketAsyncEventArgs e)
	{
		UnityEngine.Debug.Log("Send complete");
		if (e.SocketError == SocketError.Success)
		{
			UnityEngine.Debug.Log("Send Complete");
			//sendBuffer.SetBytesUsed(e.BytesTransferred);

			StartSend();
		}
		else
		{
			UnityEngine.Debug.LogError("error:"+e.SocketError);
		}
	}

	private SocketAsyncEventArgs CreateSAEA(EventHandler<SocketAsyncEventArgs> completeHandler)
	{
		var saea = new SocketAsyncEventArgs();
		saea.Completed += completeHandler;

		return saea;
	}

	private Queue<byte[]> m_sendQueue = new Queue<byte[]>();


}
