using System.Collections.Generic;

namespace UDBase.Controllers.LocalizationSystem {
	public class Localization : ILocalization {
		readonly ILocaleParser _parser;

		public Localization(ILocaleParser parser) {
			_parser = parser;
		}

		public string Translate(string key) {
			return string.Empty;
		}

		public string TranslateFormat(string key, ICollection<string> args) {
			var text = Translate(key);
			return string.Format(text, args);
		}
	}
}
