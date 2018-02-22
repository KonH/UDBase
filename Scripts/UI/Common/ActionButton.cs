using UnityEngine;
using UnityEngine.UI;

namespace UDBase.UI.Common {

	/// <summary>
	/// Base class for buttons which perform specific action
	/// </summary>
	[RequireComponent(typeof(Button))]
	public abstract class ActionButton : MonoBehaviour {
		Button _button;

		void Start() {
			Init();
		}

		/// <summary>
		/// Must be called in Start callback to set callback and initialy update state
		/// </summary>
		protected virtual void Init() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(() => OnClick());
			UpdateState();
		}

		/// <summary>
		/// Update button visibility and interactable state
		/// </summary>
		protected void UpdateState() {
			gameObject.SetActive(IsVisible());
			_button.interactable = IsInteractable();
		}

		/// <summary>
		/// Is should button currently visible?
		/// </summary>
		public abstract bool IsVisible();

		/// <summary>
		/// Is should button currently be interactable?
		/// </summary>
		public abstract bool IsInteractable();
		
		/// <summary>
		/// Concrete action to perform on click
		/// </summary>
		public abstract void OnClick();
	}
}