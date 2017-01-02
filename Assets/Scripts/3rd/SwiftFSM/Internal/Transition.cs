using System;
using System.Collections;

internal class Transition<TState, TEvent> : ITransition <TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{
	public IInnerState<TState, TEvent> Source {get;set;}
	public IInnerState<TState, TEvent> Target {get;set;}
	public TEvent EventToTrigger {get;set;}


	public bool CanTranslate(TEvent firedEvent)
	{
		return EventToTrigger.Equals(firedEvent);
	}
}
