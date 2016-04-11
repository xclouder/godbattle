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

public class SkillInfoMgr
{
	private static SkillInfoMgr ins;
	public static SkillInfoMgr Instance {
		get {
			if (ins == null)
			{
				ins = new SkillInfoMgr();
				ins.Init();
			}

			return ins;
		}
	}

	public void Init()
	{
		skillDict = new Dictionary<int, SkillInfo>();

		var skillGoHome = new SkillInfo() { 
			Id = 0, Name = "GoHome", AnimationClipName = "Recall",
			ReleaseType = SkillInfo.SkillReleaseType.ToDirection
		};

		var skill1 = new SkillInfo() { 
			Id = 1, Name = "Skill1", AnimationClipName = "Spell1", 
			ReleaseType = SkillInfo.SkillReleaseType.ToPoint
		};
		var skill2 = new SkillInfo() { 
			Id = 2, Name = "Skill2", AnimationClipName = "Spell2",
			ReleaseType = SkillInfo.SkillReleaseType.ToEntity
		};
		var skill3 = new SkillInfo() { 
			Id = 3, Name = "Skill3", AnimationClipName = "Spell3",
			ReleaseType = SkillInfo.SkillReleaseType.ToEntity
		};
		var skill4 = new SkillInfo() { 
			Id = 4, Name = "Skill4", AnimationClipName = "Ult",
			ReleaseType = SkillInfo.SkillReleaseType.ToDirection
		};

		skillDict.Add(skillGoHome.Id, skillGoHome);
		skillDict.Add(skill1.Id, skill1);
		skillDict.Add(skill2.Id, skill2);
		skillDict.Add(skill3.Id, skill3);
		skillDict.Add(skill4.Id, skill4);
	}

	public CharacterSkillsInfo GetCharacterSkills(int characterId)
	{
		//define how many skills can user use, and map it from string name to reall skill id.
		Dictionary<string, int> skillName2IdMap = new Dictionary<string, int>(){
			{BattleConst.Skill1Name, 1},
			{BattleConst.Skill2Name, 2},
			{BattleConst.Skill3Name, 3},
			{BattleConst.Skill4Name, 4},
			{BattleConst.SkillGoHome, 0},
			{BattleConst.AssistSkill1Name, 0},
			{BattleConst.AssistSkill2Name, 0},
		};

		CharacterSkillsInfo skillsInfo = new CharacterSkillsInfo();
		skillsInfo.CharacterId = characterId;

		foreach (var pair in skillName2IdMap)
		{
			var skill = GetSkill(pair.Value);
			skillsInfo.Add(pair.Key, skill);
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