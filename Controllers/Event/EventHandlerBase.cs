using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.EventSystem {
	abstract class EventHandlerBase {

		public List<object> Handlers { 
			get { 
				return _handlers; 
			}
		}

		protected List<object> _handlers = new List<object>();
	}
}
