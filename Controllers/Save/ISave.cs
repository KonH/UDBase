using UnityEngine;
using System;
using System.Collections;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.SaveSystem {
	public interface ISave : IController {
		
		T GetNode<T>();
		void SaveNode<T>(T node);
		void Clear();
	}
}
