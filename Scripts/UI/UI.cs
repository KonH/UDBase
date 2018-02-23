using UDBase.Controllers.LogSystem;

namespace UDBase.UI {

	/// <summary>
	/// Log context holder for UI elements
	/// </summary>
	public class UI : ILogContext {

		/// <summary>
		/// Log context for UI elements
		/// </summary>
		public static UI Context = new UI(); 
	}
}
