using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public class ItemHolder<TItem, TPack>:IItemHolder<TItem, TPack>
		where TItem:IInventoryItem,new() where TPack:IInventoryPack,new() {

		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		[SerializeField]
		string name;

		[SerializeField]
		List<TItem> items;

		[SerializeField]
		List<TPack> packs;

		public ItemHolder() {}

		public ItemHolder(string name) {
			this.name = name;
		}

		public TPack GetPack(string name) {
			if( packs != null ) {
				for( int i = 0; i < packs.Count; i++ ) {
					var curPack = packs[i];
					if( curPack.Name == name ) {
						return curPack;
					}
				}
			}
			return default(TPack);
		}

		public List<TPack> GetPacks() {
			return packs;
		}

		public void AddToPack(string name, int count) {
			if( packs == null ) {
				packs = new List<TPack>();
			}
			TPack pack = GetPack(name);
			if( pack == null ) {
				pack = new TPack();
				pack.Name = name;
				packs.Add(pack);
			}
			pack.Count += count;
		}

		public void RemoveFromPack(TPack pack, int count) {
			if( packs != null ) {
				for( int i = 0; i < packs.Count; i++ ) {
					if( packs[i].Equals(pack) ) {
						pack.Count -= count;
						if( pack.Count <= 0 ) {
							packs.Remove(pack);
						}
						return;
					}
				}
			}
		}

		public void ClearPack(TPack pack) {
			if( pack != null ) {
				RemoveFromPack(pack, pack.Count);
			}
		}

		public TItem GetItem(string name) {
			if( items != null ) {
				for( int i = 0; i < items.Count; i++ ) {
					var curItem = items[i];
					if( curItem.Name == name ) {
						return curItem;
					}
				}
			}
			return default(TItem);
		}

		public List<TItem> GetItems() {
			return items;
		}

		public void AddItem(string name) {
			if( items == null ) {
				items = new List<TItem>();
			}
			TItem item = new TItem();
			item.Name = name;
			items.Add(item);
		}

		public void RemoveItem(TItem item) {
			if( items != null ) {
				for( int i = 0; i < items.Count; i++ ) {
					var curItem = items[i];
					if( curItem.Equals(item) ) {
						items.Remove(curItem);
						return;
					}
				}
			}
		}
	}
}