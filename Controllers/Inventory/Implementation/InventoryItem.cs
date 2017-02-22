using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryItem {
		[fsProperty("name")]
		public string Name     { get; private set; }
		[fsProperty("type")]
		public string Type     { get; private set; }

		public InventoryItem() {}

		public InventoryItem(string name, string type) {
			Name = name;
			Type = type;
		}

		public void SetName(string name) {
			Name = name;
		}

		public void SetType(string type) {
			Type = type;
		}

		public virtual void Init() {}

		public virtual InventoryItem Clone() {
			return new InventoryItem(Name, Type);
		}
	}
}
