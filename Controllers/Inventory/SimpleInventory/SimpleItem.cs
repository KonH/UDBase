using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimpleItem : IInventoryItem, IClonableItem<SimpleItem> {

		public string Name { get { return name; } }
		public string Type { get { return type; } } 

		[SerializeField]
		string name;

		[SerializeField]
		string type;

		public SimpleItem() {}

		public SimpleItem(string name, string type) {
			this.name = name;
			this.type = type;
		}

		public void Init() {}
		public void Load() {}

		public SimpleItem Clone() {
			var clone = new SimpleItem(Name, Type);
			return clone;
		}
	}
}
