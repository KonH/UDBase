using UnityEngine;

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
			Debug.unityLogger.Log(type, _tagger.GetName(tag), msg);
		}
	}
}
