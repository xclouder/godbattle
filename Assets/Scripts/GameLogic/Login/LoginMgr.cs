using System;
using System.Collections;

public class LoginMgr {

	public void Login(string uid, string pwd, Action<bool, string> callback)
	{
		TaskMgr.StartCoroutineOnGlobalObject(DoLogin(uid, pwd, callback));
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
