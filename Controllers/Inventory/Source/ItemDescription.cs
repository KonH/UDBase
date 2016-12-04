using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

namespace UDBase.Controllers.InventorySystem {
	public class ItemDescription {

		[JsonProperty("name")]
		public string Name    { get; private set; }
		[JsonProperty("type")]
		public string    Type { get; private set; }

		public InventoryItem Create() {
			return new InventoryItem(Name, Type);
		}
	}
}
