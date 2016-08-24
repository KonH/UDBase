using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class MenuItems {
		
		[MenuItem("UDBase/Setup")]
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
	}
}
