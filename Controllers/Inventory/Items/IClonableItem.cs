using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IClonableItem<TItem> {
		TItem Clone();
	}
}
