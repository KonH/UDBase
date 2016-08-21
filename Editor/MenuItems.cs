using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class MenuItems {

		[MenuItem("UDBase/Setup")]
		static void DoSetup() {
			var setup = new Setup();
			setup.Prepare();
		}

		[MenuItem("UDBase/Schemes")]
		static void OpenSchemes() {
			SchemesEditor.GetWindow<SchemesEditor>("Schemes", true);
		}
	}
}
