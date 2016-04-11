/*************************************************************************
 *  FileName: Spell.cs
 *  Author: xClouder
 *  Create Time: 04/11/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;

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

}