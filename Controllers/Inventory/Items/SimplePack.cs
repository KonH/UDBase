using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimplePack : IInventoryPack {

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

		[SerializeField]
		string name;
		[SerializeField]
		int    count;
	}
}
