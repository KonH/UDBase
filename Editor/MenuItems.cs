using UnityEditor;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.ContentSystem;

namespace UDBase.EditorTools {
	public static class MenuItems {
		
		[MenuItem("UDBase/Schemes/Edit", false, -99)]
		static void OpenSchemes() {
			SchemesEditor.GetWindow<SchemesEditor>("Schemes", true);
		}

		[MenuItem("UDBase/Schemes/Update", false, -99)]
		static void Scheme() {
			SchemesTool.UpdateSchemes();
		}

		[MenuItem("UDBase/Setup", false, -98)]
		static void DoSetup() {
			ProjectSetupTool.PrepareFolders();
		}

		[MenuItem("UDBase/About", false, -97)]
		static void About() {
			UDBaseInfo.ShowAbout();
		}

		[MenuItem("UDBase/Release Notes", false, -96)]
		static void ReleaseNotes() {
			UDBaseInfo.ShowReleaseNotes();
		}

		[MenuItem("UDBase/Help", false, -95)]
		static void Help() {
			UDBaseInfo.OpenHelp();
		}

		[MenuItem("UDBase/Examples", false, -94)]
		static void Examples() {
			UDBaseInfo.OpenExamples();
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

		[MenuItem("UDBase/Screenshots/Clear")]
		public static void CleanScreenshots() {
			CaptureScreen.Clear();
		}
			
		[MenuItem("UDBase/Screenshots/Open")]
		public static void OpenScreenshots() {
			CaptureScreen.Open();
		}

		[MenuItem("UDBase/Screenshots/Make/X1 Resolution %#&1")]
		public static void MakeScreenshotX1() {
			CaptureScreen.Make(1);
		}

		[MenuItem("UDBase/Screenshots/Make/X2 Resolution %#&2")]
		public static void MakeScreenshotX2() {
			CaptureScreen.Make(2);
		}

		[MenuItem("UDBase/Screenshots/Make/X4 Resolution %#&4")]
		public static void MakeScreenshotX4() {
			CaptureScreen.Make(4);
		}

		[MenuItem("UDBase/Screenshots/Make/X8 Resolution %#&8")]
		public static void MakeScreenshotX8() {
			CaptureScreen.Make(8);
		}

		[MenuItem("UDBase/Events/Debug Window")]
		public static void ShowEventWindow() {
			EventWindow.GetWindow<EventWindow>("Events", true);
		}

		[MenuItem("UDBase/Content/Add New Config")] 
		public static void AddNewContentConfig() {
			ContentEditor.CreateContentConfig();
		}

		[MenuItem("UDBase/Content/Set type for all/Direct")]
		public static void SetContentTypeForAllConfigs_Direct() {
			ContentEditor.SetContentTypeForAll(ContentLoadType.Direct);
		}

		[MenuItem("UDBase/Content/Set type for all/AssetBundle")]
		public static void SetContentTypeForAllConfigs_AssetBundle() {
			ContentEditor.SetContentTypeForAll(ContentLoadType.AssetBundle);
		}
	}
}
