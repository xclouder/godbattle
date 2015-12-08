using System;
using System.Collections;

public interface IOnSyntax <TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{
	IInSyntax<TState, TEvent> GoTo(TState state);
}
