using UnityEngine;
using System.Collections;

namespace UDBase.Common {
	public class SchemeManager {
		public IScheme CurrentScheme { get; private set; }

		public void ApplyScheme(IScheme scheme) {
			CurrentScheme = scheme;
			scheme.Init();
		}
	}
}
