using UnityEngine;
using System.Collections;

public class CharacterAnimationCtrl : MonoBehaviour {
	
	private Animation anim;
	
	void Start()
	{
		anim = GetComponent<Animation>();
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

	public void Play(string animName, float duration = 0.7f, System.Action cb = null)
	{
		anim.CrossFade(animName);
		StartCoroutine(WaitAnimationComplete(animName, duration, cb));
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

	public delegate void AnimationCompletedCallback();
	public event AnimationCompletedCallback onAnimationCompleted;
	void OnAnimationCompleted()
	{
		if (onAnimationCompleted != null)
		{
			onAnimationCompleted();
		}
	}

	#region Private
	private IEnumerator WaitAnimationComplete(string animationName, float duration = 0.7f, System.Action cb = null)
	{
		//get the animation len from animationName
		yield return new WaitForSeconds(duration);

		if (cb != null)
		{
			cb();
		}
		OnAnimationCompleted();
	}
	#endregion

}
