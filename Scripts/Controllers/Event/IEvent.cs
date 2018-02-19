using System;

namespace UDBase.Controllers.EventSystem {

	/// <summary>
	/// IEvent is a lightweight event system, based on System.Action.
	/// It does not use UnityEvent or native C# event/delegate way.
	/// You can use both class and struct as event object.
	/// For prevent leak issues you need to unsubscribe from events when you doesn't need them, e.g. in OnDisable/OnDestroy.
	/// Unsubscribing is required for custom classes, for MonoBehaviour classes it recommended,
	/// because before each event firing watchers checked for destroyed scripts and remove it (but if event is rare it may not happen).
	/// </summary>
	public interface IEvent {

		/// <summary>
		/// Fire the specified event
		/// </summary>
		void Fire<T>(T arg);

		/// <summary>
		/// Subscribe the specified handler for specic event type using callback
		/// </summary>
		void Subscribe<T>(object handler, Action<T> callback);

		/// <summary>
		/// Unsubscribe the specified callback
		/// </summary>
		void Unsubscribe<T>(Action<T> callback);
	}
}