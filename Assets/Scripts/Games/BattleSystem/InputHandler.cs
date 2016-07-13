/*************************************************************************
 *  FileName: InputHandler.cs
 *  Author: xClouder
 *  Create Time: 07/06/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using uFrame.Kernel;

public class InputHandler : uFrameComponent
{
	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			PublishKeyPressEvent(KeyCode.Q);
			return;
		}


		if (Input.GetKeyDown(KeyCode.W))
		{
			PublishKeyPressEvent(KeyCode.W);
			return;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			PublishKeyPressEvent(KeyCode.E);
			return;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			PublishKeyPressEvent(KeyCode.R);
			return;
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			PublishKeyPressEvent(KeyCode.B);
			return;
		}


		if (Input.GetMouseButton(1))
		{
			var mousePos = Input.mousePosition;
			var ray = Camera.main.ScreenPointToRay(mousePos);

			RaycastHit hit;
			var hitted = Physics.Raycast(ray, out hit, 1000f);//, LayerMask.GetMask(new string[]{"Terrain"}));
			if (!hitted)
			{
				Debug.LogWarning("not hit terrain");
				return;
			}
				
			PublishRunToEvent(hit.point);
		
		}

	}

	private void PublishKeyPressEvent(KeyCode keyCode)
	{
		Publish(new KeyPressEvent(){KeyCode = keyCode});
	}

	private void PublishRunToEvent(Vector3 pos)
	{
		Publish(new RunToEvent(){Position = pos});
	}
}