using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour {

	public GameObject loginingIndicator;

	public InputField username;
	public InputField password;
	public GameObject loginBtn;
	public Text loginMsg;
	public Text errorMsg;

	private LoginMgr loginMgr = new LoginMgr();

	void Awake()
	{
		errorMsg.gameObject.SetActive(false);
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
		errorMsg.gameObject.SetActive(false);
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

	private IEnumerator DoShowBattleScene()
	{
		yield return new WaitForSeconds(0.2f);
		SceneMgr.LoadScene("Battle");
	}

	//handle login result
	private void HandleLogin(bool succ, string msg)
	{
		ShowLoginResult(msg);

		if (succ)
		{
			Debug.Log("succ:" + msg);
			StartCoroutine(DoShowBattleScene());
		}
		else
		{
			Debug.LogError("login failed:" + msg);
			HideLogining();
			loginMsg.gameObject.SetActive(false);
			errorMsg.gameObject.SetActive(true);
			errorMsg.text = msg;
		}
		
	}

}
