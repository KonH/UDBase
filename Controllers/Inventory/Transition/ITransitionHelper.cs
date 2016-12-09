using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.InventorySystem {
	public interface ITransitionHelper {

		bool CanSend(string fromHolder, string toHolder, InventoryItem item);
		void Send   (string fromHolder, string toHolder, InventoryItem item);
	}
}
