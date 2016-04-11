using UnityEngine;
using System.Collections;
using BehaviourMachine;
	
public class CharacterCtrl : MonoBehaviour {
	
	public CharacterAnimationCtrl animCtrl;
	private BehaviourMachine.StateMachine stateMachine;

	public int characterId = 1;
//	private bool canAcceptUserInput = true;

	void Start()
	{
		stateMachine = GetComponent<BehaviourMachine.StateMachine>();
		var skillsInfo = SkillInfoMgr.Instance.GetCharacterSkills(characterId);

		UserSkillMgr.Instance.Init(skillsInfo);
	}

	void FixedUpdate()
	{
		if (!InputMgr.Instance.CanAcceptUserInput)
		{
			return;
		}
		
		if (Input.GetKeyDown(KeyCode.Q))
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

		if (Input.GetKeyDown(KeyCode.B))
		{
			if (GoHome())
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
	
	public bool GoHome()
	{
		var floatVar = stateMachine.blackboard.GetStringVar("SkillName");
		floatVar.Value = BattleConst.SkillGoHome;
		stateMachine.SendEvent("Spell");

		return true;
	}

	public bool Spell1()
	{
		var floatVar = stateMachine.blackboard.GetStringVar("SkillName");
		floatVar.Value = BattleConst.Skill1Name;

		stateMachine.SendEvent("Spell");

		return true;
	}

	public bool Spell2()
	{
		var floatVar = stateMachine.blackboard.GetStringVar("SkillName");
		floatVar.Value = BattleConst.Skill2Name;
		stateMachine.SendEvent("Spell");
	
		return true;
	}

	public bool Spell3()
	{
		var floatVar = stateMachine.blackboard.GetStringVar("SkillName");
		floatVar.Value = BattleConst.Skill3Name;
		stateMachine.SendEvent("Spell");

		return true;
	}

	public bool Spell4()
	{
		
		var floatVar = stateMachine.blackboard.GetStringVar("SkillName");
		floatVar.Value = BattleConst.Skill4Name;

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
