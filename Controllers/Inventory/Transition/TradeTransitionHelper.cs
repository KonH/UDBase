using System;

namespace UDBase.Controllers.InventorySystem {
	public class TradeTransitionHelper : ITransitionHelper {

		protected string                   _packName          = null;
		protected Func<InventoryItem, int> _itemPriceSelector = null;
		protected Func<InventoryPack, int> _packPriceSelector = null;

		public TradeTransitionHelper(
			string packName, 
			Func<InventoryItem, int> itemPriceSelector,
			Func<InventoryPack, int> packPriceSelector = null) {
			_packName          = packName;
			_itemPriceSelector = itemPriceSelector;
			_packPriceSelector = packPriceSelector;
		}

		protected bool IsEnought(int price, string holderName) {
			var total = Inventory.GetPackCount(holderName, _packName);
			return total >= price;
		}

		public virtual bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			var price = _itemPriceSelector.Invoke(item);
			return IsEnought(price, toHolder);
		}

		protected void ChangePackValue(string holder, int price, bool upDown) {
			if( upDown ) {
				Inventory.AddToPack(holder, _packName, price);
			} else {
				var pack = Inventory.GetPack(holder, _packName);
				Inventory.RemoveFromPack(holder, pack, price);
			}
		}

		public virtual void Send(string fromHolder, string toHolder, InventoryItem item) {
			var price = _itemPriceSelector.Invoke(item);
			ChangePackValue(fromHolder, price, true);
			ChangePackValue(toHolder, price, false);
			Inventory.RemoveItem(fromHolder, item);
			Inventory.AddItem(toHolder, item);
		}

		public virtual bool CanSend(string fromHolder, string toHolder, InventoryPack pack, int count) {
			var price = _packPriceSelector.Invoke(pack);
			var totalPrice = price * count;
			return IsEnought(totalPrice, toHolder);
		}

		public virtual void Send(string fromHolder, string toHolder, InventoryPack pack, int count) {
			var price = _packPriceSelector.Invoke(pack);
			var totalPrice = price * count;
			ChangePackValue(fromHolder, totalPrice, true);
			ChangePackValue(toHolder, totalPrice, false);
			var packName = pack.Name;
			Inventory.RemoveFromPack(fromHolder, pack, count);
			Inventory.AddToPack(toHolder, packName, count);
		}
	}
}
