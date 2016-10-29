using UnityEngine;
using System.Collections;
using UDBase.Controllers;
using UDBase.Utils;
using UDBase.Utils.Json;
using UDBase.Common;

namespace UDBase.Controllers.Save {
	public class Save:ControllerHelper<ISave> {

		public static T GetNode<T>() where T:class, IJsonNode, new() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return null;
		}

		public static void SaveNode<T>(T node) where T:class, IJsonNode, new() {
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
