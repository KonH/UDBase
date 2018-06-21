using System.Collections.Generic;

namespace UDBase.Utils {
	/// <summary>
	/// Common dictionary utils
	/// </summary>
	public static class DictUtils {

		/// <summary>
		/// Return value by given key or default value if it isn't exists.
		/// </summary>
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key) {
			TValue value;
			if ( dict.TryGetValue(key, out value) ) {
				return value;
			}
			return default(TValue);
		}
	}
}