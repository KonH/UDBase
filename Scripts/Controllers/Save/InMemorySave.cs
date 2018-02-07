using System;
using System.Collections.Generic;

namespace UDBase.Controllers.SaveSystem {
	public sealed class InMemorySave:ISave {
		public Dictionary<Type, object> _state = new Dictionary<Type, object>();

		public InMemorySave AddNode<T>(string name) where T:ISaveSource {
			var instance = Activator.CreateInstance<T>();
			_state.Add(typeof(T), instance);
			return this;
		}

		public T GetNode<T>(bool autoFill) where T:ISaveSource {
			return (T)_state[typeof(T)];
		}

		public void SaveNode<T>(T node) where T:ISaveSource {}
	}
}
