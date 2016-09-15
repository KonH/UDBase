using UnityEngine;
using System.Collections;
using UDBase.Common;

namespace UDBase.Components.Log {
	public class Log_Visual : ILog {
		Log_Visual_Behaviour _handler = null;

		public Log_Visual(string prefabPath) {
			// TODO: Common loader with holder
			var prefabGo = Resources.Load(prefabPath) as GameObject;
			if( prefabGo ) {
				var instanceGo = GameObject.Instantiate(prefabGo);
				GameObject.DontDestroyOnLoad(instanceGo);
				_handler = instanceGo.GetComponent<Log_Visual_Behaviour>();
				if( _handler ) {
					_handler.Init();
					return;
				}
			}
			Debug.LogError("Error while loading Log_Visual_Behaviour from Resources!");
		}

		public Log_Visual():this(UDBaseConfig.LogVisualPrefabPath) {}

		// TODO: Create Unity UI overlay and use it for logging

		public void Init() {
			Debug.Log("Init Visual log");
		}

		public void Message(string msg) {
			_handler.AddMessage(msg);
		}	
	}
}
