using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Utils;

namespace UDBase.Controllers.LogSystem.UI {
	public class VisualLogHandler : MonoBehaviour {
		[Serializable]
		public class Settings {
			public string PrefabName;
			public ButtonPosition OpenButtonPosition;
		}

		[Serializable]
		public class ButtonPosHander {
			public ButtonPosition Position  = ButtonPosition.LeftTop;
			public Transform      Transform = null;
		}

		class LoggerState {
			protected LoggerState(
				VisualLogHandler owner,
				bool openCn, bool mainCn, bool topConCn, bool emptyCn, bool settingsCn, 
				bool miniBtn, bool maxiBtn) {
				owner.OpenContent.SetActive              (openCn);
				owner.MainContent.SetActive              (mainCn);
				owner.TopControlsContent.SetActive       (topConCn);
				owner.EmptyContent.SetActive             (emptyCn);
				owner.SettingsContent.SetActive          (settingsCn);
				owner.MinimizeButton.gameObject.SetActive(miniBtn);
				owner.MaximizeButton.gameObject.SetActive(maxiBtn);
			}
		}

		class HiddenState:LoggerState {
			public HiddenState(VisualLogHandler owner):
				base(owner, true, false, false, false, false, false, false) {}
		}

		class FullOpenState:LoggerState {
			public FullOpenState(VisualLogHandler owner):
				base(owner, false, true, true, false, false, true, false) {}
		}

		class MiniOpenState:LoggerState {
			public MiniOpenState(VisualLogHandler owner):
				base(owner, false, true, true, true, false, false, true) {}
		}

		class OpenSettingsState:LoggerState {
			public OpenSettingsState(VisualLogHandler owner):
				base(owner, false, true, false, false, true, false, false) {}
		}

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
			public readonly List<LogEntry> Entries = new List<LogEntry>(1000);

			public void Store(string msg, LogType type, string tag) {
				Entries.Add(new LogEntry(msg, type, tag));
			}
		}

		
		const string FormatStr = "<color=\"{0}\">[{1}] {2}: {3}\n</color>";
		
		[Header("Base")]
		public List<ButtonPosHander> OpenPositions      = new List<ButtonPosHander>();
		public Text                  Text;
		public ToggleContainer       TagSample;
		public ToggleContainer       TypeSample;

		[Header("Content")]
		public GameObject            OpenContent;
		public GameObject            MainContent;
		public GameObject            TopControlsContent;
		public GameObject            EmptyContent;
		public GameObject            SettingsContent;

		[Header("Controls")]
		public Button                OpenButton;
		public Button                ClearButton;
		public Button                CloseSettingsButton;
		public Button                CloseButton;
		public Button                MinimizeButton;
		public Button                MaximizeButton;
		public Button                OpenSettingsButton;

		[Header("Runtime")]
		public string                CurrentState        = "";

		readonly Dictionary<LogType, bool> _typeStates = new Dictionary<LogType, bool>();
		readonly Dictionary<string, bool>  _tagStates  = new Dictionary<string, bool>();
		readonly LogContainer              _container  = new LogContainer();
		
		StringBuilder _sb = new StringBuilder(10000);
		LoggerState   _state;

		public VisualLogHandler(Settings settings) {
			Clear(true);
			SetupTypes();
			SetupTags(Enum.GetNames(typeof(LogTags)));
			ChangeState(new HiddenState(this));
			AttachButtonToPosition(settings.OpenButtonPosition);
			SetupButtons();
		}

		Transform GetButtonPos(ButtonPosition pos) {
			for(int i = 0; i < OpenPositions.Count; i++) {
				var posItem = OpenPositions[i];
				if( posItem.Position == pos ) {
					return posItem.Transform;
				}
			}
			return null;
		}

		void AttachButtonToPosition(ButtonPosition pos) {
			var parent = GetButtonPos(pos);
			if( parent ) {
				OpenButton.transform.SetParent(parent, false);
			}
		}

		void SetupButtons() {
			OpenButton.onClick.AddListener         (() => ChangeState (new FullOpenState    (this)));
			CloseButton.onClick.AddListener        (() => ChangeState (new HiddenState      (this)));
			MinimizeButton.onClick.AddListener     (() => ChangeState (new MiniOpenState    (this)));
			MaximizeButton.onClick.AddListener     (() => ChangeState (new FullOpenState    (this)));
			OpenSettingsButton.onClick.AddListener (() => ChangeState (new OpenSettingsState(this)));
			CloseSettingsButton.onClick.AddListener(() => ChangeState (new FullOpenState    (this)));

			ClearButton.onClick.AddListener(() => Clear(true));

		}

		void ChangeState(LoggerState state) {
			_state = state;
			CurrentState = _state.GetType().Name;
		}

		void SetupTypes() {
			var values = Enum.GetValues(typeof(LogType));
			var states = new bool[values.Length];

			for( int i = 0; i < values.Length; i++) {
				var type = (LogType)values.GetValue(i);
				var state = PlayerPrefsUtils.GetBool(FormatTypeKey(type), true);
				states[i] = state;
				_typeStates.Add(type, state);
			}

			SetupToggles(TypeSample, Enum.GetNames(typeof(LogType)), states, OnTypeChanged);
		}

		void SetupTags(string[] tags) {
			var states = new bool[tags.Length];
			for( int i = 0; i < tags.Length; i++) {
				var curTag = tags[i];
				var state = PlayerPrefsUtils.GetBool(FormatTagKey(curTag), true);
				states[i] = state;
				_tagStates.Add(curTag, state);
			}
			SetupToggles(TagSample, tags, states, OnTagChanged);
		}

		void SetupToggles(ToggleContainer template, string[] names, bool[] values, Action<string, bool> callback) {
			for(int i = 0; i < names.Length; i++) {
				var newItem = Instantiate(template, template.transform.parent) as ToggleContainer;
				newItem.Init(values[i], names[i], callback);
			}
			template.gameObject.SetActive(false);
		}

		void OnTypeChanged(string typeName, bool state) {
			var value = (LogType)Enum.Parse(typeof(LogType), typeName);
			ChangeType(value, state);
			UpdateText();
		}

		void ChangeType(LogType value, bool state) {
			_typeStates[value] = state;
			PlayerPrefsUtils.SetBool(FormatTypeKey(value), state);
		}

		void OnTagChanged(string tagName, bool state) {
			ChangeTag(tagName, state);
			UpdateText();
		}

		void ChangeTag(string tagName, bool state) {
			_tagStates[tagName] = state;
			PlayerPrefsUtils.SetBool(FormatTagKey(tagName), state);
		}

		public void Clear(bool full) {
			if( full ) {
				_container.Entries.Clear();
			}
			Text.text = "";
		}

		bool IsTagRequired(string tagName) {
			bool state;
			if( _tagStates.TryGetValue(tagName, out state) ) {
				return state;
			} else {
				Debug.LogErrorFormat("Unknown tag: {0}!", tagName); 
				return true;
			}
		}

		bool IsTypeRequired(LogType type) {
			return _typeStates[type];
		}

		public void AddMessage(LogType type, string tagName, string msg) {
			_container.Store(msg, type, tagName);
			ApplyMessage(msg, type, tagName, true);
		}

		string GetColor(LogType type) {
			switch( type ) {
				case LogType.Assert: {
						return "blue";
					}

				case LogType.Error: {
						return "red";
					}

				case LogType.Exception: {
						return "red";
					}

				case LogType.Warning: {
						return "yellow";
					}
			}
			return "";
		}

		void ApplyMessage(string msg, LogType type, string tagName, bool addNow) {
			if( Text && IsTagRequired(tagName) && IsTypeRequired(type)) {
				var color = GetColor(type);
				if( addNow ) {
					Text.text += string.Format(FormatStr, color, tagName, type, msg);
				} else {
					_sb = _sb.AppendFormat(FormatStr, color, tagName, type, msg);
				}
			}
		}

		void InitApply() {
			_sb.Length = 0;
		}

		void ApplyAll() {
			Text.text += _sb.ToString();
		}

		void UpdateText() {
			Clear(false);
			InitApply();
			for( int i = 0; i < _container.Entries.Count; i++) {
				var entry = _container.Entries[i];
				ApplyMessage(entry.Message, entry.Type, entry.Tag, false);
			}
			ApplyAll();
		}

		string FormatTypeKey(LogType type) {
			return "visual_log_type_" + type.ToString();
		}

		string FormatTagKey(string tagName) {
			return "visual_log_tag_" + tagName;
		}
	}
}
