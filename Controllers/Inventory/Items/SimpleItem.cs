using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class SimpleItem : IInventoryItem {

		[SerializeField]
		string name;
	}
}
