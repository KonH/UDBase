﻿using System;

namespace UDBase.Controllers.EventSystem {
	public interface IEvent {
		void Fire<T>(T arg);
		void Subscribe<T>(object handler, Action<T> callback);
		void Unsubscribe<T>(Action<T> callback);
	}
}