using System.Collections.Generic;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class ItemConfigSource: IItemSource {

		ItemFactory          _factory = null;
		ItemSourceConfigNode _node    = null;

		public ItemConfigSource(ItemFactory factory) {
			_factory = factory;
		}

		public void Load() {
			_node = Config.GetNode<ItemSourceConfigNode>();
			Log.MessageFormat("Load inventory source: {0} items, {1} packs, {2} holders.", LogTags.Inventory, 
				_node.Items   != null ? _node.Items.Count   : -1,
				_node.Packs   != null ? _node.Packs.Count   : -1,
				_node.Holders != null ? _node.Holders.Count : -1);
		}

		public InventoryItem GetItem(string itemName) {
			var items = _node.Items;
			for( int i = 0; i < items.Count; i++ ) {
				if( items[i].Name == itemName ) {
					return CreateItem(items[i]);
				}
			}
			return null;
		}

		InventoryItem CreateItem(ItemDescription desc) {
			var item = _factory.CreateItem(desc.Type);
			item = desc.SetupItem(item);
			item.Init();
			return item;
		}

		public InventoryPack GetPack(string packName) {
			var packs = _node.Packs;
			for( int i = 0; i < packs.Count; i++ ) {
				if( packs[i].Name == packName ) {
					return packs[i].Create();
				}
			}
			return null;
		}

		public List<InventoryHolder> GetHolders() {
			var descriptions = _node.Holders;
			var holders = new List<InventoryHolder>();
			for( int i = 0; i < descriptions.Count; i++ ) {
				var description = descriptions[i];
				var newHolder = new InventoryHolder(description.Name);
				AddHolderItems(newHolder, description.Items);
				AddHolderPacks(newHolder, description.Packs);
				holders.Add(newHolder);
			}
			return holders;
		}

		void AddHolderItems(InventoryHolder holder, List<string> items) {
			for( int i = 0; i < items.Count; i++ ) {
				var item = GetItem(items[i]);
				if( item != null ) {
					holder.AddItem(item.Clone());
				}
			}
		}

		void AddHolderPacks(InventoryHolder holder, List<PackDescription> packs) {
			for( int i = 0; i < packs.Count; i++ ) {
				var pack = GetPack(packs[i].Name);
				if( pack != null ) {
					holder.AddToPack(pack.Clone(), packs[i].Count);
				}
			}
		}

		public Dictionary<string, string> GetNames() {
			var dict = new Dictionary<string, string>();
			for( int i = 0; i < _node.Items.Count; i++ ) {
				var item = _node.Items[i];
				dict.Add(item.Name, item.Type);
			}
			return dict;
		}
	}
}
