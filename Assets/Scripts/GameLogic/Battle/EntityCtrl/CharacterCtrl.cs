using UnityEngine;
using System.Collections;

public enum CharacterState
{
	Idle,
	Run,
	Attack,
	Recall,
	Spell,
	Dead
}

public enum CharacterEvent
{
	MoveTo,
	Arrive,
	DoAttack,
	ToIdle,
	Recall,
	Spell
}
	
public class CharacterCtrl : MonoBehaviour {
	
	public CharacterAnimationCtrl animCtrl;
	
	private StateMachine<CharacterState, CharacterEvent> characterFSM;
	
	private Motor motor;

	private bool canAcceptUserInput = true;
	
	void Start()
	{
		motor = GetComponent<Motor>();
		
		SetupFSM();
		motor.Init(characterFSM);
		animCtrl.Init(characterFSM);
		
		StartCoroutine(_StartFSM());
	}
	
	private IEnumerator _StartFSM()
	{
		yield return new WaitForEndOfFrame();
		characterFSM.Start();
		characterFSM.Execute();
	}
	
	private void SetupFSM()
	{
		characterFSM = new StateMachine<CharacterState, CharacterEvent>();
		characterFSM.Initialize(CharacterState.Idle);
		characterFSM.In(CharacterState.Idle).ExecuteOnEnter(()=>{animCtrl.PlayIdle();})
			.On(CharacterEvent.MoveTo).GoTo(CharacterState.Run)
			.On(CharacterEvent.Recall).GoTo(CharacterState.Recall)
			.On(CharacterEvent.Spell).GoTo(CharacterState.Spell);
			
		characterFSM.In(CharacterState.Run).ExecuteOnEnter(()=>{animCtrl.PlayRun();})
			.On(CharacterEvent.Arrive).GoTo(CharacterState.Idle)
			.On(CharacterEvent.Recall).GoTo(CharacterState.Recall)
			.On(CharacterEvent.Spell).GoTo(CharacterState.Spell);



		//Recall state transitions
		characterFSM.In(CharacterState.Recall).ExecuteOnEnter(()=> { 

			animCtrl.PlayRecall(); 
			InputMgr.Instance.CanAcceptUserInput = false;
		
		}).ExecuteOnExit(()=>{
			InputMgr.Instance.CanAcceptUserInput = true;
		})
			.On(CharacterEvent.ToIdle).GoTo(CharacterState.Idle)
			.On(CharacterEvent.MoveTo).GoTo(CharacterState.Run);



		//Spell state transitions
		characterFSM.In(CharacterState.Spell).ExecuteOnEnter(()=> { 

			animCtrl.PlaySpell1();
			InputMgr.Instance.CanAcceptUserInput = false;

		}).ExecuteOnExit(()=>{
			InputMgr.Instance.CanAcceptUserInput = true;
		})
			.On(CharacterEvent.ToIdle).GoTo(CharacterState.Idle)
			.On(CharacterEvent.MoveTo).GoTo(CharacterState.Run);

	}
	
	void FixedUpdate()
	{
		if (!InputMgr.Instance.CanAcceptUserInput)
		{
			return;
		}
		
		if (Input.GetKey(KeyCode.Q))
		{
			if (Spell1())
				return;
		}


		if (Input.GetKeyDown(KeyCode.W))
		{
			if (Spell2())
				return;
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (Spell3())
				return;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			if (Spell4())
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
			
			RunTo(hit.point);
		}
		
	}
	
	public bool Recall()
	{
		characterFSM.Fire(CharacterEvent.Recall);

		return true;
	}

	public bool Spell1()
	{
		characterFSM.Fire(CharacterEvent.Spell);

		return true;
	}

	public bool Spell2()
	{
		characterFSM.Fire(CharacterEvent.Spell);

		return true;
	}

	public bool Spell3()
	{
		characterFSM.Fire(CharacterEvent.Spell);

		return true;
	}

	public bool Spell4()
	{
		characterFSM.Fire(CharacterEvent.Spell);

		return true;
	}

	public void RunTo(Vector3 toPos)
	{
		motor.MoveTo(toPos);
	}
	
}
