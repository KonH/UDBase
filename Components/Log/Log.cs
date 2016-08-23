using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log : ComponentHelper<ILog> {

		public static void Message(string msg) {
			if(Instance != null) {
				Instance.Message(msg);
			}
		}
	}
}
