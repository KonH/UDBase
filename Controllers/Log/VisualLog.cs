using UnityEngine;
using System.Collections;
using UDBase.Common;
using UDBase.Utils;
using UDBase.Controllers.LogSystem.UI;

namespace UDBase.Controllers.LogSystem {
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
			_handler = UnityHelper.LoadPersistant<VisualLogHandler>(prefabPath);
			if( _handler ) {
				_handler.Init(_tagger.GetNames(), openButtonPos);
			}
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
