using System;

namespace UDBase.UI.Common {

	/// <summary>
	/// Animation when element hiding
	/// </summary>
	public interface IHideAnimation {

		/// <summary>
		/// Set element hide
		/// </summary>
		void SetHidden();

		/// <summary>
		/// Hide the specified element with callback
		/// </summary>
		void Hide(UIElement element, Action action);
	}
}
