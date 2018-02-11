using UnityEngine;
using UnityEngine.UI;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(Button))]
	public abstract class ActionButton : MonoBehaviour {
		Button _button = null;

		void Start() {
			Init();
		}

		protected virtual void Init() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(() => OnClick());
			UpdateState();
		}

		protected void UpdateState() {
			gameObject.SetActive(IsVisible());
			_button.interactable = IsInteractable();
		}

		public abstract bool IsVisible();
		public abstract bool IsInteractable();
		public abstract void OnClick();
	}
}