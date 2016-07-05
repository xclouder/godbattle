/*************************************************************************
 *  FileName: UserInputListener.cs
 *  Author: xClouder
 *  Create Time: 07/06/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;
using UniRx;

[RequireComponent(typeof(CharacterCtrl))]
public class UserCommandExecuter : uFrameComponent
{

	private CharacterCtrl cCtrl;

	public override void KernelLoaded ()
	{
		base.KernelLoaded ();

		cCtrl = GetComponent<CharacterCtrl>();

		OnEvent<RunToEvent>().Subscribe(e => {

			cCtrl.RunTo(e.Position);

		});

		OnEvent<KeyPressEvent>().Subscribe(e => {
			var c = e.KeyCode;

			switch (c)
			{
			case KeyCode.Q:
				{
				cCtrl.Spell1();
				break;
				}
			case KeyCode.W:
				{
					cCtrl.Spell2();
					break;
				}
			case KeyCode.E:
				{
					cCtrl.Spell3();
					break;
				}
			case KeyCode.R:
				{
					cCtrl.Spell4();
					break;
				}
			case KeyCode.B:
				{
					cCtrl.GoHome();
					break;
				}

			}

		});
	}

}