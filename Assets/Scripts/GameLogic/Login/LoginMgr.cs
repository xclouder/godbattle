using System;
using System.Collections;
using KBEngine;

public class LoginMgr {

	private System.Action<bool, string> cb;

	public LoginMgr()
	{
//		KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
//		KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
//		KBEngine.Event.registerOut("onConnectStatus", this, "onLoginSuccessfully");
		
	}

	public void Login(string uid, string pwd, Action<bool, string> callback)
	{
		cb = callback;
		// TaskMgr.StartCoroutineOnGlobalObject(DoLogin(uid, pwd, callback));
//		KBEngine.Event.fireIn("login", uid, pwd, System.Text.Encoding.UTF8.GetBytes("kbengine_godbattle"));
	}

	private IEnumerator DoLogin(string uid, string pwd, Action<bool, string> callback)
	{
		yield return new UnityEngine.WaitForSeconds(1.5f);

		if (callback != null)
		{
			callback(true, "login success");
		}
	}
	
	public void onLoginFailed(UInt16 failedcode)
	{
//		var msg = "登陆服务器失败, 错误:" + KBEngineApp.app.serverErr(failedcode) + "!";
		var msg = "";
		UnityEngine.Debug.LogError(msg);
		
		if (cb != null)
		{
			cb(false, msg);
		}
		cb = null;
		
	}
	
	public void onLoginSuccessfully(bool succ)
	{
		
		if (cb != null)
		{
			cb(true, "登陆成功");
		}
		cb = null;
	}
	
	public void onConnectStatus(bool succ)
	{
		UnityEngine.Debug.Log("onnect statua:" + succ);
	}

}
