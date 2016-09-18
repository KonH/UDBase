using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Components.Log.UI {
	public class VisualLogHandler : MonoBehaviour {
		// TODO: Do not allocate with enum/string dictionary
		class LogEntry {
			public string  Message { get; private set; }
			public LogType Type    { get; private set; }
			public string  Tag     { get; private set; }

			public LogEntry(string msg, LogType type, string tag) {
				Message = msg;
				Type    = type;
				Tag     = tag;
			}
		}

		class LogContainer {
			public List<LogEntry> Entries = new List<LogEntry>(1000);

			public void Store(string msg, LogType type, string tag) {
				Entries.Add(new LogEntry(msg, type, tag));
			}
		}

		public Text            Text       = null;
		public ToggleContainer TagSample  = null;
		public ToggleContainer TypeSample = null;

		Dictionary<LogType, bool> _typeStates = new Dictionary<LogType, bool>();
		Dictionary<string, bool>  _tagStates  = new Dictionary<string, bool>();
		LogContainer              _container  = new LogContainer();

		// TODO: Add minimize buttons
		// TODO: Setup scroll in text area
		// TODO: Filter and string builder
		// TODO: Save state in PlayerPrefs or State

		public void Init(string[] tags) {
			Clear();
			SetupTypes();
			SetupTags(tags);
		}

		void SetupTypes() {
			var values = Enum.GetValues(typeof(LogType));

			for( int i = 0; i < values.Length; i++) {
				_typeStates.Add((LogType)values.GetValue(i), true);
			}

			SetupToggles(TypeSample, Enum.GetNames(typeof(LogType)), OnTypeChanged);
		}

		void SetupTags(string[] tags) {
			for( int i = 0; i < tags.Length; i++) {
				_tagStates.Add(tags[i], true);
			}
			SetupToggles(TagSample, tags, OnTagChanged);
		}

		void SetupToggles(ToggleContainer template, string[] names, Action<string, bool> callback) {
			for(int i = 0; i < names.Length; i++) {
				var newItem = Instantiate(template, template.transform.parent) as ToggleContainer;
				newItem.Init(true, names[i], callback);
			}
			template.gameObject.SetActive(false);
		}

		void OnTypeChanged(string name, bool state) {
			var value = (LogType)Enum.Parse(typeof(LogType), name);
			_typeStates[value] = state;
			UpdateText();
		}

		void OnTagChanged(string name, bool state) {
			_tagStates[name] = state;
			UpdateText();
		}

		public void Clear() {
			Text.text = "";
		}

		bool IsTagRequired(string tag) {
			return _tagStates[tag];
		}

		bool IsTypeRequired(LogType type) {
			return _typeStates[type];
		}

		public void AddMessage(string msg, LogType type, string tag) {
			_container.Store(msg, type, tag);
			ApplyMessage(msg, type, tag);
		}

		void ApplyMessage(string msg, LogType type, string tag) {
			if( IsTagRequired(tag) && IsTypeRequired(type)) {
				Text.text += string.Format("[{0}] {1}: {2}\n", tag, type, msg);
			}
		}

		void UpdateText() {
			Clear();
			for( int i = 0; i < _container.Entries.Count; i++) {
				var entry = _container.Entries[i];
				ApplyMessage(entry.Message, entry.Type, entry.Tag);
			}
		}
	}
}
