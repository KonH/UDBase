using System;

namespace UDBase.Controllers.UTime {
	public interface ITime {
		bool     IsAvailable { get; }
		bool     IsFailed    { get; }
		DateTime CurrentTime { get; }
	}
}
