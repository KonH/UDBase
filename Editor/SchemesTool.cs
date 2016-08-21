using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using UDBase.Common;

namespace UDBase.Editor {
	public class SchemesTool {

		public void CreateDirectory(string name) {
			AssetDatabase.CreateFolder("Assets/" + UDBaseConfig.ProjectFolderName + "/Schemes", name);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		public void CreateSchemeScript(string name) {
			var path = "Assets/" + UDBaseConfig.ProjectFolderName + "/Schemes/" + name; 
			var fileName = path + "/" + name + ".cs";
			AssetDatabase.CopyAsset(UDBaseConfig.SchemeTemplateFilePath, fileName);

			ReplaceContent(name);

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		void ReplaceContent(string name) {
			var ioPath = Path.Combine("Assets", UDBaseConfig.ProjectFolderName); 
			ioPath = Path.Combine(ioPath, "Schemes"); 
			ioPath = Path.Combine(ioPath, name); 
			ioPath = Path.Combine(ioPath, name + ".cs");
			var fileContent = File.ReadAllText(ioPath);
			var newFileContent = fileContent.Replace("[Name]", name);
			File.WriteAllText(ioPath, newFileContent);
		}

		public void CreateAsset(string name) {
			var path = "Assets/" + UDBaseConfig.ProjectFolderName + "/Schemes/" + name;
			ScriptableObjectMaker.CreateAsset(path, name, name);
		}
	}
}