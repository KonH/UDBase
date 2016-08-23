using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Unity : ILog {
		public void Init() {
			Debug.Log("Init Unity log");
		}

		public void Message(string msg)
		{
			Debug.Log(msg);
		}
	}
}
