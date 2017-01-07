using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public enum ConnType
{
	LoginServer,
	GameServer
}

public class TestSceneController : SceneController {



	protected override void SceneLoaded ()
	{
		base.SceneLoaded ();


	}

	private NetConnection m_conn;
	public void OnCickConnect()
	{
//		var netService = uFrameKernel.Container.Resolve<NetService>();
//		netService.Connect("127.0.0.1", 8888, 0);

		m_conn = new NetConnection();

		NetConnectParams p = new NetConnectParams()
		{
			Ip = "127.0.0.1",
			Port = 8888
		};

		m_conn.onConnectedHandler += OnConnected;
		m_conn.onDisconnectedHandler += OnDisconnected;
		m_conn.onConnectErrorHandler += OnConnectError;
		m_conn.StartConnect(p);
	}

	private void OnConnected(NetConnection conn)
	{
		Debug.Log("connect successed");
	}

	private void OnDisconnected(NetConnection conn)
	{
		Debug.Log("disconnected");
	}

	private void OnConnectError(NetConnection conn, string msg)
	{
		Debug.LogError("connect error:" + msg);
	}

}
