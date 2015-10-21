using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour {

	public InputField username;
	public InputField password;


	public void Login()
	{
		var uid = username.text;
		var pwd = password.text;

		Debug.Log("uid:" + uid + ", pwd:" + pwd);
	}

}
