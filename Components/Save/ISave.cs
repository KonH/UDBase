using UnityEngine;
using System;
using System.Collections;
using UDBase.Components;
using UDBase.Utils.Json;

namespace UDBase.Components.Save {
	public interface ISave : IComponent {
		
		T GetNode<T>() where T:class, IJsonNode, new();
		void SaveNode<T>(T node) where T:class, IJsonNode, new();
		void Clear();
	}
}
