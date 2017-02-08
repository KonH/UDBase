using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.UI.Common {
	public class UIManager : MonoBehaviour {

		class UIOverlayGroup {
			public UIOverlay       Element;
			public List<UIElement> Blocked;
			public Action          OnClose;

			public UIOverlayGroup(UIOverlay element, List<UIElement> blocked, Action onClose) {
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
				return _overlays.Count;
			}
		}

		public Canvas  Canvas         = null;
		public KeyCode ShowHideToggle = KeyCode.None;

		bool _showHide  = false;
		bool _isLoading = false;

		Stack<UIOverlayGroup> _overlays = new Stack<UIOverlayGroup>();

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

		public void ShowOverlay(ContentId content, Action callback) {
			if( !_isLoading ) {
				_isLoading = true;
				Content.LoadAsync<GameObject>(content, (go) => ShowOverlay(go, callback));
			}
		}

		public void ShowOverlay(GameObject prefab, Action callback) {
			_isLoading = false;
			var go = Instantiate(prefab) as GameObject;
			if( go ) {
				var overlay = go.GetComponent<UIOverlay>();
				if( overlay ) {
					ProcessOverlay(overlay, callback);
				}
			}
		}

		void ProcessOverlay(UIOverlay overlay, Action callback) {
			if( Canvas ) {
				overlay.transform.SetParent(Canvas.transform, false);
			}
			var blockedElements = GetBlockedElements();
			var overlayGroup = new UIOverlayGroup(overlay, blockedElements, callback);
			_overlays.Push(overlayGroup);
			overlay.Show();
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

		public void FreeOverlay() {
			if( _overlays.Count > 0 ) {
				var curOverlay = _overlays.Pop();
				for( int i = 0; i < curOverlay.Blocked.Count; i++ ) {
					curOverlay.Blocked[i].Activate();
				}
				var callback = curOverlay.OnClose;
				if( callback != null ) {
					callback();
				}
			}
		}
	}
}
