using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	public interface IEvent:IController {

		void Fire<T>(T arg);
		void Subscribe<T>(object handler, Action<T> callback);
		void Unsubscribe<T>(Action<T> callback);
	}
}