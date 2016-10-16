using UnityEngine;
using System.Collections;

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
