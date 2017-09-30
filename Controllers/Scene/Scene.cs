#if UNITY_EDITOR
using UnityEditor;
#endif
using UDBase.Utils;

namespace UDBase.Controllers.SceneSystem {
	public class Scene : ControllerHelper<IScene> {
		public static ISceneInfo CurrentScene {
			get {
				for ( var i = 0; i < Instances.Count; i++ ) {
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
			for ( var i = 0; i < Instances.Count; i++ ) {
				Instances[i].LoadScene(sceneInfo);
			}
		}

		public static void ReloadScene() {
			for ( var i = 0; i < Instances.Count; i++ ) {
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

		public static bool IsSceneNameValid(string sceneName) {
			#if UNITY_EDITOR
			foreach( var scene in EditorBuildSettings.scenes ) {
				if( AssetUtils.ConvertScenePathToName(scene.path) == sceneName ) {
					return true;
				}
			}
			return false;
			#else
			return true;
			#endif
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
