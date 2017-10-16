using System;
using System.Collections.Generic;

namespace UDBase.Controllers.SaveSystem {
	public sealed class InMemorySave:ISave {
		public Dictionary<Type, object> _state = new Dictionary<Type, object>();

		public void Init() {}
		public void PostInit() {}
		public void Reset() {}

		public InMemorySave AddNode<T>(string name) {
			var instance = Activator.CreateInstance<T>();
			_state.Add(typeof(T), instance);
			return this;
		}

		public T GetNode<T>(bool autoFill) {
			return (T)_state[typeof(T)];
		}

		public void SaveNode<T>(T node) {}
			
		public void Clear() {}
	}
}
