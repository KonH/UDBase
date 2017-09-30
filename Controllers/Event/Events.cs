using System;

namespace UDBase.Controllers.EventSystem {
	public class Events:ControllerHelper<IEvent> {
		public static void Fire<T>(T arg) {
			if( Instance != null ) {
				Instance.Fire(arg);
			}
		}

		public static void Subscribe<T>(object handler, Action<T> callback) {
			if( Instance != null ) {
				Instance.Subscribe(handler, callback);
			}
		}

		public static void Unsubscribe<T>(Action<T> callback) {
			if( Instance != null ) {
				Instance.Unsubscribe(callback);
			}
		}

		public static IEvent GetInstance() {
			return Instance;
		}
	}
}
