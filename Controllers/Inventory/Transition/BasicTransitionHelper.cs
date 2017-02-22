namespace UDBase.Controllers.InventorySystem {
	public class BasicTransitionHelper : ITransitionHelper {

		public bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			return true;
		}

		public void Send(string fromHolder, string toHolder, InventoryItem item) {
			Inventory.RemoveItem(fromHolder, item);
			Inventory.AddItem(toHolder, item);
		}

		public bool CanSend(string fromHolder, string toHolder, InventoryPack pack, int count) {
			if( pack != null ) {
				return pack.Count >= count;
			}
			return false;
		}

		public void Send(string fromHolder, string toHolder, InventoryPack pack, int count) {
			var packName = pack.Name;
			Inventory.RemoveFromPack(fromHolder, pack, count);
			Inventory.AddToPack(toHolder, packName, count);
		}
	}
}
