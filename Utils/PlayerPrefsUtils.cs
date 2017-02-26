using UnityEngine;

namespace UDBase.Utils {
	public static class PlayerPrefsUtils {
		public static void SetBool(string key, bool value, bool save = true) {
			PlayerPrefs.SetInt(key, value ? 1 : 0);
			if( save ) {
				PlayerPrefs.Save();
			}
		}

		public static bool GetBool(string key, bool defaultValue) {
			var value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
			return (value == 1);
		}
	}
}
