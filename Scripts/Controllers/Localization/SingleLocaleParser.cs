using System;

namespace UDBase.Controllers.LocalizationSystem {
	public class SingleLocaleParser : ILocaleParser {

		[Serializable]
		public class Settings {
			public string FileName;
		}

		string _fileName;

		public SingleLocaleParser(Settings settings) {
			_fileName = settings.FileName;
		}
	}
}
