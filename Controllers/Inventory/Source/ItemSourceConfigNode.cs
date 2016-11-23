using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;

namespace UDBase.Controllers.InventorySystem {
	public class ItemSourceConfigNode<TItem, TPack> : IJsonNode 
		where TItem:IInventoryItem where TPack:IInventoryPack {

		public string                  Name    { get { return "inventory_source"; } }
		public List<TItem>             Items   { get { return items;              } }
		public List<TPack>             Packs   { get { return packs;              } }
		public List<HolderDescription> Holders { get { return holders;            } }

		[SerializeField]
		List<TItem>             items   = new List<TItem>();
		[SerializeField]
		List<TPack>             packs   = new List<TPack>();
		[SerializeField]
		List<HolderDescription> holders = new List<HolderDescription>();
	}
}
