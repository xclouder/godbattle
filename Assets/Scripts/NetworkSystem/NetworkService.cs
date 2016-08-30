using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using Network.ImprovedInterface;

public class NetworkService : SystemServiceMonoBehavior {

	/// <summary>
	/// NetworkInterface
	/// NetworkService
	/// PacketSender
	/// PacketReceiver
	/// ByteBuffer
	/// </summary>

	private NetworkInterface netInterface;
	private PacketSender packageSender;

	public override IEnumerator SetupAsync ()
	{
		netInterface = new NetworkInterface();
		packageSender = new PacketSender();


		netInterface.ConnectTo("127.0.0.1", 50001);

		while (netInterface.State == ConnectionState.Connecting)
		{
			yield return null;
		}

		Debug.Log("Connected!");

		var data = System.Text.Encoding.ASCII.GetBytes("hello~");

		netInterface.Send(data);
		netInterface.StartReceive();

		//StartCoroutine(send(netInterface));
	}

	IEnumerator send(NetworkInterface ni)
	{
		while (true)
		{
			yield return new WaitForSeconds(1f);

			var t = Time.time.ToString();
			var msg = new Message() { ID = 1, Content = t};
//			packageSender.Send(msg, ni);

			ni.Process();
		}

	}

}
