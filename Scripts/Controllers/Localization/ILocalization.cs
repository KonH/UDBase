using UnityEngine;

namespace UDBase.Controllers.LocalizationSystem {

	/// <summary>
	/// Localization system to detect and store current language and translate text for it
	/// </summary>
	public interface ILocalization {

		/// <summary>
		/// Current user language
		/// </summary>
		SystemLanguage CurrentLanguage { get; set; }

		/// <summary>
		/// Get text for given key and current language
		/// </summary>
		string Translate (string key);

		/// <summary>
		/// Get text for given key and current language, then use string.Format with given args on it
		/// </summary>
		string TranslateFormat(string key, string[] args);
	}
}
