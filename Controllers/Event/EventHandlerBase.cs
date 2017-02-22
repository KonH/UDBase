using System.Collections.Generic;

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
