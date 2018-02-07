using System.Collections.Generic;

namespace UDBase.Controllers.ConfigSystem {
	public interface IConfig {
		T GetNode<T>() where T:IConfigSource;
	}
}
