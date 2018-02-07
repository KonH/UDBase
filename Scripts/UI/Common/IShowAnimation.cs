using System;

namespace UDBase.UI.Common {
	public interface IShowAnimation {
		void SetShown();
		void Show(UIElement element, Action action);
	}
}
