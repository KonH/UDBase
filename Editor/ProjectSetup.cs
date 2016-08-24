using UnityEngine;
using UnityEditor;
using System.Collections;
using UDBase.Common;

namespace UDBase.Editor {
	public class ProjectSetup {

		public static void PrepareFolders() {
			var projectPath = UDBaseConfig.ProjectFolderName;
			AssetDatabase.CreateFolder("Assets", projectPath);
			AssetDatabase.CreateFolder("Assets/" + projectPath, "Schemes");
			AssetDatabase.CreateFolder("Assets/" + projectPath, "Editor");
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
	}
}
