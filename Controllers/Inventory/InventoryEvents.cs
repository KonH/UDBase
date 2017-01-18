using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.InventorySystem {

	public struct Inv_ItemAdded {
		public string        HolderName { get; private set; }
		public InventoryItem Item       { get; private set; }

		public Inv_ItemAdded(string holderName, InventoryItem item) {
			HolderName = holderName;
			Item       = item;
		}
	}

	public struct Inv_PackChanged {
		public string HolderName { get; private set; }
		public string PackName   { get; private set; }

		public Inv_PackChanged(string holderName, string packName) {
			HolderName = holderName;
			PackName   = packName;
		}
	}

	public struct Inv_HolderChanged {
		public string HolderName { get; private set; }

		public Inv_HolderChanged(string holderName) {
			HolderName = holderName;
		}
	}
}
