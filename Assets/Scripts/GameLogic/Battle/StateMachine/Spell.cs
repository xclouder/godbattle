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
		var skillId = blackboard.GetIntVar("SkillId").Value;
		var skillInfo = SkillMgr.Instance.GetSkill(skillId);

		CharAnimCtrl.Play(skillInfo.AnimationClipName, 1f, ()=>{
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