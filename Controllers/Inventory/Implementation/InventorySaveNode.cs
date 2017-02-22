using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveNode {
		
		[fsProperty("holders")]
		public List<InventoryHolder> Holders { get; private set; }

		public InventorySaveNode() {}

		public InventorySaveNode(List<InventoryHolder> holders) {
			Holders = holders;
		}
	}
}
