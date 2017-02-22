using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class PackDescription {
		
		[fsProperty("name")]
		public string Name  { get; private set; }
		[fsProperty("count")]
		public int    Count { get; private set; }

		public InventoryPack Create() {
			return new InventoryPack(Name, Count);
		}
	}
}
