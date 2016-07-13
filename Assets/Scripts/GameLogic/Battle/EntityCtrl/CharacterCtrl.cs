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
		ResourceMgr.CreateInstanceAsync<GameObject>("ab_MapObjects_01/Sphere", (go)=>{
			Debug.Assert(go != null, "go is null");
			go.transform.position = Vector3.zero;
		});
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
