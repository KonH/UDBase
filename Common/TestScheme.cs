using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Components.Log;

namespace UDBase.Common {
	public class TestScheme : Scheme {

		public TestScheme() {
			AddComponent(new Log(), new Log_Unity());
		}
	}
}
