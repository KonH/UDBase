using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public abstract class BaseInventory<TItem, TPack, THolder> : IInventory<TItem, TPack, THolder>
		where TItem:IInventoryItem, IClonableItem<TItem>
		where TPack:IInventoryPack, IClonableItem<TPack>
		where THolder:IItemHolder<TItem, TPack>,new() {
	
		protected IItemSource<TItem, TPack, THolder>    _source = null;
		protected IInventorySave<TItem, TPack, THolder> _save   = null;

		public BaseInventory(
			IItemSource<TItem, TPack, THolder> source, 
			IInventorySave<TItem, TPack, THolder> save) {
			_source = source;
			_save   = save;
		}

		public void Init() {}

		public void PostInit() {
			_source.Load();
			_save.Setup(_source.GetHolders());
		}

		protected THolder GetHolder(string holderName) {
			return _save.GetHolder(holderName);
		}

		protected THolder GetOrCreateHolder(string holderName) {
			var holder = GetHolder(holderName);
			if( holder == null ) {
				holder = new THolder();
				holder.Name = holderName;
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
				var sourcePack = _source.GetPack(packName);
				if( sourcePack == null ) {
					Log.ErrorFormat("Could not find pack: {0}", LogTags.Inventory, packName);
					return;
				}
				pack = sourcePack.Clone();
			}
			holder.AddToPack(pack, count);
			_save.SaveChanges();
		}

		public TPack GetPackTyped(string holderName, string packName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetPack(packName);
			}
			return default(TPack);
		}

		public List<TPack> GetHolderPacksTyped(string holderName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetPacks();
			}
			return null;
		}

		public void RemoveFromPackTyped(string holderName, TPack pack, int count) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.RemoveFromPack(pack, count);
				_save.SaveChanges();
			}
		}

		public void ClearPackTyped(string holderName, TPack pack) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.ClearPack(pack);
				_save.SaveChanges();
			}
		}

		public void AddItem(string holderName, string itemName) {
			var holder = GetOrCreateHolder(holderName);
			var sourceItem = _source.GetItem(itemName);
			if( sourceItem == null ) {
				Log.ErrorFormat("Could not find item {0}", LogTags.Inventory, itemName); 
				return;
			}
			var item = sourceItem.Clone();
			holder.AddItem(item);
			_save.SaveChanges();
		}

		public TItem GetItemTyped(string holderName, string itemName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetItem(itemName);
			}
			return default(TItem);
		}

		public List<TItem> GetHolderItemsTyped(string holderName) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				return holder.GetItems();
			}
			return null;
		}

		public void RemoveItemTyped(string holderName, TItem item) {
			var holder = GetHolder(holderName);
			if( holder != null ) {
				holder.RemoveItem(item);
				_save.SaveChanges();
			}
		}

		protected bool CheckPackType<TP>() {
			return (typeof(TP) == typeof(TPack));
		}

		TPack ConvertPack<TP>(TP pack) {
			return (TPack)(object)ConvertPack(pack);
		}

		protected bool CheckItemType<TI>() {
			return (typeof(TI) == typeof(TItem));
		}

		TItem ConvertItem<TI>(TI item) {
			return (TItem)(object)item;
		}

		public TP GetPack<TP>(string holderName, string packName) {
			if( CheckPackType<TP>() ) {
				var obj = (object)GetPackTyped(holderName, packName);
				return (TP)obj;
			} 
			return default(TP);
		}

		public List<TP> GetHolderPacks<TP>(string holderName) {
			if( CheckPackType<TP>() ) {
				var obj = (object)GetHolderPacksTyped(holderName);
				return (List<TP>)obj;
			}
			return null;
		}

		public void RemoveFromPack<TP>(string holderName, TP pack, int count) {
			if( CheckPackType<TP>() ) {
				RemoveFromPackTyped(holderName, ConvertPack(pack), count);
			}
		}

		public void ClearPack<TP>(string holderName, TP pack) {
			if( CheckPackType<TP>() ) {
				ClearPackTyped(holderName, ConvertPack(pack));
			}
		}

		public TI GetItem<TI>(string holderName, string itemName) {
			if( CheckItemType<TI>() ) {
				var obj = (object)GetItemTyped(holderName, itemName);
				return (TI)obj;
			}
			return default(TI);
		}

		public List<TI> GetHolderItems<TI>(string holderName) {
			if( CheckItemType<TI>() ) {
				var obj = (object)GetHolderItemsTyped(holderName);
				return (List<TI>)obj;
			}
			return null;
		}

		public void RemoveItem<TI>(string holderName, TI item) {
			if( CheckItemType<TI>() ) {
				RemoveItemTyped(holderName, ConvertItem(item));
			}
		}
	}
}
