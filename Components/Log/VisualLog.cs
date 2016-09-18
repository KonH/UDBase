using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Components.Log.UI;

namespace UDBase.Components.Log {
	public enum ButtonPosition {
		LeftTop,
		RightTop,
		LeftBottom,
		RightBottom
	}

	public class VisualLog : ILog {
		LogTags             _tagger  = null;
		VisualLogHandler    _handler = null;

		public VisualLog(string prefabPath, LogTags tagger, ButtonPosition openButtonPos) {
			_tagger = tagger;
			// TODO: Common loader with holder
			var prefabGo = Resources.Load(prefabPath) as GameObject;
			if( prefabGo ) {
				var instanceGo = GameObject.Instantiate(prefabGo);
				GameObject.DontDestroyOnLoad(instanceGo);
				_handler = instanceGo.GetComponent<VisualLogHandler>();
				if( _handler ) {
					_handler.Init(_tagger.GetNames(), openButtonPos);
					return;
				}
			}
			Debug.LogError("Error while loading Log_Visual_Behaviour from Resources!");
		}

		public VisualLog(LogTags tagger):
			this(UDBaseConfig.LogVisualPrefabPath, tagger, ButtonPosition.RightTop) {}

		public VisualLog(string prefabPath):
			this(prefabPath, new LogTags(), ButtonPosition.RightTop) {}

		public VisualLog(ButtonPosition openButtonPos):
			this(UDBaseConfig.LogVisualPrefabPath, new LogTags(), openButtonPos) {}

		public VisualLog():
			this(UDBaseConfig.LogVisualPrefabPath, new LogTags(), ButtonPosition.RightTop) {}

		public void Init() {}

		public void Message(string msg, LogType type, int tag) {
			_handler.AddMessage(msg, type, _tagger.GetName(tag));
		}	
	}
}
