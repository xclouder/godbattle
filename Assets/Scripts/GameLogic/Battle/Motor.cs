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
	
	private StateMachine<CharacterState, CharacterEvent> characterFSM;

	// Use this for initialization
	void Start () {
		characterCtrl = GetComponent<CharacterController>();
		EventDispatcher.AddListener<Vector3>(BattleConst.kEvent_MoveTo, MoveTo);
	}
	
	public void Init(StateMachine<CharacterState, CharacterEvent> fsm)
	{
		characterFSM = fsm;
	}

	public void MoveTo(Vector3 pos)
	{
		if (Vector3.Distance(transform.position, pos) < 0.1f)
		{
			return;
		}
		
		//use fsm fully later.
		characterFSM.Fire(CharacterEvent.MoveTo);

		targetPos = pos;
		pos.y = transform.position.y;

		transform.LookAt(pos);
	}


	// Update is called once per frame
	void FixedUpdate () {
		if (characterFSM != null && characterFSM.IsStarted && characterFSM.CurrentStateId == CharacterState.Run)
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

}
