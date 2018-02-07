using System;
using System.Collections.Generic;

namespace UDBase.Utils {
	public static class RandomUtils {
		public static int Range(int min, int max) {
			return UnityEngine.Random.Range(min, max);
		}

		public static T GetItem<T>(List<T> items) {
			if( (items != null) && (items.Count > 0) ) {
				return items[Range(0, items.Count)];
			}
			return default(T);
		}

		public static T GetItem<T>(IEnumerable<T> items) {
			if( items != null ) {
				var list = new List<T>(items);
				return GetItem(list);
			}
			return default(T);
		}

		public static T GetEnumValue<T>() {
			var values = Enum.GetValues(typeof(T));
			var index = Range(0, values.Length);
			return (T)values.GetValue(index);
		}
	}
}
