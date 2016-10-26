using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UDBase.Components.Scene {
	public class Scene : ComponentHelper<IScene> {

		public static void LoadScene(ISceneInfo sceneInfo) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].LoadScene(sceneInfo);
			}
		}

		/*
		 * SceneType Extensions
		 */

		public static void LoadScene<T>(T type) {
			LoadScene(GetInfo(type));
		}

		public static void LoadScene<T>(T type, string param) {
			LoadScene(GetInfo(type, param));
		}

		public static void LoadScene<T>(T type, params string[] param) {
			LoadScene(GetInfo(type, param));
		}

		public static bool IsSceneNameValid(string scene_name) {
			#if UNITY_EDITOR
			foreach( var scene in EditorBuildSettings.scenes ) {
				if( ConvertPathToName(scene.path) == scene_name ) {
					return true;
				}
			}
			return false;
			#else
			return true;
			#endif
		}

		// TODO: Get asset name helper
		static string ConvertPathToName(string path) {
			var parts = path.Split('/');
			if( parts.Length > 0 ) {
				var result = parts[parts.Length-1];
				if( result.Length > 6 ) {
					result = result.Remove(result.Length - 6, 6);
					return result;
				}
			}
			return null;
		}

		static ISceneInfo GetInfo<T>(T type) {
			return new SceneParam<T>(type, "");
		}

		static ISceneInfo GetInfo<T>(T type, string param) {
			return new SceneParam<T>(type, param);
		}

		static ISceneInfo GetInfo<T>(T type, params string[] param) {
			return new MultiSceneParam<T>(type, param);
		}
	}
}
