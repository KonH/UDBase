using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemHolder<TItem, TPack>
		where TItem:IInventoryItem where TPack:IInventoryPack {

		string Name { get; }

		void        Init          (string name);
		TPack       GetPack       (string name);
		List<TPack> GetPacks      ();
		void        AddToPack     (TPack pack, int count);
		void        RemoveFromPack(TPack pack, int count);
		void        ClearPack     (TPack pack);
		TItem       GetItem       (string name);
		List<TItem> GetItems      ();
		void        AddItem       (TItem item);
		void        RemoveItem    (TItem item);
	}
}
