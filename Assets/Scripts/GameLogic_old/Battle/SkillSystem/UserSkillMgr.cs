/*************************************************************************
 *  FileName: UserSkillMgr.cs
 *  Author: xClouder
 *  Create Time: 04/11/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

public class UserSkillMgr
{
	private Dictionary<string, UserSkill> skillDict;

	private static UserSkillMgr ins;
	public static UserSkillMgr Instance
	{
		get {
			if (ins == null)
			{
				ins = new UserSkillMgr();
			}

			return ins;
		}
	}

	public void Init(CharacterSkillsInfo skillsInfo)
	{
		skillDict = new Dictionary<string, UserSkill>();

		foreach (var pair in skillsInfo.GetSkillDict())
		{
			skillDict.Add(pair.Key, new UserSkill(pair.Value));
		}
	}


	public UserSkill GetSkill(string skillName)
	{
		if (!skillDict.ContainsKey(skillName))
		{
			return null;
		}

		return skillDict[skillName];
	}

}