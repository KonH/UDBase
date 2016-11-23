using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	[System.Serializable]
	public class HolderDescription {

		public string                Name  { get { return name;  } }
		public List<string>          Items { get { return items; } }
		public List<PackDescription> Packs { get { return packs; } }

		[SerializeField]
		string                name  = "";
		[SerializeField]
		List<string>          items = new List<string>();
		[SerializeField]
		List<PackDescription> packs = new List<PackDescription>();
	}
}
