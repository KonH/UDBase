using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryHolder {

		[JsonProperty("name")]
		public string              Name   { get; private set; }
		[JsonProperty("items")]
		public List<JObject>       JItems { get; private set; }
		[JsonIgnore()]
		public List<InventoryItem> Items  { get; private set; }
		[JsonProperty("packs")]
		public List<InventoryPack> Packs  { get; private set; }

		ItemFactory _factory = null;

		public InventoryHolder() {}

		public InventoryHolder(ItemFactory factory, string name) {
			_factory = factory;
			Name = name;
		}

		public void Init(ItemFactory factory, Dictionary<string, string> nameToTypes) {
			_factory = factory;
			Items = new List<InventoryItem>();
			if( JItems != null ) {
				for( int i = 0; i < JItems.Count; i++) {
					var baseItem = JItems[i].ToObject<InventoryItem>();
					var itemTypeName = nameToTypes[baseItem.Name];
					var itemType = _factory.GetItemType(itemTypeName);
					InventoryItem item; 
					if ( itemType != typeof(InventoryItem) ) {
						item = JItems[i].ToObject(itemType) as InventoryItem;
					} else {
						item = baseItem;
					}
					item.SetType(itemTypeName);
					item.AssignContent(JItems[i]);
					Items.Add(item);
				}
			}
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
				JItems = new List<JObject>();
			}
			Items.Add(item);
			var content = CreateByItem(item);
			item.AssignContent(content);
			JItems.Add(content);
		}

		JObject CreateByItem(InventoryItem item) {
			JObject content;
			var itemType = _factory.GetItemType(item.Type);
			if ( itemType != typeof(InventoryItem) ) {
				var customItem = Convert.ChangeType(item, itemType);
				content = JObject.FromObject(customItem);
			} else {
				content = JObject.FromObject(item);
			}
			return content;
		}

		public void RemoveItem(InventoryItem item) {
			if( Items != null ) {
				for( int i = 0; i < Items.Count; i++ ) {
					var curItem = Items[i];
					if( curItem == item ) {
						Items.RemoveAt(i);
						JItems.RemoveAt(i);
						return;
					}
				}
			}
		}

		public void SaveChanges() {
			if( Items != null ) {
				for( int i = 0; i < Items.Count; i++) {
					JItems[i] = CreateByItem(Items[i]);
				}
			}
		}
	}
}