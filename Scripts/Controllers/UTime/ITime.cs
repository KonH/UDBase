using System;

namespace UDBase.Controllers.UTime {
	
	/// <summary>
	/// ITime is a simple interface to retrieve time from defined sources
	/// </summary>
	public interface ITime {

		/// <summary>
		/// Is time already available?
		/// </summary>
		bool IsAvailable { get; }

		/// <summary>
		/// Is time failed to retrieve?
		/// </summary>
		bool IsFailed { get; }

		/// <summary>
		/// Current time
		/// </summary>
		DateTime CurrentTime { get; }
	}
}
