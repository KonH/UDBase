using UnityEngine;
using System.Collections;
using UDBase.Utils;

namespace UDBase.Common {
	public static class UDBaseConfig {

		// Scheme
		public const string SchemeSymbolPrefix = "Scheme_";
		public const string SchemeDefaultName  = "Default";
		public const string SchemeDeclaredName = "Declared";

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
		public const string AssetsFolder         = "Assets";
		public const string BaseFolder           = "UDBase";
		public const string TemplatesFolder      = "Templates";
		public const string SchemeTemplateFile   = "TemplateScheme.txt";
		public const string MenuTemplateFile     = "SchemesMenu_Template.txt";
		public const string MenuItemTemplateFile = "SchemesMenuItem_Template.txt";
		public const string ProjectFolder        = "UDBase_Project";
		public const string ProjectEditorFolder  = "Editor";
		public const string ProjectSchemesFolder = "Schemes";
		public const string MenuItemsFile        = "SchemesMenuItems.cs";

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

		// Config
		public const string JsonConfigName = "config";

		// Save
		public const string JsonSaveName = "save.json";
		
		// Log
		public const string LogVisualPrefabPath = "VisualLogger";

		// CaptureScreen
		public const string ScreenshotsDirectory = "Screenshots";
	}
}
