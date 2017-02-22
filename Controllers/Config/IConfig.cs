using System.Collections.Generic;

namespace UDBase.Controllers.ConfigSystem {
	public interface IConfig : IController {
		
		T GetNode<T>();
		T GetItem<T>(string name);

		Dictionary<string, T> GetItems<T>();
	}
}
