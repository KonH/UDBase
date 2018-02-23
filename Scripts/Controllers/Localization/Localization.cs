using System;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.LocalizationSystem {

	/// <summary>
	/// Event which fired when language was changed
	/// </summary>
	public struct LanguageChanged {
		public SystemLanguage NewLanguage { get; }

		public LanguageChanged(SystemLanguage newLanguage) {
			NewLanguage = newLanguage;
		}

		public override string ToString() => $"LanguageChanged: {NewLanguage}";
	}

	/// <summary>
	/// Default localization controller
	/// </summary>
	public class Localization : ILocalization {

		/// <summary>
		/// Common localization settings
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// Language to set when user language isn't supported
			/// </summary>
			[Tooltip("Language to set when user language isn't supported")]
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

		/// <summary>
		/// Init with dependencies
		/// </summary>
		public Localization(Settings settings, ILocaleParser parser, IEvent events) {
			_parser = parser;
			_events = events;
			_lang   = settings.DefaultLanguage;
			CurrentLanguage = DetectLanguage();
		}

		/// <summary>
		/// Detect language at first time
		/// </summary>
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
