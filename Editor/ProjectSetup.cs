using UnityEngine;
using UnityEditor;
using System.Collections;
using UDBase.Common;
using UDBase.Utils;

namespace UDBase.Editor {
	public class ProjectSetup {

		public static void PrepareFolders() {
			IOTool.CreateDirectory(UDBaseConfig.ProjectPath);
			IOTool.CreateDirectory(UDBaseConfig.ProjectSchemesPath);
			IOTool.CreateDirectory(UDBaseConfig.ProjectEditorPath);

			AssetDatabase.Refresh();
		}
	}
}
