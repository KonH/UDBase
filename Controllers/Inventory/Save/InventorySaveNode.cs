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

		public List<THolder> Holders { get { return holders;} }

		public InventorySaveNode() {}

		public InventorySaveNode(List<THolder> holders) {
			this.holders = holders;
		}

		[SerializeField]
		List<THolder> holders = new List<THolder>();
	}
}
