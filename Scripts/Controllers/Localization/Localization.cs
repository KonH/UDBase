using System;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.LocalizationSystem {
	public struct LanguageChanged {
		public SystemLanguage NewLanguage { get; }

		public LanguageChanged(SystemLanguage newLanguage) {
			NewLanguage = newLanguage;
		}

		public override string ToString() => $"LanguageChanged: {NewLanguage}";
	}

	public class Localization : ILocalization {

		[Serializable]
		public class Settings {
			public SystemLanguage DefaultLanguage;
		}

		public SystemLanguage CurrentLanguage {
			get {
				return _lang;
			}
			set {
				if ( _lang != value ) {
					if ( _parser.HasLanguage(value) ) {
						_lang = value;
						_events.Fire(new LanguageChanged(_lang));
					}
				}
			}
		}

		SystemLanguage _lang;

		readonly ILocaleParser _parser;
		readonly IEvent        _events;

		public Localization(Settings settings, ILocaleParser parser, IEvent events) {
			_parser = parser;
			_events = events;
			_lang   = settings.DefaultLanguage;
			CurrentLanguage = DetectLanguage();
		}

		protected SystemLanguage DetectLanguage() {
			return Application.systemLanguage;
		}

		public string Translate(string key) {
			var value = _parser.GetValue(CurrentLanguage, key);
			return TextUtils.EnsureString(value);
		}

		public string TranslateFormat(string key, string[] args) {
			var text = Translate(key);
			if ( !string.IsNullOrEmpty(text) ) {
				return string.Format(text, args);
			}
			return string.Empty;
		}
	}
}
