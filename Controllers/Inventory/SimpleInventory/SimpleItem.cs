using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimpleItem : IInventoryItem, IClonableItem<SimpleItem> {

		public string Name { get { return name; } }
		public string Type { get { return type; } } 

		[SerializeField]
		protected string name;

		[SerializeField]
		protected string type;

		public SimpleItem() {}

		public SimpleItem(string name, string type) {
			this.name = name;
			this.type = type;
		}

		public virtual void Init() {}
		public virtual void Load() {}

		public SimpleItem Clone() {
			var clone = new SimpleItem(Name, Type);
			return clone;
		}
	}
}
