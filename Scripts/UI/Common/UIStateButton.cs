namespace UDBase.UI.Common {
    public class UIStateButton : ActionButton {
        public UIElement Element = null;
		
	    public override bool IsInteractable() {
			return true;
        }

        public override bool IsVisible() {
            return Element;
        }

        public override void OnClick() {
	        if (!Element) {
		        return;
	        }
	        switch ( Element.State) {
		        case UIElement.UIElementState.Shown:
			        Element.Hide();
			        break;

		        case UIElement.UIElementState.Hidden:
			        Element.Show();
			        break;
	        }
        }
    }
}
