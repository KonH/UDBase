namespace UDBase.Controllers.InventorySystem {
	public interface ITransitionHelper {
		bool CanSend(string fromHolder, string toHolder, InventoryItem item);
		void Send   (string fromHolder, string toHolder, InventoryItem item);
		bool CanSend(string fromHolder, string toHolder, InventoryPack pack, int count);
		void Send   (string fromHolder, string toHolder, InventoryPack pack, int count);
	}
}
