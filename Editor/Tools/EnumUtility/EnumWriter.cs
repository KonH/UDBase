using System;
using UnityEngine;
using UnityEditor;
using UDBase.Utils;

namespace UDBase.Editor.Tools.EnumUtility {
	public class EnumWriter {
		protected EnumFormatter Formatter { get; private set; }
		
		public EnumWriter(EnumFormatter formatter) {
			Formatter = formatter;
		}
		
		public virtual void WriteEnums(EnumInfoContainer container) {
			foreach (var node in container) {
				var baseType = node.Key;
				var values = node.Value.Values;
				if (values.Count > 0) {
					var content = Formatter.MakeEnumContent(node.Value);
					WriteEnumContent(baseType, content);
				}
			}
		}

		protected virtual string FindAssetPathForType(Type type) {
			var assetGuids = AssetDatabase.FindAssets(type.Name);
			if (assetGuids.Length > 0) {
				var guid = assetGuids[0];
				return AssetDatabase.GUIDToAssetPath(guid);
			}
			return null;
		}
	
		protected virtual void WriteEnumContent(Type type, string content) {
			var assetPath = FindAssetPathForType(type);
			if (!string.IsNullOrEmpty(assetPath)) {
				var oldContent = IOTool.ReadAllText(assetPath);
				if (oldContent == content) {
					return;
				}
				IOTool.WriteAllText(assetPath, content);
				AssetDatabase.Refresh();
				Debug.LogFormat("[EnumUtility] Updated enum: {0} at {1}", type, assetPath);
			} else {
				Debug.LogErrorFormat("[EnumUtility] Can't find asset for {0}!", type);
			}
		}
	}
}
