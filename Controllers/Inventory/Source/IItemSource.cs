using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemSource<TItem, TPack, THolder> 
		where TItem:IInventoryItem
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack> {

		void          Load();
		TItem         GetItem(string name);
		TPack         GetPack(string name);
		List<THolder> GetHolders();
	}
}
