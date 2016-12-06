using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryItem {
		[JsonIgnore()]
		public JObject Content { get; private set; }
		[JsonProperty("name")]
		public string Name { get; private set; }
		[JsonIgnore()]
		public string Type { get; private set; }

		public InventoryItem() {}

		public InventoryItem(string name, string type) {
			Name = name;
			Type = type;
		}

		public void SetName(string name) {
			Name = name;
		}

		public void SetType(string type) {
			Type = type;
		}

		public void AssignContent(JObject content) {
			Content = content;
		}

		public InventoryItem Clone() {
			return new InventoryItem(Name, Type);
		}

		public T As<T>() {
			return Content.ToObject<T>();
		}
	}
}
