using UnityEngine;

namespace UDBase.Controllers.LogSystem {
	public interface ILog : IController {		
		void Message(string msg, LogType type, LogTags tag);
	}
}
