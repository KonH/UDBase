using System.IO;
using UnityEngine;
using UDBase.Utils;

namespace UDBase.EditorTools {
	public static class CaptureScreen {
		const string ScreenshotsDirectory = "Screenshots";

		static string GetRandomName() {
			return System.DateTime.Now.ToString("hh.mm.ss") + "." + Mathf.Abs(new System.Object().GetHashCode()) + ".png";
		}

		public static void Make(int superSize) {
			var dir = ScreenshotsDirectory;
			if ( !Directory.Exists(dir) ) {
				IOTool.CreateDirectory(dir);
			}
			var fileName = GetRandomName();
			fileName = Path.Combine(dir, fileName);
			ScreenCapture.CaptureScreenshot(fileName, superSize);
			Debug.Log("Screenshot saved to " + fileName);
		}

		public static void Open() {
			IOTool.Open(ScreenshotsDirectory);
		}

		public static void Clear() {
			var dir = ScreenshotsDirectory;
			if ( Directory.Exists(dir) ) {
				IOTool.DeleteDirectory(dir, true);
				Debug.Log("Directorory cleared: " + dir);
			}
		}
	}
}