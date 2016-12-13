using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	public class Event:ControllerHelper<IEvent> {

		public void Fire<T>(T arg) {
			if( Instance != null ) {
				Instance.Fire(arg);
			}
		}

		public void Subscribe<T>(T eventType, object handler, System.Action<T> callback) {
			if( Instance != null ) {
				Instance.Subscribe(eventType, handler, callback);
			}
		}

		public void Unsubscribe<T>(T eventType, object handler) {
			if( Instance != null ) {
				Instance.Unsubscribe(eventType, handler);
			}
		}
	}
}
