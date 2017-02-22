using UnityEngine;

namespace UDBase.Common {
	/// <summary>
	/// Scheme manager. Holds reference to current used scheme and init it
	/// Note: This class used native Debug messages (Log controller is unreachable yet)
	/// </summary>
	public sealed class SchemeManager {
		public IScheme CurrentScheme { get; private set; }

		public void ApplyScheme(IScheme scheme) {
			if( scheme == null ) {
				Debug.LogError("Scheme can't be null!");
				return;
			}
			CurrentScheme = scheme;
			scheme.Init();
			scheme.PostInit();
		}
	}
}
