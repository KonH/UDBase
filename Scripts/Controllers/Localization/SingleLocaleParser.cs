﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;

using LanguageKeyDict = 
	System.Collections.Generic.Dictionary
		<UnityEngine.SystemLanguage, 
		System.Collections.Generic.Dictionary<string, string>>;

namespace UDBase.Controllers.LocalizationSystem {

	/// <summary>
	/// Localization source which uses CSV file in format:
	/// first line header: ignored; language_name_0; ...; language_name_N;
	/// (language_name = UnityEngine.SystemLanguage name)
	/// next lines: key; value_for_language_0; ...; value_for_language_N;
	/// </summary>
	public class SingleLocaleParser : ILocaleParser, ILogContext {

		/// <summary>
		/// Settings for CSV single locale parser
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// The character which separates fields
			/// </summary>
			[Tooltip("The character which separates fields")]
			public char Separator;

			/// <summary>
			/// Filename in resources
			/// </summary>
			[Tooltip("Filename in resources")]
			public string FileName;
		}

		LanguageKeyDict _values;

		ULogger _log;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		public SingleLocaleParser(Settings settings, ILog log) {
			_log = log.CreateLogger(this);
			var content = GetLocaleContent(settings.FileName);
			_values = ParseLocaleContent(content, settings.Separator);
		}

		string GetLocaleContent(string fileName) {
			var asset = Resources.Load<TextAsset>(fileName);
			if ( asset ) {
				return asset.text;
			} else {
				_log.ErrorFormat("Can't find file '{0}' in Resources", fileName);
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
				_log.Error("File is in wrong format");
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
						_log.ErrorFormat("Unknown language: '{0}'", langStr);
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
					_log.ErrorFormat("Several values for '{0}' in language {1}", key, language);
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
					_log.ErrorFormat("Can't find value '{0}' in language {1}", key, language);
				}
			} else {
				_log.ErrorFormat("Can't find language {0}", language);
			}
			return value;
		}
	}
}
