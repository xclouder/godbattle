using UnityEngine;
using System.Collections;

public class InputMgr {

	public bool CanAcceptUserInput {
		get;set;
	}

	public InputMgr ()
	{
		CanAcceptUserInput = true;
	}

	private static InputMgr ins;
	public static InputMgr Instance
	{
		get {
			if (ins == null)
			{
				ins = new InputMgr();
			}
			return ins;
		}
	}

}
