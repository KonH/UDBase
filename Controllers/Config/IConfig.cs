using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.ConfigSystem {
	public interface IConfig : IController {
		
		T GetNode<T>();
		T GetItem<T>(string name);

		Dictionary<string, T> GetItems<T>();
	}
}
