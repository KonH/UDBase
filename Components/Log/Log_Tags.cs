using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Tags {
		public const int Common = 1;
		public const int UI     = 2;

		string[] _names = new string[]{"Common", "UI"};

		public virtual string GetName(int index) {
			switch( index ) {
				case Common: {
						return "Common";
				}

				case UI: {
						return "UI";
				}
			}
			return "Unknown";
		}

		public virtual string[] GetNames() {
			return _names;
		}
	}
}