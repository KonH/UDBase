using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public interface ILog : IComponent {
		
		void Message(string msg, LogType type, int tag);
	}
}
