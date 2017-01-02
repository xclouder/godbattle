using System;
using System.Collections;

internal interface ITransition <TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{

	IInnerState<TState, TEvent> Source {get;set;}
	IInnerState<TState, TEvent> Target {get;set;}
	TEvent EventToTrigger {get;set;}

	bool CanTranslate(TEvent firedEvent);

}
