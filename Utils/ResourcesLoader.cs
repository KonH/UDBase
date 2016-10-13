using UnityEngine;
using System.Collections;

namespace UDBase.Utils {
	public static class ResourcesLoader {

		static Transform _persistantRoot = null;
		static Transform PersistantRoot {
			get {
				if( !_persistantRoot ) {
					_persistantRoot = MakeRoot("[Application]", true);
				}
				return _persistantRoot;
			}
		}

		static Transform _sceneRoot = null;
		static Transform SceneRoot {
			get {
				if( !_sceneRoot ) {
					_sceneRoot = MakeRoot("[Scene]", false);
				}
				return _sceneRoot;
			}
		}

		static Transform MakeRoot(string name, bool persistant) {
			GameObject go = new GameObject(name);
			if( persistant ) {
				GameObject.DontDestroyOnLoad(go);
			}
			return go.transform;
		}

		public static T LoadPersistant<T>(string prefabPath) {
			return Load<T>(true, prefabPath);
		}

		public static T LoadForScene<T>(string prefabPath) {
			return Load<T>(false, prefabPath);
		}

		static T Load<T>(bool persistant, string prefabPath) {
			var prefabGo = Resources.Load(prefabPath) as GameObject;
			if( prefabGo ) {
				var instanceGo = GameObject.Instantiate(prefabGo);
				var parent = persistant ? PersistantRoot : SceneRoot;
				instanceGo.transform.SetParent(parent);
				return instanceGo.GetComponent<T>();
			}
			Debug.LogErrorFormat("Error while loading {0} from Resources!", prefabPath);
			return default(T);
		}

		public static T CreatePersistant<T>() where T:Component {
			return Create<T>(true);

		}

		public static T CreateForScene<T>() where T:Component {
			return Create<T>(false);
		}

		static T Create<T>(bool persistant) where T:Component {
			var root = persistant ? PersistantRoot : SceneRoot;
			if( root ) {
				return root.gameObject.AddComponent<T>();
			}
			return null;
		}
	}
}
