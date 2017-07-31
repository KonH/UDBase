using System;
using UnityEngine;
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

	public sealed class VisualLog : ILog {
		readonly VisualLogHandler _handler;

		public VisualLog(string prefabPath, ButtonPosition openButtonPos) {
			_handler = UnityHelper.LoadPersistant<VisualLogHandler>(prefabPath);
			if( _handler ) {
				_handler.Init(GetTagNames(), openButtonPos);
			}
		}

		string[] GetTagNames() {
			return Enum.GetNames(typeof(LogTags));
		}

		public VisualLog():
			this(UDBaseConfig.LogVisualPrefabPath, ButtonPosition.RightTop) {}

		public VisualLog(string prefabPath):
			this(prefabPath, ButtonPosition.RightTop) {}

		public VisualLog(ButtonPosition openButtonPos):
			this(UDBaseConfig.LogVisualPrefabPath, openButtonPos) {}

		public void Init() {}

		public void PostInit() {}

		public void Reset() {}

		public void Message(string msg, LogType type, LogTags tag) {
			_handler.AddMessage(msg, type, tag.ToString());
		}	
	}
}
