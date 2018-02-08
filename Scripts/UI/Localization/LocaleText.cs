using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UDBase.Controllers.LocalizationSystem.UI {
	[RequireComponent(typeof(Text))]
	public class LocaleText : MonoBehaviour {

		[SerializeField]
		string       Key;
		[SerializeField]
		List<string> Arguments;

		Text          _text;
		ILocalization _locale;

		[Inject]
		public void Init(ILocalization locale) {
			_locale = locale;
			_text = GetComponent<Text>();
		}

		void Start() {
			UpdateText();
		}

		public void UpdateKey(string key) {
			Key = key;
			UpdateText();
		}

		public void UpdateArguments(params string[] arguments) {
			UpdateValues(Key, arguments);
		}

		public void UpdateValues(string key, string[] arguments) {
			Key = key;
			Arguments.Clear();
			Arguments.AddRange(arguments);
			UpdateText();
		}

		void UpdateText() {
			if ( _locale != null ) {
				_text.text = Translate();
			}
		}

		string Translate() {
			if ( Arguments.Count > 0 ) {
				return _locale.TranslateFormat(Key, Arguments);
			} else {
				return _locale.Translate(Key);
			}
		}
	}
}
