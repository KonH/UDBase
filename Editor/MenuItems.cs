using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class MenuItems {
		// TODO: Generated menu items to switch schemes;

		[MenuItem("UDBase/Setup")]
		static void DoSetup() {
			ProjectSetup.PrepareFolders();
		}

		[MenuItem("UDBase/Schemes")]
		static void OpenSchemes() {
			SchemesEditor.GetWindow<SchemesEditor>("Schemes", true);
		}

		[MenuItem("UDBase/Setup TestScheme")]
		static void Scheme() {
			EditorDefinesTool.SetScheme("TestScheme");
		}
	}
}
