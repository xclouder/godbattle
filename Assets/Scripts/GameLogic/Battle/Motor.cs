using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class Motor : MonoBehaviour {

	public float speed = 1f;
	private CharacterController characterCtrl;

	public float pickNextWaypointDist = 0.1f;
	private Vector3 targetPos;

	public float gravity = 20f;

	//TODO characterState lay here for convinient, refactor it later.
	public enum CharacterState
	{
		Idle,
		Run,
		Attack,
		Dead
	}

	public enum CharacterEvent
	{
		MoveTo,
		Arrive,
		DoAttack
	}

	private StateMachine<CharacterState, CharacterEvent> characterFSM;

	// Use this for initialization
	void Start () {
		characterCtrl = GetComponent<CharacterController>();
		EventDispatcher.AddListener<Vector3>(BattleConst.kEvent_MoveTo, MoveTo);

		//setup fsm
		characterFSM = new StateMachine<CharacterState, CharacterEvent>();
		characterFSM.Initialize(CharacterState.Idle);
		characterFSM.In(CharacterState.Idle).On(CharacterEvent.MoveTo).GoTo(CharacterState.Run);
		characterFSM.In(CharacterState.Run).On(CharacterEvent.Arrive).GoTo(CharacterState.Idle);

		characterFSM.Start();
		characterFSM.Execute();
	}

	void Update()
	{
		if (Input.GetMouseButton(1))
		{
			var mousePos = Input.mousePosition;
			var ray = Camera.main.ScreenPointToRay(mousePos);
			_ray = ray;

			RaycastHit hit;
			var hitted = Physics.Raycast(ray, out hit, 1000f);//, LayerMask.GetMask(new string[]{"Terrain"}));
			if (!hitted)
			{
				Debug.LogError("not hit terrain");
				return;
			}
			
			var targetPos = hit.point;
			EventDispatcher.Fire<Vector3>(BattleConst.kEvent_MoveTo, targetPos);

		}
	}

	public void MoveTo(Vector3 pos)
	{

		//use fsm fully later.
		characterFSM.Fire(CharacterEvent.MoveTo);

		targetPos = pos;
		pos.y = transform.position.y;

		transform.LookAt(pos);
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (characterFSM != null && characterFSM.CurrentStateId == CharacterState.Run)
		{
			if (Vector3.Distance(transform.position, targetPos) < pickNextWaypointDist)
			{
				//arrived
				characterFSM.Fire(CharacterEvent.Arrive);
			}
			else
			{
				//var lookAt = new Vector3(targetPos.x, transform.position.y, targetPos.z);

//				Debug.Log("lookAt2: " + lookAt);
//				transform.LookAt(lookAt);

				//TODO:time.deltaTime should be replaced using a more powerful TimeSystem
				var dir = (targetPos - transform.position);
				characterCtrl.Move(dir.normalized * Time.deltaTime * speed - new Vector3(0f, gravity * Time.deltaTime, 0f));

			}
		}
	}


	#region Debug
	private Ray _ray;
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawRay(_ray.origin, _ray.origin + _ray.direction * 1000f);
	}
	#endregion

}
