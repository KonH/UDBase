using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimpleItem : IInventoryItem, IClonableItem<SimpleItem> {

		public SimpleItem() {}

		public SimpleItem(string name) {
			this.name = name;
		}

		public string Name {
			get {
				return name;
			}
		}

		[SerializeField]
		string name;

		public SimpleItem Clone() {
			var clone = new SimpleItem(Name);
			return clone;
		}
	}
}
