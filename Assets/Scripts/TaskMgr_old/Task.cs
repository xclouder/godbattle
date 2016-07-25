using UnityEngine;
using System.Collections;

public class Task {

	public enum Status
	{
		WaitForStart,
		Started,
		Fault,
		Completed
	}


	public TaskQueue OwningQueue { get; set; }

	public Status State { get; protected set; }
	public Task()
	{
		State = Status.WaitForStart;
	}

	public virtual void Start()
	{
		State = Status.Started;
	}

	public virtual void Cancel()
	{

	}

}
