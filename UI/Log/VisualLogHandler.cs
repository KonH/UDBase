using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.Log;

namespace UDBase.Controllers.Log.UI {
	public class VisualLogHandler : MonoBehaviour {

		[Serializable]
		public class ButtonPosHander {
			public ButtonPosition Position  = ButtonPosition.LeftTop;
			public Transform      Transform = null;
		}

		class LoggerState {
			
			public LoggerState(
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
			public List<LogEntry> Entries = new List<LogEntry>(1000);

			public void Store(string msg, LogType type, string tag) {
				Entries.Add(new LogEntry(msg, type, tag));
			}
		}

		[Header("Base")]
		public List<ButtonPosHander> OpenPositions      = new List<ButtonPosHander>();
		public Text                  Text               = null;
		public ToggleContainer       TagSample          = null;
		public ToggleContainer       TypeSample         = null;

		[Header("Content")]
		public GameObject            OpenContent        = null;
		public GameObject            MainContent        = null;
		public GameObject            TopControlsContent = null;
		public GameObject            EmptyContent       = null;
		public GameObject            SettingsContent    = null;

		[Header("Controls")]
		public Button                OpenButton          = null;
		public Button                ClearButton         = null;
		public Button                CloseSettingsButton = null;
		public Button                CloseButton         = null;
		public Button                MinimizeButton      = null;
		public Button                MaximizeButton      = null;
		public Button                OpenSettingsButton  = null;

		[Header("Runtime")]
		public string                CurrentState        = "";

		Dictionary<LogType, bool> _typeStates = new Dictionary<LogType, bool>();
		Dictionary<string, bool>  _tagStates  = new Dictionary<string, bool>();
		LogContainer              _container  = new LogContainer();
		StringBuilder             _sb         = new StringBuilder(10000);
		LoggerState               _state      = null;
		string                    _formatStr  = "<color=\"{0}\">[{1}] {2}: {3}\n</color>";
			

		// TODO: Setup scroll in text area (later)
		// TODO: Save state in PlayerPrefs or State (later)

		public void Init(string[] tags, ButtonPosition openButtonPos) {
			Clear(true);
			SetupTypes();
			SetupTags(tags);
			ChangeState(new HiddenState(this));
			AttachButtonToPosition(openButtonPos);
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

		public void Clear(bool full) {
			if( full ) {
				_container.Entries.Clear();
			}
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
			ApplyMessage(msg, type, tag, true);
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

		void ApplyMessage(string msg, LogType type, string tag, bool addNow) {
			if( IsTagRequired(tag) && IsTypeRequired(type)) {
				var color = GetColor(type);
				if( addNow ) {
					Text.text += string.Format(_formatStr, color, tag, type, msg);
				} else {
					_sb = _sb.AppendFormat(_formatStr, color, tag, type, msg);
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
	}
}
