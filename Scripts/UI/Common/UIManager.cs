using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;
using Zenject;

namespace UDBase.UI.Common {

	/// <summary>
	/// UI system is based on Unity UI and provides you methods of interacting with grouped interface elements which can contain animations.
	/// With UIManager you can show overlays and dialogs and also switch elements visibility: all or by its group.
	/// You can specify key command to Show/Hide elements using ShowHideToggle field.
	/// UIManager is created by request if it is not exist on scene before.
	/// To show overlay/dialog you need to add *UICanvas* component to your canvas, that will show that elements, or assign it directly.
	/// </summary>
	public class UIManager : MonoBehaviour {

		/// <summary>
		/// UI Manager settings
		/// </summary>
		[Serializable]
		public class Settings {

			/// <summary>
			/// Canvas to attach UI elements
			/// </summary>
			[Tooltip("Canvas to attach UI elements")]
			public Canvas  Canvas;

			/// <summary>
			/// Optional button to show/hide all UI elements
			/// </summary>
			[Tooltip("Optional button to show/hide all UI elements")]
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

		/// <summary>
		/// How many overlays is shown?
		/// </summary>
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

		/// <summary>
		/// Init with dependencies
		/// </summary>
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

		/// <summary>
		/// Shows all UI elements
		/// </summary>
		public void ShowAll() {
			var elements = UIElement.Instances;
			foreach ( var element in elements ) {
				if( !element.HasParent ) {
					element.Show();
				}
			}
		}

		/// <summary>
		/// Hide all UI elements
		/// </summary>
		public void HideAll() {
			var elements = UIElement.Instances;
			foreach ( var element in elements ) {
				if ( !element.HasParent ) {
					element.Hide();
				}
			}
		}

		/// <summary>
		/// Show UI elements of the specified group
		/// </summary>
		public void Show(string group) {
			var elements = UIElement.Instances;
			foreach ( var element in elements ) {
				if( !element.HasParent && (element.Group == group) ) {
					element.Show();
				}
			}
		}

		/// <summary>
		/// Hide UI elements of the specified group
		/// </summary>
		public void Hide(string group) {
			var elements = UIElement.Instances;
			foreach ( var element in elements ) {
				if ( !element.HasParent && (element.Group == group) ) {
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

		/// <summary>
		/// Shows the overlay with closing callback
		/// </summary>
		public void ShowOverlay(ContentId content, Action callback) {
			ShowDialog(content, _ => SafeCallback(callback));
		}

		/// <summary>
		/// Shows the overlay with closing callback
		/// </summary>
		public void ShowOverlay(GameObject prefab, Action callback) {
			ShowDialog(prefab, _ => SafeCallback(callback));
		}

		/// <summary>
		/// Shows the dialog with positive and negative callbacks
		/// </summary>
		public void ShowDialog(ContentId content, Action onOk, Action onCancel) {
			ShowDialog(content, (result) => SelectionCallback(result, onOk, onCancel));
		}

		/// <summary>
		/// Shows the dialog with positive and decision result callback
		/// </summary>
		public void ShowDialog(ContentId content, Action<bool> callback) {
			if( !_isLoading ) {
				_isLoading = true;
				_loaders.GetLoaderFor(content).LoadAsync<GameObject>(content, (go) => ShowDialog(go, callback));
			}
		}

		/// <summary>
		/// Shows the dialog with positive and negative callbacks
		/// </summary>
		public void ShowDialog(GameObject prefab, Action onOk, Action onCancel) {
			ShowDialog(prefab, (result) => SelectionCallback(result, onOk, onCancel));
		}

		/// <summary>
		/// Shows the dialog with positive and decision result callback
		/// </summary>
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
			foreach ( var element in elements ) {
				if ( element.IsInteractable ) {
					element.Deactivate();
					blockedElements.Add(element);
				}
			}
			return blockedElements;
		}

		internal void FreeOverlay(bool result) {
			if( _dialogs.Count > 0 ) {
				var curOverlay = _dialogs.Pop();
				for( int i = 0; i < curOverlay.Blocked.Count; i++ ) {
					curOverlay.Blocked[i].Activate();
				}
				curOverlay.OnClose?.Invoke(result);
			}
		}

		internal void CallOverlayCallback(bool result) {
			if( _dialogs.Count > 0 ) {
				var curOverlay = _dialogs.Peek();
				curOverlay.OnClose?.Invoke(result);
			}
		}
	}
}
