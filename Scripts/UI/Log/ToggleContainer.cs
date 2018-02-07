using UnityEngine;
using UnityEngine.UI;
using System;

namespace UDBase.Controllers.LogSystem.UI {
	public class ToggleContainer : MonoBehaviour {
		public Toggle Toggle;
		public Text   Text;

		public void Init(bool state, string itemName, Action<string, bool> onValueChangedCallback) {
			Toggle.isOn = state;
			Text.text   = itemName;
			Toggle.onValueChanged.AddListener((bool status) => onValueChangedCallback(itemName, status));
		}


	}
}
