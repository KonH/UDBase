using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Utils {
	public class UpdateHelper : MonoBehaviour {
		static UpdateHelper _globalInstance;
		static UpdateHelper GlobalInstance {
			get {
				if( !_globalInstance ) {
					_globalInstance = UnityHelper.GetOrCreatePersistantComponent<UpdateHelper>();
				}
				return _globalInstance;
			}
		}

		static UpdateHelper _sceneInstance;
		static UpdateHelper SceneInstance {
			get {
				if( !_sceneInstance ) {
					_sceneInstance = UnityHelper.GetOrCreateSceneComponent<UpdateHelper>();
				}
				return _sceneInstance;
			}
		}

		readonly List<ICustomUpdate> _instances = new List<ICustomUpdate>();
		
		void Subscribe(ICustomUpdate instance) {
			_instances.Add(instance);
		}

		void Unsubscribe(ICustomUpdate instance) {
			_instances.Remove(instance);
		}

		void Update () {
			if ( _instances.Count == 0 ) {
				return;
			}
			for ( int i = 0; i < _instances.Count; i++ ) {
				_instances[i].CustomUpdate();
			}
		}

		public static void SceneSubscribe(ICustomUpdate instance) {
			if( ApplicationQuitTracker.IsClosing ) {
				return;
			}
			SceneInstance.Subscribe(instance);
		}

		public static void SceneUnsubscribe(ICustomUpdate instance) {
			if( ApplicationQuitTracker.IsClosing ) {
				return;
			}
			SceneInstance.Unsubscribe(instance);
		}

		public static void GlobalSubscribe(ICustomUpdate instance) {
			if( ApplicationQuitTracker.IsClosing ) {
				return;
			}
			GlobalInstance.Subscribe(instance);
		}

		public static void GlobalUnsubscribe(ICustomUpdate instance) {
			if( ApplicationQuitTracker.IsClosing ) {
				return;
			}
			GlobalInstance.Unsubscribe(instance);
		}
	}
}
