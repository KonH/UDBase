using UnityEngine;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SaveSystem;
using FullSerializer;

namespace UDBase.Controllers.LocalizationSystem {
	public class LocalizationSaveNode : ISaveSource {
		[fsProperty("cur_language")]
		public SystemLanguage CurrentLanguage { get; set; }
	}

	public class SaveLocalization : ILocalization {

		public SystemLanguage CurrentLanguage {
			get {
				return _impl.CurrentLanguage;
			}
			set {
				if ( _impl.CurrentLanguage != value ) {
					_impl.CurrentLanguage = value;
					SaveLanguage(_impl.CurrentLanguage);
				}
			}
		}

		readonly ILocalization _impl;
		readonly ISave         _save;

		public SaveLocalization(Localization.Settings settings, ILocaleParser parser, IEvent events, ISave save) {
			_impl = new Localization(settings, parser, events);
			_save = save;
			_impl.CurrentLanguage = LoadLanguage();
		}

		SystemLanguage LoadLanguage() {
			var node = _save.GetNode<LocalizationSaveNode>(false);
			return (node != null) ? node.CurrentLanguage : _impl.CurrentLanguage;
		}

		void SaveLanguage(SystemLanguage language) {
			var node = _save.GetNode<LocalizationSaveNode>();
			node.CurrentLanguage = language;
			_save.SaveNode(node);
		}

		protected SystemLanguage DetectLanguage() {
			return Application.systemLanguage;
		}

		public string Translate(string key) {
			return _impl.Translate(key);
		}

		public string TranslateFormat(string key, string[] args) {
			return _impl.TranslateFormat(key, args);
		}
	}
}
