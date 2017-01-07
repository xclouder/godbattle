using System;
using Debug = UnityEngine.Debug;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

/// <summary>
/// 对Socket的封装，内部维护收／发队列，同步调用Send数据入队，异步发送并回调
/// 收到数据后由PacketScanner切分为数据包，进入收包队列
/// </summary>
public class NetInterface {

	public static int ReceiveBufferSize = 256 * 1024;
	public static int ReceiveTimeout = 10000;

	public static int SendBufferSize = 256 * 1024;
	public static int SendTimeout = 10000;

	public delegate void NetInterfaceErrorEventHandler(NetInterface net, string errmsg);
	public delegate void NetInterfaceEventHandler(NetInterface net);
	public delegate void NetInterfaceOnReceivePacketHandler(NetInterface net, byte[] data);

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

	//receive:
	//负责将收到的数据流按照协议切分为包
	private bool m_isReceiving = false;
	public void Process()
	{
		if (!m_isReceiving)
		{
			StartReceive();
		}
	}

	private SocketAsyncEventArgs m_receiveEA;
	public void StartReceive()
	{
		m_receiveEA = m_receiveEA ?? CreateSAEA(new EventHandler<SocketAsyncEventArgs>(OnReceiveComplete));

//		var raw = receiveBuffer.RawBuffer;
//
//		receiveEA.SetBuffer(raw, receiveBuffer.ProducePosition, receiveBuffer.RawAvailableSpace);

		var isSucc = m_socket.ReceiveAsync(m_receiveEA);
		if (!isSucc)
		{
			UnityEngine.Debug.LogError(m_receiveEA.SocketError.ToString());
		}
	}

	private void OnReceiveComplete(object sender, SocketAsyncEventArgs e)
	{
		

		StartReceive();
	}

}
