using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Visual_Behaviour : MonoBehaviour {
		public Text Text;

		public void Init() {
			Text.text = "";
		}

		public void AddMessage(string msg) {
			Text.text += msg + "\n";
		}
	}
}
