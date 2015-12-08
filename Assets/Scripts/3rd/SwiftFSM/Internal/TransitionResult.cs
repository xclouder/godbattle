using System;
using System.Collections;

internal class TransitionResult<TState, TEvent> 
	where TState : IComparable
	where TEvent : IComparable
{

	public TransitionResult (bool fired, IInnerState<TState, TEvent> toState)
	{
		IsFired = fired;
		ToState = toState;
	}

	public bool IsFired {get;set;}

	public IInnerState<TState, TEvent> ToState {get;set;}

}
