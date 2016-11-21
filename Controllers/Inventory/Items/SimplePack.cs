using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimplePack : IInventoryPack, IClonableItem<SimplePack> {

		public SimplePack() {}

		public SimplePack(string name, int count = 0) {
			this.name  = name;
			this.count = count;
		}

		public string Name { 
			get {
				return name;
			}		
		}

		public int Count {
			get {
				return count;
			}
			set {
				count = Mathf.Max(value, 0);
			}
		}

		[SerializeField]
		string name;
		[SerializeField]
		int    count;

		public SimplePack Clone() {
			var clone = new SimplePack(name, count);
			return clone;
		}
	}
}
