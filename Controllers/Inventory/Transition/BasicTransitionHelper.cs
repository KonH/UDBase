using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.InventorySystem {
	public class BasicTransitionHelper : ITransitionHelper {

		public bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			return true;
		}

		public void Send(string fromHolder, string toHolder, InventoryItem item) {
			Inventory.RemoveItem(fromHolder, item);
			Inventory.AddItem(toHolder, item);
		}
	}
}
