using UnityEditor;
using UDBase.Common;
using UDBase.Utils;

namespace UDBase.EditorTools {
	public class ProjectSetup {

		public static void PrepareFolders() {
			IOTool.CreateDirectory(UDBaseConfig.ProjectPath);
			IOTool.CreateDirectory(UDBaseConfig.ProjectSchemesPath);
			IOTool.CreateDirectory(UDBaseConfig.ProjectEditorPath);

			AssetDatabase.Refresh();
		}
	}
}
