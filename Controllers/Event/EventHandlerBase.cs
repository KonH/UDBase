using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	abstract class EventHandlerBase {
		protected List<object> _handlers = new List<object>();
	}
}
