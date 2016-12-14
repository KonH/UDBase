using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	public class Events:ControllerHelper<IEvent> {

		public static void Fire<T>(T arg) {
			if( Instance != null ) {
				Instance.Fire(arg);
			}
		}

		public static void Subscribe<T>(object handler, System.Action<T> callback) {
			if( Instance != null ) {
				Instance.Subscribe<T>(handler, callback);
			}
		}

		public static void Unsubscribe<T>(Action<T> callback) {
			if( Instance != null ) {
				Instance.Unsubscribe<T>(callback);
			}
		}

		public static IEvent GetInstance() {
			return Instance;
		}
	}
}
