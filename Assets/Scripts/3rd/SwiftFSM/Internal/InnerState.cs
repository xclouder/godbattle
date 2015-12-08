using System;
using System.Collections;
using System.Collections.Generic;

internal class InnerState<TState, TEvent> : IInnerState<TState, TEvent> 
	where TState : IComparable
	where TEvent : IComparable 
{

    private IList<ITransition<TState, TEvent>> transitions;

	public TState StateId {
		get;
		private set;
	}

	internal InnerState (TState stateId, IState attachedStateEntity)
	{
		StateId = stateId;
		AttachedState = attachedStateEntity;
	}

	public void Enter()
	{
		if (ExecuteOnEnterAction != null)
			ExecuteOnEnterAction();

		if (AttachedState != null)
			AttachedState.Enter();
	}

	public void Execute()
	{
		if (ExecuteAction != null)
			ExecuteAction();

		if (AttachedState != null)
			AttachedState.Execute();
	}

	public void Exit()
	{
		if (ExecuteOnExitAction != null)
			ExecuteOnExitAction();

		if (AttachedState != null)
			AttachedState.Exit();
	}
	
	public TransitionResult<TState, TEvent> Fire(TEvent eventId, Hashtable parameters = null)
	{
        bool fired = false;
		IInnerState<TState, TEvent> toState = null;
		if (transitions != null)
		{
			foreach (var t in transitions)
			{
				if (t.EventToTrigger.Equals(eventId))
				{
					fired = true;
					toState = t.Target;
				}
			}
		}

		return new TransitionResult<TState, TEvent>(fired, toState);
	}

	public void AddTransition(ITransition<TState, TEvent> tr)
	{
		if (transitions == null)
			transitions = new List<ITransition<TState, TEvent>>();

		transitions.Add(tr);
	}


	public IState AttachedState {get; private set;}
	public void AttachStateObject(IState state)
	{
		AttachedState = state;
	}

	public Action ExecuteOnEnterAction {set; private get;}
	public Action ExecuteOnExitAction {set; private get;}
	public Action ExecuteAction {set; private get;}

}
