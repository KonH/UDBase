using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Utils {
	public static class RandomUtils {

		public static T GetItem<T>(List<T> items) {
			if( (items != null) && (items.Count > 0) ) {
				return items[Random.Range(0, items.Count)];
			}
			return default(T);
		}
	}
}
