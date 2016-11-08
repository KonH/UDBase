using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventoryBase : IController {
		int      GetPackCount      (string holderName, string packName);
		void     AddToPack         (string holderName, string packName, int count);
		void     AddItem           (string holderName, string itemName);
		TP       GetPack<TP>       (string holderName, string packName);
		List<TP> GetHolderPacks<TP>(string holderName);
		void     RemoveFromPack<TP>(string holderName, TP pack, int count);
		void     ClearPack<TP>     (string holderName, TP pack);
		TI       GetItem<TI>       (string holderName, string itemName);
		List<TI> GetHolderItems<TI>(string holderName);
		void     RemoveItem<TI>    (string holderName, TI item);
	}

	public interface IInventory<TItem, TPack, THolder> : IInventoryBase
		where TItem:IInventoryItem
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack> {

		TPack       GetPackTyped        (string holderName, string packName);
		List<TPack> GetHolderPacksTyped (string holderName);
		void        RemoveFromPackTyped (string holderName, TPack pack, int count);
		void        ClearPackTyped      (string holderName, TPack pack);
		TItem       GetItemTyped        (string holderName, string itemName);
		List<TItem> GetHolderItemsTyped (string holderName);
		void        RemoveItemTyped     (string holderName, TItem item);
	}
}
