using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public class Log_Unity : ILog {
		Log_Tags _tagger = null;

		public Log_Unity(Log_Tags tagger) {
			_tagger = tagger;
		}

		public Log_Unity():this(new Log_Tags()) {}

		public void Init() {}

		public void Message(string msg, LogType type, int tag) {
			Debug.logger.Log(type, _tagger.GetName(tag), msg);
		}
	}
}
