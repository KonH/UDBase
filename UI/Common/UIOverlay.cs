using UnityEngine;
using UDBase.Controllers.EventSystem;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(UIElement))]
	public class UIOverlay : MonoBehaviour {
		UIElement Element {
			get {
				if( !_element ) {
					_element = GetComponent<UIElement>();
				}
				return _element;
			}
		}

		UIElement _element = null;

		public void Show() {
			Element.Show();
			Events.Subscribe<UI_ElementHidden>(this, OnElementHidden);
		}

		public void Close() {
			Element.Hide();
		}

		void OnElementHidden(UI_ElementHidden e) {
			if( e.Element == Element ) {
				UIManager.Current.FreeOverlay();
				Destroy(gameObject);
			}
		}
	}
}
