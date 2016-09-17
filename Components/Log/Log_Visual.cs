using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Components.Log.UI;

namespace UDBase.Components.Log {
	public class Log_Visual : ILog {
		Log_Tags             _tagger  = null;
		Log_Visual_Behaviour _handler = null;

		public Log_Visual(string prefabPath, Log_Tags tagger) {
			_tagger = tagger;
			// TODO: Common loader with holder
			var prefabGo = Resources.Load(prefabPath) as GameObject;
			if( prefabGo ) {
				var instanceGo = GameObject.Instantiate(prefabGo);
				GameObject.DontDestroyOnLoad(instanceGo);
				_handler = instanceGo.GetComponent<Log_Visual_Behaviour>();
				if( _handler ) {
					_handler.Init(_tagger.GetNames());
					return;
				}
			}
			Debug.LogError("Error while loading Log_Visual_Behaviour from Resources!");
		}

		public Log_Visual():this(UDBaseConfig.LogVisualPrefabPath, new Log_Tags()) {}

		public Log_Visual(Log_Tags tagger):this(UDBaseConfig.LogVisualPrefabPath, tagger) {}

		public Log_Visual(string prefabPath):this(prefabPath, new Log_Tags()) {}

		// TODO: Create Unity UI overlay and use it for logging

		public void Init() {}

		public void Message(string msg, LogType type, int tag) {
			_handler.AddMessage(msg, type, _tagger.GetName(tag));
		}	
	}
}
