using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using uFrame.Kernel;

public class NetService : SystemServiceMonoBehavior {

	public override IEnumerator SetupAsync ()
	{
		return base.SetupAsync ();

		m_connDict = new Dictionary<int, NetConnection>(12);


	}

	public void Send(IMessage msg)
	{

	}

	public void Connect(string ip, int port, int connType)
	{
		
	}

	private Dictionary<int, NetConnection> m_connDict;


}
