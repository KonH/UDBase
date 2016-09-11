using UnityEngine;
using UnityEditor;
using System.Collections;
using UDBase.Components.Save;

namespace UDBase.Editor {
	public static class MenuItems {
		
		[MenuItem("UDBase/Setup", false, -98)]
		static void DoSetup() {
			ProjectSetup.PrepareFolders();
		}

		[MenuItem("UDBase/Schemes/Edit", false, -99)]
		static void OpenSchemes() {
			SchemesEditor.GetWindow<SchemesEditor>("Schemes", true);
		}

		[MenuItem("UDBase/Schemes/Update", false, -99)]
		static void Scheme() {
			SchemesTool.UpdateSchemes();
		}

		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}

		[MenuItem("UDBase/Save/Open")]
		static void OpenDirectoryForSave() {
			Save.OpenDirectory();
		}

		[MenuItem("UDBase/Save/Clear")]
		static void ClearSave() {
			Save.Clear();
		}
	}
}
