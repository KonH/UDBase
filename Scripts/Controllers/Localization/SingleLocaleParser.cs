using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;

using LanguageKeyDict = 
	System.Collections.Generic.Dictionary
		<UnityEngine.SystemLanguage, 
		System.Collections.Generic.Dictionary<string, string>>;

namespace UDBase.Controllers.LocalizationSystem {
	public class SingleLocaleParser : ILocaleParser, ILogContext {

		[Serializable]
		public class Settings {
			public char Separator;
			public string FileName;
		}

		LanguageKeyDict _values;

		ILog _log;

		public SingleLocaleParser(Settings settings, ILog log) {
			_log = log;
			var content = GetLocaleContent(settings.FileName);
			_values = ParseLocaleContent(content, settings.Separator);
		}

		string GetLocaleContent(string fileName) {
			var asset = Resources.Load<TextAsset>(fileName);
			if ( asset ) {
				return asset.text;
			} else {
				_log.ErrorFormat(this, "Can't find file '{0}' in Resources", fileName);
				return string.Empty;
			}
		}

		LanguageKeyDict ParseLocaleContent(string content, char separator) {
			var values = new LanguageKeyDict();
			if ( string.IsNullOrEmpty(content) ) {
				return values;
			}
			var lines = content.Split('\n');
			if ( lines.Length >= 1 ) {
				var languages = GetLanguagesFromHeader(lines[0], separator);
				foreach ( var lang in languages ) {
					values.Add(lang, new Dictionary<string, string>());
				}
				for ( var i = 1; i < lines.Length; i++ ) {
					var line = lines[i];
					AddContent(languages, line, separator, values);
				}
			} else {
				_log.Error(this, "File is in wrong format");
			}
			return values;
		}

		List<SystemLanguage> GetLanguagesFromHeader(string line, char separator) {
			var languages = new List<SystemLanguage>();
			var lineParts = line.Split(separator);
			if ( lineParts.Length > 1 ) {
				for ( var i = 1; i < lineParts.Length; i++ ) {
					var langStr = lineParts[i];
					if ( string.IsNullOrWhiteSpace(langStr) ) {
						continue;
					}
					SystemLanguage langValue;
					if ( Enum.TryParse(langStr, out langValue) ) {
						languages.Add(langValue);
					} else {
						_log.ErrorFormat(this, "Unknown language: '{0}'", langStr);
					}
				}
			}
			return languages;
		}

		void AddContent(List<SystemLanguage> languages, string line, char separator, LanguageKeyDict values) {
			var lineParts = line.Split(separator);
			if ( lineParts.Length <= 1 ) {
				return;
			}
			var key = lineParts[0];
			for ( var i = 0; i < languages.Count; i++ ) {
				var language = languages[i];
				if ( lineParts.Length < i + 2 ) {
					return;
				}
				var value = lineParts[i + 1].Trim();
				var langDict = values[language];
				if ( !langDict.ContainsKey(key) ) {
					langDict.Add(key, value);
				} else {
					_log.ErrorFormat(this, "Several values for '{0}' in language {1}", key, language);
				}
			}
		}

		public bool HasLanguage(SystemLanguage language) {
			return _values.ContainsKey(language);
		}

		public string GetValue(SystemLanguage language, string key) {
			var value = string.Empty;
			Dictionary<string, string> keyDict;
			if ( _values.TryGetValue(language, out keyDict) ) {
				var found = keyDict.TryGetValue(key, out value);
				if ( !found ) {
					_log.ErrorFormat(this, "Can't find value '{0}' in language {1}", key, language);
				}
			} else {
				_log.ErrorFormat(this, "Can't find language {0}", language);
			}
			return value;
		}
	}
}
