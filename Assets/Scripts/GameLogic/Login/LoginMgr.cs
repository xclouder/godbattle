using System;
using System.Collections;
using KBEngine;

public class LoginMgr {

	public LoginMgr()
	{
		KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
		KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
	}

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
	
	public void onLoginFailed(UInt16 failedcode)
	{
		UnityEngine.Debug.Log("登陆服务器失败, 错误:" + KBEngineApp.app.serverErr(failedcode) + "!");
	}
	
	public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, Account accountEntity)
	{
		// log_label.obj.color = UnityEngine.Color.green;
		// log_label.obj.text = "登陆成功!";
		
		// loader.inst.enterScene("selavatar");
		
		UnityEngine.Debug.Log("create account succ");
	}

}
