using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Empty : ILog {

		public void Init() {
			Debug.Log("Init empty log");
		}

		public void Message(string msg) {}
	}
}