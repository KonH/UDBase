using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.UI.Common {
	public class UIManager : MonoBehaviour {

		static UIManager _current = null;
		public static UIManager Current {
			get {
				if( !_current ) {
					_current = UnityHelper.AddForScene<UIManager>();
				}
				return _current;
			}
		}

		public Canvas  Canvas         = null;
		public KeyCode ShowHideToggle = KeyCode.None;

		bool _showHide = false;

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
				elements[i].Show();
			}
		}

		public void HideAll() {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				elements[i].Hide();
			}
		}

		public void Show(string group) {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( element.Group == group ) {
					element.Show();
				}
			}
		}

		public void Hide(string group) {
			var elements = UIElement.Instances;
			for( int i = 0; i < elements.Count; i++ ) {
				var element = elements[i];
				if( element.Group == group ) {
					element.Hide();
				}
			}
		}

		public void ShowOverlay(ContentId content) {
			Content.LoadAsync<UIElement>(content, ShowOverlayCallback);
		}

		void ShowOverlayCallback(UIElement element) {
			var go = Instantiate(element.gameObject) as GameObject;
			ShowOverlay(go.GetComponent<UIElement>());
		}

		public void ShowOverlay(UIElement element) {
			if( Canvas ) {
				element.transform.SetParent(Canvas.transform, false);
				//if( Canvas.transform.localScale ) {
//
//				}
			}
			element.Show();
		}
	}
}
