using UnityEngine;
using System;
using System.Collections;
using UDBase.Components;

namespace UDBase.Components.Save {
	public interface ISave : IComponent {
		
		T GetNode<T>() where T:class, ISaveNode, new();
		void SaveNode<T>(T node) where T:class, ISaveNode, new();
	}
}
