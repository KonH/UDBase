using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;

namespace UDBase.Editor {
	public static class ScriptableObjectMaker {
		
		public static void CreateAsset<T> (string path, string name) where T : ScriptableObject
		{
			T asset = ScriptableObject.CreateInstance<T> ();

			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + name + ".asset");
			AssetDatabase.CreateAsset (asset, assetPathAndName);

			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
		}

		public static void CreateAsset(string path, string name, string typeName)
		{
			var asset = ScriptableObject.CreateInstance(typeName);

			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/" + name + ".asset");
			AssetDatabase.CreateAsset (asset as ScriptableObject, assetPathAndName);

			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh();
		}
	}
}
