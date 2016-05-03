using UnityEngine;
using System.Collections;

public class BattleSceneOrigin : MyScene {

  // ReSharper disable once ArrangeTypeMemberModifiers
	void Update()
	{
	  if (!Input.GetMouseButton(1)) return;
	  var pos = Input.mousePosition;
	  pos.y = 0;

	  EventDispatch.EventDispatcher.Fire<Vector3>(BattleConst.kEvent_MoveTo, pos);
	}

}
