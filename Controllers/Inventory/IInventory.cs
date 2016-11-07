using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventoryBase : IController {
		int  GetPackCount(string holderName, string packName);
		void AddToPack(string holderName, string packName, int count);
	}

	public interface IInventory<TItem, TPack, THolder> : IInventoryBase
		where TItem:IInventoryItem
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack> {
	}
}
