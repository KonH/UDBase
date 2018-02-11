using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.LocalizationSystem.UI {
	[RequireComponent(typeof(Text))]
	public class LocaleText : MonoBehaviour {

		[SerializeField]
		string       Key;
		[SerializeField]
		List<string> Arguments = new List<string>();

		Text _text;

		ILocalization _locale;
		IEvent        _events;

		[Inject]
		public void Init(ILocalization locale, IEvent events) {
			_locale = locale;
			_events = events;
			_text = GetComponent<Text>();
			_events.Subscribe<LanguageChanged>(this, OnLanguageChanged);
		}

		void Start() {
			UpdateText();
		}

		void OnDestroy() {
			_events?.Unsubscribe<LanguageChanged>(OnLanguageChanged);
		}

		void OnLanguageChanged(LanguageChanged e) {
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
				return _locale.TranslateFormat(Key, Arguments.ToArray());
			} else {
				return _locale.Translate(Key);
			}
		}
	}
}
