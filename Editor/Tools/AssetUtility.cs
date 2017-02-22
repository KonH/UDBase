using UnityEngine;
using UnityEditor;
using System.IO;

namespace UDBase.EditorTools {
	public static class AssetUtility {

		public static T CreateAsset<T>(bool focus = true) where T : ScriptableObject {
			T asset = ScriptableObject.CreateInstance<T>();
			string path = AssetDatabase.GetAssetPath (Selection.activeObject);
			if ( path == "" ) {
				path = "Assets";
			} else if ( Path.GetExtension (path) != "" ) {
				path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
			}
			string assetPathAndName = path + "/" + typeof(T).ToString() + ".asset";
			assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(assetPathAndName);
			AssetDatabase.CreateAsset(asset, assetPathAndName);
			SaveAndFocusAsset(asset, focus);
			return asset;
		}

		public static T AddSubAsset<T>(ScriptableObject parent, bool focus = true) where T:ScriptableObject {
			T asset = ScriptableObject.CreateInstance<T>();
			AssetDatabase.AddObjectToAsset(asset, parent);
			SaveAndFocusAsset(asset, focus);
			return asset;
		}

		public static void SaveAndFocusAsset<T>(T asset, bool focus = true) where T:ScriptableObject {
			SaveAssets();
			if( focus) {
				FocusAsset(asset);
			}
		}

		public static void SaveAssets() {
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		public static void FocusAsset<T>(T asset) where T:ScriptableObject {
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;
		}

		public static void RemoveSubAsset<T>(T subasset) where T:ScriptableObject {
			ScriptableObject.DestroyImmediate(subasset, true);
			SaveAssets();
		}
	}
}
