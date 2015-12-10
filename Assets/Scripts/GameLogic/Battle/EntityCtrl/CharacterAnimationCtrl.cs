using UnityEngine;
using System.Collections;

public class CharacterAnimationCtrl : MonoBehaviour {
	
	private Animator anim;
	
	private StateMachine<CharacterState, CharacterEvent> characterFSM;
	
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	
	public void Init(StateMachine<CharacterState, CharacterEvent> fsm)
	{
		characterFSM = fsm;
	}
	
	public void PlayIdle()
	{
		anim.Play("idle");
	}
	
	public void PlayRun()
	{
		anim.Play("run");
	}
	
	public void PlayRecall()
	{
		anim.Play("Recall");
	}
	
	void OnRecallCompleted()
	{
		characterFSM.Fire(CharacterEvent.ToIdle);
	}
}
