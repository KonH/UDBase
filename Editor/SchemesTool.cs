using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;

namespace UDBase.Editor {
	public class SchemesTool {
		// TODO: Use only Unity API or IO to work with files
		// TODO: Handle errors

		public static List<string> GetSchemes() {
			var ioPath = Path.Combine("Assets", UDBaseConfig.ProjectFolderName);
			ioPath = Path.Combine(ioPath, "Schemes");
			var dir = new DirectoryInfo(ioPath);
			var files = dir.GetFiles("*.cs");
			var items = new List<string>();
			items.Add("Default");
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
			var ioPath = Path.Combine("Assets", UDBaseConfig.ProjectFolderName);
			ioPath = Path.Combine(ioPath, "Editor");
			ioPath = Path.Combine(ioPath, "SchemesMenuItems.cs");
			var contents = GetSchemesFileContent(items);
			File.WriteAllText(ioPath, contents);
			AssetDatabase.Refresh();
		}

		static string GetSchemesFileContent(List<string> items) {
			var fileTemplate = GetSchemesTemplate();
			var itemsContent = GetItemsContent(GetSchemesItemTemplate(), items);
			fileTemplate = fileTemplate.Replace("[CONTENT]", itemsContent);
			return fileTemplate;
		}

		static string GetItemsContent(string template, List<string> items) {
			var itemsContent = "";
			for(int i = 0; i < items.Count; i++) {
				itemsContent += template.Replace("[Scheme]", items[i]);
			}
			return itemsContent;
		}

		static string GetSchemesTemplate() {
			var ioPath = Path.Combine("Assets", "UDBase");
			ioPath = Path.Combine(ioPath, "Templates");
			ioPath = Path.Combine(ioPath, UDBaseConfig.MenuFileTemplate);
			return File.ReadAllText(ioPath);
		}

		static string GetSchemesItemTemplate() {
			var ioPath = Path.Combine("Assets", "UDBase");
			ioPath = Path.Combine(ioPath, "Templates");
			ioPath = Path.Combine(ioPath, UDBaseConfig.MenuItemTemplate);
			return File.ReadAllText(ioPath);
		}

		public static void CreateSchemeScript(string name) {
			var path = "Assets/" + UDBaseConfig.ProjectFolderName + "/Schemes"; 
			var fileName = path + "/" + name + ".cs";
			AssetDatabase.CopyAsset(UDBaseConfig.SchemeTemplateFilePath, fileName);

			ReplaceContent(name);

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		static void ReplaceContent(string name) {
			var ioPath = Path.Combine("Assets", UDBaseConfig.ProjectFolderName); 
			ioPath = Path.Combine(ioPath, "Schemes"); 
			ioPath = Path.Combine(ioPath, name + ".cs");
			var fileContent = File.ReadAllText(ioPath);
			var newFileContent = fileContent.Replace("[Name]", name);
			File.WriteAllText(ioPath, newFileContent);
		}

		public static void SwitchScheme(string name) {
			EditorDefinesTool.SetScheme(name);
		}

		public static void RemoveScheme(string name) {
			if( name == "Default" ) {
				return;
			}
			var ioPath = Path.Combine("Assets", UDBaseConfig.ProjectFolderName);
			ioPath = Path.Combine(ioPath, "Schemes");
			ioPath = Path.Combine(ioPath, name + ".cs");
			File.Delete(ioPath);
			UpdateSchemes();
			AssetDatabase.Refresh();
		}

		public static bool IsActiveScheme(string name) {
			return EditorDefinesTool.IsActiveScheme(name);
		}
	}
}