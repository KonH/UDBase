using UnityEngine;
using UnityEditor;
using System.Collections;
using UDBase.Common;

namespace UDBase.Editor {
	public class Setup {

		public void Prepare() {
			var projectPath = UDBaseConfig.ProjectFolderName;
			AssetDatabase.CreateFolder("Assets", projectPath);
			AssetDatabase.CreateFolder("Assets/" + projectPath, "Resources");
			AssetDatabase.CreateFolder("Assets/" + projectPath, "Schemes");
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			AddSchemeSetup("Assets/" + projectPath + "/Resources");
		}

		void AddSchemeSetup(string path) {
			ScriptableObjectMaker.CreateAsset<ProjectSetup>(path, UDBaseConfig.ResourcesProjectSetupFileName);
		}
	}
}
