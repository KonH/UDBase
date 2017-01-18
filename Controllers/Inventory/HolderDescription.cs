using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FullSerializer;

namespace UDBase.Controllers.InventorySystem {
	public class HolderDescription {
		
		[fsProperty("name")]
		public string                Name  { get; private set; }
		[fsProperty("items")]
		public List<string>          Items { get; private set; }
		[fsProperty("packs")]
		public List<PackDescription> Packs { get; private set; }
	}
}
