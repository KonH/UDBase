using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimpleItem : IInventoryItem {

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		[SerializeField]
		string name;
	}
}
