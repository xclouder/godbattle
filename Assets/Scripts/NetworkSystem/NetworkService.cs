using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class NetworkService : SystemServiceMonoBehavior {

	private NetworkInterface netInterface;

	public override IEnumerator SetupAsync ()
	{
		netInterface = new NetworkInterface();

		netInterface.ConnectTo("127.0.0.1", 50001);

		while (netInterface.State == NetworkInterface.ConnectionState.Connecting)
		{
			yield return null;
		}

		Debug.Log("Connected!");

		var data = System.Text.Encoding.ASCII.GetBytes("hello~");

		netInterface.Send(data);
		netInterface.StartReceive();

		StartCoroutine(send(netInterface));
	}

	IEnumerator send(NetworkInterface ni)
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			var t = Time.time.ToString();
			Debug.Log("t:"+t);
			ni.Send(System.Text.Encoding.ASCII.GetBytes(t));

			ni.Process();
		}

	}

}
