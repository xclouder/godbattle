using System;
using System.Collections;
using System.Collections.Generic;

namespace EventDispatch
{

	public delegate void EventHandler();
	public delegate void EventHandler<T>(T p1);
	public delegate void EventHandler<T, U>(T p1, U p2);
	public delegate void EventHandler<T, U, V>(T p1, U p2, V p3);

	public class DispatchEventException : Exception {
		public DispatchEventException(string msg)
			: base(msg) {
		}
	}

	public struct EventHandlePair
	{
		public string eventName;
		public Delegate handler;

		public EventHandlePair(string evtName, Delegate h)
		{
			eventName = evtName;
			handler = h;
		}
	}

	public class EventDispatcher {

		static private IDictionary<string, Delegate> eventTable = new Dictionary<string, Delegate>();


		#region Helper Methods
		static private bool CheckEventName(string eventName)
		{
			if (!eventTable.ContainsKey(eventName))
			{
				UnityEngine.Debug.LogError("event name:" + eventName + " not exist");
				return false;
			}

			return true;
		}

		static private void PrintEventTable()
		{
			UnityEngine.Debug.Log("\t\t\t=== EventDispatcher PrintEventTable ===");

			foreach (KeyValuePair<string, Delegate> pair in eventTable) {
				UnityEngine.Debug.Log("\t\t\t" + pair.Key + "\t\t" + pair.Value);
			}

			UnityEngine.Debug.Log("\n");
		}

		static private DispatchEventException CreateDispatchSignatureException(string eventName)
		{
			return new DispatchEventException(string.Format("Dispatch event \"{0}\" but listeners have a different signature than the event.", eventName));
		}

		static private void OnListenerAdding(string eventType, Delegate listenerBeingAdded) {

			if (!eventTable.ContainsKey(eventType)) {
				eventTable.Add(eventType, null );
			}

			Delegate d = eventTable[eventType];
			if (d != null && d.GetType() != listenerBeingAdded.GetType()) {
				throw new InvalidOperationException(string.Format("Attempting to add listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being added has type {2}", eventType, d.GetType().Name, listenerBeingAdded.GetType().Name));
			}
		}

		static private void OnListenerRemoving(string eventType, Delegate listenerBeingRemoved) {
			if (eventTable.ContainsKey(eventType)) {
				Delegate d = eventTable[eventType];

				if (d == null) {
					throw new InvalidOperationException(string.Format("Attempting to remove listener with for event type \"{0}\" but current listener is null.", eventType));
				} else if (d.GetType() != listenerBeingRemoved.GetType()) {
					throw new InvalidOperationException(string.Format("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
				}
			} else {
				throw new InvalidOperationException(string.Format("Attempting to remove listener for type \"{0}\" but Messenger doesn't know about this event type.", eventType));
			}
		}

		static private void OnListenerRemoved(string eventType) {
			if (eventTable[eventType] == null) {
				eventTable.Remove(eventType);
			}
		}

		#endregion

		#region Fire Event
		static public void Fire(string eventName)
		{
			if (!CheckEventName(eventName))
				return;

			Delegate del = null;
			if (eventTable.TryGetValue(eventName, out del))
			{
				var h = del as EventHandler;
				if (h != null)
				{
					h();
				}
				else
				{
					throw CreateDispatchSignatureException(eventName);
				}
			}
		}

		static public void Fire<T>(string eventName, T p1)
		{
			if (!CheckEventName(eventName))
				return;

			Delegate del = null;
			if (eventTable.TryGetValue(eventName, out del))
			{
				var h = del as EventHandler<T>;
				if (h != null)
				{
					h(p1);
				}
				else
				{
					throw CreateDispatchSignatureException(eventName);
				}
			}
		}

		static public void Fire<T, U>(string eventName, T p1, U p2)
		{
			if (!CheckEventName(eventName))
				return;

			Delegate del = null;
			if (eventTable.TryGetValue(eventName, out del))
			{
				var h = del as EventHandler<T, U>;
				if (h != null)
				{
					h(p1, p2);
				}
				else
				{
					throw CreateDispatchSignatureException(eventName);
				}
			}
		}

		static public void Fire<T, U, V>(string eventName, T p1, U p2, V p3)
		{
			if (!eventTable.ContainsKey(eventName))
			{
				UnityEngine.Debug.LogError("event name:" + eventName + " not exist");
				return;
			}

			Delegate del = null;
			if (eventTable.TryGetValue(eventName, out del))
			{
				var h = del as EventHandler<T, U, V>;
				if (h != null)
				{
					h(p1, p2, p3);
				}
				else
				{
					throw CreateDispatchSignatureException(eventName);
				}
			}
		}


		#endregion

		#region Add Listener
		static public EventHandlePair AddListener(string eventName, EventHandler handler)
		{
			OnListenerAdding(eventName, handler);
			eventTable[eventName] = (EventHandler)eventTable[eventName] + handler;

			return new EventHandlePair(eventName, handler);
		}

		static public EventHandlePair AddListener<T>(string eventName, EventHandler<T> handler)
		{
			OnListenerAdding(eventName, handler);
			eventTable[eventName] = (EventHandler<T>)eventTable[eventName] + handler;

			return new EventHandlePair(eventName, handler);
		}

		static public EventHandlePair AddListener<T, U>(string eventName, EventHandler<T, U> handler)
		{
			OnListenerAdding(eventName, handler);
			eventTable[eventName] = (EventHandler<T, U>)eventTable[eventName] + handler;

			return new EventHandlePair(eventName, handler);
		}

		static public EventHandlePair AddListener<T, U, V>(string eventName, EventHandler<T, U, V> handler)
		{
			OnListenerAdding(eventName, handler);
			eventTable[eventName] = (EventHandler<T, U, V>)eventTable[eventName] + handler;

			return new EventHandlePair(eventName, handler);
		}

		#endregion

		#region Remove Listener

		static public void RemoveListener(string eventType, EventHandler handler) {
			OnListenerRemoving(eventType, handler);   
			eventTable[eventType] = (EventHandler)eventTable[eventType] - handler;
			OnListenerRemoved(eventType);
		}

		static public void RemoveListener<T>(string eventType, EventHandler<T> handler) {
			OnListenerRemoving(eventType, handler);   
			eventTable[eventType] = (EventHandler<T>)eventTable[eventType] - handler;
			OnListenerRemoved(eventType);
		}
		static public void RemoveListener<T, U>(string eventType, EventHandler<T, U> handler) {
			OnListenerRemoving(eventType, handler);   
			eventTable[eventType] = (EventHandler<T, U>)eventTable[eventType] - handler;
			OnListenerRemoved(eventType);
		}
		static public void RemoveListener<T, U, V>(string eventType, EventHandler<T, U, V> handler) {
			OnListenerRemoving(eventType, handler);   
			eventTable[eventType] = (EventHandler<T, U, V>)eventTable[eventType] - handler;
			OnListenerRemoved(eventType);
		}


		static public void RemoveListener(EventHandlePair pair) {
			OnListenerRemoving(pair.eventName, pair.handler);

			var del = eventTable[pair.eventName];
			del = Delegate.Remove(del, pair.handler);
			eventTable[pair.eventName] = del;

			OnListenerRemoved(pair.eventName);
		}

		#endregion

		#region CleanUp
		static public void Cleanup()
		{
			/*
		List<string> messagesToRemove = new List<string>();
		
		foreach (KeyValuePair<string, Delegate> pair in eventTable) {
			messagesToRemove.Add( pair.Key );
		}
		
		foreach (string message in messagesToRemove) {
			eventTable.Remove( message );
		}
		*/

			eventTable.Clear();
		}

		#endregion
	}
}