using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class Motor : MonoBehaviour {

	public float speed = 1f;
	private CharacterController characterCtrl;

	private Vector3 targetPos;

	// Use this for initialization
	void Start () {

		characterCtrl = GetComponent<CharacterController>();
		EventDispatcher.AddListener<Vector3>(BattleConst.kEvent_MoveTo, MoveTo);
	}

	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			var mousePos = Input.mousePosition;
			var ray = Camera.main.ScreenPointToRay(mousePos);
			
			RaycastHit hit;
			var hitted = Physics.Raycast(ray, out hit, 1000f);
			if (!hitted)
			{
				Debug.LogError("not hit terrain");
				return;
			}
			
			var targetPos = hit.point;
			Debug.Log("hit obj:" + hit.transform.gameObject.name);
			EventDispatcher.Fire<Vector3>(BattleConst.kEvent_MoveTo, targetPos);
		}
	}

	public void MoveTo(Vector3 pos)
	{
		var dir = pos - transform.position;
		dir.y = pos.y;

		transform.LookAt(dir);

	}


	// Update is called once per frame
	void FixedUpdate () {

	}

}
