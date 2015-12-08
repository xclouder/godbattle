using System;
using System.Collections;
using System.Collections.Generic;

internal class StateDictionary<TState, TEvent> 
	where TState : IComparable
	where TEvent : IComparable
{
	private IDictionary<TState, IInnerState<TState, TEvent>> dict;
	private IFactory<TState, TEvent> factory;

	public StateDictionary(IFactory<TState, TEvent> fac)
	{
		dict = new Dictionary<TState, IInnerState<TState, TEvent>>();
		factory = fac;
	}

	public IInnerState<TState, TEvent> this[TState stateId]
	{
		get {

			if (dict.ContainsKey(stateId))
			{
				return dict[stateId];
			}

			var s = factory.Create(stateId);
			dict.Add(stateId, s);

			return s;
		}
	}
}
