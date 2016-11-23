using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class PackDescription {

		public string Name  { get { return name;  } }
		public int    Count { get { return count; } }

		[SerializeField]
		string name  = "";
		[SerializeField]
		int    count = 0;
	}
}
