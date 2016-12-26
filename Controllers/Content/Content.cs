using UnityEngine;
using System.Collections;
using UDBase.Controllers;
using UDBase.Common;

namespace UDBase.Controllers.ContentSystem {
	public class Content:ControllerHelper<IContent> {

		public static T Load<T>(ContentId id) where T:Object {
			return Instance.Load<T>(id);
		}
	}
}
