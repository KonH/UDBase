using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventory : IController {
		int                 GetPackCount  (string holderName, string packName);
		void                AddToPack     (string holderName, string packName, int count);
		void                AddItem       (string holderName, string itemName);
		InventoryPack       GetPack       (string holderName, string packName);
		List<InventoryPack> GetHolderPacks(string holderName);
		void                RemoveFromPack(string holderName, InventoryPack pack, int count);
		void                ClearPack     (string holderName, InventoryPack pack);
		InventoryItem       GetItem       (string holderName, string itemName);
		List<InventoryItem> GetHolderItems(string holderName);
		void                RemoveItem    (string holderName, InventoryItem item);
	}
}
