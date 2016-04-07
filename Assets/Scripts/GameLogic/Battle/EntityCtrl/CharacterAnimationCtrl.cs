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
	}
	
	public void CancelRecall()
	{
		
	}
	
	void OnRecallCompleted()
	{
		
		characterFSM.Fire(CharacterEvent.ToIdle);
		
	}
}
