using System;
using System.Collections;

internal interface IInnerState <TState, TEvent> 
	where TState : IComparable 
	where TEvent : IComparable
{

	TState StateId {get;}

	TransitionResult<TState, TEvent> Fire(TEvent eventId, Hashtable parameters);
	void AddTransition(ITransition<TState, TEvent> tr);

	void AttachStateObject(IState state);

	Action ExecuteOnEnterAction {set;}
	Action ExecuteOnExitAction {set;}
	Action ExecuteAction {set;}

	void Enter();
	void Execute();
	void Exit();
}
