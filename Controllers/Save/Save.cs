using UnityEngine;
using UDBase.Utils;
using UDBase.Common;

namespace UDBase.Controllers.SaveSystem {
	public class Save {
		public static void OpenDirectory() {
			IOTool.Open(Application.persistentDataPath);
		}

		public static void Clear() {
			IOTool.DeleteFile(IOTool.GetPath(Application.persistentDataPath, UDBaseConfig.JsonSaveName));
			Debug.Log("Save file cleared.");
		}
	}
}
