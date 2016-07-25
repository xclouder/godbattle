/*************************************************************************
 *  FileName: BaseStateBehaviour.cs
 *  Author: xClouder
 *  Create Time: 04/10/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using BehaviourMachine;

public class BaseStateBehaviour : StateBehaviour
{
	private CharacterCtrl _charCtrl;
	protected CharacterCtrl CharCtrl
	{
		get 
		{
			if (_charCtrl == null)
			{
				_charCtrl = GetComponent<CharacterCtrl>();
			}

			return _charCtrl;
		}
	}

	private CharacterAnimationCtrl _charAnimCtrl;
	protected CharacterAnimationCtrl CharAnimCtrl
	{
		get {
			if (_charAnimCtrl == null)
			{
				_charAnimCtrl = CharCtrl.animCtrl;
			}
			return _charAnimCtrl;
		}
	}

	#region Public Method
	#endregion
}