using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Editor {
	
	// Tool to change current "Scheme_" defines with keeping third-party defines 
	public class EditorDefinesTool {
		static Dictionary<BuildTarget, BuildTargetGroup> buildTargetMap;

		static EditorDefinesTool() {
			FillMap();
		}

		static void FillMap() {
			buildTargetMap = new Dictionary<BuildTarget, BuildTargetGroup>();
			AddToMap(BuildTargetGroup.Android, BuildTarget.Android);
			AddToMap(BuildTargetGroup.iOS, BuildTarget.iOS);
			AddToMap(BuildTargetGroup.Nintendo3DS, BuildTarget.Nintendo3DS);
			AddToMap(BuildTargetGroup.PS3, BuildTarget.PS3);
			AddToMap(BuildTargetGroup.PS4, BuildTarget.PS4);
			AddToMap(BuildTargetGroup.PSM, BuildTarget.PSM);
			AddToMap(BuildTargetGroup.PSP2, BuildTarget.PSP2);
			AddToMap(BuildTargetGroup.SamsungTV, BuildTarget.SamsungTV);
			AddToMap(BuildTargetGroup.Standalone, 
				BuildTarget.StandaloneLinux, 
				BuildTarget.StandaloneLinux64, 
				BuildTarget.StandaloneLinuxUniversal,
				BuildTarget.StandaloneOSXIntel,
				BuildTarget.StandaloneOSXIntel64,
				BuildTarget.StandaloneOSXUniversal,
				BuildTarget.StandaloneWindows,
				BuildTarget.StandaloneWindows64);
			AddToMap(BuildTargetGroup.Tizen, BuildTarget.Tizen);
			AddToMap(BuildTargetGroup.tvOS, BuildTarget.tvOS);
			AddToMap(BuildTargetGroup.WebGL, BuildTarget.WebGL);
			AddToMap(BuildTargetGroup.WiiU, BuildTarget.WiiU);
			AddToMap(BuildTargetGroup.WSA, BuildTarget.WSAPlayer);
			AddToMap(BuildTargetGroup.XBOX360, BuildTarget.XBOX360);
			AddToMap(BuildTargetGroup.XboxOne, BuildTarget.XboxOne);
		}

		static void AddToMap(BuildTargetGroup group, params BuildTarget[] targets) {
			for(int i = 0; i < targets.Length; i++) {
				buildTargetMap.Add(targets[i], group);
			}
		}

		public static void SetScheme(string schemeName) {
			var currentGroup = GetCurrentGroup();
			var currentSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(currentGroup);
			var newSymbols = currentSymbols.Length > 0 ? RemoveGroup(currentSymbols) : "";
			newSymbols += "Scheme_" + schemeName + ";Scheme_Declared";
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, newSymbols);
			Debug.Log("Active scheme now: " + schemeName);
		} 

		static string RemoveGroup(string define) {
			if(define.Length > 0) {
				var parts = define.Split(';');
				var newDefine = "";
				for(int i = 0; i < parts.Length; i++) {
					if( !parts[i].Contains("Scheme_") ) {
						newDefine += parts[i] + ";";
					}
				}
				return newDefine;
			}
			return define;
		}

		static BuildTargetGroup GetCurrentGroup() {
			return ConvertBuildTarget(EditorUserBuildSettings.activeBuildTarget);
		}

		// Obsolete BuildTargets is not supported
		public static BuildTargetGroup ConvertBuildTarget(BuildTarget target) {
			var group = BuildTargetGroup.Unknown;
			if( !buildTargetMap.TryGetValue(target, out group) ) {
				throw new UnityException("Unknown BuildTarget!");
			}
			return group;
		}
	}
}
