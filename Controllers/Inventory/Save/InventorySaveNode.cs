using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveNode<TItem, TPack, THolder>:IJsonNode
		where TItem:IInventoryItem 
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack> {

		public string Name { get { return "inventory"; } }

		public List<THolder> Holders = new List<THolder>();
	}
}
