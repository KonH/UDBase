using UnityEngine;

namespace UDBase.UI.Common {
    
	/// <summary>
	/// Button to simply change state of UI element
	/// </summary>
	[AddComponentMenu("UDBase/UI/State Button")]
	public class UIStateButton : ActionButton {
        
		/// <summary>
		/// Element, which state is controlled
		/// </summary>
		[Tooltip("Element, which state is controlled")]
		public UIElement Element;
		
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
