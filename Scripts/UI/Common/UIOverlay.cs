using UnityEngine;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(UIElement))]
	public class UIOverlay : MonoBehaviour {		
		public enum OverlayHideMode {
			Both,
			OnlyPosilive,
			OnlyNegative,
			Manual
		}

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

		[Inject]
		public void Init(IEvent events, UIManager manager) {
			_events  = events;
			_manager = manager;
		}

		public void Show() {
			Element.Show();
			_events.Subscribe<UI_ElementHidden>(this, OnElementHidden);
		}

		void OnDestroy() {
			_events?.Unsubscribe<UI_ElementHidden>(OnElementHidden);
		}

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
