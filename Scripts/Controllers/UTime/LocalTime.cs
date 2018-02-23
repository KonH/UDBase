using System;

namespace UDBase.Controllers.UTime {

	/// <summary>
	/// Local time wrapper
	/// </summary>
	public class LocalTime : ITime {
		readonly bool _useUniversalTime;

		public LocalTime(bool useUniversalTime = false) {
			_useUniversalTime = useUniversalTime;
		}

		public bool     IsAvailable { get { return true;  } }
		public bool     IsFailed    { get { return false; } }
		public DateTime CurrentTime { 
			get { 
				return _useUniversalTime ? DateTime.Now.ToUniversalTime() : DateTime.Now; 
			} 
		}
	}
}