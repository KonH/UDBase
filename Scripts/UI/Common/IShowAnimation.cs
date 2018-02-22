using System;

namespace UDBase.UI.Common {

	/// <summary>
	/// Animation, when element showing
	/// </summary>
	public interface IShowAnimation {

		/// <summary>
		/// Set state to shown
		/// </summary>
		void SetShown();

		/// <summary>
		/// Show the specified element with action
		/// </summary>
		void Show(UIElement element, Action action);
	}
}
