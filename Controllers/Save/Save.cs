using UnityEngine;
using UDBase.Utils;
using UDBase.Common;

namespace UDBase.Controllers.SaveSystem {
	public class Save:ControllerHelper<ISave> {
		public static T GetNode<T>(bool autoFill = true) {
			return (Instance != null) ? Instance.GetNode<T>(autoFill) : default(T);
		}

		public static void SaveNode<T>(T node) {
			if( Instance != null ) {
				Instance.SaveNode(node);
			}
		}

		public static void OpenDirectory() {
			IOTool.Open(Application.persistentDataPath);
		}

		public static void Clear() {
			if( Instance != null ) {
				Instance.Clear();
			} else {
				IOTool.DeleteFile(IOTool.GetPath(Application.persistentDataPath, UDBaseConfig.JsonSaveName));
			}
			Debug.Log("Save file cleared.");
		}
	}
}
