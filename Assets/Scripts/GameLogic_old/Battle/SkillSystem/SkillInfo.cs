/*************************************************************************
 *  FileName: Skill.cs
 *  Author: xClouder
 *  Create Time: 04/10/2016
 *  Description:
 *
 *************************************************************************/

using System;
using System.Collections;




public class SkillInfo
{
	public enum SkillReleaseType
	{
		ToPoint,
		ToDirection,
		ToEntity
	}

	public enum SkillTargetType
	{
		EnemyHero,
		EnemySoldier,
		TeammateHero,
		TeammateSoldier,
		Monsters
	}

	public int Id { get;set; }
	public string Name { get;set; }
	public string Desc { get;set; }
	public string Icon { get;set; }

	public SkillReleaseType ReleaseType { get;set; }
	public SkillTargetType TargetType { get;set; }

	public string AnimationClipName { get;set;}

}