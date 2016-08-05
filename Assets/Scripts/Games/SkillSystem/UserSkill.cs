/*************************************************************************
 *  FileName: UserSkill.cs
 *  Author: xClouder
 *  Create Time: 04/11/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;

public class UserSkill
{
	
	public int Level {
		get;set;
	}

	public float CD {
		get {
			return 5f;
		}
	}

	public float ExitTime
	{
		get {
			if (Skill.Name == BattleConst.SkillGoHome)
				return 0f;

			return 1f;
		}
	}

	public float Duration
	{
		get {
			if (Skill.Name == BattleConst.SkillGoHome)
				return 8f;
			
			return 1f;
		}
	}

	public SkillInfo Skill {
		get;set;
	}

	public UserSkill(SkillInfo skillInfo, int initLevel = 0)
	{
		Skill = skillInfo;
		Level = initLevel;
	}

}