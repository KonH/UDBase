using UnityEngine;
using System;
using System.Collections;

namespace UDBase.Components.UTime {
	public class LocalTime : ITime {

		public void Init() {}

		public bool     IsAvailable { get { return true;         } }
		public bool     IsFailed    { get { return false;        } }
		public DateTime CurrentTime { get { return DateTime.Now; } }
	}
}