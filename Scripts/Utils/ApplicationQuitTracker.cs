using UnityEngine;

namespace UDBase.Utils {
	public class ApplicationQuitTracker : MonoBehaviour {
		public static bool IsClosing = false;

		void OnApplicationQuit() {
			IsClosing = true;
		}
	}
}
