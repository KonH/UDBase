using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class ItemConfigSource<TItem, TPack>: IItemSource<TItem, TPack> 
		where TItem:IInventoryItem where TPack:IInventoryPack {

		ItemSourceConfigNode<TItem, TPack> _node = null;

		public void Load() {
			_node = Config.GetNode<ItemSourceConfigNode<TItem, TPack>>();
			Log.MessageFormat("Load inventory source: {0} items, {1} packs.", LogTags.Inventory, 
				_node.Items != null ? _node.Items.Count : -1,
				_node.Packs != null ? _node.Packs.Count : -1);
		}

		public TItem GetItem(string itemName) {
			var items = _node.Items;
			for( int i = 0; i < items.Count; i++ ) {
				if( items[i].Name == itemName ) {
					return items[i];
				}
			}
			return default(TItem);
		}

		public TPack GetPack(string packName) {
			var packs = _node.Packs;
			for( int i = 0; i < packs.Count; i++ ) {
				if( packs[i].Name == packName ) {
					return packs[i];
				}
			}
			return default(TPack);
		}
	}
}
