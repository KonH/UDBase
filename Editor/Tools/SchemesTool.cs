using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UDBase.Common;
using UDBase.Utils;

namespace UDBase.EditorTools {
	public static class SchemesTool {
		public static List<string> GetSchemes() {
			var files = IOTool.GetDirFiles(UDBaseConfig.ProjectSchemesPath, "*.cs");
			var items = new List<string>();
			items.Add(UDBaseConfig.SchemeDefaultName);
			for(int i = 0; i < files.Length; i++) {
				var schemeName = files[i].Name;
				schemeName = schemeName.Remove(schemeName.Length - 3, 3);
				items.Add(schemeName);
			}
			return items;
		}

		public static void UpdateSchemes() {
			var items = GetSchemes();
			CreateMenuItems(items);
		}

		public static void CreateMenuItems(List<string> items) {
			var contents = GetSchemesFileContent(items);
			if( !string.IsNullOrEmpty(contents) ) {
				IOTool.WriteAllText(UDBaseConfig.ProjectEditorMenuItemsPath, contents);
				AssetDatabase.Refresh();
			}
		}

		static string GetSchemesFileContent(List<string> items) {
			var fileTemplate = GetSchemesTemplate();
			if( !string.IsNullOrEmpty(fileTemplate) ) { 
				var itemsContent = GetItemsContent(GetSchemesItemTemplate(), items);
				fileTemplate = fileTemplate.Replace("[CONTENT]", itemsContent);
				return fileTemplate;
			}
			return null;
		}

		static string GetItemsContent(string template, List<string> items) {
			var itemsContent = "";
			for(int i = 0; i < items.Count; i++) {
				itemsContent += template.Replace("[Scheme]", items[i]);
			}
			return itemsContent;
		}

		static string GetSchemesTemplate() {
			return IOTool.ReadAllText(UDBaseConfig.MenuTemplatePath);
		}

		static string GetSchemesItemTemplate() {
			return File.ReadAllText(UDBaseConfig.MenuItemTemplatePath);
		}

		public static void CreateSchemeScript(string name) { 
			var templatePath = UDBaseConfig.SchemeTemplatePath;
			var copyPath = UDBaseConfig.GetProjectSchemePathFor(name);
			if( IOTool.CopyFile(templatePath, copyPath) ) {
				ReplaceContent(copyPath, name);
				AssetDatabase.Refresh();
			}
		}

		static void ReplaceContent(string path, string name) {
			var fileContent = IOTool.ReadAllText(path);
			if( !string.IsNullOrEmpty(fileContent) ) {
				var newFileContent = fileContent.Replace("[Name]", name);
				IOTool.WriteAllText(path, newFileContent);
			}
		}

		public static void SwitchScheme(string name) {
			EditorDefinesTool.SetScheme(name);
		}

		public static void RemoveScheme(string name) {
			if( name == UDBaseConfig.SchemeDefaultName ) {
				return;
			}
			if( IOTool.DeleteFile(UDBaseConfig.GetProjectSchemePathFor(name)) ) {
				UpdateSchemes();
				AssetDatabase.Refresh();
			}
		}

		public static bool IsActiveScheme(string name) {
			return EditorDefinesTool.IsActiveScheme(name);
		}
	}
}