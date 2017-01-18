using System;

namespace UDBase.Controllers.UTime {
	public class LocalTime : ITime {

		public void Init() {}
		public void PostInit() {}

		public bool     IsAvailable { get { return true;         } }
		public bool     IsFailed    { get { return false;        } }
		public DateTime CurrentTime { get { return DateTime.Now; } }
	}
}