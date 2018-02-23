using UnityEngine;

namespace UDBase.Utils {
	/// <summary>
	/// Helper methods for PlayerPrefs usage
	/// </summary>
	public static class PlayerPrefsUtils {

		/// <summary>
		/// Set boolean value in int representation (1 = true, 0 = false)
		/// </summary>
		public static void SetBool(string key, bool value, bool save = true) {
			PlayerPrefs.SetInt(key, value ? 1 : 0);
			if( save ) {
				PlayerPrefs.Save();
			}
		}

		/// <summary>
		/// Get boolean value in int representation (1 = true, 0 = false)
		/// </summary>
		public static bool GetBool(string key, bool defaultValue) {
			var value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
			return (value == 1);
		}
	}
}
