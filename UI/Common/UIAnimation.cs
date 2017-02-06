using UnityEngine;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(UIElement))]
	public abstract class UIAnimation : MonoBehaviour {

		public abstract void Show(UIElement element, bool initial);
		public abstract void Hide(UIElement element);
	}
}
