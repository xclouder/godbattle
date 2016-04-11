/*************************************************************************
 *  FileName: Spell.cs
 *  Author: xClouder
 *  Create Time: 04/11/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using BehaviourMachine;

public class Spell : BaseStateBehaviour
{

	void OnEnable()
	{
		var userSkillName = blackboard.GetStringVar("SkillName").Value;
		var userSkill = UserSkillMgr.Instance.GetSkill(userSkillName);
		var skillInfo = userSkill.Skill;
		CharAnimCtrl.Play(skillInfo.AnimationClipName, userSkill.Duration, ()=>{
			SendEvent("Finish");
		});
	}

	#region Public Method

	public override bool ProcessEvent(int eventId)
	{
		var moveEvt = blackboard.GetFsmEvent("Spell");
		if (moveEvt.id == eventId)
		{
			Debug.Log("Skill not finished");
			return false;
		}

		return base.ProcessEvent(eventId);
	}
	#endregion

}