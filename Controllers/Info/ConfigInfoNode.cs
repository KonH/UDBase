using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;

namespace UDBase.Controllers.InfoSystem {
	public abstract class ConfigInfoNode<T> : IJsonNode {

		public abstract string Name { get; }
		public List<T> Items { get { return items; } }

		[SerializeField]
		List<T> items;
	}
}
