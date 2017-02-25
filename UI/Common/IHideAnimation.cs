using System;

namespace UDBase.UI.Common {
	public interface IHideAnimation {
		
		void SetHidden();
		void Hide(UIElement element, Action action);
	}
}
