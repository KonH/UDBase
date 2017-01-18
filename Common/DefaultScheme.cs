#if !Scheme_Declared || Scheme_Default
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Common {
	public class ProjectScheme : Scheme {

		public ProjectScheme() {
			AddController(new Log(), new UnityLog());
		}
	}
}
#endif
