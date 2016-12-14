using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.InventorySystem {
	public class BasicInventory : IInventory {
	
		protected IItemSource       _source   = null;
		protected IInventorySave    _save     = null;
		protected ItemFactory       _factory  = null;
		protected ITransitionHelper _helper   = null;
		protected bool              _autoSave = false;

		public BasicInventory(
			IItemSource source, 
			IInventorySave save,
			ItemFactory factory,
			ITransitionHelper helper,
			bool autoSave) {
			_source   = source;
			_save     = save;
			_factory  = factory;
			_helper   = helper;
			_autoSave = autoSave;
		}

		public BasicInventory(ITransitionHelper helper, bool autoSave = true) {
			_factory  = new ItemFactory();
			_source   = new ItemConfigSource(_factory);
			_save     = new InventorySaveState();
			_helper   = helper; 
			_autoSave = autoSave;
		}

		public BasicInventory(bool autoSave = true):this(new BasicTransitionHelper(), autoSave) {}

		public BasicInventory AddType<T>(string typeName) {
			_factory.AddType<T>(typeName);
			return this;
		}

		public void Init() {}

		public void PostInit() {
			_source.Load();
			Load();
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
				if( pack != null ) {
					return pack.Count;
				}
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

			Events.Fire<Inv_PackChanged>(new Inv_PackChanged(holderName, packName));
			Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

			TryToAutoSave();
		}

		public void AddItem(string holderName, string itemName) {
			var holder = GetOrCreateHolder(holderName);
			var item = _source.GetItem(itemName);
			if( item == null ) {
				Log.ErrorFormat("Could not find item {0}", LogTags.Inventory, itemName); 
				return;
			}
			holder.AddItem(item);

			Events.Fire<Inv_ItemAdded>(new Inv_ItemAdded(holderName, item));
			Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

			TryToAutoSave();
		}

		public void AddItem(string holderName, InventoryItem item) {
			var holder = GetOrCreateHolder(holderName);
			holder.AddItem(item);

			Events.Fire<Inv_ItemAdded>(new Inv_ItemAdded(holderName, item));
			Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

			TryToAutoSave();
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

				Events.Fire<Inv_PackChanged>(new Inv_PackChanged(holderName, pack.Name));
				Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

				TryToAutoSave();
			}
		}

		public void ClearPack(string holderName, InventoryPack pack) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.ClearPack(pack);

				Events.Fire<Inv_PackChanged>(new Inv_PackChanged(holderName, pack.Name));
				Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

				TryToAutoSave();
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

				Events.Fire<Inv_HolderChanged>(new Inv_HolderChanged(holderName));

				TryToAutoSave();
			}
		}

		protected void TryToAutoSave() {
			if( _autoSave ) {
				_save.SaveChanges();
			}
		}

		public void SaveChanges() {
			_save.SaveChanges();
		}

		public void Load() {
			_save.Setup(_source.GetHolders(), _source.GetNames());
		}

		public bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			return _helper.CanSend(fromHolder, toHolder, item);
		}

		public void Send(string fromHolder, string toHolder, InventoryItem item) {
			_helper.Send(fromHolder, toHolder, item);
		}
	}
}
