using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryHolder {
		
		[fsProperty("name")]
		public string              Name   { get; private set; }
		[fsProperty("items")]
		public List<InventoryItem> Items  { get; private set; }
		[fsProperty("packs")]
		public List<InventoryPack> Packs  { get; private set; }

		public InventoryHolder() {}

		public InventoryHolder(string name) {
			Name = name;
		}

		public InventoryPack GetPack(string name) {
			if( Packs != null ) {
				for( int i = 0; i < Packs.Count; i++ ) {
					var curPack = Packs[i];
					if( curPack.Name == name ) {
						return curPack;
					}
				}
			}
			return null;
		}

		public void AddToPack(InventoryPack pack, int count) {
			if( pack == null ) {
				return;
			}
			if( Packs == null ) {
				Packs = new List<InventoryPack>();
			}
			if( !Packs.Contains(pack) ) {
				Packs.Add(pack);
			}
			pack.Add(count);
		}

		public void RemoveFromPack(InventoryPack pack, int count) {
			if( Packs != null ) {
				for( int i = 0; i < Packs.Count; i++ ) {
					if( Packs[i] == pack ) {
						pack.Remove(count);
						if( pack.Count <= 0 ) {
							Packs.Remove(pack);
						}
						return;
					}
				}
			}
		}

		public void ClearPack(InventoryPack pack) {
			if( pack != null ) {
				RemoveFromPack(pack, pack.Count);
			}
		}

		public InventoryItem GetItem(string name) {
			if( Items != null ) {
				for( int i = 0; i < Items.Count; i++ ) {
					var curItem = Items[i];
					if( curItem.Name == name ) {
						return curItem;
					}
				}
			}
			return null;
		}

		public void AddItem(InventoryItem item) {
			if( Items == null ) {
				Items = new List<InventoryItem>();
			}
			Items.Add(item);
		}

		public void RemoveItem(InventoryItem item) {
			if( Items != null ) {
				for( int i = 0; i < Items.Count; i++ ) {
					var curItem = Items[i];
					if( curItem == item ) {
						Items.RemoveAt(i);
						return;
					}
				}
			}
		}
	}
}