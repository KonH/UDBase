using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Common;
using UDBase.Controllers;

namespace UDBase.Controllers.ContentSystem {
	public sealed class DirectContentController:IContent {

		public void Init() {}
		public void PostInit() {}

		public T Load<T>(ContentId id) where T:Object {
			return id.ContentObject as T;
		}
	}
}
