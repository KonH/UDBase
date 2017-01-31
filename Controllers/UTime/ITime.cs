using System;

namespace UDBase.Controllers.UTime {
	public interface ITime : IController {
		bool     IsTrusted   { get; }
		bool     IsAvailable { get; }
		bool     IsFailed    { get; }
		DateTime CurrentTime { get; }
	}
}
