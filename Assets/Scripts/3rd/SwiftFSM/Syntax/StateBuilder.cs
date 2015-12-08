using System;
using System.Collections;

internal class StateBuilder<TState, TEvent> : IInSyntax<TState, TEvent>, IOnSyntax<TState, TEvent>
	where TState : IComparable
	where TEvent : IComparable
{
	private StateDictionary<TState, TEvent> StateDict {get;set;}
	private IFactory<TState, TEvent> Factory {get;set;}

	private IInnerState<TState, TEvent> CurrentState {get;set;}
	private TEvent CurrentEvent {get;set;}

	public StateBuilder(IInnerState<TState, TEvent> state, StateDictionary<TState, TEvent> stateDict, IFactory<TState, TEvent> factory)
	{
		StateDict = stateDict;
		Factory = factory;

		CurrentState = state;
	}

	IInSyntax<TState, TEvent> IInSyntax<TState, TEvent>.ExecuteOnEnter(Action enterAction)
	{
		CurrentState.ExecuteOnEnterAction = enterAction;
		return this;
	}

	IInSyntax<TState, TEvent> IInSyntax<TState, TEvent>.Execute(Action executeAction)
	{
		CurrentState.ExecuteAction = executeAction;

		return this;
	}

	IInSyntax<TState, TEvent> IInSyntax<TState, TEvent>.ExecuteOnExit(Action exitAction)
	{
		CurrentState.ExecuteOnExitAction = exitAction;

		return this;
	}

	IOnSyntax<TState, TEvent> IInSyntax<TState, TEvent>.On(TEvent evt)
	{
		CurrentEvent = evt;

		return this;
	}

	IInSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.GoTo(TState state)
	{
		var toState = StateDict[state];
		var tr = Factory.CreateTransition(CurrentEvent, toState);
		CurrentState.AddTransition(tr);

		return this;
	}

	IInSyntax<TState, TEvent> IInSyntax<TState, TEvent>.Attach(IState attachedState)
	{
		CurrentState.AttachStateObject(attachedState);

		return this;
	}
}
