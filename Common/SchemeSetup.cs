using UnityEngine;
using System.Collections;

namespace UDBase.Common {
	public static class SchemeSetup {
		// TODO: Find a way to move scheme setup to UDBaseProject or just ignore it
		// TODO: Make SchemeBuilder

		// Get selected scheme for runtime
		public static IScheme GetScheme() {
			return new TestScheme();
		}
	}
}
