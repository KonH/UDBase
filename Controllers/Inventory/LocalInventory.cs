﻿using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public class LocalInventory<TItem, TPack, THolder> : BaseInventory<TItem, TPack, THolder>
		where TItem: IInventoryItem
		where TPack: IInventoryPack
		where THolder: IItemHolder<TItem, TPack>, new() {

		public LocalInventory():
			this(new InventorySaveState<TItem, TPack, THolder>()) {}

		public LocalInventory(IInventorySave<TItem, TPack, THolder> save):
			base(new ItemConfigSource<TItem, TPack>(), save) {}

	}
}
