using System.Collections.Generic;

namespace UDBase.Controllers.EventSystem {
	abstract class EventHandlerBase {
		protected List<object> _handlers = new List<object>();
		public List<object> Handlers { 
			get { 
				return _handlers;
			}
		}
	}
}
