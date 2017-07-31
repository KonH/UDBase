using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class ItemDescription {		
		[fsProperty("name")]
		public string Name    { get; private set; }
		[fsProperty("type")]
		public string    Type { get; private set; }

		public InventoryItem SetupItem(InventoryItem item) {
			item.SetName(Name);
			item.SetType(Type);
			return item;
		}
	}
}
