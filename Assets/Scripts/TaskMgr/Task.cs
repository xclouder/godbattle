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


	public Status State { get; protected set; }
	public Task()
	{
		State = Status.WaitForStart;
	}

	public virtual void Start()
	{
		State = Status.Started;
	}

}
