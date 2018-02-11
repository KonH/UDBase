using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.LocalizationSystem {
	public interface ILocalization {
		SystemLanguage CurrentLanguage { get; set; }

		string Translate      (string key);
		string TranslateFormat(string key, string[] args);
	}
}
