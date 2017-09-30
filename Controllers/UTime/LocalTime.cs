using System;

namespace UDBase.Controllers.UTime {
	public class LocalTime : ITime {
		readonly bool _useUniversalTime;

		public LocalTime(bool isTrusted = false, bool useUniversalTime = false) {
			IsTrusted         = isTrusted;
			_useUniversalTime = useUniversalTime;
		}
		public void Init() {}
		
		public void PostInit() {}

		public void Reset() {}

		public bool     IsTrusted   { get; private set;   }
		public bool     IsAvailable { get { return true;  } }
		public bool     IsFailed    { get { return false; } }
		public DateTime CurrentTime { 
			get { 
				return _useUniversalTime ? DateTime.Now.ToUniversalTime() : DateTime.Now; 
			} 
		}
	}
}