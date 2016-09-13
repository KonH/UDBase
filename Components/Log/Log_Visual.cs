using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Visual : ILog {
		// TODO: Create Unity UI overlay and use it for logging

		public void Init() {
			Debug.Log("Init Visual log");
		}

		public void Message(string msg) {
			Debug.Log("This message will be on-screen: " + msg);
		}	
	}
}
