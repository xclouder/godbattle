using System;
using System.Collections;

internal interface IFactory<TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{
	IInnerState<TState, TEvent> Create(TState stateId);
	ITransition<TState, TEvent> CreateTransition(TEvent evtId, IInnerState<TState, TEvent> target);
}
