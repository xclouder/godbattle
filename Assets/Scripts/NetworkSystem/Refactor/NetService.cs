using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using uFrame.Kernel;

public class NetService : SystemServiceMonoBehavior {

	public override IEnumerator SetupAsync ()
	{
		yield return base.SetupAsync ();

		m_connDict = new Dictionary<int, NetConnection>(12);
	}

	public void Send(IMessage msg, int connId)
	{
		var conn = GetConnection(connId);

		if (conn != null)
		{
			conn.Send(msg);
		}
	}

	public void RegisterConnection(NetConnection conn, int connId)
	{
		if (m_connDict.ContainsKey(connId))
		{
			Debug.LogError("connId exist, ignore");
			return;
		}

		m_connDict.Add(connId, conn);
	}

	public NetConnection GetConnection(int connId)
	{
		NetConnection conn = null;

		m_connDict.TryGetValue(connId, out conn);
		if (conn == null)
		{
			Debug.LogError("cannot find a conn registered with connId:" + connId);
		}

		return conn;
	}

	private Dictionary<int, NetConnection> m_connDict;


}
