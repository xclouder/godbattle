using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour {

	public GameObject loginingIndicator;

	public InputField username;
	public InputField password;
	public GameObject loginBtn;
	public Text loginMsg;

	private LoginMgr loginMgr = new LoginMgr();

	void Awake()
	{
		HideLogining();
	}

	public void Login()
	{
		var uid = username.text;
		var pwd = password.text;

		ShowLogining();
		loginMgr.Login(uid, pwd, HandleLogin);

	}

	private void ShowLogining()
	{
		loginingIndicator.SetActive(true);
		loginBtn.SetActive(false);

	}
	private void HideLogining()
	{
		loginingIndicator.SetActive(false);
		loginBtn.SetActive(true);
	}

	private void ShowLoginResult(string msg)
	{
		loginingIndicator.SetActive(false);
		loginMsg.gameObject.SetActive(true);
		loginMsg.text = msg;
	}

	//handle login result
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

		ShowLoginResult(msg);
	}

}
