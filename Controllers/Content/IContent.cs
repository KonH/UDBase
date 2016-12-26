using UnityEngine;
using System.Collections;
using UDBase.Controllers;

namespace UDBase.Controllers.ContentSystem {
	public interface IContent : IController {

		T Load<T>(ContentId id) where T:Object;
	}
}
