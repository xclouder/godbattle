/*************************************************************************
 *  FileName: CharacterSkillsInfo.cs
 *  Author: xClouder
 *  Create Time: 04/10/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

public class CharacterSkillsInfo
{
	public int CharacterId {get;set;}

	public void Add(string name, SkillInfo skill)
	{
		skillDict.Add(name, skill);
	}

	public Dictionary<string, SkillInfo> GetSkillDict()
	{
		return skillDict;
	}

	private Dictionary<string, SkillInfo> skillDict = new Dictionary<string, SkillInfo>();

}