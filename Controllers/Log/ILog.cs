using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.LogSystem {
	public interface ILog : IController {
		
		void Message(string msg, LogType type, int tag);
	}
}
