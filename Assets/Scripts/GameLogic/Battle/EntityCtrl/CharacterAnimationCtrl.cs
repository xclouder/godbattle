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
	
	public void CancelRecall()
	{
		anim.CrossFade("Idle");
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
