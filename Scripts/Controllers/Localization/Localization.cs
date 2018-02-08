namespace UDBase.Controllers.LocalizationSystem {
	public class Localization : ILocalization {
		readonly ILocaleParser _parser;

		public Localization(ILocaleParser parser) {
			_parser = parser;
		}
	}
}
