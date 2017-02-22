using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryPack {
		[fsProperty("name")]
		public string Name  { get; private set; }
		[fsProperty("count")]
		public int    Count { get; private set; }

		public InventoryPack() {}

		public InventoryPack(string name, int count) {
			Name = name;
			Count = count;
		}

		public void Add(int count) {
			Count += count;
		}

		public void Remove(int count) {
			Count -= count;
		}

		public InventoryPack Clone() {
			return new InventoryPack(Name, Count);
		}
	}
}
