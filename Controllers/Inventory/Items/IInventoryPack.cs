using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventoryPack {

		string Name  { get; set; }
		int    Count { get; set; }
	}
}
