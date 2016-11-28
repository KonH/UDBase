using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class ItemConfigSource<TItem, TPack, THolder>: IItemSource<TItem, TPack, THolder> 
		where TItem:IInventoryItem, IClonableItem<TItem>, new() 
		where TPack:IInventoryPack, IClonableItem<TPack>, new()
		where THolder:ItemHolder<TItem, TPack>, new() {

		ItemSourceConfigNode<TItem, TPack> _node = null;

		public void Load() {
			_node = Config.GetNode<ItemSourceConfigNode<TItem, TPack>>();
			Log.MessageFormat("Load inventory source: {0} items, {1} packs, {2} holders.", LogTags.Inventory, 
				_node.Items   != null ? _node.Items.Count   : -1,
				_node.Packs   != null ? _node.Packs.Count   : -1,
				_node.Holders != null ? _node.Holders.Count : -1);
			if( _node.Items != null ) {
				for( int i = 0; i < _node.Items.Count; i++ ) {
					var item = _node.Items[i];
					item.Init();
				}
			}
		}

		TItem GetItem(string itemName) {
			var items = _node.Items;
			for( int i = 0; i < items.Count; i++ ) {
				if( items[i].Name == itemName ) {
					return items[i];
				}
			}
			return default(TItem);
		}

		TPack GetPack(string packName) {
			var packs = _node.Packs;
			for( int i = 0; i < packs.Count; i++ ) {
				if( packs[i].Name == packName ) {
					return packs[i];
				}
			}
			return default(TPack);
		}

		public TItem LoadItem(string itemName) {
			var item = GetItem(itemName);
			if( item != null ) {
				var itemClone = item.Clone();
				itemClone.Load();
				return itemClone;
			}
			return default(TItem);
		}

		public TPack LoadPack(string packName) {
			var pack = GetPack(packName);
			if( pack != null ) {
				var packClone = pack.Clone();
				packClone.Load();
				return packClone;
			}
			return default(TPack);
		}

		public List<THolder> GetHolders() {
			var descriptions = _node.Holders;
			var holders = new List<THolder>();
			for( int i = 0; i < descriptions.Count; i++ ) {
				var description = descriptions[i];
				var newHolder = new THolder();
				newHolder.Init(description.Name);
				AddHolderItems(newHolder, description.Items);
				AddHolderPacks(newHolder, description.Packs);
				holders.Add(newHolder);
			}
			return holders;
		}

		void AddHolderItems(THolder holder, List<string> items) {
			for( int i = 0; i < items.Count; i++ ) {
				var item = GetItem(items[i]);
				if( item != null ) {
					var itemClone = item.Clone();
					itemClone.Init();
					holder.AddItem(itemClone);
				}
			}
		}

		void AddHolderPacks(THolder holder, List<PackDescription> packs) {
			for( int i = 0; i < packs.Count; i++ ) {
				var pack = GetPack(packs[i].Name);
				if( pack != null ) {
					var packClone = pack.Clone();
					packClone.Init();
					holder.AddToPack(packClone, packs[i].Count);
				}
			}
		}
	}
}
