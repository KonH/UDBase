using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class ItemSourceConfigNode {
		
		[fsProperty("items")]
		public List<ItemDescription>   Items   { get; private set; }
		[fsProperty("packs")]
		public List<PackDescription>   Packs   { get; private set; }
		[fsProperty("holders")]
		public List<HolderDescription> Holders { get; private set; }
	}
}
