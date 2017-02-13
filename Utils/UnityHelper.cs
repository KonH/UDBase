using UnityEngine;
using System.Collections;

namespace UDBase.Utils {
	public static class UnityHelper {

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
		public static T AddPersistant<T>() where T:Component {
			return Add<T>(true);
		}

		public static T AddForScene<T>() where T:Component {
			return Add<T>(false);
		}

		static T Add<T>(bool persistant) where T:Component {
			var parent = persistant ? PersistantRoot : SceneRoot;
			return parent.gameObject.AddComponent<T>();
		}

		public static T GetComponent<T>() where T:Component {
			var sceneComp = GetSceneComponent<T>();
			if( !sceneComp ) {
				return GetPersistantComponent<T>();
			}
			return GetSceneComponent<T>();
		}

		public static T GetPersistantComponent<T>() where T:Component {
			return PersistantRoot.GetComponent<T>();
		}

		public static T GetSceneComponent<T>() where T:Component {
			return SceneRoot.GetComponent<T>();
		}

		static T GetOrCreateComponent<T>(bool persistant) where T:Component {
			var root = persistant ? PersistantRoot : SceneRoot;
			var comp = root.GetComponent<T>();
			if( !comp ) {
				comp = root.gameObject.AddComponent<T>();
			}
			return comp;
		}

		public static T GetOrCreatePersistantComponent<T>() where T:Component {
			return GetOrCreateComponent<T>(true);
		}

		public static T GetOrCreateSceneComponent<T>() where T:Component {
			return GetOrCreateComponent<T>(false);
		}

		public static void StartCoroutine(IEnumerator coroutine) {
			GetOrCreatePersistantComponent<CoroutineHelper>().Execute(coroutine);
		}

		public static void StartSceneCoroutine(IEnumerator coroutine) {
			GetOrCreateSceneComponent<CoroutineHelper>().Execute(coroutine);
		}
	}
}
