using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class BasicInventory : IInventory {
	
		protected IItemSource    _source = null;
		protected IInventorySave _save   = null;

		public BasicInventory(
			IItemSource source, 
			IInventorySave save) {
			_source = source;
			_save   = save;
		}

		public BasicInventory():this(new ItemConfigSource(), new InventorySaveState()) {}

		public void Init() {}

		public void PostInit() {
			_source.Load();
			_save.Setup(_source.GetHolders(), _source.GetNames());
		}

		protected InventoryHolder GetHolder(string holderName) {
			return _save.GetHolder(holderName);
		}

		protected InventoryHolder GetOrCreateHolder(string holderName) {
			var holder = GetHolder(holderName);
			if( holder == null ) {
				holder = new InventoryHolder(holderName);
				_save.AddHolder(holder);
			}
			return holder;
		}

		public int GetPackCount(string holderName, string packName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				var pack = holder.GetPack(packName);
				return pack.Count;
			} 
			return 0;
		}

		public void AddToPack(string holderName, string packName, int count) {
			if( count <= 0 ) {
				Log.ErrorFormat(
					"Try to add {0} items to {1} in {2}", 
					LogTags.Inventory, count, packName, holderName);
				return;
			}
			var holder = GetOrCreateHolder(holderName);
			var pack = holder.GetPack(packName);
			if( pack == null ) {
				pack = _source.GetPack(packName);
				if( pack == null ) {
					Log.ErrorFormat("Could not find pack: {0}", LogTags.Inventory, packName);
					return;
				}
			}
			holder.AddToPack(pack, count);
			_save.SaveChanges();
		}

		public void AddItem(string holderName, string itemName) {
			var holder = GetOrCreateHolder(holderName);
			var item = _source.GetItem(itemName);
			if( item == null ) {
				Log.ErrorFormat("Could not find item {0}", LogTags.Inventory, itemName); 
				return;
			}
			holder.AddItem(item);
			_save.SaveChanges();
		}

		public InventoryPack GetPack(string holderName, string packName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetPack(packName);
			}
			return null;
		}

		public List<InventoryPack> GetHolderPacks(string holderName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.Packs;
			}
			return null;
		}

		public void RemoveFromPack(string holderName, InventoryPack pack, int count) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.RemoveFromPack(pack, count);
			}
		}

		public void ClearPack(string holderName, InventoryPack pack) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.ClearPack(pack);
			}
		}

		public InventoryItem GetItem(string holderName, string itemName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetItem(itemName);
			}
			return null;
		}

		public List<InventoryItem> GetHolderItems(string holderName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.Items;
			}
			return null;
		}

		public void RemoveItem(string holderName, InventoryItem item) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.RemoveItem(item);
			}
		}
	}
}
