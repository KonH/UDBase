using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemSource<TItem, TPack> 
		where TItem:IInventoryItem
		where TPack:IInventoryPack {

		void Load();
		TItem GetItem(string name);
		TPack GetPack(string name);
	}
}
