using System.Collections.Generic;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class Config : ControllerHelper<IConfig> {
		public static T GetNode<T>() {
			return (Instance != null) ? Instance.GetNode<T>() : default(T);
		}

		public static T GetItem<T>(string name) {
			return (Instance != null) ? Instance.GetItem<T>(name) : default(T);
		}

		public static Dictionary<string, T> GetItems<T>() {
			return (Instance != null) ? Instance.GetItems<T>() : null;
		}
	}
}
