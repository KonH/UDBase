namespace UDBase.UI.Common {
	public struct UI_ElementShown {
		public UIElement Element { get; private set; }

		public UI_ElementShown(UIElement element) {
			Element = element;
		}
	}

	public struct UI_ElementHidden {
		public UIElement Element { get; private set; }

		public UI_ElementHidden(UIElement element) {
			Element = element;
		}
	}
}
