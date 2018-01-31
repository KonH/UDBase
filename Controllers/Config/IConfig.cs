using System.Collections.Generic;

namespace UDBase.Controllers.ConfigSystem {
	public interface IConfig {
		
		T GetNode<T>();
		T GetItem<T>(string name);

		Dictionary<string, T> GetItems<T>();
	}
}
