using UnityEngine;
using System;
using System.Collections;
using UDBase.Controllers;

namespace UDBase.Controllers.ContentSystem {
	public interface IContent : IController {

		bool LoadAsync<T>(ContentId id, Action<T> callback) where T:UnityEngine.Object;
	}
}
