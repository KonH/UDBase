using UnityEngine;
using System.Collections;
using UDBase.Utils;

namespace UDBase.Common {
	public static class UDBaseConfig {

		// Scheme
		public static string SchemeSymbolPrefix = "Scheme_";
		public static string SchemeDefaultName  = "Default";
		public static string SchemeDeclaredName = "Declared";

		public static string DefaultSchemeSymbols {
			get {
				return SchemeSymbolPrefix + SchemeDefaultName;
			}
		}

		public static string SchemeDeclarationSymbols {
			get {
				return SchemeSymbolPrefix + SchemeDeclaredName;
			}
		}

		// File structure
		public static string AssetsFolder         = "Assets";
		public static string BaseFolder           = "UDBase";
		public static string TemplatesFolder      = "Templates";
		public static string SchemeTemplateFile   = "TemplateScheme.txt";
		public static string MenuTemplateFile     = "SchemesMenu_Template.txt";
		public static string MenuItemTemplateFile = "SchemesMenuItem_Template.txt";
		public static string ProjectFolder        = "UDBase_Project";
		public static string ProjectEditorFolder  = "Editor";
		public static string ProjectSchemesFolder = "Schemes";
		public static string MenuItemsFile        = "SchemesMenuItems.cs";

		public static string SchemeTemplatePath { 
			get {
				return IOTool.GetPath(AssetsFolder, BaseFolder, TemplatesFolder, SchemeTemplateFile);
			}
		}

		public static string MenuTemplatePath {
			get {
				return IOTool.GetPath(AssetsFolder, BaseFolder, TemplatesFolder, MenuTemplateFile);
			}
		}

		public static string MenuItemTemplatePath {
			get {
				return IOTool.GetPath(AssetsFolder, BaseFolder, TemplatesFolder, MenuItemTemplateFile);
			}
		}

		public static string ProjectPath {
			get {
				return IOTool.GetPath(AssetsFolder, ProjectFolder); 
			}
		}

		public static string ProjectEditorPath {
			get {
				return IOTool.GetPath(AssetsFolder, ProjectFolder, ProjectEditorFolder);
			}
		}

		public static string ProjectSchemesPath {
			get {
				return IOTool.GetPath(AssetsFolder, ProjectFolder, ProjectSchemesFolder);
			}
		}

		public static string GetProjectSchemePathFor(string schemeName) {
			return IOTool.GetPath(AssetsFolder, ProjectFolder, ProjectSchemesFolder, schemeName + ".cs");
		}

		public static string ProjectEditorMenuItemsPath {
			get {
				return IOTool.GetPath(AssetsFolder, ProjectFolder, ProjectEditorFolder, MenuItemsFile);
			}
		}

		// Log
		public static string LogVisualPrefabPath = "VisualLogger";
	}
}
