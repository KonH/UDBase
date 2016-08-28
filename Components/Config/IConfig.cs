using UnityEngine;
using System;
using System.Collections;
using UDBase.Components;

namespace UDBase.Components.Config {
	public interface IConfig : IComponent {

		T GetNode<T>() where T:class, IConfigNode, new();
	}
}
