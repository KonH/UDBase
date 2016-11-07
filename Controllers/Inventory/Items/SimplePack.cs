using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimplePack : IInventoryPack {

		[SerializeField]
		public string name;
		[SerializeField]
		public int    count;

		public string Name { 
			get {
				return name;
			} 
			set {
				name = value;
			}
		}

		public int Count {
			get {
				return count;
			}
			set {
				count = value;
			}
		}
	}
}
