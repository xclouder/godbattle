using UnityEngine;
using System.Collections;

public class NetConnectParams
{
	public string Ip;
	public int Port;
}

public class NetConnection {

	public enum NetConnectionState
	{
		Disconnected,
		Connecting,
		Connected,
		Disconnecting,
	}

	private enum NetConnectionEvent
	{
		StartConnect,
		ConnectSuccess,
		ConnectFail,

		StartDisconnect,
		DisconnectSuccess
	}

	private StateMachine<NetConnectionState, NetConnectionEvent> m_connFsm;
	private NetInterface m_netInterface;

	public NetConnection()
	{
		m_netInterface = new NetInterface();
		m_netInterface.onConnectedHandler += OnConnected;
		m_netInterface.onConnectErrorHandler += OnConnectError;
		m_netInterface.onDisconnectedHandler += OnDisconnected;

		m_connFsm = new StateMachine<NetConnectionState, NetConnectionEvent>();
		m_connFsm.In(NetConnectionState.Disconnected)
			.On(NetConnectionEvent.StartConnect)
				.GoTo(NetConnectionState.Connecting)
			.ExecuteOnEnter(OnEnter_DisconnectedState);

		m_connFsm.In(NetConnectionState.Connecting)
			.On(NetConnectionEvent.ConnectSuccess)
				.GoTo(NetConnectionState.Connected)
			.On(NetConnectionEvent.ConnectFail)
				.GoTo(NetConnectionState.Disconnected);

		m_connFsm.In(NetConnectionState.Connected)
			.On(NetConnectionEvent.StartDisconnect)
				.GoTo(NetConnectionState.Disconnecting)
			.ExecuteOnEnter(OnEnter_ConnectedState);

		m_connFsm.In(NetConnectionState.Disconnecting)
			.On(NetConnectionEvent.DisconnectSuccess)
				.GoTo(NetConnectionState.Disconnected);

		m_connFsm.Initialize(NetConnectionState.Disconnected);
		m_connFsm.Start();
		m_connFsm.Execute();

	}

	public bool IsConnected
	{
		get {
			return m_connFsm.CurrentStateId == NetConnectionState.Connected;
		}
	}

	public NetConnectionState CurrentState
	{
		get {
			return m_connFsm.CurrentStateId;
		}
	}

	public void StartConnect(NetConnectParams param)
	{
		m_connFsm.Fire(NetConnectionEvent.StartConnect);

		m_netInterface.Connect(param.Ip, param.Port);
	}

	public void StartDisconnect()
	{
		m_connFsm.Fire(NetConnectionEvent.StartDisconnect);
	}

	public void Send(IMessage msg)
	{
		if (!IsConnected)
		{
			Debug.Log("not connected.");
			return;
		}

		var data = PackMessage(msg);
		m_netInterface.Send(data);
	}

	private byte[] PackMessage(IMessage msg)
	{
		return msg.Pack();
	}

	#region NetInterface Handlers
	private void OnConnected(NetInterface net)
	{
		m_connFsm.Fire(NetConnectionEvent.ConnectSuccess);
	}

	private void OnConnectError(NetInterface net)
	{
		m_connFsm.Fire(NetConnectionEvent.ConnectFail);
	}

	private void OnDisconnected(NetInterface net)
	{
		m_connFsm.Fire(NetConnectionEvent.DisconnectSuccess);
	}

	private void OnConnectError(NetInterface net, string errmsg)
	{
		m_connFsm.Fire(NetConnectionEvent.ConnectFail);
		if (onConnectErrorHandler != null)
		{
			onConnectErrorHandler(this, errmsg);
		}
	}

	#endregion

	public delegate void NetConnectionEventHandler(NetConnection conn);
	public delegate void NetConnectionErrorEventHandler(NetConnection conn, string errmsg);
	public event NetConnectionEventHandler onConnectedHandler;
	public event NetConnectionEventHandler onDisconnectedHandler;
	public event NetConnectionErrorEventHandler onConnectErrorHandler;

	#region Fsm Callback
	private void OnEnter_ConnectedState()
	{
		if (onConnectedHandler != null)
		{
			onConnectedHandler(this);
		}
	}

	private void OnEnter_DisconnectedState()
	{
		if (onDisconnectedHandler != null)
		{
			onDisconnectedHandler(this);
		}
	}

	#endregion

}
