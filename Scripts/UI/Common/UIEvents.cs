namespace UDBase.UI.Common {

	/// <summary>
	/// Event which fired when element is shown
	/// </summary>
	public struct UI_ElementShown {
		public UIElement Element { get; private set; }

		public UI_ElementShown(UIElement element) {
			Element = element;
		}
	}

	/// <summary>
	/// Event which fired when element is hidden
	/// </summary>
	public struct UI_ElementHidden {
		public UIElement Element { get; private set; }

		public UI_ElementHidden(UIElement element) {
			Element = element;
		}
	}
}
