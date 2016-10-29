using UnityEngine;
using System;
using System.Collections;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.Save {
	public interface ISave : IController {
		
		T GetNode<T>() where T:class, IJsonNode, new();
		void SaveNode<T>(T node) where T:class, IJsonNode, new();
		void Clear();
	}
}
