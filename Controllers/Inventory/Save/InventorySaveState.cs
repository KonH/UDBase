using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveState: IInventorySave {

		ItemFactory       _factory = null;
		InventorySaveNode _node    = null;

		public InventorySaveState(ItemFactory factory) {
			_factory = factory;
		}

		public void Setup(List<InventoryHolder> defaultHolders, Dictionary<string, string> nameToTypes) {
			TryLoad();
			if( !IsExist() ) {
				Create(defaultHolders);
			}
			_node.Init(_factory, nameToTypes);
			SaveChanges();
			Log.MessageFormat("Load saved inventory: {0} holders.", LogTags.Inventory, 
				_node.Holders != null ? _node.Holders.Count : -1);
		}

		void TryLoad() {
			_node = Save.GetNode<InventorySaveNode>();
		}

		bool IsExist() {
			return _node != null;
		}

		void Create(List<InventoryHolder> defaultHolders) {
			_node = new InventorySaveNode(defaultHolders);
			Log.MessageFormat("Create default inventory: {0} holders.", LogTags.Inventory,
				_node.Holders.Count);
		}

		public void SaveChanges() {
			_node.SaveChanges();
			Save.SaveNode(_node);
		}

		public InventoryHolder GetHolder(string name) {
			var holders = _node.Holders;
			for( int i = 0; i < holders.Count; i++ ) {
				var curHolder = holders[i];
				if( curHolder.Name == name ) {
					return curHolder;
				}
			}
			return null;
		}

		public void AddHolder(InventoryHolder holder) {
			_node.Holders.Add(holder);
		}
	}
}
