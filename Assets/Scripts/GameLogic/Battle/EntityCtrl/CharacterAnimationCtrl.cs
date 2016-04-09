using UnityEngine;
using System.Collections;

public class CharacterAnimationCtrl : MonoBehaviour {
	
	private Animation anim;
	
	private StateMachine<CharacterState, CharacterEvent> characterFSM;
	
	void Start()
	{
		anim = GetComponent<Animation>();
	}
	
	public void Init(StateMachine<CharacterState, CharacterEvent> fsm)
	{
		characterFSM = fsm;
	}
	
	public void PlayIdle()
	{
		anim.CrossFade("Idle");
	}
	
	public void PlayRun()
	{
		anim.CrossFade("Run");
	}
	
	public void PlayRecall()
	{
		anim.CrossFade("Recall");
		//TODO:how to get complete callback? Legacy Animation System's ugly design
		StartCoroutine(WaitAnimationComplete("Recall"));
	}

	public void PlaySpell1()
	{
		anim.CrossFade("Spell1");
		StartCoroutine(WaitAnimationComplete("Spell1"));
	}

	public void PlaySpell2()
	{
		anim.CrossFade("Spell2");
		StartCoroutine(WaitAnimationComplete("Spell2"));
	}

	public void PlaySpell3()
	{
		anim.CrossFade("Spell3");

		StartCoroutine(WaitAnimationComplete("Spell3"));
	}

	public void PlaySpell4()
	{
		anim.CrossFade("Spell4");

		StartCoroutine(WaitAnimationComplete("Spell4"));
	}
	
	void OnRecallCompleted()
	{
		characterFSM.Fire(CharacterEvent.ToIdle);
		
	}

	#region Private
	private IEnumerator WaitAnimationComplete(string animationName)
	{
		//get the animation len from animationName
		float len = anim.clip.length / 3f;
		yield return new WaitForSeconds(len);

		OnRecallCompleted();
	}
	#endregion

}
