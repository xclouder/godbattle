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
	private float enterTime;
	private UserSkill userSkill;
	void OnEnable()
	{
		enterTime = Time.time;

		var userSkillName = blackboard.GetStringVar("SkillName").Value;
		userSkill = UserSkillMgr.Instance.GetSkill(userSkillName);
		var skillInfo = userSkill.Skill;
		CharAnimCtrl.Play(skillInfo.AnimationClipName, userSkill.Duration, ()=>{
			SendEvent("Finish");
		});
	}

	#region Public Method

	public override bool ProcessEvent(int eventId)
	{
		var evt = blackboard.GetFsmEvent("Spell");
		if (evt.id == eventId)
		{
			Debug.Log("Skill not finished");
			return false;
		}

		if (Time.time - enterTime < userSkill.ExitTime)
		{
			return false;
		}

		return base.ProcessEvent(eventId);
	}
	#endregion

}