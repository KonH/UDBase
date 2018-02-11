using UnityEngine;

namespace UDBase.Controllers.LocalizationSystem {
	public interface ILocaleParser {
		bool   HasLanguage(SystemLanguage language);
		string GetValue(SystemLanguage language, string key);
	}
}
