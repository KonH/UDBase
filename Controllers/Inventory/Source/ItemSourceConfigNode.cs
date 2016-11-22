using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;

namespace UDBase.Controllers.InventorySystem {
	public class ItemSourceConfigNode<TItem, TPack> : IJsonNode 
		where TItem:IInventoryItem where TPack:IInventoryPack {

		public string Name { get { return "inventory_source"; } }

		public List<TItem>             Items   = new List<TItem>();
		public List<TPack>             Packs   = new List<TPack>();
		public List<HolderDescription> Holders = new List<HolderDescription>();
	}
}
