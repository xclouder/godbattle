using UnityEngine;
using System.Collections;
using BehaviourMachine;
	
public class CharacterCtrl : MonoBehaviour {
	
	public CharacterAnimationCtrl animCtrl;
	private BehaviourMachine.StateMachine stateMachine;

	public int characterId = 1;
	CharacterSkillsInfo skillsInfo;
//	private bool canAcceptUserInput = true;

	void Start()
	{
		stateMachine = GetComponent<BehaviourMachine.StateMachine>();
		skillsInfo = SkillMgr.Instance.GetCharacterSkills(characterId);
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
		stateMachine.SendEvent("Recall");

		return true;
	}

	public bool Spell1()
	{
		var floatVar = stateMachine.blackboard.GetIntVar("SkillId");
		floatVar.Value = skillsInfo.Skill1Info.Id;

		stateMachine.SendEvent("Spell");

		return true;
	}

	public bool Spell2()
	{
		var floatVar = stateMachine.blackboard.GetIntVar("SkillId");
		floatVar.Value = skillsInfo.Skill2Info.Id;
		stateMachine.SendEvent("Spell");
	
		return true;
	}

	public bool Spell3()
	{
		var floatVar = stateMachine.blackboard.GetIntVar("SkillId");
		floatVar.Value = skillsInfo.Skill3Info.Id;
		stateMachine.SendEvent("Spell");

		return true;
	}

	public bool Spell4()
	{
		
		var floatVar = stateMachine.blackboard.GetIntVar("SkillId");
		floatVar.Value = skillsInfo.Skill4Info.Id;

		stateMachine.SendEvent("Spell");

		return true;
	}

	public void RunTo(Vector3 toPos)
	{
		if (Utils.GetDistanceIn2D(transform.position, toPos) < 0.1f)
		{
			return;
		}

		var toPosVar = stateMachine.blackboard.GetVector3Var("ToPos");
		toPosVar.Value = toPos;
		stateMachine.SendEvent("MoveTo");
	}
	
}
