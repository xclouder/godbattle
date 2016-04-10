/*************************************************************************
 *  FileName: Run.cs
 *  Author: xClouder
 *  Create Time: 04/10/2016
 *  Description:
 *
 *************************************************************************/

using UnityEngine;
using System.Collections;
using BehaviourMachine;

public class Run : BaseStateBehaviour
{
	public float speed = 1f;
	private CharacterController characterCtrl;

	public float pickNextWaypointDist = 0.1f;
	private Vector3 targetPos;

	public float gravity = 20f;

	#region Private Methods

	void Start()
	{
		characterCtrl = GetComponent<CharacterController>();
	}

	void OnEnable()
	{
		RefreshTargetPos();
		CharAnimCtrl.PlayRun();
	}

	private void RefreshTargetPos()
	{
		targetPos = blackboard.GetVector3Var("ToPos").Value;
		targetPos.y = transform.position.y;

		transform.LookAt(targetPos);
	}

	void Update () {

		Debug.Log("current pos:" + transform.position);
		Debug.Log("target pos:" + targetPos);

		var distance = Utils.GetDistanceIn2D(transform.position, targetPos);
		Debug.Log("distance" + distance);
		if (distance < pickNextWaypointDist)
		{
			Debug.Log("Arrived");
			//arrived
			SendEvent("Finish");
		}
		else
		{
			//TODO:time.deltaTime should be replaced using a more powerful TimeSystem
			var dir = (targetPos - transform.position);
			dir.y = 0;
			var shouldMove = Time.deltaTime * speed;


			if (distance <= shouldMove)
			{
				characterCtrl.Move(dir);
			}
			else
			{
				characterCtrl.Move(dir.normalized * shouldMove - new Vector3(0f, gravity * Time.deltaTime, 0f));
			}
		}

	}
	#endregion

	#region Public Method

	public override bool ProcessEvent(int eventId)
	{
		var moveEvt = blackboard.GetFsmEvent("MoveTo");
		if (moveEvt.id == eventId)
		{
			RefreshTargetPos();
			return false;
		}

		return base.ProcessEvent(eventId);
	}
	#endregion
}