using System.Collections.Generic;

namespace UDBase.Controllers.AnalyticsSystem {

	/// <summary>
	/// Analytics system allows you to track analytics events without using concrete analytics API
	/// </summary>
	public interface IAnalytics {

		/// <summary>
		/// Raise event without additional data
		/// </summary>
		void Event(string eventName);

		/// <summary>
		/// Raise event with additional data dictionary
		/// </summary>
		void Event(string eventName, Dictionary<string, object> data);
	}
}
