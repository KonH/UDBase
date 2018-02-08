using System.Collections.Generic;

namespace UDBase.Controllers.LocalizationSystem {
	public interface ILocalization {
		string Translate(string key);
		string TranslateFormat(string key, ICollection<string> args);
	}
}
