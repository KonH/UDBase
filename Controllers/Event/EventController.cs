using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	public class EventController : IEvent {

		public void Init() {}

		public void PostInit() {}

		public void Fire<T>(T arg) {
			Debug.LogFormat("Fire: {0}", arg);
		}

		public void Subscribe<T>(T eventType, object handler, System.Action<T> callback) {
			Debug.LogFormat("Subscribe: {0} for {1}", eventType, handler);
		}

		public void Unsubscribe<T>(T eventType, object handler) {
			Debug.LogFormat("Unsubscribe: {0} from {1}", eventType, handler);
		}
	}
}