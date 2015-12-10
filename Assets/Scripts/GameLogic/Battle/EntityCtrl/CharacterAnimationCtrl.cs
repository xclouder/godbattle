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
		anim.SetBool("IsRunning", false);
	}
	
	public void PlayRun()
	{
		anim.SetBool("IsRunning", true);
		//anim.Play("run");
	}
	
	public void PlayRecall()
	{
		anim.SetBool("IsRecalling", true);
		//anim.Play("Recall");
	}
	
	public void CancelRecall()
	{
		anim.SetBool("IsRecalling", false);
	}
	
	void OnRecallCompleted()
	{
		anim.SetBool("IsRecalling", false);
		characterFSM.Fire(CharacterEvent.ToIdle);
		
	}
}
