using UnityEngine;
using UnityEngine.UI;
using System;

namespace UDBase.Controllers.LogSystem.UI {
	/// <summary>
	/// Internal LogSystem.UI component to switch tag/type visibility
	/// </summary>
	public class ToggleContainer : MonoBehaviour {
		public Toggle Toggle;
		public Text   Text;

		public void Init(bool state, string itemName, Action<string, bool> onValueChangedCallback) {
			Toggle.isOn = state;
			Text.text   = ToShortName(itemName);
			Toggle.onValueChanged.AddListener((bool status) => onValueChangedCallback(itemName, status));
		}

		string ToShortName(string fullName) {
			var lastDotIndex = fullName.LastIndexOf('.');
			if ( lastDotIndex > 0 ) {
				return fullName.Substring(lastDotIndex + 1);
			}
			return fullName;
		}
	}
}
