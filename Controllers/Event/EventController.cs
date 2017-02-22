using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.EventSystem {
	public class EventController : IEvent {

		Dictionary<Type, EventHandlerBase> _handlers    = new Dictionary<Type, EventHandlerBase>();
		Dictionary<Type, List<object>>     _tmpHandlers = new Dictionary<Type, List<object>>();

		public void Init() {}

		public void PostInit() {}

		public void Reset() {}

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
			if( handler == null ) {
				handler = new EventHandler<T>();
				_handlers.Add(typeof(T), handler);
			}
			return handler;
		}

		public void Fire<T>(T arg) {
			var handler = GetHandler<T>();
			if( handler != null ) {
				handler.Fire(arg);
			}
			Log.MessageFormat("Fire: {0}", LogTags.Event, arg);
		}

		public void Subscribe<T>(object handler, Action<T> callback) {
			var eventHandler = GetOrCreateHandler<T>();
			eventHandler.Subscribe(handler, callback);
			Log.MessageFormat("Subscribe: {0} for {1}", LogTags.Event, typeof(T), handler);
		}

		public void Unsubscribe<T>(Action<T> action) {
			var handler = GetHandler<T>();
			if( handler != null ) {
				handler.Unsubscribe(action);
			}
			Log.MessageFormat("Unsubscribe: {0}", LogTags.Event, typeof(T));
		}
	
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