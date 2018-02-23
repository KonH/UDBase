using UnityEngine;

namespace UDBase.Controllers.LocalizationSystem {

	/// <summary>
	/// Localization source parser
	/// </summary>
	public interface ILocaleParser {

		/// <summary>
		/// Is requested language presented in source?
		/// </summary>
		bool HasLanguage(SystemLanguage language);

		/// <summary>
		/// Return text for given languange and key
		/// </summary>
		string GetValue(SystemLanguage language, string key);
	}
}
