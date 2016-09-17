using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Components.Log {
	public class Log_Visual_Behaviour : MonoBehaviour {
		public Text Text;

		List<string> _messages = new List<string>();

		public void Init() {
			Clear();
		}

		public void Clear() {
			Text.text = "";
		}

		public void AddMessage(string msg) {
			_messages.Add(msg);
			ApplyMessage(msg);
		}

		void ApplyMessage(string msg) {
			Text.text += msg + "\n";
		}
	}
}
