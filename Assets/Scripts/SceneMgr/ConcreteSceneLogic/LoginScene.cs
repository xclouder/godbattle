using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour {

	public InputField username;
	public InputField password;


	void Start()
	{
		EventDispatcher.AddListener<bool, string>("Login", HandleLogin);
	}

	public void Login()
	{
		var uid = username.text;
		var pwd = password.text;

		Debug.Log("uid:" + uid + ", pwd:" + pwd);
	}

	private void HandleLogin(bool succ, string msg)
	{
		if (succ)
		{
			Debug.Log("succ:" + msg);
		}
		else
		{
			Debug.LogError("login failed:" + msg);
		}
	}

}
