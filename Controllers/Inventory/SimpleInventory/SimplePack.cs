using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimplePack : IInventoryPack, IClonableItem<SimplePack> {

		public string Name { get { return name; } }

		public string Type { get { return type; } } 

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
		string type;
		[SerializeField]
		int    count;

		public SimplePack() {}

		public SimplePack(string name, string type, int count = 0) {
			this.name  = name;
			this.type  = type;
			this.count = count;
		}
	
		public void Init() {}
		public void Load() {}

		public SimplePack Clone() {
			var clone = new SimplePack(Name, Type, Count);
			return clone;
		}
	}
}
