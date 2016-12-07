using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

namespace UDBase.Controllers.InventorySystem {
	public class PackDescription {

		[JsonProperty("name")]
		public string Name  { get; private set; }
		[JsonProperty("count")]
		public int    Count { get; private set; }

		public InventoryPack Create() {
			return new InventoryPack(Name, Count);
		}
	}
}
