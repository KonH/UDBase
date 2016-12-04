using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UDBase.Controllers.InventorySystem {
	public class HolderDescription {

		[JsonProperty("name")]
		public string                Name  { get; private set; }
		[JsonProperty("items")]
		public List<string>          Items { get; private set; }
		[JsonProperty("packs")]
		public List<PackDescription> Packs { get; private set; }
	}
}
