using UnityEngine;
using System.Collections;

public class BattleScene : Scene {

  // ReSharper disable once ArrangeTypeMemberModifiers
	void Update()
	{
	  if (!Input.GetMouseButton(1)) return;
	  var pos = Input.mousePosition;
	  pos.y = 0;

	  EventDispatcher.Fire<Vector3>(BattleConst.kEvent_MoveTo, pos);
	}

}
