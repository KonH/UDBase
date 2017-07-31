using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public sealed class UnityLog : ILog {		
		public void Init() {}
		public void PostInit() {}
		public void Reset() {}

		public void Message(string msg, LogType type, LogTags tag) {
			Debug.unityLogger.Log(type, tag.ToString(), msg);
		}
	}
}
