using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Agent : MonoBehaviour {
	public float speed = 1f;
	private CharacterController cCtrl;

	// Use this for initialization
	void Start () {
		cCtrl = GetComponent<CharacterController>();
		EventDispatcher.AddListener<Vector3>(BattleConst.kEvent_MoveTo, HandleMoveTo);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1))
		{
			var pos = Input.mousePosition;
			pos.y = 0;
			
			EventDispatcher.Fire<Vector3>(BattleConst.kEvent_MoveTo, pos);
		}
	}

	private void HandleMoveTo(Vector3 moveTo)
	{
		var delta = (moveTo - transform.position) * speed * Time.deltaTime;
		var flag = cCtrl.Move(delta);
		Debug.Log("flag:" + flag);
	}
}
