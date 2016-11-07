using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class ItemConfigSource<TItem, TPack>: IItemSource 
		where TItem:IInventoryItem where TPack:IInventoryPack {

		ItemSourceConfigNode<TItem, TPack> _node = null;

		public void Load() {
			_node = Config.GetNode<ItemSourceConfigNode<TItem, TPack>>();
			Log.MessageFormat("Load inventory source: {0} items, {1} packs.", LogTags.Inventory, 
				_node.Items != null ? _node.Items.Count : -1,
				_node.Packs != null ? _node.Packs.Count : -1);
		}
	}
}
