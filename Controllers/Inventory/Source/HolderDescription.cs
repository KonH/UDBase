using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class HolderDescription {
		public string                name  = "";
		public List<string>          items = new List<string>();
		public List<PackDescription> packs = new List<PackDescription>();
	}
}
