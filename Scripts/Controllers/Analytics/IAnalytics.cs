using System;
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

		/// <summary>
		/// Adds data item, which be sent with all next events 
		/// </summary>
		void AddSessionData(string key, object value);

		/// <summary>
		/// Update data item, which be sent with all next events 
		/// </summary>
		void UpdateSessionData(string key, Func<object, object> valueChange);

		/// <summary>
		/// Removes session data item with given key
		/// </summary>
		void RemoveSessionData(string key);
	}
}
