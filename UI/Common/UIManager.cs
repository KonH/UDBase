using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.UI.Common {
	public class UIManager : MonoBehaviour {

		class UIDialogGroup {
			public UIOverlay       Element;
			public List<UIElement> Blocked;
			public Action<bool>    OnClose;

			public UIDialogGroup(UIOverlay element, List<UIElement> blocked, Action<bool> onClose) {
				Element = element;
				Blocked = blocked;
				OnClose = onClose;
			}
		}

		static UIManager _current = null;
		public static UIManager Current {
			get {
				if( !_current ) {
					_current = UnityHelper.AddForScene<UIManager>();
				}
				return _current;
			}
		}

		public int OverlayDepth {
			get {
				return _dialogs.Count;
			}
		}

		public Canvas  Canvas         = null;
		public KeyCode ShowHideToggle = KeyCode.None;

		bool _showHide  = false;
		bool _isLoading = false;

		Stack<UIDialogGroup> _dialogs = new Stack<UIDialogGroup>();

		void Awake() {
			if( _current ) {
				Log.Warning("Multiple UIManager is not supported.", LogTags.UI);
			}
			if( !Canvas ) {
				var wantedCanvas = FindObjectOfType<UICanvas>();
				if( wantedCanvas ) {
					Canvas = wantedCanvas.GetComponent<Canvas>();
				} else {
					Log.Warning("You need to assign Canvas to UIManager or add UICanvas component to wanted canvas.", LogTags.UI);
				}
			}
			_current = this;
		}

		void Update() {
			if( (ShowHideToggle != KeyCode.None) && Input.GetKeyDown(ShowHideToggle) ) {
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
				Content.LoadAsync<GameObject>(content, (go) => ShowDialog(go, callback));
			}
		}

		public void ShowDialog(GameObject prefab, Action onOk, Action onCancel) {
			ShowDialog(prefab, (result) => SelectionCallback(result, onOk, onCancel));
		}

		public void ShowDialog(GameObject prefab, Action<bool> callback) {
			_isLoading = false;
			var go = Instantiate(prefab) as GameObject;
			if( go ) {
				var overlay = go.GetComponent<UIOverlay>();
				if( overlay ) {
					ProcessOverlay(overlay, callback);
				}
			}
		}

		void ProcessOverlay(UIOverlay dialog, Action<bool> callback) {
			if( Canvas ) {
				dialog.transform.SetParent(Canvas.transform, false);
			}
			var blockedElements = GetBlockedElements();
			var dialogGroup = new UIDialogGroup(dialog, blockedElements, callback);
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
