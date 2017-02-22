using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.LogSystem {
	public sealed class UnityLog : ILog {
		LogTags _tagger = null;

		public UnityLog(LogTags tagger) {
			_tagger = tagger;
		}

		public UnityLog():this(new LogTags()) {}

		public void Init() {}

		public void PostInit() {}

		public void Reset() {}

		public void Message(string msg, LogType type, int tag) {
			Debug.logger.Log(type, _tagger.GetName(tag), msg);
		}
	}
}
