using System;
using System.Collections.Generic;
using UnityEngine;
using UDBase.Utils;
using UDBase.Common;
using Rotorz.Games.Reflection;

namespace UDBase.Controllers.SaveSystem {
	public interface ISaveSource { }

	public class Save {

		[Serializable]
		public class SaveItem {
			[ClassImplements(typeof(ISaveSource))]
			public ClassTypeReference Type;
			public string Name;
		}

		[Serializable]
		public class Settings {
			public List<SaveItem> Items;
		}

		[Serializable]
		public class JsonSettings : Settings {
			public string FileName;
			public bool PrettyJson;
			public bool Versioning;
		}

		public static void OpenDirectory() {
			IOTool.Open(Application.persistentDataPath);
		}

		public static void Clear() {
			IOTool.DeleteFile(IOTool.GetPath(Application.persistentDataPath, UDBaseConfig.JsonSaveName));
			Debug.Log("Save file cleared.");
		}
	}
}
