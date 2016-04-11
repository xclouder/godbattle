/*************************************************************************
 *  FileName: SkillMgr.cs
 *  Author: xClouder
 *  Create Time: 04/10/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

public class SkillMgr
{
	private static SkillMgr ins;
	public static SkillMgr Instance {
		get {
			if (ins == null)
			{
				ins = new SkillMgr();
				ins.Init();
			}

			return ins;
		}
	}

	public void Init()
	{
		skillDict = new Dictionary<int, SkillInfo>();

		var skill1 = new SkillInfo() { Id = 1, Name = "Skill1", CD = 2f, AnimationClipName = "Spell1"};
		var skill2 = new SkillInfo() { Id = 2, Name = "Skill2", CD = 5f, AnimationClipName = "Spell2"};
		var skill3 = new SkillInfo() { Id = 3, Name = "Skill3", CD = 10f, AnimationClipName = "Spell3"};
		var skill4 = new SkillInfo() { Id = 4, Name = "Skill2", CD = 76f, AnimationClipName = "Ult"};

		skillDict.Add(skill1.Id, skill1);
		skillDict.Add(skill2.Id, skill2);
		skillDict.Add(skill3.Id, skill3);
		skillDict.Add(skill4.Id, skill4);
	}

	public CharacterSkillsInfo GetCharacterSkills(int characterId)
	{
		//
		int [] skillIds = new int[]{1,2,3,4};

		CharacterSkillsInfo skillsInfo = new CharacterSkillsInfo();
		skillsInfo.CharacterId = characterId;

		for (int i = 0; i < skillIds.Length; i++)
		{
			switch (i)
			{
			case 0:
				{
					skillsInfo.Skill1Info = GetSkill(skillIds[i]);
					break;
				}
			case 1:
				{
					skillsInfo.Skill2Info = GetSkill(skillIds[i]);
					break;
				}
			case 2:
				{
					skillsInfo.Skill3Info = GetSkill(skillIds[i]);
					break;
				}
			case 3:
				{
					skillsInfo.Skill4Info = GetSkill(skillIds[i]);
					break;
				}

			}
		}
			
		return skillsInfo;
	}

	private IDictionary<int, SkillInfo> skillDict;
	public SkillInfo GetSkill(int skillId)
	{
		if (!skillDict.ContainsKey(skillId))
		{
			//
			return null;
		}

		return skillDict[skillId];
	}


}