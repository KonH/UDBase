using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveState<TItem, TPack, THolder> : IInventorySave<TItem, TPack, THolder> 
		where TItem: IInventoryItem
		where TPack: IInventoryPack
		where THolder: IItemHolder<TItem, TPack> {

		InventorySaveNode<TItem, TPack, THolder> _node = null;

		public void Setup() {
			TryLoad();
			if( !IsExist() ) {
				Create();
			}
			SaveChanges();
			Log.MessageFormat("Load saved inventory: {0} holders.", LogTags.Inventory, 
				_node.Holders != null ? _node.Holders.Count : -1);
		}

		void TryLoad() {
			_node = Save.GetNode<InventorySaveNode<TItem, TPack, THolder>>();
		}

		bool IsExist() {
			return _node != null;
		}

		void Create() {
			_node = new InventorySaveNode<TItem, TPack, THolder>();
			_node.Holders = new List<THolder>();
		}

		public void SaveChanges() {
			Save.SaveNode(_node);
		}

		public THolder GetHolder(string name) {
			var holders = _node.Holders;
			for( int i = 0; i < holders.Count; i++ ) {
				var curHolder = holders[i];
				if( curHolder.Name == name ) {
					return curHolder;
				}
			}
			return default(THolder);
		}

		public void AddHolder(THolder holder) {
			_node.Holders.Add(holder);
		}
	}
}
