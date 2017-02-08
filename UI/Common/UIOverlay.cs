using UnityEngine;
using UDBase.Controllers.EventSystem;

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

		UIElement _element = null;
		bool      _ended   = false;
		bool      _result  = false;

		public void Show() {
			Element.Show();
			Events.Subscribe<UI_ElementHidden>(this, OnElementHidden);
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
				UIManager.Current.CallOverlayCallback(_result);
			}
		}

		void OnElementHidden(UI_ElementHidden e) {
			if( _ended && (e.Element == Element) ) {
				UIManager.Current.FreeOverlay(_result);
				Destroy(gameObject);
			}
		}
	}
}
