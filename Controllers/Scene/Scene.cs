using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UDBase.Controllers.SceneSystem {
	public class Scene : ControllerHelper<IScene> {

		public static ISceneInfo CurrentScene {
			get {
				for( int i = 0; i < Instances.Count; i++ ) {
					var curScene = Instances[i].CurrentScene;
					if( curScene != null ) {
						return curScene;
					}
				}
				return null;
			}
		}

		public static void LoadSceneByName(string sceneName) {
			LoadSceneByInfo(new SceneName(sceneName));
		}

		public static void LoadSceneByInfo(ISceneInfo sceneInfo) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].LoadScene(sceneInfo);
			}
		}

		public static void ReloadScene() {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].ReloadScene();
			}
		}

		/*
		 * SceneType Extensions
		 */

		public static void LoadScene<T>(T type) {
			LoadSceneByInfo(GetInfo(type));
		}

		public static void LoadScene<T>(T type, string param) {
			LoadSceneByInfo(GetInfo(type, param));
		}

		public static void LoadScene<T>(T type, params string[] param) {
			LoadSceneByInfo(GetInfo(type, param));
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

		public static ISceneInfo GetInfo<T>(T type) {
			return new SceneParam<T>(type, "");
		}

		public static ISceneInfo GetInfo<T>(T type, string param) {
			return new SceneParam<T>(type, param);
		}

		public static ISceneInfo GetInfo<T>(T type, params string[] param) {
			return new MultiSceneParam<T>(type, param);
		}
	}
}
