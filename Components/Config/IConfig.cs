using UnityEngine;
using System;
using System.Collections;
using UDBase.Components;
using UDBase.Utils.Json;

namespace UDBase.Components.Config {
	public interface IConfig : IComponent {

		T GetNode<T>() where T:class, IJsonNode, new();
	}
}
