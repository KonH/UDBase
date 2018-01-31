using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveState: IInventorySave {
		InventorySaveNode _node;

		ISave _save;

		public InventorySaveState() {}

		public void Setup(List<InventoryHolder> defaultHolders, Dictionary<string, string> nameToTypes) {
			TryLoad();
			if( !IsExist() ) {
				Create(defaultHolders);
			}
			SaveChanges();
			Log.MessageFormat("Load saved inventory: {0} holders.", LogTags.Inventory, 
				_node.Holders != null ? _node.Holders.Count : -1);
		}

		void TryLoad() {
			_node = _save.GetNode<InventorySaveNode>();
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
			_save.SaveNode(_node);
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
