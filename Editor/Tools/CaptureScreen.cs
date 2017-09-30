using System.IO;
using UnityEngine;
using UDBase.Common;
using UDBase.Utils;

namespace UDBase.EditorTools {
	public static class CaptureScreen {
		static string GetRandomName() {
			return System.DateTime.Now.ToString("hh.mm.ss") + "." + Mathf.Abs(new System.Object().GetHashCode()) + ".png";
		}

		public static void Make(int superSize) {
			var dir = UDBaseConfig.ScreenshotsDirectory;
			if(!IOTool.DirectoryExist(dir)) {
				IOTool.CreateDirectory(dir);
			}
			var fileName = GetRandomName();
			fileName = Path.Combine(dir, fileName);
			ScreenCapture.CaptureScreenshot(fileName, superSize);
			Debug.Log("Screenshot saved to " + fileName);
		}

		public static void Open() {
			IOTool.Open(UDBaseConfig.ScreenshotsDirectory);
		}

		public static void Clear() {
			var dir = UDBaseConfig.ScreenshotsDirectory;
			if(IOTool.DirectoryExist(dir)) {
				IOTool.DeleteDirectory(dir, true);
				Debug.Log("Directorory cleared: " + dir);
			}
		}
	}
}