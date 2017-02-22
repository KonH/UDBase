using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventory : IController {
		int                 GetPackCount  (string holderName, string packName);
		void                AddToPack     (string holderName, string packName, int count);
		void                AddItem       (string holderName, string itemName);
		void                AddItem       (string holderName, InventoryItem item);
		InventoryPack       GetPack       (string holderName, string packName);
		List<InventoryPack> GetHolderPacks(string holderName);
		void                RemoveFromPack(string holderName, InventoryPack pack, int count);
		void                ClearPack     (string holderName, InventoryPack pack);
		InventoryItem       GetItem       (string holderName, string itemName);
		List<InventoryItem> GetHolderItems(string holderName);
		void                RemoveItem    (string holderName, InventoryItem item);
		void                SaveChanges   ();
		void                Load          ();
		bool                CanSend       (string fromHolder, string toHolder, InventoryItem item);
		void                Send          (string fromHolder, string toHolder, InventoryItem item);
		bool                CanSend       (string fromHolder, string toHolder, InventoryPack pack, int count);
		void                Send          (string fromHolder, string toHolder, InventoryPack pack, int count);
	}
}
