using UnityEngine;
using System;
using System.Collections;

namespace UDBase.Components.UTime {
	public interface ITime : IComponent {
		bool     IsAvailable { get; }
		bool     IsFailed    { get; }
		DateTime CurrentTime { get; }
	}
}
