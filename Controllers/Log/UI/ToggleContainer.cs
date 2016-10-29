using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

namespace UDBase.Controllers.Log.UI {
	public class ToggleContainer : MonoBehaviour {
		public Toggle Toggle = null;
		public Text   Text   = null;

		public void Init(bool state, string name, Action<string, bool> onValueChangedCallback) {
			Toggle.isOn = state;
			Text.text   = name;
			Toggle.onValueChanged.AddListener((bool status) => onValueChangedCallback(name, status));
		}


	}
}
