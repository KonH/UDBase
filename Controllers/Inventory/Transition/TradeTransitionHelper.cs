using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.InventorySystem {
	public class TradeTransitionHelper : ITransitionHelper {

		protected string                   _packName      = null;
		protected Func<InventoryItem, int> _priceSelector = null;

		public TradeTransitionHelper(string packName, Func<InventoryItem, int> priceSelector) {
			_packName      = packName;
			_priceSelector = priceSelector;
		}

		protected bool IsEnought(int price, string holderName) {
			var total = Inventory.GetPackCount(holderName, _packName);
			return total >= price;
		}

		public bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			var price = _priceSelector.Invoke(item);
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

		public void Send(string fromHolder, string toHolder, InventoryItem item) {
			var price = _priceSelector.Invoke(item);
			ChangePackValue(fromHolder, price, true);
			ChangePackValue(toHolder, price, false);
			Inventory.RemoveItem(fromHolder, item);
			Inventory.AddItem(toHolder, item);
		}
	}
}
