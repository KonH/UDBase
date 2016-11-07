using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public abstract class BaseInventory<TItem, TPack, THolder> : IInventory<TItem, TPack, THolder>
		where TItem:IInventoryItem
		where TPack:IInventoryPack
		where THolder:IItemHolder<TItem, TPack>,new() {
	
		protected IItemSource                           _source = null;
		protected IInventorySave<TItem, TPack, THolder> _save   = null;

		public BaseInventory(IItemSource source, IInventorySave<TItem, TPack, THolder> save) {
			_source = source;
			_save   = save;
		}

		public void Init() {}

		public void PostInit() {
			_source.Load();
			_save.Setup();
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
			var holder = GetOrCreateHolder(holderName);
			holder.AddToPack(packName, count);
			_save.SaveChanges();
		}
	}
}
