using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventorySave<TItem, TPack, THolder>
		where TItem:IInventoryItem
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack> {

		void    Setup(List<THolder> defaultHolders);
		THolder GetHolder(string name);
		void    AddHolder(THolder holder);
		void    SaveChanges();
	}
}
