using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Utils.Json;
using Newtonsoft.Json;

namespace UDBase.Controllers.InventorySystem {
	public class InventorySaveNode {

		[JsonProperty("holders")]
		public List<InventoryHolder> Holders { get; private set; }

		public InventorySaveNode() {}

		public InventorySaveNode(List<InventoryHolder> holders) {
			Holders = holders;
		}

		public void Init(Dictionary<string, string> nameToTypes) {
			for( int i = 0; i < Holders.Count; i++) {
				Holders[i].Init(nameToTypes);
			}
		}

		public void SaveChanges() {
			for( int i = 0; i < Holders.Count; i++) {
				Holders[i].SaveChanges();
			}
		}
	}
}
