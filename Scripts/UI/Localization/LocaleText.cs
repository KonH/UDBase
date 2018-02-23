using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.LocalizationSystem.UI {
	/// <summary>
	/// Component to localize UnityEngine.UI.Text by given keys and parameters
	/// </summary>
	[RequireComponent(typeof(Text))]
	[AddComponentMenu("UDBase/UI/Localization/LocaleText")]
	public class LocaleText : MonoBehaviour {

		[SerializeField]
		string       _key;
		[SerializeField]
		List<string> _arguments = new List<string>();

		Text _text;

		ILocalization _locale;
		IEvent        _events;

		/// <summary>
		/// Init with dependencies
		/// </summary>
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

		/// <summary>
		/// Change only localization key
		/// </summary>
		public void UpdateKey(string key) {
			_key = key;
			UpdateText();
		}

		/// <summary>
		/// Change only localization arguments
		/// </summary>
		public void UpdateArguments(params string[] arguments) {
			UpdateValues(_key, arguments);
		}

		/// <summary>
		/// Change both localization key and arguments
		/// </summary>
		public void UpdateValues(string key, string[] arguments) {
			_key = key;
			_arguments.Clear();
			_arguments.AddRange(arguments);
			UpdateText();
		}

		void UpdateText() {
			if ( _locale != null ) {
				_text.text = Translate();
			}
		}

		string Translate() {
			if ( _arguments.Count > 0 ) {
				return _locale.TranslateFormat(_key, _arguments.ToArray());
			} else {
				return _locale.Translate(_key);
			}
		}
	}
}
