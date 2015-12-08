using System;
using System.Collections;

public interface IInSyntax<TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{
	IInSyntax<TState, TEvent> ExecuteOnEnter(Action enterAction);
	IInSyntax<TState, TEvent> Execute(Action executeAction);
	IInSyntax<TState, TEvent> ExecuteOnExit(Action enterAction);
	IOnSyntax<TState, TEvent> On(TEvent evt);
	IInSyntax<TState, TEvent> Attach(IState attachedState);
}
