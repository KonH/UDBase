using UnityEngine;
using UDBase.Utils;

namespace UDBase.EditorTools {
	public static class UDBaseInfo {
		const string RepositoryLink   = "https://github.com/KonH/UDBase";
		const string ExamplesLink     = "https://github.com/KonH/UDBaseExample";
		const string AssetsDir        = "Assets";
		const string BaseDir          = "UDBase";
		const string DocsDir          = "Docs";
		const string ReleaseNotesFile = "_ReleaseNotes.txt";

		public static void ShowAbout() {
			Debug.LogFormat("UDBase {0} ({1})", GetVersion(), RepositoryLink);
		}

		public static void ShowReleaseNotes() {
			Debug.LogFormat("Release notes below:\n{0}", GetLastReleaseNotes());
		}

		public static void OpenHelp() {
			Application.OpenURL(RepositoryLink);
		}

		public static void OpenExamples() {
			Application.OpenURL(ExamplesLink);
		}

		static string GetVersion() {
			var content = GetReleaseNotes();
			if( (content != null) && (content.Length > 0) ) {
				return content[0];
			}
			return "Unknown";
		}

		static string GetLastReleaseNotes() {
			var content = GetReleaseNotes();
			if( content != null ) {
				string lastNotes = "";
				for( int i = 0; i < content.Length; i++ ) {
					lastNotes += content[i] + "\n";
					if( string.IsNullOrEmpty(content[i]) ) {
						break;
					}
				}
				return lastNotes;
			}
			return "Not found";
		}

		static string[] GetReleaseNotes() {
			var path = IOTool.GetPath(AssetsDir, BaseDir, DocsDir, ReleaseNotesFile);
			return IOTool.ReadAllLines(path);
		}
	}
}
