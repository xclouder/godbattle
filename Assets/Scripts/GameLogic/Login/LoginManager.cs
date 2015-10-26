using System;
using System.Collections;

public class LoginManager {

	public void Login(string uid, string pwd, Action<bool, string> callback)
	{
		TaskMgr.StartCoroutineTask(DoLogin(uid, pwd, callback));
	}

	private IEnumerator DoLogin(string uid, string pwd, Action<bool, string> callback)
	{
		yield return new UnityEngine.WaitForSeconds(1.5f);

		if (callback != null)
		{
			callback(true, "login success");
		}
	}

}
