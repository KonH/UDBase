using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;
using Newtonsoft.Json;

namespace UDBase.Controllers.InventorySystem {
	public class ItemSourceConfigNode {

		[JsonProperty("items")]
		public List<ItemDescription>   Items   { get; private set; }
		[JsonProperty("packs")]
		public List<PackDescription>   Packs   { get; private set; }
		[JsonProperty("holders")]
		public List<HolderDescription> Holders { get; private set; }
	}
}
