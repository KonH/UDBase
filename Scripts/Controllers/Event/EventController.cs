using System;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.EventSystem {

	/// <summary>
	/// Default event controller
	/// </summary>
	public class EventController : IEvent, ILogContext {
		readonly Dictionary<Type, EventHandlerBase> _handlers    = new Dictionary<Type, EventHandlerBase>();
		readonly Dictionary<Type, List<object>>     _tmpHandlers = new Dictionary<Type, List<object>>();

		ULogger _log;

		public EventController(ILog log) {
			_log = log.CreateLogger(this);
		}

		EventHandler<T> GetHandler<T>() {
			var eventType = typeof(T);
			EventHandlerBase baseHandler;
			if( _handlers.TryGetValue(eventType, out baseHandler) ) {
				EventHandler<T> concreteHandler = baseHandler as EventHandler<T>;
				return concreteHandler;
			}
			return null;
		}

		EventHandler<T> GetOrCreateHandler<T>() {
			var handler = GetHandler<T>();
			if (handler != null) {
				return handler;
			}
			handler = new EventHandler<T>();
			_handlers.Add(typeof(T), handler);
			return handler;
		}

		public void Fire<T>(T arg) {
			var handler = GetHandler<T>();
			if( handler != null ) {
				handler.Fire(arg);
			}
			_log.MessageFormat("Fire: {0}", arg);
		}

		public void Subscribe<T>(object handler, Action<T> callback) {
			var eventHandler = GetOrCreateHandler<T>();
			eventHandler.Subscribe(handler, callback);
			_log.MessageFormat("Subscribe: {0} for {1}", typeof(T), handler);
		}

		public void Unsubscribe<T>(Action<T> action) {
			var handler = GetHandler<T>();
			if( handler != null ) {
				handler.Unsubscribe(action);
			}
			_log.MessageFormat("Unsubscribe: {0}", typeof(T));
		}
	
		/// <summary>
		/// Gets the handlers for further use in EventWindow
		/// </summary>
		public Dictionary<Type, List<object>> GetHandlers() {
			_tmpHandlers.Clear();
			var handlerIter = _handlers.GetEnumerator();
			while( handlerIter.MoveNext() ) {
				var current = handlerIter.Current;
				_tmpHandlers.Add(current.Key, current.Value.Handlers);
			}
			return _tmpHandlers;
		}
	}
}