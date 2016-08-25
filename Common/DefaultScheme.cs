#if !Scheme_Declared || Scheme_Default
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Components.Log;

namespace UDBase.Common {
	public class ProjectScheme : Scheme {

		public ProjectScheme() {
			AddComponent(new Log(), new Log_Unity());
		}
	}
}
#endif
