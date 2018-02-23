using UnityEngine;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.UI.Common {

	/// <summary>
	/// UIOverlay is a component which shows overlays and dialogs to user:
	/// it can be closed with boolean argument and you can pass callback which would be executed when wanted result is happen.
	/// When overlay is shown, all background elements become non-interactable and made interactable back after overlay is hidden.
	/// Overlay can be shown over another overlay.
	/// </summary>
	[AddComponentMenu("UDBase/UI/Overlay")]
	[RequireComponent(typeof(UIElement))]
	public class UIOverlay : MonoBehaviour {		

		/// <summary>
		/// Overlay hide mode
		/// </summary>
		public enum OverlayHideMode {

			/// <summary>
			/// In any close case
			/// </summary>
			Both,

			/// <summary>
			/// Only on positive decision
			/// </summary>
			OnlyPosilive,

			/// <summary>
			/// Only on negative decision
			/// </summary>
			OnlyNegative,

			/// <summary>
			/// Manually
			/// </summary>
			Manual
		}

		/// <summary>
		/// How overlay needs to closed?
		/// </summary>
		[Tooltip("How overlay needs to closed?")]
		public OverlayHideMode HideMode;

		UIElement Element {
			get {
				if( !_element ) {
					_element = GetComponent<UIElement>();
				}
				return _element;
			}
		}

		UIElement _element;
		bool      _ended;
		bool      _result;

		IEvent    _events;
		UIManager _manager;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(IEvent events, UIManager manager) {
			_events  = events;
			_manager = manager;
		}

		/// <summary>
		/// Show this overlay
		/// </summary>
		public void Show() {
			Element.Show();
			_events.Subscribe<UI_ElementHidden>(this, OnElementHidden);
		}

		void OnDestroy() {
			_events?.Unsubscribe<UI_ElementHidden>(OnElementHidden);
		}

		/// <summary>
		/// Close this overlay with negative decision
		/// </summary>
		public void Close() {
			Close(false);
		}

		bool NeedToHide(bool result) {
			switch( HideMode ) {
				case OverlayHideMode.Manual      : return false;
				case OverlayHideMode.OnlyPosilive: return result;
				case OverlayHideMode.OnlyNegative: return !result;
				default: return true;
			}
		}

		/// <summary>
		/// Close this overlay with specified decision
		/// </summary>
		public void Close(bool result) {
			_result = result;
			_ended = NeedToHide(result);
			if( _ended ) {
				Element.Hide();
			} else {
				_manager.CallOverlayCallback(_result);
			}
		}

		void OnElementHidden(UI_ElementHidden e) {
			if ( _ended && (e.Element == Element) ) {
				_manager.FreeOverlay(_result);
				Destroy(gameObject);
			}
		}
	}
}
