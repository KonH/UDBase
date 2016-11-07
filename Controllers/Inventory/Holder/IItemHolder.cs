using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemHolder<TItem, TPack>
		where TItem:IInventoryItem where TPack:IInventoryPack {

		string Name { get; set; }

		TPack GetPack(string name);
		void  AddToPack(string name, int count);
	}
}
