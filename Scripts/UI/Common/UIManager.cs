using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.UI.Common {
	public class UIManager : MonoBehaviour {

		[Serializable]
		public class Settings {
			public Canvas  Canvas;
			public KeyCode ShowHideToggle;
		}

		class UIDialogGroup {
			public readonly List<UIElement> Blocked;
			public readonly Action<bool>    OnClose;

			public UIDialogGroup(List<UIElement> blocked, Action<bool> onClose) {
				Blocked = blocked;
				OnClose = onClose;
			}
		}

		public int OverlayDepth {
			get {
				return _dialogs.Count;
			}
		}

		bool _showHide;
		bool _isLoading;

		readonly Stack<UIDialogGroup> _dialogs = new Stack<UIDialogGroup>();

		Settings       _settings;
		OverlayFactory _overlayFactory;

		List<IContent> _loaders;
		ILog           _log;

		[Inject]
		public void Init(Settings settings, OverlayFactory overlayFactory, List<IContent> loaders, ILog log) {
			_settings       = settings;
			_overlayFactory = overlayFactory;
			_loaders        = loaders;
			_log            = log;
			if( !_settings.Canvas ) {
				var wantedCanvas = FindObjectOfType<UICanvas>();
				if( wantedCanvas ) {
					_settings.Canvas = wantedCanvas.GetComponent<Canvas>();
				} else {
					_log.Warning(UI.Context, "You need to assign Canvas to UIManager or add UICanvas component to wanted canvas.");
				}
			}
		}

		void Update() {
			if( (_settings.ShowHideToggle != KeyCode.None) && Input.GetKeyDown(_settings.ShowHideToggle) ) {
				if( _showHide ) {
					ShowAll();
				} else {
					HideAll();
				}
				_showHide = !_showHide;
			}
		}

		public void ShowAll() {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( !element.HasParent ) {
					element.Show();
				}
			}
		}

		public void HideAll() {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( !element.HasParent ) {
					elements[i].Hide();
				}
			}
		}

		public void Show(string group) {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( !element.HasParent && (element.Group == group) ) {
					element.Show();
				}
			}
		}

		public void Hide(string group) {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( !element.HasParent && (element.Group == group) ) {
					element.Hide();
				}
			}
		}

		void SafeCallback(Action action) {
			if( action != null ) {
				action.Invoke();
			}
		}
		void SelectionCallback(bool result, Action onTrue, Action onFalse) {
			if( result ) {
				if( onTrue != null ) {
					onTrue.Invoke();
				}
			} else {
				if( onFalse != null ) {
					onFalse.Invoke();
				}
			}
		}

		public void ShowOverlay(ContentId content, Action callback) {
			ShowDialog(content, _ => SafeCallback(callback));
		}

		public void ShowOverlay(GameObject prefab, Action callback) {
			ShowDialog(prefab, _ => SafeCallback(callback));
		}

		public void ShowDialog(ContentId content, Action onOk, Action onCancel) {
			ShowDialog(content, (result) => SelectionCallback(result, onOk, onCancel));
		}

		public void ShowDialog(ContentId content, Action<bool> callback) {
			if( !_isLoading ) {
				_isLoading = true;
				_loaders.GetLoaderFor(content).LoadAsync<GameObject>(content, (go) => ShowDialog(go, callback));
			}
		}

		public void ShowDialog(GameObject prefab, Action onOk, Action onCancel) {
			ShowDialog(prefab, (result) => SelectionCallback(result, onOk, onCancel));
		}

		public void ShowDialog(GameObject prefab, Action<bool> callback) {
			_isLoading = false;
			var overlay = _overlayFactory.Create(prefab);
			ProcessOverlay(overlay, callback);
		}

		void ProcessOverlay(UIOverlay dialog, Action<bool> callback) {
			if( _settings.Canvas ) {
				dialog.transform.SetParent(_settings.Canvas.transform, false);
			}
			var blockedElements = GetBlockedElements();
			var dialogGroup = new UIDialogGroup(blockedElements, callback);
			_dialogs.Push(dialogGroup);
			dialog.Show();
		}

		List<UIElement> GetBlockedElements() {
			var elements = UIElement.Instances;
			var blockedElements = new List<UIElement>();
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( element.IsInteractable ) {
					element.Deactivate();
					blockedElements.Add(element);
				}
			}
			return blockedElements;
		}

		public void FreeOverlay(bool result) {
			if( _dialogs.Count > 0 ) {
				var curOverlay = _dialogs.Pop();
				for( int i = 0; i < curOverlay.Blocked.Count; i++ ) {
					curOverlay.Blocked[i].Activate();
				}
				var callback = curOverlay.OnClose;
				if( callback != null ) {
					callback(result);
				}
			}
		}

		public void CallOverlayCallback(bool result) {
			if( _dialogs.Count > 0 ) {
				var curOverlay = _dialogs.Peek();
				var callback = curOverlay.OnClose;
				if( callback != null ) {
					callback(result);
				}
			}
		}
	}
}
