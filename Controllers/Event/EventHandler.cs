using System;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	class EventHandler<T>: EventHandlerBase {
		readonly List<Action<T>> _callbacks     = new List<Action<T>>();
		readonly List<Action<T>> _tempCallbacks = new List<Action<T>>();

		public void Subscribe(object handler, Action<T> callback) {
			_callbacks.Add(callback);
			_handlers.Add(handler);
		}

		public void Unsubscribe(Action<T> callback) {
			var index = _callbacks.IndexOf(callback);
			if( index >= 0 ) {
				Unsubscribe(index);
			}
		}

		void Unsubscribe(int index) {
			_callbacks.RemoveAt(index);
			_handlers.RemoveAt(index);
		}

		public void Fire(T arg) {
			CheckHandlers();
			CollectCallbacks();
			for ( var i = 0; i < _tempCallbacks.Count; i++ ) {
				var currentCallback = _tempCallbacks[i];
				currentCallback.Invoke(arg);
			}
		}

		void CheckHandlers() {
			for ( var i = 0; i < _handlers.Count; i++) {
				var curHandler = _handlers[i];
				var monoHandler = curHandler as MonoBehaviour;
				if ( monoHandler ) {
					continue;
				}
				if ( monoHandler == null ) {
					continue;
				}
				Unsubscribe(i);
				i--;
			}
		}

		void CollectCallbacks() {
			_tempCallbacks.Clear();
			_tempCallbacks.AddRange(_callbacks);
		}
	}
}
