using UnityEngine;
using System.Collections;

namespace UDBase.Components.Log {
	public interface ILog : IComponent {
		// TODO: Make useful interface for logging

		void Message(string msg, LogType type, int tag);
	}
}
