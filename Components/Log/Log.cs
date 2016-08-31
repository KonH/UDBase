using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log : ComponentHelper<ILog> {
		// TODO: Make full set of calls without memory allocation (code ganeration)

		public static void Message(string msg) {
			if(Instance != null) {
				Instance.Message(msg);
			}
		}
	}
}
