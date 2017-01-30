using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(Button))]
	public abstract class ActionButton : MonoBehaviour {
		Button _button = null;

		void Start() {
			Init();
		}

		protected virtual void Init() {
			gameObject.SetActive(IsVisible());
			_button = GetComponent<Button>();
			_button.interactable = IsInteractable();
			_button.onClick.AddListener(() => OnClick());
		}

		public abstract bool IsVisible();
		public abstract bool IsInteractable();
		public abstract void OnClick();
	}
}