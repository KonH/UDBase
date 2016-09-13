using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log : CompositeHelper<ILog> {
		// TODO: Make full set of calls without memory allocation (code ganeration)

		public static void Message(string msg) {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].Message(msg);
			}
		}
	}
}
