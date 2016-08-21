using UnityEngine;
using System.Collections;

namespace UDBase.Common {
	public static class SchemeSetup {

		// Get selected scheme for runtime
		public static IScheme GetScheme() {
			var setup = Resources.Load<ProjectSetup>(UDBaseConfig.ResourcesProjectSetupFileName);
			return setup.CurrentScheme;
		}
	}
}
